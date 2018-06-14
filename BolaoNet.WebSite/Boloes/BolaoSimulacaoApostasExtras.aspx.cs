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
using System.Collections.Generic;

namespace BolaoNet.WebSite.Boloes
{
    public partial class BolaoSimulacaoApostasExtras : BolaoUserBasePage
    {


        #region Properties
        public List<Model.Boloes.Simulation.ApostasExtrasBolaoMembros> Classificacao
        {
            get 
            { 
                return (List<Model.Boloes.Simulation.ApostasExtrasBolaoMembros>) ViewState["Classificacao"];
            }
            set{ ViewState["Classificacao"] = value ;}
        }
        #endregion

        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Business.Campeonatos.Support.Campeonato business =
                    new Business.Campeonatos.Support.Campeonato(base.UserName, CurrentCampeonato.Nome);

                #region Buscando os times
                IList<Framework.DataServices.Model.EntityBaseData> list = business.LoadTimes();
                ViewState["Times"] = list;
                #endregion

                #region Atualizando as apostas extras

                Business.Boloes.Support.ApostaExtra businessExtra =
                    new Business.Boloes.Support.ApostaExtra(base.UserName);

                IList<Framework.DataServices.Model.EntityBaseData> listExtra = businessExtra.SelectAll("NomeBolao='" + CurrentBolao.Nome + "'");

                ViewState["Grid"] = listExtra;

                this.grdApostas.DataSource = ViewState["Grid"];
                this.grdApostas.DataBind();


                #endregion

                #region Buscando a classificação do campeonato
                Business.Boloes.Support.Bolao businessBolao = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);
                IList<Model.Boloes.BolaoMembros> listClassificacao = businessBolao.LoadClassificacao(0);
                #endregion

                #region Criando a lista de usuários

                List<Model.Boloes.Simulation.ApostasExtrasBolaoMembros> listSimulation = new List<Model.Boloes.Simulation.ApostasExtrasBolaoMembros>();

                foreach (Model.Boloes.BolaoMembros entry in listClassificacao)
                {
                    Model.Boloes.Simulation.ApostasExtrasBolaoMembros extraUser = new BolaoNet.Model.Boloes.Simulation.ApostasExtrasBolaoMembros();
                    extraUser.Copy((Model.Boloes.BolaoMembros)entry);
                    extraUser.LastPontos = extraUser.TotalPontos;
                    extraUser.LastPosicao = extraUser.Posicao;

                    listSimulation.Add(extraUser);
                }
                #endregion

                #region Buscando as apostas extras dos usuários

                Business.Boloes.Support.ApostaExtraUsuario businessExtraUser = new BolaoNet.Business.Boloes.Support.ApostaExtraUsuario(base.UserName);
                businessExtra.Bolao = CurrentBolao;


                foreach (Model.Boloes.ApostaExtra entry in listExtra)
                {
                    IList<Framework.DataServices.Model.EntityBaseData> listPos = businessExtraUser.SelectByPosicao(CurrentBolao, entry.Posicao, null);

                    foreach (Model.Boloes.ApostaExtraUsuario modelExtraUser in listPos)
                    {
                        for (int c=0; c < listSimulation.Count; c++)
                        {
                            if (string.Compare(listSimulation[c].UserName, modelExtraUser.UserName, true) == 0)
                            {
                                listSimulation[c].ListApostasExtras.Add(modelExtraUser);
                                break;
                            }
                        }
                    }
                }

                Classificacao = listSimulation;
                #endregion


                BindUsers();



            }
        }
        #endregion

        #region Methods
        private void SetDefaultPontos()
        {
            for (int c = 0; c < Classificacao.Count; c++)
            {

                for (int l = 0; l < Classificacao[c].ListApostasExtras.Count; l++)
                {
                    Classificacao[c].ListApostasExtras[l].Pontos = 0;
                }
                

                Classificacao[c].Posicao = Classificacao[c].LastPosicao;
            }
        }
        private void BindUsers()
        {
            this.grdJogosUsuarios.DataSource = OrderPontos(Classificacao);
            this.grdJogosUsuarios.DataBind();
        }
        private List<Model.Boloes.Simulation.ApostasExtrasBolaoMembros> OrderPontos(List<Model.Boloes.Simulation.ApostasExtrasBolaoMembros> list)
        {
            List<Model.Boloes.Simulation.ApostasExtrasBolaoMembros> result = new List<BolaoNet.Model.Boloes.Simulation.ApostasExtrasBolaoMembros>();

            var sortedList =
                from w in list
                orderby w.TotalPontosCalculado descending
                select w;

            int c = 1;
            int count = 1;
            int lastCheck = -1;


            foreach (var w in sortedList)
            {
                if (lastCheck == -1)
                    lastCheck = w.TotalPontosCalculado;


                if (lastCheck != w.TotalPontosCalculado)
                    c = count;


                w.Posicao = c;
                result.Add(w);


                lastCheck = w.TotalPontosCalculado;
                count++;
            }




            return result;
        }
        private List<Model.Boloes.Simulation.ApostasExtrasBolaoMembros> CalculatePontos(List<Framework.DataServices.Model.EntityBaseData> listExtra, List<Model.Boloes.Simulation.ApostasExtrasBolaoMembros> list)
        {
            List<Model.Boloes.Simulation.ApostasExtrasBolaoMembros> listResult = new List<BolaoNet.Model.Boloes.Simulation.ApostasExtrasBolaoMembros>();
            int l = 0;
      
            foreach (Model.Boloes.ApostaExtra entryMain in listExtra)
            {
                for (int c=0; c < list.Count; c++)
                {
                    if (list[c].ListApostasExtras.Count > l)
                    {
                        if (string.Compare(entryMain.NomeTimeValidado, list[c].ListApostasExtras[l].NomeTime, true) == 0)
                        {
                            list[c].ListApostasExtras[l].Pontos =  entryMain.TotalPontos;
                        }
                        else
                        {
                            list[c].ListApostasExtras[l].Pontos = 0;
                        }
                    }

                }
                l++;

            }

            return list;
        }
        #endregion

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.ctlMenuTools.ButtonClick += new CommandEventHandler(ctlMenuTools_ButtonClick);
            this.ctlNavigateHomeControl.ButtonClick += new CommandEventHandler(ctlNavigateHomeControl_ButtonClick);
        }
        private void ctlNavigateHomeControl_ButtonClick(object sender, CommandEventArgs e)
        {
            base.NavigateHome();
        }
        private void ctlMenuTools_ButtonClick(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case WebSite.Controls.MenuManager.MenuTools.Return:
                    Response.Redirect("~/Boloes/BolaoJogos.aspx");
                    break;
                case WebSite.Controls.MenuManager.MenuTools.Save:

                    break;

                default:
                    break;
            }
        }
        protected void grdApostas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;


            DropDownList cboNomeTime = (DropDownList)e.Row.FindControl("cboNomeTime");

            Image imgTime = (Image)e.Row.FindControl("imgTime");


            IList<Framework.DataServices.Model.EntityBaseData> list =
                (IList<Framework.DataServices.Model.EntityBaseData>)ViewState["Times"];

            cboNomeTime.DataSource = list;
            cboNomeTime.DataValueField = "Nome";
            cboNomeTime.DataTextField = "Nome";
            cboNomeTime.DataBind();


            Model.Boloes.ApostaExtra aposta = (Model.Boloes.ApostaExtra)e.Row.DataItem;


            if (!string.IsNullOrEmpty(aposta.NomeTimeValidado))
            {
                cboNomeTime.SelectedValue = aposta.NomeTimeValidado;
            }

            Label lblPontos = (Label)e.Row.FindControl("lblPontos");
            Label lblDataAposta = (Label)e.Row.FindControl("lblDataAposta");
            Label lblNomeTime = (Label)e.Row.FindControl("lblNomeTime");


            if (aposta.IsValido)
            {
                lblNomeTime.Visible = true;
                cboNomeTime.Visible = false;

                imgTime.ImageUrl = @"~\Images\Database\Times\" + lblNomeTime.Text + ".gif";
            }
            else
            {
                //lblPontos.Text = "-";
                lblNomeTime.Visible = false;
                cboNomeTime.Visible = true;



                imgTime.ImageUrl = @"~\Images\Database\Times\" + cboNomeTime.Text + ".gif";
            }



        }
        protected void cboNomeTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList combo = (DropDownList)sender;

            Image imgTime = (Image)combo.Parent.FindControl("imgTime");

            imgTime.ImageUrl = @"~\Images\Database\Times\" + combo.Text + ".gif";


        }
        protected void btnSimular_Click(object sender, EventArgs e)
        {
            List<Framework.DataServices.Model.EntityBaseData> list = (List<Framework.DataServices.Model.EntityBaseData>)ViewState["Grid"];

            for (int c=0; c < list.Count; c++)
            {
                DropDownList cboNomeTime =(DropDownList) this.grdApostas.Rows[c].FindControl("cboNomeTime");

                ((Model.Boloes.ApostaExtra)list[c]).NomeTimeValidado = cboNomeTime.Text;
            }

            this.grdJogosUsuarios.DataSource =  OrderPontos ( CalculatePontos(list, Classificacao));
            this.grdJogosUsuarios.DataBind();
        }
        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            SetDefaultPontos();
            BindUsers();

        }
        protected void grdJogosUsuarios_DataBinding(object sender, EventArgs e)
        {

        }
        protected void grdJogosUsuarios_DataBound(object sender, EventArgs e)
        {

        }
        protected void grdJogosUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Se não é registro
            if (e.Row.RowType != DataControlRowType.DataRow)
            {
                return;

            }//endif registro

            //Buscando o valor do registro
            Model.Boloes.Simulation.ApostasExtrasBolaoMembros entry =
                (Model.Boloes.Simulation.ApostasExtrasBolaoMembros)e.Row.DataItem;


            //Buscando os objetos da tela
            Image imgLastPos = (Image)e.Row.FindControl("imgLastPos");
            Label lblLastPos = (Label)e.Row.FindControl("lblLastPos");

            //Se tem informação encontrada
            if (imgLastPos != null && lblLastPos != null)
            {

                int diferenca =  entry.LastPosicao - entry.Posicao;

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
