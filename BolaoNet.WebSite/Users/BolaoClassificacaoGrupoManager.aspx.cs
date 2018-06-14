using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BolaoNet.WebSite.Users
{
    public partial class BolaoClassificacaoGrupoManager : UserBasePage
    {
        #region Properties
        public IList<Model.Boloes.BolaoMembros> DataSelected
        {
            get
            {
                if (ViewState["DataSelected"] == null)
                    ViewState["DataSelected"] = new List<Model.Boloes.BolaoMembros>();

                return (IList<Model.Boloes.BolaoMembros>)ViewState["DataSelected"];
            }
            set { ViewState["DataSelected"] = value; }
        }
        #endregion

        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
            BindSelected();
        }
        #endregion

        #region Methods
        private void BindGrid()
        {
            Business.Boloes.Support.Bolao bolao = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName);
            bolao.Nome = BolaoUserBasePage.CurrentBolao.Nome;


            IList<Model.Boloes.BolaoMembros> list = bolao.LoadClassificacao(0);
            IList<Framework.DataServices.Model.EntityBaseData> listPosicoes = bolao.SelectPremios();


            ViewState["listPosicoes"] = listPosicoes;
            ViewState["list"] = list;


            this.grdClassificacao.DataSource = list;
            this.grdClassificacao.DataBind();


        }
        private void BindSelected()
        {
            Business.Boloes.Support.Bolao bolao = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName);
            bolao.Nome = BolaoUserBasePage.CurrentBolao.Nome;


            IList<Model.Boloes.BolaoMembros> list = bolao.LoadClassificacaoGrupo(new Framework.Security.Model.UserData(base.UserName));
            IList<Framework.DataServices.Model.EntityBaseData> listPosicoes = bolao.SelectPremios();


            DataSelected = list;

            this.grdSelecionados.DataSource = list;
            this.grdSelecionados.DataBind();
        }
        #endregion

        #region Events

        protected void grdClassificacao_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Se não é registro
            if (e.Row.RowType != DataControlRowType.DataRow)
            {
                return;

            }//endif registro

            //Buscando o valor do registro
            Model.Boloes.BolaoMembros entry =
                (Model.Boloes.BolaoMembros)e.Row.DataItem;

            //Buscando os objetos da tela
            Image imgLastPos = (Image)e.Row.FindControl("imgLastPos");
            Label lblLastPos = (Label)e.Row.FindControl("lblLastPos");

            LinkButton button = (LinkButton)e.Row.FindControl("lnkAdd");

            if (button != null)
            {
                button.CommandName = entry.UserName;
                button.CommandArgument = entry.FullName;
            }

            //Se tem informação encontrada
            if (imgLastPos != null && lblLastPos != null)
            {

                int diferenca = entry.LastPosicao - entry.Posicao;

                //Se continua na mesma posição
                if (diferenca == 0)
                {
                    lblLastPos.Text = "";
                    imgLastPos.ImageUrl = "~/Images/quadrado.gif";
                }
                //Se subiu posições
                else if (diferenca > 0)
                {
                    lblLastPos.Text = diferenca.ToString();
                    imgLastPos.ImageUrl = "~/Images/seta_cima.gif";
                }
                //se Desceu posições
                else
                {
                    imgLastPos.ImageUrl = "~/Images/seta_baixo.gif";
                    lblLastPos.Text = (diferenca * -1).ToString();

                }//endif diferenças



            }//endif informação encontrada


        }
        protected void grdClassificacao_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (string.IsNullOrEmpty(e.CommandName))
                return;

            bool found = false;

            for (int c = 0; c < this.DataSelected.Count; c++)
            {
                if (string.Compare(this.DataSelected[c].UserName, e.CommandName, true) == 0)
                {
                    found = true;
                    break;
                }
            }


            if (!found)
            {
                Model.Boloes.BolaoMembros newEntry = new Model.Boloes.BolaoMembros(e.CommandName);
                newEntry.FullName = e.CommandArgument.ToString();
                //this.DataSelected.Add(newEntry);

                Business.Boloes.Support.Bolao bolao = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName);
                bolao.Nome = BolaoUserBasePage.CurrentBolao.Nome;
                bolao.InsertGrupoMembro(new Framework.Security.Model.UserData(base.UserName), newEntry);
            }

            BindSelected();
        }
        protected void grdSelecionados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            for (int c = 0; c < this.DataSelected.Count; c++)
            {
                if (string.Compare(this.DataSelected[c].UserName, e.CommandArgument.ToString(), true) == 0)
                {


                    Business.Boloes.Support.Bolao bolao = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName);
                    bolao.Nome = BolaoUserBasePage.CurrentBolao.Nome;
                    bolao.DeleteGrupoMembro(new Framework.Security.Model.UserData(base.UserName), this.DataSelected[c]);

                    break;
                }
            }

            BindSelected();
        }
        protected void grdSelecionados_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            //Se não é registro
            if (e.Row.RowType != DataControlRowType.DataRow)
            {
                return;

            }//endif registro


            LinkButton lnkRemove = (LinkButton)e.Row.FindControl("lnkRemove");

            Model.Boloes.BolaoMembros entry =
                (Model.Boloes.BolaoMembros)e.Row.DataItem;


            lnkRemove.CommandArgument = entry.UserName;
        }

        #endregion

        

       
    }
}