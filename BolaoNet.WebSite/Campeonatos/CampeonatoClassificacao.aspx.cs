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
using Framework.UI.Web.Controls.GridView.Group;

namespace BolaoNet.WebSite.Campeonatos
{
    public partial class CampeonatoClassificacao : CampeonatoUserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["Campeonato"] != null)
                {
                    Business.Campeonatos.Support.Campeonato bo = new Business.Campeonatos.Support.Campeonato(CurrentUserName, Request.QueryString["campeonato"]);
                    bo.Load();
                    CurrentCampeonato = bo;
                }


                Business.Campeonatos.Support.Campeonato business = new BolaoNet.Business.Campeonatos.Support.Campeonato(base.UserName);

                business.Nome = CurrentCampeonato.Nome;

                this.cboGrupo.DataSource = business.LoadGrupos();
                this.cboGrupo.DataTextField = "Nome";
                this.cboGrupo.DataValueField = "Nome";
                this.cboGrupo.DataBind();




                this.cboFase.DataSource = business.LoadFases();
                this.cboFase.DataTextField = "Nome";
                this.cboFase.DataValueField = "Nome";
                this.cboFase.DataBind();
                
            }//endif ispostback



            BindGrid();
        }
        #endregion

        #region Methods
        private void BindGrid()
        {
            Business.Campeonatos.Support.Campeonato campeonato =
                new Business.Campeonatos.Support.Campeonato(base.UserName, CurrentCampeonato);


            //Se existir grupo e fases cadastrados para o campeonato
            if (this.cboFase.Text.Length > 0 && this.cboGrupo.Text.Length > 0)
            {

                List<Model.Campeonatos.CampeonatoClassificacao> list =
                    (List<Model.Campeonatos.CampeonatoClassificacao>)campeonato.LoadClassificacao(
                    new BolaoNet.Model.Campeonatos.Fase(this.cboFase.Text),
                    new BolaoNet.Model.Campeonatos.Grupo(this.cboGrupo.Text));


                IList<Framework.DataServices.Model.EntityBaseData> listPosicoes = campeonato.SelectPosicoes(
                    new BolaoNet.Model.Campeonatos.Fase(this.cboFase.Text),
                    new BolaoNet.Model.Campeonatos.Grupo(this.cboGrupo.Text));


                ViewState["listPosicoes"] = listPosicoes;
                ViewState["list"] = list;



                //Atribuindo os dados para a grid
                this.grdClassificacao.DataSource = list;
                this.grdClassificacao.DataBind();

            }
            



        }

        private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
        {
            switch (groupName.ToLower())
            {
                case "rodada":
                    row.CssClass = "data_section_header_selected";
                    //row.BackColor = Color.Red;
                    row.Cells[0].Text = "Rodada: " + row.Cells[0].Text;
                    break;

                case "grupo":
                    row.CssClass = "section_grupo";
                    //row.BackColor = Color.Gray;
                    row.Cells[0].Text = "Grupo: " + row.Cells[0].Text;
                    break;

                case "datajogo":
                    //row.CssClass = "section_datajogo";
                    row.CssClass = "data_section_header";
                    //row.BackColor = Color.BlueViolet;
                    row.Cells[0].Text = "Dia: " + Convert.ToDateTime(row.Cells[0].Text).ToString("dd/MM/yyyy");
                    break;

                case "fase":
                    row.CssClass = "section_fase";
                    //row.BackColor = Color.YellowGreen;
                    row.Cells[0].Text = "Fase: " + row.Cells[0].Text;
                    break;
            }
        }
        #endregion

        #region Events
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
            Model.Campeonatos.CampeonatoClassificacao entry = 
                (Model.Campeonatos.CampeonatoClassificacao)e.Row.DataItem;

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


                List<Model.Campeonatos.CampeonatoClassificacao> list = 
                    (List<Model.Campeonatos.CampeonatoClassificacao>)ViewState["list"];


                List<Model.Campeonatos.CampeonatoPosicao> listGroup =
                    new List<BolaoNet.Model.Campeonatos.CampeonatoPosicao>();



                foreach (Model.Campeonatos.CampeonatoPosicao posicao in listPosicoes)
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
                    foreach (Model.Campeonatos.CampeonatoPosicao itemGroup in listGroup)
                    {
                        //Se encontrou o item pesquisado
                        if (itemGroup.BackColor == posicao.BackColor &&
                            itemGroup.ForeColor == posicao.ForeColor &&
                            string.Compare (itemGroup.Titulo, posicao.Titulo, true) == 0)
                        {
                            found  = true;
                            break;

                        }//endif encontrou o item pesquisado
                        

                    }//endif items agrupados


                    //Se não encontrou o item
                    if (!found)
                    {
                        listGroup.Add(posicao);

                    }//endif found

                }//end foreach posições


                //Atribuindo os dados da legenda
                this.dtlLegend.DataSource = listGroup;
                this.dtlLegend.DataBind();



            }//endif viewstate com conteúdo
        }

        #endregion


    }
}
