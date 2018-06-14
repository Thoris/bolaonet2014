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
using Framework.UI.Web.Controls.GridView.Group;

namespace BolaoNet.WebSite.Controls.Filters
{
    public partial class ListJogo : System.Web.UI.UserControl
    {
        #region Constants
        private const int GridPosAposta1 = 11;
        private const int GridPosAposta2 = 13;
        private const int GridPosPontos = 19;
        private const int GridPosResultado = 25;

        private const int GridPosApostas = 26;
        private const int GridPosDataAposta = 24;
        private const int GridPosApostaAuto = 23;

        private const int GridPosSimulacao = 27;
        #endregion
        
        #region Enumerations
        public enum Mode
        {
            All = 0,
            Apostas = 1,
            JogoByTime = 2,
            ApostasReadOnly = 3,
            JogosBolao = 4,
        }
        #endregion

        #region Properties
        public Mode ModeList
        {
            get 
            {
                if (ViewState["mode"] == null)
                {
                    return Mode.All;
                }
                else
                {
                    return (Mode)ViewState["mode"];
                }
            }
            set
            {
                ViewState["mode"] = value;

            }
        }
        public bool GroupHeader
        {
            get
            {
                if (ViewState["GroupHeader"] == null)
                {
                    return true;
                }
                else
                {
                    return Convert.ToBoolean ( ViewState["GroupHeader"]);
                }
            }

        }
        public string UserNameToCheck
        {
            get 
            {
                if (ViewState["userNameToCheck"] == null)
                    return UserBasePage.CurrentUserName;
                else
                    return ViewState["userNameToCheck"].ToString();
            }
            set
            {
                ViewState["userNameToCheck"] = value;
            }
        }
        public bool IsUserInBolao
        {
            get
            {
                if (ViewState["ListJogo.IsUserInBolao"] == null)
                {
                    Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(
                        UserBasePage.CurrentUserName, BolaoUserBasePage.CurrentBolao.Nome);

                    bool result = business.IsUserInBolao(new Framework.Security.Model.UserData(UserBasePage.CurrentUserName));

                    ViewState["ListJogo.IsUserInBolao"] = result;

                    return result;

                }
                else
                {
                    return Convert.ToBoolean(ViewState["ListJogo.IsUserInBolao"]);
                }

            }
        }
        public bool IsUserCanSetResultadoJogo
        {
            get
            {
                if (Session["ListJogo.CanSetJogo"] == null)
                {
                    bool result = System.Web.Security.Roles.IsUserInRole("Gerenciador de Resultados");

                    if (result)
                    {
                        Session["ListJogo.CanSetJogo"] = result;
                        return result;
                    }
                    else
                    {
                        result = System.Web.Security.Roles.IsUserInRole("Administrador");

                        return result;
                    }

                }
                else
                {
                    return Convert.ToBoolean(Session["ListJogo.CanSetJogo"]);
                }
            }
        }

        private List<Model.Boloes.BoloesPontuacao> Pontuacoes
        {
            get 
            {
                return (List<Model.Boloes.BoloesPontuacao>)ViewState["BoloesPontuacao"];
            }
            set
            {
                //if (ViewState["BoloesPontuacao"] == null)
                //     ViewState["BoloesPontuacao"] = new List<Model.Boloes.BoloesPontuacao>();

                ViewState["BoloesPontuacao"] = value;
            }
        }
        #endregion

        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }


            BindGrid(true, this.ctlFilterJogo.Rodada,
              this.ctlFilterJogo.DataInicial,
              this.ctlFilterJogo.DataFinal,
              this.ctlFilterJogo.Time,
              this.ctlFilterJogo.Fase,
              this.ctlFilterJogo.Grupo);

        }
        #endregion

        #region Methods

        private IList<Framework.DataServices.Model.EntityBaseData> LoadData(bool groupHeaderItems, int rodada, DateTime dataInicial, DateTime dataFinal, string time, string fase, string grupo)
        {
            Mode modeItem = Mode.All;

            IList<Framework.DataServices.Model.EntityBaseData> list = null;


            if (ViewState["mode"] != null)
                modeItem = (Mode)ViewState["mode"];


            //Se deve agrupar os jogos
            if (groupHeaderItems && modeItem != Mode.Apostas)
            {
                GridViewHelper helper = new GridViewHelper(this.grdJogos);
                helper.GroupHeader += new GroupEvent(helper_GroupHeader);

                helper.RegisterGroup("rodada", true, true);
                helper.RegisterGroup("onlydatajogo", true, true);

                ViewState["refreshed"] = true;
            }//endif agrupar items



            switch (modeItem)
            {
                case Mode.All:
                case Mode.JogosBolao:

                    //Criando o objeto a ser carregada as informações
                    Business.Campeonatos.Support.Jogo jogo = new BolaoNet.Business.Campeonatos.Support.Jogo(UserBasePage.CurrentUserName);

                    //Buscando os jogos por período
                    list = jogo.SelectAllByPeriod(
                        CampeonatoUserBasePage.CurrentCampeonato,
                        rodada,
                        dataInicial,
                        dataFinal,
                        time,
                        fase,
                        grupo,
                        null,
                        null);


                    break;

                case Mode.Apostas:

                    //Criando o objeto a ser carregada as informações
                    Business.Boloes.Support.JogoUsuario jogoUsuario = new BolaoNet.Business.Boloes.Support.JogoUsuario(UserBasePage.CurrentUserName);


                    //Buscando os jogos por período
                    list = jogoUsuario.SelectAllByPeriod(
                        BolaoUserBasePage.CurrentBolao,
                        this.UserNameToCheck,
                        rodada,
                        dataInicial,
                        dataFinal,
                        time,
                        fase,
                        grupo,
                        null);


                    break;


                case Mode.JogoByTime:

                    break;


                case Mode.ApostasReadOnly:


                    //Criando o objeto a ser carregada as informações
                    Business.Boloes.Support.JogoUsuario jogoUsuarioReadOnly = new BolaoNet.Business.Boloes.Support.JogoUsuario(UserBasePage.CurrentUserName);


                    //Buscando os jogos por período
                    list = jogoUsuarioReadOnly.SelectAllByPeriod(
                        BolaoUserBasePage.CurrentBolao,
                        this.UserNameToCheck,
                        rodada,
                        dataInicial,
                        dataFinal,
                        time,
                        fase,
                        grupo,
                        null);


                    break;

            }//end switch

            return list;
        }
        public void BindGrid()
        {
            BindGrid(false, this.ctlFilterJogo.Rodada,
                this.ctlFilterJogo.DataInicial,
                this.ctlFilterJogo.DataFinal,
                this.ctlFilterJogo.Time,
                this.ctlFilterJogo.Fase,
                this.ctlFilterJogo.Grupo);
        }
        private void BindGrid(bool groupHeaderItems, int rodada, DateTime dataInicial, DateTime dataFinal, string time, string fase, string grupo)
        {
          
            IList<Framework.DataServices.Model.EntityBaseData> list = 
                LoadData(groupHeaderItems, rodada, dataInicial, dataFinal, time, fase, grupo);            
            

            this.grdJogos.DataSource = list;
            this.grdJogos.DataBind();


            ViewState["JogosSourceFilter"] = list;


        }
        private void helper_GroupHeader(string groupName, object[] values, GridViewRow row)
        {
            switch (groupName.ToLower())
            {
                case "rodada":
                    row.CssClass = "header_jogo_rodada";
                    row.Cells[0].Text = "Rodada: " + row.Cells[0].Text;
                    break;

                case "grupo":
                    row.CssClass = "header_jogo_grupo";
                    row.Cells[0].Text = "Grupo: " + row.Cells[0].Text;
                    break;

                case "onlydatajogo":
                    row.CssClass = "header_jogo_data";
                    row.Cells[0].Text = "Dia: " + Convert.ToDateTime(row.Cells[0].Text).ToString("dd/MM/yyyy");
                    break;

                case "fase":
                    row.CssClass = "header_jogo_fase";
                    row.Cells[0].Text = "Fase: " + row.Cells[0].Text;
                    break;
            }
        }
        public List<Model.Boloes.JogoUsuario> LoadApostasChanged()
        {

            List<Framework.DataServices.Model.EntityBaseData> list =
                (List<Framework.DataServices.Model.EntityBaseData>)ViewState["JogosSourceFilter"];


            //IList<Framework.DataServices.Model.EntityBaseData> list =
            //    LoadData(false, this.ctlFilterJogo.Rodada,
            //    this.ctlFilterJogo.DataInicial,
            //    this.ctlFilterJogo.DataFinal,
            //    this.ctlFilterJogo.Time,
            //    this.ctlFilterJogo.Fase,
            //    this.ctlFilterJogo.Grupo);



            List<Model.Boloes.JogoUsuario> listChanged = new List<BolaoNet.Model.Boloes.JogoUsuario>();


            //Para cada item na tela
            for (int c = 0; c < list.Count; c++)
            {
                Model.Boloes.JogoUsuario jogo = (Model.Boloes.JogoUsuario)list[c];

                //Buscando os dados da tela
                TextBox txtAposta1 = (TextBox)this.grdJogos.Rows[c].FindControl("txtAposta1");
                TextBox txtAposta2 = (TextBox)this.grdJogos.Rows[c].FindControl("txtAposta2");

                TextBox txtAposta1Debug = (TextBox)this.grdJogos.Rows[c].Cells[11].Controls[3];
                TextBox txtAposta2Debug = (TextBox)this.grdJogos.Rows[c].Cells[13].Controls[3];
                Label lblIDDebug = (Label)this.grdJogos.Rows[c].Cells[0].Controls[1];


                CheckBox chkValido = (CheckBox)this.grdJogos.Rows[c].FindControl("chkValido");
                Label lblID = (Label)this.grdJogos.Rows[c].FindControl("lblID");

                RadioButton rdoTime1 = (RadioButton)this.grdJogos.Rows[c].FindControl("rdoTime1");
                RadioButton rdoTime2 = (RadioButton)this.grdJogos.Rows[c].FindControl("rdoTime2");

                if (txtAposta1.Text != txtAposta1Debug.Text && txtAposta2.Text != txtAposta2Debug.Text && lblID.Text != jogo.IDJogo.ToString ())
                {
                }
                
                //Se ainda não foi validado o jogo
                if (!chkValido.Checked)
                {
                    //Se os items de apostas estão visíveis
                    if (txtAposta1.Visible && txtAposta2.Visible &&
                        txtAposta1.Text.Length > 0 && txtAposta2.Text.Length > 0)
                    {
                        try
                        {
                            //Convertendo os dados
                            int aposta1 = int.Parse(txtAposta1.Text);
                            int aposta2 = int.Parse(txtAposta2.Text);


                            int ganhador = 0;
                            if (aposta1 == aposta2 && string.IsNullOrEmpty (jogo.Grupo.Nome.Trim()))
                            {
                                if (rdoTime1.Checked)
                                    ganhador = 1;
                                else if (rdoTime2.Checked)
                                    ganhador = 2;
                            }

                            //Se a aposta do jogo é diferente
                            if (jogo.ApostaTime1 != aposta1 || jogo.ApostaTime2 != aposta2 || jogo.DataAposta == DateTime.MinValue || ganhador != jogo.Ganhador)
                            {

                                jogo.ApostaTime1 = aposta1;
                                jogo.ApostaTime2 = aposta2;
                                jogo.Ganhador = ganhador;
                                
                                listChanged.Add(jogo);
                            }
                            else
                            {
                                if (jogo.ApostaTime1 != aposta1 && jogo.ApostaTime2 != aposta2)
                                {
                                }

                            }//endif aposta diferente

                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }//endif jogo ainda não validado
            }//end for items



            return listChanged;
        }
        private bool IsEnabledToAposta(Model.Boloes.JogoUsuario jogo, Model.Boloes.Bolao bolao)
        {
            //Se o jogo já aconteceu
            if (jogo.PartidaValida)
                return false;

            if (!IsUserInBolao)
                return false;



            //Se deve ser feita aposta dos jogos antes do bolão começar
            if (bolao.ApostasApenasAntes)
            {
                //Se o bolão ainda não foi iniciado
                if (bolao.IsIniciado)
                    return false;
                else
                    return true;
            }
            //Se pode fazer a aposta depois do campeonato começado
            else
            {
                //Carregando a data possível para mudar o valor da aposta
                DateTime dateAllowed = jogo.DataJogo.AddHours(-bolao.HorasLimiteAposta);

                //Se ultrapassou a data permitida para a aposta
                if (DateTime.Compare(DateTime.Now, dateAllowed) > 0)
                    return false;
                else
                    return true;


            }//endif campeonato campeonato começado



            //return false;
        }
        private void SetColumnColor(TableCell column, int pontos, List<Model.Boloes.BoloesPontuacao> listPontuacao)
        {
            foreach (Model.Boloes.BoloesPontuacao entry in listPontuacao)
            {
                if (entry.Posicao == pontos)
                {
                    column.ForeColor = entry.ForeColor;
                    column.BackColor = entry.BackColor;
                    break;
                }
            }
        }

        #endregion

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.ctlFilterJogo.FilterChanged += new FilterJogo.FilterEventHandler(ctlFilterJogo_FilterChanged);

            
            //Atualizando o bolão que está sendo analisado
            if (BolaoUserBasePage.CurrentBolao!= null)
            {

                Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(
                    UserBasePage.CurrentUserName, BolaoUserBasePage.CurrentBolao.Nome);

                business.Load();
                BolaoUserBasePage.CurrentBolao = business;
            }
        }
        private void ctlFilterJogo_FilterChanged(object sender, FilterJogoEventArgs e)
        {
            BindGrid(false, e.Rodada, e.DataInicial, e.DataFinal, e.Time, e.Fase, e.Grupo);
            //BindGrid(true, e.Rodada, e.DataInicial, e.DataFinal, e.Time, e.Fase, e.Grupo);
        }
        protected void grdJogos_DataBinding(object sender, EventArgs e)
        {
            switch (ModeList)
            {
                case Mode.Apostas:
                case Mode.ApostasReadOnly:
                case Mode.JogosBolao:

                    
                    if (Pontuacoes == null)
                    {
                        Business.Boloes.Support.Bolao bolao = new BolaoNet.Business.Boloes.Support.Bolao(
                            UserBasePage.CurrentUserName, BolaoUserBasePage.CurrentBolao.Nome);

                        IList<Framework.DataServices.Model.EntityBaseData> list = bolao.SelectPontuacao();

                        Pontuacoes = new List<BolaoNet.Model.Boloes.BoloesPontuacao>();
                        Pontuacoes.Clear();

                        foreach (Model.Boloes.BoloesPontuacao pontos in list)
                        {
                            Pontuacoes.Add(pontos);
                        }

                    }


                    break;
            }
        }
        protected void grdJogos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
            {
                return;
            }


            Label lblGolsTime1 = (Label)e.Row.FindControl("lblGolsTime1");
            Label lblGolsTime2 = (Label)e.Row.FindControl("lblGolsTime2");

            //Verificando o tipo de lista que está sendo mostrado
            switch (ModeList)
            {
                case Mode.All:
                case Mode.JogosBolao:

                    Model.Campeonatos.Jogo jogo = (Model.Campeonatos.Jogo)e.Row.DataItem;

                    
                    RadioButton rdoTime1Jogo = (RadioButton)e.Row.FindControl("rdoTime1");
                    RadioButton rdoTime2Jogo = (RadioButton)e.Row.FindControl("rdoTime2");

                    rdoTime1Jogo.Visible = false;
                    rdoTime2Jogo.Visible = false;

                    if (!jogo.PartidaValida)
                    {
                        lblGolsTime1.Text = "-";
                        lblGolsTime2.Text = "-";
                    }
                    else
                    {
                        e.Row.Cells[GridPosSimulacao].Visible = false;
                    }



                    break;

                case Mode.Apostas:


                    Model.Boloes.JogoUsuario jogoUsuario = (Model.Boloes.JogoUsuario)e.Row.DataItem;

                    TextBox txtAposta1 = (TextBox)e.Row.FindControl("txtAposta1");
                    TextBox txtAposta2 = (TextBox)e.Row.FindControl("txtAposta2");

                    Label lblID = (Label)e.Row.FindControl("lblID");

                    Label lblAposta1 = (Label)e.Row.FindControl("lblAposta1");
                    Label lblAposta2 = (Label)e.Row.FindControl("lblAposta2");

                    Label lblPontos = (Label)e.Row.FindControl("lblPontos");

                    Label lblDataAposta = (Label)e.Row.FindControl("lblDataAposta");
                    CheckBox chkApostaAuto = (CheckBox)e.Row.FindControl("chkApostaAuto");

                    Label lblGrupo = (Label)e.Row.FindControl("lblGrupo");

                    RadioButton rdoTime1 = (RadioButton)e.Row.FindControl("rdoTime1");
                    RadioButton rdoTime2 = (RadioButton)e.Row.FindControl("rdoTime2");

                    rdoTime1.Style.Add("visibility", "hidden");
                    rdoTime2.Style.Add("visibility", "hidden");

                    rdoTime1.Style.Add("display", "inline");
                    rdoTime2.Style.Add("display", "inline");



                    txtAposta1.Attributes.Add("onChange", "JavaScript:onChangeText('" + txtAposta1.ClientID + "','" + txtAposta2.ClientID + "','" + rdoTime1.ClientID + "','" + rdoTime2.ClientID + "','" + lblGrupo.ClientID + "')");
                    txtAposta2.Attributes.Add("onChange", "JavaScript:onChangeText('" + txtAposta1.ClientID + "','" + txtAposta2.ClientID + "','" + rdoTime1.ClientID + "','" + rdoTime2.ClientID + "','" + lblGrupo.ClientID + "')");
                    

                    chkApostaAuto.Checked = jogoUsuario.Automatico;

                    //Verificando se é jogo de eliminatórias
                    if (jogoUsuario.Grupo == null || string.IsNullOrEmpty(jogoUsuario.Grupo.Nome.Trim()))
                    {
                        //Se a aposta do usuário é de empate
                        if (jogoUsuario.ApostaTime1 == jogoUsuario.ApostaTime2)
                        {
                            rdoTime1.Style["visibility"]= "visible";
                            rdoTime2.Style["visibility"] = "visible";
                            if (jogoUsuario.Ganhador == 1)
                                rdoTime1.Checked = true;
                            else if (jogoUsuario.Ganhador == 2)
                                rdoTime2.Checked = true;
                        }//endif aposta empate
                    }//endif eliminatórias


                    if (!IsEnabledToAposta (jogoUsuario, BolaoUserBasePage.CurrentBolao))
                    {
                        
                        lblAposta1.Visible = true;
                        lblAposta2.Visible = true;
                        txtAposta1.Visible = false;
                        txtAposta2.Visible = false;

                        rdoTime1.Enabled = false;
                        rdoTime2.Enabled = false;


                        //Se o jogo já aconteceu
                        if (jogoUsuario.PartidaValida)
                        {
                            rdoTime1.Enabled = false;
                            rdoTime2.Enabled = false;


                            lblPontos.Text = jogoUsuario.ApostaPontos.Pontos.ToString();

                            SetColumnColor(e.Row.Cells[GridPosPontos], jogoUsuario.Pontos, Pontuacoes);
                        }
                        //Se o jogo não aconteceu ainda                        
                        else
                        {
                            lblPontos.Text = "-";

                        }//endif jogo aconteceu

                        //Se não houve apostas
                        if (jogoUsuario.DataAposta == DateTime.MinValue)
                        {

                            lblAposta1.Text = "-";
                            lblAposta2.Text = "-";
                            
                        }
                        else
                        {
                            lblAposta1.Text = jogoUsuario.ApostaTime1.ToString();
                            lblAposta2.Text = jogoUsuario.ApostaTime2.ToString();
                            


                        }//endif houve apostas
                    }
                    else
                    {
                        txtAposta1.Text = jogoUsuario.ApostaTime1.ToString();
                        txtAposta2.Text = jogoUsuario.ApostaTime2.ToString();


                        lblAposta1.Visible = false;
                        lblAposta2.Visible = false;
                        txtAposta1.Visible = true;
                        txtAposta2.Visible = true;


                        lblGolsTime1.Text = "-";
                        lblGolsTime2.Text = "-";
                        lblPontos.Text = "-";
                    }

                    //Alteração para validar a aposta
                    if (jogoUsuario.DataAposta == DateTime.MinValue)
                    {
                        lblDataAposta.Text = "-";
                        txtAposta1.Text = "";
                        txtAposta2.Text = "";
                    }
                    else
                    {
                        lblDataAposta.Text = jogoUsuario.DataAposta.ToString("dd/MM/yy HH:mm:ss");
                    }



                    break;

                case Mode.JogoByTime:

                    break;


                case Mode.ApostasReadOnly:

                    Model.Boloes.JogoUsuario jogoUsuarioReadOnly = (Model.Boloes.JogoUsuario)e.Row.DataItem;

                    TextBox txtAposta1ReadOnly = (TextBox)e.Row.FindControl("txtAposta1");
                    TextBox txtAposta2ReadOnly = (TextBox)e.Row.FindControl("txtAposta2");

                    Label lblAposta1ReadOnly = (Label)e.Row.FindControl("lblAposta1");
                    Label lblAposta2ReadOnly = (Label)e.Row.FindControl("lblAposta2");

                    Label lblPontosReadOnly = (Label)e.Row.FindControl("lblPontos");

                    Label lblDataApostaReadOnly = (Label)e.Row.FindControl("lblDataAposta");
                    CheckBox chkApostaAutoReadOnly = (CheckBox)e.Row.FindControl("chkApostaAuto");

                    RadioButton rdoTime_1 = (RadioButton)e.Row.FindControl("rdoTime1");
                    RadioButton rdoTime_2 = (RadioButton)e.Row.FindControl("rdoTime2");

                    rdoTime_1.Enabled = false;
                    rdoTime_2.Enabled = false;


                    if (jogoUsuarioReadOnly.Grupo == null || string.IsNullOrEmpty(jogoUsuarioReadOnly.Grupo.Nome.Trim()))
                    {
                        if (jogoUsuarioReadOnly.ApostaTime1 == jogoUsuarioReadOnly.ApostaTime2)
                        {
                            rdoTime_1.Style.Add("visibility", "visible");
                            rdoTime_2.Style.Add("visibility", "visible");

                            if (jogoUsuarioReadOnly.Ganhador == 1)
                                rdoTime_1.Checked = true;
                            else if (jogoUsuarioReadOnly.Ganhador == 2)
                                rdoTime_2.Checked = true;
                        }
                        else
                        {
                            rdoTime_1.Style.Add("visibility", "hidden");
                            rdoTime_2.Style.Add("visibility", "hidden");

                        }
                    }
                    else
                    {
                        rdoTime_1.Style.Add("visibility", "hidden");
                        rdoTime_2.Style.Add("visibility", "hidden");

                    }

                    if (jogoUsuarioReadOnly.DataAposta == DateTime.MinValue)
                    {
                        lblDataApostaReadOnly.Text = "-";
                    }
                    else
                    {
                        lblDataApostaReadOnly.Text = jogoUsuarioReadOnly.DataAposta.ToString("dd/MM/yy HH:mm:ss");
                    }
                    chkApostaAutoReadOnly.Checked = jogoUsuarioReadOnly.Automatico;



                    if (jogoUsuarioReadOnly.PartidaValida)
                    {
                        lblAposta1ReadOnly.Text = jogoUsuarioReadOnly.ApostaTime1.ToString();
                        lblAposta2ReadOnly.Text = jogoUsuarioReadOnly.ApostaTime2.ToString();

                        lblAposta1ReadOnly.Visible = true;
                        lblAposta2ReadOnly.Visible = true;
                        txtAposta1ReadOnly.Visible = false;
                        txtAposta2ReadOnly.Visible = false;

                        lblPontosReadOnly.Text = jogoUsuarioReadOnly.ApostaPontos.Pontos.ToString();



                        SetColumnColor(e.Row.Cells[GridPosPontos], jogoUsuarioReadOnly.Pontos, Pontuacoes);
                    }
                    else
                    {
                        lblAposta1ReadOnly.Text = jogoUsuarioReadOnly.ApostaTime1.ToString();
                        lblAposta2ReadOnly.Text = jogoUsuarioReadOnly.ApostaTime2.ToString();


                        lblAposta1ReadOnly.Visible = true;
                        lblAposta2ReadOnly.Visible = true;
                        txtAposta1ReadOnly.Visible = false;
                        txtAposta2ReadOnly.Visible = false; 


                        lblGolsTime1.Text = "-";
                        lblGolsTime2.Text = "-";
                        lblPontosReadOnly.Text = "-";
                    }


                    break;
            }//end switch tipo de list
        }
        protected void grdJogos_DataBound(object sender, EventArgs e)
        {
            switch (ModeList)
            {
                case Mode.All:

                    this.grdJogos.Columns[GridPosAposta1].Visible = false;
                    this.grdJogos.Columns[GridPosAposta2].Visible = false;
                    this.grdJogos.Columns[GridPosPontos].Visible = false;


                    this.grdJogos.Columns[GridPosResultado].Visible = IsUserCanSetResultadoJogo;


                    this.grdJogos.Columns[GridPosDataAposta].Visible = false;
                    this.grdJogos.Columns[GridPosApostaAuto].Visible = false;


                    this.grdJogos.Columns[GridPosApostas].Visible = false;
                    this.grdJogos.Columns[GridPosSimulacao].Visible = false;


                    


                    break;

                case Mode.JogosBolao:

                    this.grdJogos.Columns[GridPosAposta1].Visible = false;
                    this.grdJogos.Columns[GridPosAposta2].Visible = false;
                    this.grdJogos.Columns[GridPosPontos].Visible = false;


                    this.grdJogos.Columns[GridPosResultado].Visible = false;


                    this.grdJogos.Columns[GridPosDataAposta].Visible = false;
                    this.grdJogos.Columns[GridPosApostaAuto].Visible = false;


                    this.grdJogos.Columns[GridPosApostas].Visible = true;
                    this.grdJogos.Columns[GridPosSimulacao].Visible = true;


                    break;



                case Mode.Apostas:


                    this.grdJogos.Columns[GridPosAposta1].Visible = true;
                    this.grdJogos.Columns[GridPosAposta2].Visible = true;
                    this.grdJogos.Columns[GridPosPontos].Visible = true;


                    this.grdJogos.Columns[GridPosResultado].Visible = false;

                    this.grdJogos.Columns[GridPosDataAposta].Visible = true;
                    this.grdJogos.Columns[GridPosApostaAuto].Visible = true;


                    this.grdJogos.Columns[GridPosApostas].Visible = false;
                    this.grdJogos.Columns[GridPosSimulacao].Visible = false;


                    break;

                case Mode.JogoByTime:

                    break;


                case Mode.ApostasReadOnly:

                    this.grdJogos.Columns[GridPosAposta1].Visible = true;
                    this.grdJogos.Columns[GridPosAposta2].Visible = true;
                    this.grdJogos.Columns[GridPosPontos].Visible = true;


                    this.grdJogos.Columns[GridPosResultado].Visible = false;

                    this.grdJogos.Columns[GridPosDataAposta].Visible = true;
                    this.grdJogos.Columns[GridPosApostaAuto].Visible = true;

                    this.grdJogos.Columns[GridPosApostas].Visible = true;
                    this.grdJogos.Columns[GridPosSimulacao].Visible = true;


                    break;


            }

        }
        
        #endregion


    }
}