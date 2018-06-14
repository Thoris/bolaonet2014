using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Collections.Generic;

namespace BolaoNet.WebSite.Boloes
{
    public partial class BolaoClassificacao : BolaoUserBasePage
    {

        #region Variables
        #endregion

        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }
        #endregion

        #region Methods
        private void BindGrid()
        {
            Business.Boloes.Support.Bolao bolao = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName);
            bolao.Nome = base.BaseCurrentBolao.Nome;


            IList<Model.Boloes.BolaoMembros> list = bolao.LoadClassificacao(0);
            IList<Framework.DataServices.Model.EntityBaseData> listPosicoes = bolao.SelectPremios();


            ViewState["listPosicoes"] = listPosicoes;
            ViewState["list"] = list;


            this.grdClassificacao.DataSource = list;
            this.grdClassificacao.DataBind();


        }
        #endregion

        #region Events
        protected override void OnLoad(EventArgs e)
        {
            if (!IsPostBack)
            {

                //for (int c = 0; c < 17; c++)
                //    this.grdClassificacao.Columns[c + 4].Visible = false;

                for (int c = 0; c < 18; c++)
                    this.grdClassificacao.Columns[c + 5].Visible = false;
                

                Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);
                IList<Framework.DataServices.Model.EntityBaseData> list = business.LoadCriteriosPontos(null);

                //IList<Model.Boloes.BolaoCriterioPontos> criterios = new List<Model.Boloes.BolaoCriterioPontos>();

                foreach (Model.Boloes.BolaoCriterioPontos criterio in list)
                {
                    if (criterio.Pontos > 0)
                    {
                        //criterios.Add(criterio);

                        //this.grdClassificacao.Columns[3 + (int)criterio.CriterioID].Visible = true;
                        this.grdClassificacao.Columns[4 + (int)criterio.CriterioID].Visible = true;
                    }
                }

                this.grdClassificacao.Columns[this.grdClassificacao.Columns.Count - 1].Visible = true;

                
                
                
            }

            base.OnLoad(e);
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.ctlNavigateHomeControl.ButtonClick += new CommandEventHandler(ctlNavigateHomeControl_ButtonClick);
        }
        private void ctlNavigateHomeControl_ButtonClick(object sender, CommandEventArgs e)
        {
            base.NavigateHome();
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
        protected void grdClassificacao_DataBound(object sender, EventArgs e)
        {
            if (ViewState["listPosicoes"] != null && ViewState["list"] != null)
            {
                IList<Framework.DataServices.Model.EntityBaseData> listPosicoes = (
                    IList<Framework.DataServices.Model.EntityBaseData>)ViewState["listPosicoes"];


                List<Model.Boloes.BolaoMembros> list =
                    (List<Model.Boloes.BolaoMembros>)ViewState["list"];


                List<Model.Boloes.BolaoPremio> listGroup =
                    new List<Model.Boloes.BolaoPremio>();



                foreach (Model.Boloes.BolaoPremio posicao in listPosicoes)
                {
                    //Verificando o item para ser pintado
                    for (int c = 0; c < list.Count; c++)
                    {
                        //Se encontrou o item na lista
                        if (posicao.Posicao == list[c].Posicao)
                        {
                            this.grdClassificacao.Rows[c].Cells[0].BackColor = posicao.BackColor;
                            this.grdClassificacao.Rows[c].Cells[0].ForeColor = posicao.ForeColor;
                        }
                        //Se ultrapassou o item da lista
                        else if (posicao.Posicao < list[c].Posicao)
                        {
                            break;

                        }//endif passou o item da lista

                    }//end for items


                    bool found = false;

                    //Verificando se os items já estão agrupados
                    foreach (Model.Boloes.BolaoPremio itemGroup in listGroup)
                    {
                        //Se encontrou o item pesquisado
                        if (itemGroup.BackColor == posicao.BackColor &&
                            itemGroup.ForeColor == posicao.ForeColor &&
                            string.Compare(itemGroup.Titulo, posicao.Titulo, true) == 0)
                        {
                            found = true;
                            break;

                        }//endif encontrou o item pesquisado


                    }//endif items agrupados


                    //Se não encontrou o item
                    if (!found)
                    {
                        listGroup.Add(posicao);

                    }//endif found

                }//end foreach posições



                foreach (Model.Boloes.BolaoPremio posicao in listPosicoes)
                {
                    if (string.Compare(posicao.Titulo, "lanterna", true) == 0)
                    {
                        int lastPos = list[list.Count -1].Posicao;
                        bool okToHighlight = true;

                        foreach (Model.Boloes.BolaoPremio check in listPosicoes)
                        {
                            if (check.Posicao == lastPos && string.Compare(check.Titulo, "lanterna") != 0)
                            {
                                okToHighlight = false;
                            }
                        }


                        if (okToHighlight)
                        {
                            for (int c = list.Count - 1; c >= 0; c--)
                            {
                                if (lastPos != list[c].Posicao || list[c].Posicao == 0)
                                    break;

                                this.grdClassificacao.Rows[c].Cells[0].BackColor = posicao.BackColor;
                                this.grdClassificacao.Rows[c].Cells[0].ForeColor = posicao.ForeColor;
                            }
                        }

                        break;
                    }                    
                }



                //Atribuindo os dados da legenda
                this.dtlLegend.DataSource = listGroup;
                this.dtlLegend.DataBind();



            }//endif viewstate com conteúdo
        }
        #endregion

    }
}
