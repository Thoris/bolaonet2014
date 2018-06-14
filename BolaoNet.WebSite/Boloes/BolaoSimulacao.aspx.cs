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
    public partial class BolaoSimulacao : BolaoUserBasePage
    {
        #region Constants
        private const int GridPosPontos = 7;
        #endregion

        #region Properties
        private List<Model.Boloes.BolaoCriterioPontos> Criterios
        {
            get { return (List<Model.Boloes.BolaoCriterioPontos>)ViewState["Simulacao.Criterios"]; }
            set { ViewState["Simulacao.Criterios"] = value; }
        }
        private List<Model.Boloes.BolaoCriterioPontosTimes> CriteriosTimes
        {
            get { return (List<Model.Boloes.BolaoCriterioPontosTimes>)ViewState["Simulacao.CriteriosTimes"]; }
            set { ViewState["Simulacao.CriteriosTimes"] = value; }
        }
        private List<Model.Boloes.Simulation.JogoUsuarioPosicao> JogoUsuarios
        {
            get { return (List<Model.Boloes.Simulation.JogoUsuarioPosicao>)ViewState["Simulacao.JogoUsuarioPosicao"]; }
            set { ViewState["Simulacao.JogoUsuarioPosicao"] = value; }
        }
        private List<Model.Boloes.BoloesPontuacao> Pontuacoes
        {
            get
            {
                return (List<Model.Boloes.BoloesPontuacao>)ViewState["BoloesPontuacao"];
            }
            set
            {
                ViewState["BoloesPontuacao"] = value;
            }
        }
        #endregion

        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                Business.Campeonatos.Support.Jogo jogo = new BolaoNet.Business.Campeonatos.Support.Jogo(base.UserName);
                    
                //Se estiver passando o id do jogo
                if (Request.QueryString["IDJogo"] != null)
                {
                    long idJogo = Convert.ToInt64(Request.QueryString["IDJogo"].ToString());

                    jogo.Campeonato = CurrentCampeonato;
                    jogo.IDJogo = idJogo;
                    jogo.Load();


                    this.ctlJogoDetail.Jogo = jogo;

                }//endif passando id do jogo
            






                Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);


                #region Buscando os pontos dos jogos
                List<Model.Boloes.BolaoCriterioPontos> listCriteriosPontos = new List<Model.Boloes.BolaoCriterioPontos>();
                
                IList<Framework.DataServices.Model.EntityBaseData> auxlist = business.LoadCriteriosPontos(null);

                for (int c = 0; c < 20; c++)
                {
                    Model.Boloes.BolaoCriterioPontos criteriosPontos = new BolaoNet.Model.Boloes.BolaoCriterioPontos();
                    criteriosPontos.Bolao = new BolaoNet.Model.Boloes.Bolao(CurrentBolao.Nome);
                    criteriosPontos.CriterioID = (Model.Boloes.BolaoCriterioPontos.CriteriosID) (c + 1);
                    listCriteriosPontos.Add(criteriosPontos);
                }


                foreach (Model.Boloes.BolaoCriterioPontos pontos in auxlist)
                {
                    if (pontos.Pontos != 0)
                        listCriteriosPontos[(int)pontos.CriterioID - 1].Pontos = pontos.Pontos;
                }

                Criterios = listCriteriosPontos;
                #endregion

                #region Buscando os pontos dos times

                List<Model.Boloes.BolaoCriterioPontosTimes> listCriteriosPontosTimes = new List<BolaoNet.Model.Boloes.BolaoCriterioPontosTimes>();
                
                auxlist = business.LoadCriteriosPontosTimes(null);

                foreach (Model.Boloes.BolaoCriterioPontosTimes times in auxlist)
                {
                    listCriteriosPontosTimes.Add(times);
                }

                CriteriosTimes = listCriteriosPontosTimes;

                #endregion

                #region Buscando a classificação do campeonato
                IList<Model.Boloes.BolaoMembros> listClassificacao = business.LoadClassificacao(0);


                #endregion

                #region Buscando as apostas do Usuários
                List<Model.Boloes.Simulation.JogoUsuarioPosicao> listJogosPos = new List<BolaoNet.Model.Boloes.Simulation.JogoUsuarioPosicao>();

                Business.Boloes.Support.JogoUsuario businessJogos = new BolaoNet.Business.Boloes.Support.JogoUsuario(base.UserName);
                businessJogos.Bolao = CurrentBolao;

                //Model.Campeonatos.Jogo jogo = new BolaoNet.Model.Campeonatos.Jogo(380);
                //jogo.Campeonato = CurrentCampeonato;
                    
                auxlist = businessJogos.LoadApostasByJogo(CurrentBolao, jogo, null);

                foreach (Model.Boloes.JogoUsuario aposta in auxlist)
                {
                    Model.Boloes.Simulation.JogoUsuarioPosicao apostaPosicao = new Model.Boloes.Simulation.JogoUsuarioPosicao();
                    apostaPosicao.CopyAposta(aposta);


                    for (int c = listClassificacao.Count - 1; c >= 0; c--)
                    {
                        if (string.Compare(apostaPosicao.UserName, listClassificacao[c].UserName, true) == 0)
                        {
                            apostaPosicao.TotalPontos = listClassificacao[c].TotalPontos;
                            apostaPosicao.LastPontos = listClassificacao[c].TotalPontos;
                            
                            apostaPosicao.Posicao = listClassificacao[c].Posicao;
                            apostaPosicao.LastPosicao = listClassificacao[c].Posicao;


                            apostaPosicao.LastApostaPontos = apostaPosicao.ApostaPontos.Pontos;

                            listClassificacao.RemoveAt(c);

                            break;
                        }
                    }


                    listJogosPos.Add(apostaPosicao);
                }

                JogoUsuarios = listJogosPos;

                #endregion


                this.grdJogosUsuarios.DataSource = OrderPontos( listJogosPos);
                this.grdJogosUsuarios.DataBind();
            }

        }
        #endregion

        #region Methods
        public List<Model.Boloes.Simulation.JogoUsuarioPosicao> OrderPontos(List<Model.Boloes.Simulation.JogoUsuarioPosicao> list)
        {
            List<Model.Boloes.Simulation.JogoUsuarioPosicao> result = new List<BolaoNet.Model.Boloes.Simulation.JogoUsuarioPosicao>();

            var sortedList =
                from w in list
                orderby w.TotalPontos descending
                select w;

            int c = 1;
            int count = 1;
            int lastCheck = -1;


            foreach (var w in sortedList)
            {
                if (lastCheck == -1)
                    lastCheck = w.TotalPontos;


                if (lastCheck != w.TotalPontos)
                    c = count;


                w.Posicao = c;
                result.Add(w);


                lastCheck = w.TotalPontos;
                count++;
            }




            return result;
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
        private void SetDefaultPontos()
        {
            for (int c = 0; c < JogoUsuarios.Count; c++)
            {
                JogoUsuarios[c].TotalPontos = JogoUsuarios[c].LastPontos;
                JogoUsuarios[c].Posicao = JogoUsuarios[c].LastPosicao;

                
                JogoUsuarios[c].ApostaPontos.Pontos = 0;
            }
        }
        private void CalculePontos(Model.Boloes.Simulation.JogoUsuarioPosicao entry, List<Model.Boloes.BolaoCriterioPontos> criterios, List<Model.Boloes.BolaoCriterioPontosTimes> criteriosTimes)
        {

            int PontosTotal			= 0;     //
		
	        int CountEmpate			= 0		;     // Se o usuário apostou empate e o jogo deu empate
	        int CountVitoria			= 0		;     // Se o usuário apostou vitória para o time e deu vitória para o time selecionado
	        int CountDerrota			= 0		;     // Se o usuário apostou derrota para o time e deu derrota para o time selecionado
	        int CountGanhador			= 0		;     // Se acertou o time ganhador, idependente se está jogando em casa ou fora
	        int CountPerdedor			= 0		;     // Se acertou o time perdedor, idependente se está jogando em casa ou fora
	        int CountTime1				= 0		;     // Se acertou a quantidade de gols do time 1 
	        int CountTime2				= 0		;     // Se acertou a quantidade de gols do time 2
	        int CountVDE				= 0		;     // Se acertou se deu empate/derrota ou vitória no jogo
	        int CountErro				= 0		;     // Se errou o jogo
	        int CountGanhadorFora		= 0		;     // Se acertou que o time foi ganhador jogando fora de casa
	        int CountGanhadorDentro	= 0		;     // Se acertou que o time foi ganhador dentro de casa
	        int CountPerdedorFora		= 0		;     // Se acertou que o time foi perdedor fora de casa
	        int CountPerdedorDentro	= 0		;     // Se acertou que o time foi perdedor dentro de casa
	        int CountEmpateGols		= 0		;     // Se acertou a quantidade de gols quando ocorrer empate
	        int CountGolsTime1			= 0		;     // Se acertou a quantidade de gols do time 1
	        int CountGolsTime2			= 0		;     // Se acertou a quantidade de gols do time 2
	        int CountCheio				= 0		;     // Se acertou em cheio o resultado

            //-------------------------------------------------------
            //-- PARTE 1 : Verificando o resultado do jogo
            //-- Se ocorreu empate
            if (entry.GolsTime1 == entry.GolsTime2)
            {
                if (entry.ApostaTime1 == entry.ApostaTime2)
                {
                    CountEmpate=1;
                    CountVDE=1;

                    if (entry.ApostaTime1 == entry.GolsTime1)
                    {
                        CountGanhador=1;
                        CountTime1=1;
                        CountEmpateGols=1;
                        CountPerdedor=1;
                        CountTime2=1;
                        CountCheio=1;
                    }
                }
                else
                {
                    CountErro=1;
                }
            }
            //-- Se ocorreu vitória do time 1
            else if (entry.GolsTime1 > entry.GolsTime2)
            {
                if (entry.ApostaTime1 > entry.ApostaTime2)
                {
                    CountVitoria=1;
                    CountDerrota=1;
                    CountVDE=1;

                    if (entry.ApostaTime1 == entry.GolsTime1 && entry.ApostaTime2 == entry.GolsTime2)
                    {
                        CountCheio=1;
                        CountGanhadorDentro=1;
                        CountPerdedorFora=1;
                    }

                    if (entry.ApostaTime1 == entry.GolsTime1)
                    {
                        CountGanhador=1;
                        CountTime1=1;
                    }

                    if (entry.ApostaTime2 == entry.GolsTime2)
                    {
                        CountPerdedor=1;
                        CountTime2=1;
                    }
                }
                else
                {
                    CountErro=1;
                }
            }
            //-- Se ocorreu derrota do time 1
            else if (entry.GolsTime1 < entry.GolsTime2)
            {
                if (entry.ApostaTime1 < entry.ApostaTime2)
                {
                    CountVitoria=1;
                    CountDerrota=1;
                    CountVDE=1;

                    if (entry.ApostaTime1 == entry.GolsTime1 && entry.ApostaTime2 == entry.GolsTime2)
                    {
                        CountCheio=1;
                        CountGanhadorFora=1;
                        CountPerdedorDentro=1;
                    }

                    if (entry.ApostaTime2 == entry.GolsTime2)
                    {
                        CountGanhador=1;
                        CountTime2=1;

                    }

                    if (entry.ApostaTime1 == entry.GolsTime1)
                    {
                        CountPerdedor=1;
                        CountTime1=1;
                    }
                }
                else
                {
                    CountErro=1;
                }
            }


            //-------------------------------------------------------
            //---- PARTE 2 : Verificando a quantidade de gols do time casa/fora
            //---- Se acertou a quantidade de gols do time 1
            if (entry.GolsTime1 == entry.ApostaTime1)
            {
                CountGolsTime1 =1;
            }
            if (entry.GolsTime2 == entry.ApostaTime2)
            {
                CountGolsTime2 =1;
            }

            PontosTotal = criterios[0].Pontos * CountEmpate +
                criterios[1].Pontos * CountVitoria +
                criterios[2].Pontos * CountDerrota +
                criterios[3].Pontos * CountGanhador +
                criterios[4].Pontos * CountPerdedor +
                criterios[5].Pontos * CountTime1 +
                criterios[6].Pontos * CountTime2 +
                criterios[7].Pontos * CountVDE +
                criterios[8].Pontos * CountErro +
                criterios[9].Pontos * CountGanhadorFora +
                criterios[10].Pontos * CountGanhadorDentro +
                criterios[11].Pontos * CountPerdedorFora +
                criterios[12].Pontos * CountPerdedorDentro +
                criterios[13].Pontos * CountEmpateGols +
                criterios[14].Pontos * CountGolsTime1 +
                criterios[15].Pontos * CountGolsTime2 +
                criterios[16].Pontos * CountCheio;


            foreach (Model.Boloes.BolaoCriterioPontosTimes entryTimes in criteriosTimes)
            {
                if (string.Compare(entry.Time1.Nome, entryTimes.Time.Nome) == 0)
                {
                    PontosTotal *= entryTimes.MultiploTime;
                }
                else if (string.Compare(entry.Time2.Nome, entryTimes.Time.Nome) == 0)
                {
                    PontosTotal *= entryTimes.MultiploTime;
                }
            }



            entry.TotalPontos += PontosTotal;
            entry.ApostaPontos.Pontos = PontosTotal;
    	
//1	Empate
//2	Vitória
//3	Derrota
//4	Ganhador
//5	Perdedor
//6	Time 1
//7	Time 2
//8	Vitória/Empate/Derrota
//9	Erro
//10	Ganhador Fora
//11	Ganhador Dentro
//12	Perdedor Fora
//13	Perdedor Dentro
//14	Empate Gols
//15	Gols Time 1
//16	Gols Time 2
//17	Cheio
	
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
        protected void grdJogosUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Se não é registro
            if (e.Row.RowType != DataControlRowType.DataRow)
            {
                return;

            }//endif registro

            //Buscando o valor do registro
            Model.Boloes.Simulation.JogoUsuarioPosicao entry =
                (Model.Boloes.Simulation.JogoUsuarioPosicao)e.Row.DataItem;



            SetColumnColor(e.Row.Cells[GridPosPontos], entry.Pontos, Pontuacoes);


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
        protected void grdJogosUsuarios_DataBound(object sender, EventArgs e)
        {

        }
        protected void grdJogosUsuarios_DataBinding(object sender, EventArgs e)
        {
            if (Pontuacoes == null)
            {
                Business.Boloes.Support.Bolao bolao = new BolaoNet.Business.Boloes.Support.Bolao(
                    base.UserName, CurrentBolao.Nome);

                IList<Framework.DataServices.Model.EntityBaseData> list = bolao.SelectPontuacao();

                Pontuacoes = new List<BolaoNet.Model.Boloes.BoloesPontuacao>();
                Pontuacoes.Clear();

                foreach (Model.Boloes.BoloesPontuacao pontos in list)
                {
                    Pontuacoes.Add(pontos);
                }

            }
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
        protected void btnSimular_Click(object sender, EventArgs e)
        {
            Model.Campeonatos.Jogo jogo = this.ctlJogoDetail.Jogo;

            SetDefaultPontos();

            foreach (Model.Boloes.Simulation.JogoUsuarioPosicao entry in JogoUsuarios)
            {
                entry.GolsTime1 = jogo.GolsTime1;
                entry.GolsTime2 = jogo.GolsTime2;
                entry.Time1 = jogo.Time1;
                entry.Time2 = jogo.Time2;

                entry.NomeTimeResult1 = jogo.Time1;
                entry.NomeTimeResult2 = jogo.Time2;
                
                CalculePontos(entry, Criterios, CriteriosTimes);
            }

            this.grdJogosUsuarios.DataSource = OrderPontos(JogoUsuarios);
            this.grdJogosUsuarios.DataBind();

        }
        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            SetDefaultPontos();


            this.grdJogosUsuarios.DataSource = OrderPontos(JogoUsuarios);
            this.grdJogosUsuarios.DataBind();
        }
        #endregion

    }
}
