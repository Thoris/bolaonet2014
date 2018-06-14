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
    public partial class ApostasClassificacao : BolaoUserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Business.Boloes.Support.Bolao bolao = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);
                IList<Framework.DataServices.Model.EntityBaseData> list = bolao.LoadMembros();

                this.cboUsuarios.DataSource = list;
                this.cboUsuarios.DataTextField = "UserName";
                this.cboUsuarios.DataValueField = "UserName";
                this.cboUsuarios.DataBind();




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


            Business.Boloes.Support.JogoUsuario jogoUsuario =
                new Business.Boloes.Support.JogoUsuario(base.UserName);

            Business.Campeonatos.Support.Campeonato campeonato =
                new BolaoNet.Business.Campeonatos.Support.Campeonato(base.UserName, CurrentCampeonato);


            //Se existir grupo e fases cadastrados para o campeonato
            if (this.cboFase.Text.Length > 0 && this.cboGrupo.Text.Length > 0)
            {

                List<Model.Campeonatos.CampeonatoClassificacao> list =
                    (List<Model.Campeonatos.CampeonatoClassificacao>)jogoUsuario.LoadClassificacao(
                    CurrentBolao,
                    new BolaoNet.Model.Campeonatos.Fase(this.cboFase.Text),
                    new BolaoNet.Model.Campeonatos.Grupo(this.cboGrupo.Text),
                    new Framework.Security.Model.UserData (this.cboUsuarios.Text));


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
        private void CheckPosicao()
        {
            int countPos = 1;
            int currentPos = 1;
            int currentPontos = -1;

            for (int c = 0; c < this.grdClassificacao.Rows.Count; c++)
            {
                int gridValue = int.Parse (this.grdClassificacao.Rows[c].Cells[5].Text);

                if (currentPontos == -1)
                {
                    currentPontos = gridValue;
                    currentPos = 1;
                }
                else if (currentPontos != gridValue)
                {
                    currentPos = countPos;
                }

                this.grdClassificacao.Rows[c].Cells[0].Text = currentPos.ToString();
                countPos++;
                
            }
        }
        #endregion

        #region Events
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



                CheckPosicao();



                foreach (Model.Campeonatos.CampeonatoPosicao posicao in listPosicoes)
                {
                    //Verificando o item para ser pintado
                    for (int c = 0; c < list.Count; c++)
                    {
                        //Se encontrou o item na lista
                        if (posicao.Posicao == int.Parse (this.grdClassificacao.Rows[c].Cells[0].Text))
                        //if (posicao.Posicao == list[c].Posicao)
                        {
                            this.grdClassificacao.Rows[c].Cells[0].BackColor = posicao.BackColor;
                            this.grdClassificacao.Rows[c].Cells[0].ForeColor = posicao.ForeColor;
                        }
                        //Se ultrapassou o item da lista
                        else if (posicao.Posicao < int.Parse(this.grdClassificacao.Rows[c].Cells[0].Text))
                        //else if (posicao.Posicao < list[c].Posicao)
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


                //Atribuindo os dados da legenda
                this.dtlLegend.DataSource = listGroup;
                this.dtlLegend.DataBind();



            }//endif viewstate com conteúdo
        }
        protected void grdClassificacao_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.ctlNavigateHomeControl.ButtonClick += new CommandEventHandler(ctlNavigateHomeControl_ButtonClick);
            this.ctlMenuTools.ButtonClick += new CommandEventHandler(ctlMenuTools_ButtonClick);
        }
        private void ctlNavigateHomeControl_ButtonClick(object sender, CommandEventArgs e)
        {
            base.NavigateHome();
        }
        private void ctlMenuTools_ButtonClick(object sender, CommandEventArgs e)
        {
        }
        #endregion

    }
}
