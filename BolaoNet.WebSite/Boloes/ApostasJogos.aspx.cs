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
using BolaoNet.WebSite.Source.FaceManager;
using System.Net;
using System.IO;
using Facebook;


namespace BolaoNet.WebSite.Boloes
{
    public partial class ApostasJogos : BolaoUserBasePage
    {
        #region Constants
        private const int GridPosPontos = 6;
        private const int GridPosTime1 = 2;
        private const int GridPosTime2 = 4;
        #endregion

        #region Variables

        string _scope = ConfigurationManager.AppSettings["Facebook_scope"];  //"publish_actions";
        string _applicationKey = ConfigurationManager.AppSettings["Facebook_aplicationKey"];
        string _applicationSecret = ConfigurationManager.AppSettings["Facebook_aplicationSecret"];


        #endregion

        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {



            if (!IsPostBack)
            {
                Business.Campeonatos.Support.Jogo jogo = null;

                //Se estiver passando o id do jogo
                if (Request.QueryString["IDJogo"] != null)
                {
                    long idJogo = Convert.ToInt64(Request.QueryString["IDJogo"].ToString());

                    jogo = new BolaoNet.Business.Campeonatos.Support.Jogo(base.UserName);
                    jogo.Campeonato = CurrentCampeonato;
                    jogo.IDJogo = idJogo;
                    jogo.Load();


                    this.ctlJogoDetail.Jogo = jogo;


                    if (jogo.PartidaValida)
                    {

                        Model.Boloes.JogoUsuario social = 
                            new Business.Boloes.Support.JogoUsuario(base.UserName).LoadSocialNetwork(base.BaseCurrentBolao, base.UserName, jogo);

                        if (social.DataFacebook == DateTime.MinValue)
                        {
                            this.ctlMenuTools.FaceVisible = true;
                        }
                    
                    }


                }//endif passando id do jogo



                //Adicionando os dados do facebook
                if (Request["code"] != null)
                {

                    Model.Boloes.JogoUsuario jogoUsuario = new Model.Boloes.JogoUsuario();
                    jogoUsuario.Copy (jogo);
                    jogoUsuario.Bolao = base.BaseCurrentBolao;
                    jogoUsuario.UserName = base.UserName;

                    

                    IList<Framework.DataServices.Model.EntityBaseData> res 
                        = new Business.Boloes.Support.JogoUsuario(base.UserName, jogoUsuario).SelectAll("JogosUsuarios.IdJogo='" + jogo.IDJogo + "' and JogosUsuarios.UserName='" + base.UserName+ "'");

                    jogoUsuario = (Model.Boloes.JogoUsuario) res[0];

                    string message = "";
                    string caption = "Resultado: " + 
                        jogo.Time1.Nome  + " " + jogo.GolsTime1.ToString () + " x " + 
                        jogo.GolsTime2.ToString () + " " + jogo.Time2.Nome;
                    string description = "Minha Aposta: " +
                        jogo.Time1.Nome + " " + jogoUsuario.ApostaTime1.ToString() + " x " +
                        jogoUsuario.ApostaTime2.ToString() + " " + jogo.Time2.Nome + "   - Pontos: " + jogoUsuario.Pontos;
                    string imagePontos = "";

                    message = ConfigurationManager.AppSettings["Facebook_Pontos_" + jogoUsuario.Pontos.ToString()];


                    imagePontos = ConfigurationManager.AppSettings["Facebook_images"] + "pontos" + jogoUsuario.Pontos + ".gif";


                    if (jogoUsuario.Pontos == 10 && (string.Compare(jogo.Time1.Nome, "Brasil", true) == 0 || string.Compare(jogo.Time2.Nome, "Brasil", true) == 0))
                    {
                        message = ConfigurationManager.AppSettings["Facebook_Pontos_10_Brasil"];
                        imagePontos = ConfigurationManager.AppSettings["Facebook_images"] + "pontos" + jogoUsuario.Pontos + "_Brasil.gif";
                    }

                    if (string.IsNullOrEmpty(message))
                    {


                        switch (jogoUsuario.Pontos)
                        {
                            case 0:
                                message = "Não tive sorte neste jogo, que zebra, não acertei nada!";
                                break;
                            case 1:
                                message = "Consegui acertar pelo menos o gol de uma das duas seleções.";
                                break;
                            case 2:
                                message = "Que chance eu perdi...pelo menos acertei o gol de uma das duas seleções";
                                break;
                            case 3:
                                message = "Acertei o ganhador do jogo!";
                                break;
                            case 4:
                                message = "Quase, acertei a vitória de uma das seleções e o gol de uma delas!";
                                break;
                            case 5:
                                message = "Resultado difícil, mas acertei o empate!";
                                break;
                            case 6:
                                message = "Já que é jogo do Brasil, consegui acertar a vitória da seleção.";
                                break;
                            case 8:
                                message = "Quase em cheio! Acertei a vitória da seleção e quantidade de gols de uma delas! Mas como é jogo do Brasil, perdi uma chance boa!";
                                break;
                            case 10:
                                if (string.Compare(jogo.Time1.Nome, "Brasil") == 0 || string.Compare(jogo.Time2.Nome, "Brasil") == 0)
                                {
                                    message = "Jogo do Brasil é sempre difícil, ainda mais quando ocorre empate.";
                                }
                                else
                                {
                                    message = "Na mosca! Muito fácil ... rs";
                                }
                                break;
                            case 20:
                                message = "No jogo do Brasil é melhor ainda, consegui acertar em cheio!!!";
                                break;
                        }
                    }

                    

                    Dictionary<string, string> tokens = new Dictionary<string, string>();

                    string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                        _applicationKey, Request.Url.AbsoluteUri, _scope, Request["code"].ToString(), _applicationSecret);

                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());

                        string vals = reader.ReadToEnd();

                        foreach (string token in vals.Split('&'))
                        {
                            //meh.aspx?token1=steve&token2=jake&...
                            tokens.Add(token.Substring(0, token.IndexOf("=")),
                                token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
                        }
                    }

                    string access_token = tokens["access_token"];

                    var client = new FacebookClient(access_token);


                    string originalQuery = "/Boloes/ApostasJogos.aspx?IdJogo=" + Request.QueryString["IDJogo"].ToString();

                    var postParams = new
                    {
                        name = "BolãoNET",
                        caption = caption,
                        description = description,
                        message = message,
                        link = Request.Url.Host + originalQuery,
                        picture = imagePontos,                        
                    };

                    
                    object resultFacebook = client.Post("/me/feed", postParams);


                    bool result = new Business.Boloes.Support.JogoUsuario(base.UserName).UpdateFacebook(base.BaseCurrentBolao, base.UserName, jogo);

                    Response.Redirect("~" + originalQuery);

                }//endif code (Facebook)

            }//end if IsPostBack

            BindGrid();
        }
        #endregion

        #region Properties

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

        #region Methods
        private void BindGrid()
        {

            Business.Boloes.Support.JogoUsuario business = new BolaoNet.Business.Boloes.Support.JogoUsuario(base.UserName);
            IList<Framework.DataServices.Model.EntityBaseData> list = business.LoadApostasByJogo(
                CurrentBolao, this.ctlJogoDetail.Jogo, null);


            ViewState["Calculo"] = list;

            this.grdJogosUsuarios.DataSource = list;
            this.grdJogosUsuarios.DataBind();


           

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

                case WebSite.Controls.MenuManager.MenuTools.SocialFace:


                    
                    if (Request["code"] == null)
                    {
                        Response.Redirect(string.Format(
                            "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                            _applicationKey, Request.Url.AbsoluteUri, _scope));
                    }
                    
                    break;

                default:
                    break;
            }
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
        protected void grdJogosUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
            {
                return;
            }

            Model.Boloes.JogoUsuario jogoUsuario = (Model.Boloes.JogoUsuario)e.Row.DataItem;

            string time1 = e.Row.Cells[GridPosTime1].Text;
            string time2= e.Row.Cells[GridPosTime2].Text;

            if (!string.IsNullOrEmpty(time1) && !string.IsNullOrEmpty(time2))
            {
                int value1 = int.Parse(time1);
                int value2 = int.Parse(time2);


                if (value1 == value2)
                {
                    //e.Row.Cells[GridPosTime1].BackColor = System.Drawing.Color.Cyan;
                    //e.Row.Cells[GridPosTime2].BackColor = System.Drawing.Color.Cyan;
                    e.Row.Cells[GridPosTime1].Font.Bold = true;
                    e.Row.Cells[GridPosTime2].Font.Bold = true;
                
                }
                else if (value1 > value2)
                {
                    e.Row.Cells[GridPosTime1].BackColor = System.Drawing.Color.LightCyan;
                    e.Row.Cells[GridPosTime1].Font.Bold = true;
                
                }
                else
                {
                    e.Row.Cells[GridPosTime2].BackColor = System.Drawing.Color.LightCyan;
                    e.Row.Cells[GridPosTime2].Font.Bold = true;
                
                
                }
            }


            SetColumnColor(e.Row.Cells[GridPosPontos], jogoUsuario.Pontos, Pontuacoes);

        }
        protected void grdJogosUsuarios_DataBound(object sender, EventArgs e)
        {

            IList<Framework.DataServices.Model.EntityBaseData> list = (IList<Framework.DataServices.Model.EntityBaseData>)ViewState["Calculo"];

            if (list.Count == 0)
                return;

            for (int c = 0; c < this.grdJogosUsuarios.Rows.Count; c++)
            {
                BolaoNet.Model.Boloes.JogoUsuario jogoCorrente = (BolaoNet.Model.Boloes.JogoUsuario)list[c];
                int total = 0;


                foreach (BolaoNet.Model.Boloes.JogoUsuario jogo in list)
                {

                    if (jogoCorrente.ApostaTime1 == jogo.ApostaTime1 && jogoCorrente.ApostaTime2 == jogo.ApostaTime2)
                    {
                        total++;
                    }

                }

                this.grdJogosUsuarios.Rows[c].Cells[this.grdJogosUsuarios.Rows[c].Cells.Count - 1].Text = total + " (" + ((double)total / (double)list.Count * (double)100).ToString("0.0") + "%)";
            }


            int countTime1 = 0, countTime2 = 0, countEmpate = 0;
            foreach (BolaoNet.Model.Boloes.JogoUsuario jogo in list)
            {
                if (jogo.ApostaTime1 == jogo.ApostaTime2)
                {
                    countEmpate++;
                }
                else if (jogo.ApostaTime1 > jogo.ApostaTime2)
                {
                    countTime1++;
                }
                else
                {
                    countTime2++;
                }
            }

            this.lblPorcentEmpate.Text = countEmpate + " (" + ((double)countEmpate / (double)list.Count * (double)100).ToString("0.00") + "% )";
            this.lblPorcentTime1.Text = countTime1 + " (" + ((double)countTime1 / (double)list.Count * (double)100).ToString("0.00") + "% )";
            this.lblPorcentTime2.Text = countTime2 + " (" + ((double)countTime2 / (double)list.Count * (double)100).ToString("0.00") + "% )";




        }
        #endregion



    }
}
