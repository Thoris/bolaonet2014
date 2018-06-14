using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

namespace BolaoNet.WebSite.Users
{
    public partial class Home : UserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            BindMeusBoloes();
            BindPagamentos();
            BindMensagens();

            BindSelected();
            BindProximosJogos();
            BindPontosObtidos();
        }
        #endregion

        #region Methods

        private void BindPontosObtidos()
        {
            Business.Boloes.Support.JogoUsuario bo = new Business.Boloes.Support.JogoUsuario(base.UserName);
            IList<Framework.DataServices.Model.EntityBaseData> list = bo.LoadPontosObtidos(base.UserName);

            this.grdPontosObtidos.DataSource = list;
            this.grdPontosObtidos.DataBind();

        }
        private void BindProximosJogos()
        {
            Business.Boloes.Support.JogoUsuario bo = new Business.Boloes.Support.JogoUsuario(base.UserName);
            IList<Framework.DataServices.Model.EntityBaseData> list = bo.LoadProximasApostas(base.UserName);

            this.grdJogos.DataSource = list;
            this.grdJogos.DataBind();

        }
        private void BindMensagens()
        {
            Business.Users.Support.User user = new BolaoNet.Business.Users.Support.User(base.UserName);
            user.UserName = base.UserName;
            IList<Framework.DataServices.Model.EntityBaseData> list = user.LoadMensagens();

            this.grdMensagens.DataSource = list;
            this.grdMensagens.DataBind();
        }
        public void BindMeusBoloes()
        {
            Business.Users.Support.User user = new BolaoNet.Business.Users.Support.User(base.UserName);
            user.UserName = base.UserName;
            IList<BolaoNet.Model.Users.UserBoloes> list = user.LoadBoloes();


            this.grdMeusBoloes.DataSource = list;
            this.grdMeusBoloes.DataBind();

        }
        public void BindPagamentos()
        {
            Business.Users.Support.User user = new BolaoNet.Business.Users.Support.User(base.UserName);
            user.UserName = base.UserName;
            IList<BolaoNet.Model.Users.UserPagamentos> list = user.LoadPagamentos();


            decimal total = 0;

            for (int c = list.Count - 1; c >= 0; c--)
            {
                if (list[c].Devendo == 0)
                    list.RemoveAt(c);
                else
                    total += list[c].Devendo;
                
            }



            this.grdPagamentos.DataSource = list;
            this.grdPagamentos.DataBind();


         


            

            this.lblTotalDevedor.Text = total.ToString("##0.00");

            if (total > 0)
                this.lblTotalDevedor.ForeColor = System.Drawing.Color.Red;
            else
                this.lblTotalDevedor.ForeColor = System.Drawing.Color.Green;


        }
        private void BindSelected()
        {
            if (BolaoUserBasePage.CurrentBolao == null)
            {
                this.lnkConfigurar.Visible = false;
                return;
            }

            this.lnkConfigurar.Visible = true;
            Business.Boloes.Support.Bolao bolao = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName);
            bolao.Nome = BolaoUserBasePage.CurrentBolao.Nome;


            IList<Model.Boloes.BolaoMembros> list = bolao.LoadClassificacaoGrupo(new Framework.Security.Model.UserData(base.UserName));
            IList<Framework.DataServices.Model.EntityBaseData> listPosicoes = bolao.SelectPremios();



            this.grdClassificacao.DataSource = list;
            this.grdClassificacao.DataBind();
        }

        #endregion

        #region Events

        protected void grdMeusBoloes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;


            //Model.Users.UserBoloes bolao = (Model.Users.UserBoloes)e.Row.DataItem;

            //HyperLink lnkBolao = (HyperLink)e.Row.FindControl("lnkBolao");
            //HyperLink lnkCobertura = (HyperLink)e.Row.FindControl("lnkCobertura");

            //lnkBolao.CommandName = "Bolao";
            //lnkBolao.CommandArgument = bolao.Bolao.Nome;

            //lnkBolao.CommandName = "Cobertura";
            //lnkBolao.CommandArgument = bolao.Cobertura;



            
            
        }
        protected void lnkBolao_Click(object sender, EventArgs e)
        {

        }
        protected void grdMeusBoloes_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        protected void lnkConfigurar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Users/BolaoClassificacaoGrupoManager.aspx");
        }
        protected void grdClassificacao_DataBound(object sender, EventArgs e)
        {
           
            for (int c = 0; c < this.grdClassificacao.Rows.Count; c++)
            {
                this.grdClassificacao.Rows[c].Cells[0].Text = (c + 1).ToString();
            }

        }
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

        #endregion

 
    }
}
