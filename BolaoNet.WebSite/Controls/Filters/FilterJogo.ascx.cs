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
using System.Xml.Linq;
using System.Collections.Generic;

namespace BolaoNet.WebSite.Controls.Filters
{
    public partial class FilterJogo : System.Web.UI.UserControl
    {
        #region Enumerations / Constants
        public enum Filtro
        {
            Ontem_Hoje_Amanha = 0,
            Ultimos_7_dias = 1,
            Proximos_7_dias = 2,
            Ultimo_Mes = 3,
            Proximo_Mes = 4,
            Este_Mes = 5,
            Periodo = 6,
            Rodada = 7,
            Time = 8,
            Fase = 9,
            Grupo = 10,
        }
        #endregion

        #region Events
        public delegate void FilterEventHandler(object sender, FilterJogoEventArgs e);
        public event FilterEventHandler FilterChanged; 
        #endregion

        #region Properties
        public DateTime DataInicial
        {
            get 
            {
                if (ViewState["dataInicial"] == null)
                {
                    GetDataAndSendEvent(false);
                }
                return Convert.ToDateTime(ViewState["dataInicial"]);
            }
        }
        public DateTime DataFinal
        {
            get 
            {
                if (ViewState["dataFinal"] == null)
                {
                    GetDataAndSendEvent(false);
                } 
                return Convert.ToDateTime(ViewState["dataFinal"]);
            }
        }
        public int Rodada
        {
            get 
            {
                if (ViewState["rodada"] == null)
                {
                    GetDataAndSendEvent(false);
                } 
                return Convert.ToInt32(ViewState["rodada"]);
            }
        }
        public string Time
        {
            get
            {
                if (ViewState["time"] == null)
                {
                    GetDataAndSendEvent(false);
                } 
                return Convert.ToString(ViewState["time"]);
            }
        }
        public string Fase
        {
            get
            {
                if (ViewState["fase"] == null)
                {
                    GetDataAndSendEvent(false);
                }
                return Convert.ToString(ViewState["fase"]);
            }
        }
        public string Grupo
        {
            get
            {
                if (ViewState["Grupo"] == null)
                {
                    GetDataAndSendEvent(false);
                }
                return Convert.ToString(ViewState["grupo"]);
            }
        }
        
        #endregion

        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region Datas
                //Atribuindo as datas iniciais
                DateTime dataMes = new DateTime(DateTime.Now.Year,
                    DateTime.Now.Month, 1);

                if (this.txtFiltroDataInicial.Text.Length == 0)
                    this.txtFiltroDataInicial.Text = dataMes.ToString("dd/MM/yyyy");

                if (this.txtFiltroDataFinal.Text.Length == 0)
                    this.txtFiltroDataFinal.Text = dataMes.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy");
                #endregion

                //Criando o objeto para o campeonato
                Business.Campeonatos.Support.Campeonato business = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                    UserBasePage.CurrentUserName, CampeonatoUserBasePage.CurrentCampeonato);

                #region Rodadas
                //Carregando as rodadas
                IList<int> list = business.LoadRodadas();

                foreach (int rodada in list)
                {
                    this.cboRodada.Items.Add(rodada.ToString());
                }
                #endregion

                #region Times
                //Carregando os times do campeonato
                IList<Framework.DataServices.Model.EntityBaseData> listTimes = business.LoadTimes();
                this.cboTime.DataSource = listTimes;
                this.cboTime.DataTextField = "Nome";
                this.cboTime.DataValueField = "Nome";
                this.cboTime.DataBind();
                #endregion

                #region Fases
                //Carregando as fases do campeonato
                IList<Framework.DataServices.Model.EntityBaseData> listFases = business.LoadFases();
                this.cboFase.DataSource = listFases;
                this.cboFase.DataTextField = "Nome";
                this.cboFase.DataValueField = "Nome";
                this.cboFase.DataBind();
                #endregion

                #region Grupos
                //Carregando os grupos do campeonato
                IList<Framework.DataServices.Model.EntityBaseData> listGrupos = business.LoadGrupos();
                this.cboGrupo.DataSource = listGrupos;
                this.cboGrupo.DataTextField = "Nome";
                this.cboGrupo.DataValueField = "Nome";
                this.cboGrupo.DataBind();
                #endregion


                #region Atribuindo os dados já selecionados
                if (Session["FilterJogo.DataInicial"] != null)
                {
                    this.PopCalendarDataInicial.DateValue = Convert.ToDateTime(Session["FilterJogo.DataInicial"]);
                    this.txtFiltroDataInicial.Text = Convert.ToDateTime(Session["FilterJogo.DataInicial"]).ToString("dd/MM/yyyy");
                }

                if (Session["FilterJogo.DataFinal"] != null)
                {
                    this.PopCalendarDataFinal.DateValue = Convert.ToDateTime(Session["FilterJogo.DataFinal"]);
                    this.txtFiltroDataFinal.Text = Convert.ToDateTime(Session["FilterJogo.DataFinal"]).ToString("dd/MM/yyyy");
                }

                if (Session["FilterJogo.Rodada"] != null)
                    this.cboRodada.SelectedValue = Session["FilterJogo.Rodada"].ToString();


                if (Session["FilterJogo.Time"] != null)                
                    this.cboTime.SelectedValue = Session["FilterJogo.Time"].ToString();


                if (Session["FilterJogo.Fase"] != null)
                    this.cboFase.SelectedValue = Session["FilterJogo.Fase"].ToString();

                if (Session["FilterJogo.Grupo"] != null)
                {
                    this.cboGrupo.SelectedValue = Session["FilterJogo.Grupo"].ToString();
                }
                else
                {
                    for (int c = 0; c < this.cboGrupo.Items.Count; c++)
                    {
                        if (!string.IsNullOrEmpty (this.cboGrupo.Items[c].Text.Trim ()) )
                        {
                            Session["FilterJogo.Grupo"] = this.cboGrupo.Items[c].Text;
                            this.cboGrupo.SelectedIndex = c;
                            break;
                        }
                    }
                }
                

                if (Session["FilterJogo.Filter"] != null)
                {
                    int filtro = (int)Session["FilterJogo.Filter"];
                    this.cboFiltro.SelectedIndex = filtro;

                    cboFiltro_SelectedIndexChanged(this, new EventArgs());

                }
                else
                {
                    GetDataAndSendEvent(false);
                }
                #endregion


            }
        }
        #endregion

        #region Methods       
        private void GetDataAndSendEvent(bool sendEvent)
        {
            DateTime dataInicial = DateTime.MinValue;
            DateTime dataFinal = DateTime.MinValue;
            int rodada = 0;
            string time = null;
            string grupo = null;
            string fase = null;

            //Verificando o tipo de filtro a ser analisado
            switch ((Filtro)this.cboFiltro.SelectedIndex)
            {
                case Filtro.Este_Mes:

                    dataInicial = new DateTime(
                        DateTime.Now.Year,
                        DateTime.Now.Month,
                        1);

                    dataFinal = dataInicial.AddMonths(1).AddDays(-1);

                    break;

                case Filtro.Ontem_Hoje_Amanha:

                    dataInicial = new DateTime(
                        DateTime.Now.Year,
                        DateTime.Now.Month,
                        DateTime.Now.Day);

                    dataFinal = dataInicial.AddDays(2);
                    dataInicial = dataInicial.AddDays(-1);



                    break;

                case Filtro.Periodo:


                    try
                    {
                        dataInicial = Convert.ToDateTime(this.txtFiltroDataInicial.Text);
                    }
                    catch
                    {
                    }

                    try
                    {
                        dataFinal = Convert.ToDateTime(this.txtFiltroDataFinal.Text);
                    }
                    catch
                    {
                    }

                    break;

                case Filtro.Proximo_Mes:

                    dataInicial = new DateTime(
                          DateTime.Now.Year,
                          DateTime.Now.Month,
                          1);

                    dataInicial = dataInicial.AddMonths(1);
                    dataFinal = dataInicial.AddMonths(1).AddDays(-1);


                    break;

                case Filtro.Proximos_7_dias:

                    dataInicial = new DateTime(
                          DateTime.Now.Year,
                          DateTime.Now.Month,
                          DateTime.Now.Day).AddDays(1);

                    dataFinal = dataInicial.AddDays(7);


                    break;

                case Filtro.Rodada:

                    try
                    {
                        rodada = int.Parse(this.cboRodada.Text);
                    }
                    catch
                    {
                        rodada = 0;
                    }

                    break;

                case Filtro.Ultimo_Mes:

                    dataInicial = new DateTime(
                        DateTime.Now.Year,
                        DateTime.Now.Month,
                        1).AddMonths(-1);

                    dataFinal = dataInicial.AddMonths(1).AddDays(-1);

                    break;

                case Filtro.Ultimos_7_dias:

                    dataInicial = new DateTime(
                      DateTime.Now.Year,
                      DateTime.Now.Month,
                      DateTime.Now.Day).AddDays(-8);

                    dataFinal = new DateTime(
                      DateTime.Now.Year,
                      DateTime.Now.Month,
                      DateTime.Now.Day).AddDays(-1);

                    break;

                case Filtro.Time:

                    time = this.cboTime.Text;

                    break;

                case Filtro.Fase:

                    fase = this.cboFase.Text;

                    break;

                case Filtro.Grupo:

                    grupo = this.cboGrupo.Text;

                    break;
            }

            ViewState["rodada"] = rodada;
            ViewState["dataInicial"] = dataInicial;
            ViewState["dataFinal"] = dataFinal;
            ViewState["time"] = time;
            ViewState["fase"] = fase;
            ViewState["grupo"] = grupo;


            if (sendEvent && FilterChanged != null)
            {
                FilterChanged (this, new FilterJogoEventArgs (rodada, dataInicial, dataFinal, time, fase, grupo));
            }

        }
        #endregion

        #region Events
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!IsPostBack)
            {
                if (Session["FilterJogo.Filter"] == null)
                {
                    Session["FilterJogo.Filter"] = (int)Filtro.Rodada;
                }
            }


        }
        protected void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((Filtro)this.cboFiltro.SelectedIndex)
            {
                case Filtro.Este_Mes:
                case Filtro.Ontem_Hoje_Amanha:
                case Filtro.Proximo_Mes:
                case Filtro.Proximos_7_dias:
                case Filtro.Ultimo_Mes:
                case Filtro.Ultimos_7_dias:
                    this.MultiViewFiltro.ActiveViewIndex = 0;
                    break;
                case Filtro.Periodo:
                    this.MultiViewFiltro.ActiveViewIndex = 1;
                    break;
                case Filtro.Rodada:
                    this.MultiViewFiltro.ActiveViewIndex = 2;
                    break;
                case Filtro.Time:
                    this.MultiViewFiltro.ActiveViewIndex = 3;
                    break;
                case Filtro.Fase:
                    this.MultiViewFiltro.ActiveViewIndex = 4;
                    break;
                case Filtro.Grupo:
                    this.MultiViewFiltro.ActiveViewIndex = 5;
                    break;

            }

            GetDataAndSendEvent(true);

            Session["FilterJogo.Filter"] = this.cboFiltro.SelectedIndex;

        }
        protected void PopCalendarDataInicial_SelectionChanged(object sender, EventArgs e)
        {
            GetDataAndSendEvent(true);


            Session["FilterJogo.DataInicial"] = Convert.ToDateTime(this.txtFiltroDataInicial.Text);
        }
        protected void PopCalendarDataFinal_SelectionChanged(object sender, EventArgs e)
        {
            GetDataAndSendEvent(true);

            Session["FilterJogo.DataFinal"] = Convert.ToDateTime(this.txtFiltroDataFinal.Text);
        }
        protected void cboRodada_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDataAndSendEvent(true);

            Session["FilterJogo.Rodada"] = this.cboRodada.Text;
        }
        protected void cboTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDataAndSendEvent(true);

            Session["FilterJogo.Time"] = this.cboTime.Text;
        }
        protected void cboFase_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetDataAndSendEvent(true);

            Session["FilterJogo.Fase"] = this.cboFase.Text;
        }
        protected void cboGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {

            GetDataAndSendEvent(true);

            Session["FilterJogo.Grupo"] = this.cboGrupo.Text;
        }
        #endregion
        


    }
}