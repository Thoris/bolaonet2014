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

namespace BolaoNet.WebSite.Shared
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                

                this.lblVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

                BindNextJogo();

                //Verificando se o usuário é autenticado
                if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    //Atribuindo o nome do usuário
                    UserBasePage.CurrentUserName = HttpContext.Current.User.Identity.Name;



                    BindComboBolao();
                    BindComboCampeonato();
                    
                
                }
                //Se o usuário não for autenticado, saia da instrução
                else
                {
                    return;
                }



            }//endif ispostback

        }
        #endregion

        #region Methods
        public void SetWarningMessages(IList<string> messages)
        {
            pnlMessages.Visible = true;
            lstMessages.DataSource = messages;
            lstMessages.DataBind();
        }
        public void SetErrorMessages(IList<string> validations)
        {
            pnlErrors.Visible = true;
            lstErrorMessages.DataSource = validations;
            lstErrorMessages.DataBind();
            
        }
        public void HideErrorText()
        {
            pnlErrors.Visible = false;
        }
        public void HideWarningText()
        {
            pnlMessages.Visible = false;
            lstMessages.DataSource = null;
            lstMessages.DataBind();
        }

        public bool SelectCampeonato(string nomeCampeonato)
        {

            //Buscando os combos usados no processo
            DropDownList cboCampeonato = (DropDownList)this.LoginViewMenuRigth.FindControl("cboCampeonato");
            DropDownList cboBolao = (DropDownList)this.LoginViewMenuRigth.FindControl("cboBolao");



            //Zerando o bolão, pois selecionou um campeonato
            cboBolao.SelectedIndex = 0;
            BolaoUserBasePage.CurrentBolao = null;
            ClearJogosCampeonato();



            //Buscando o campeonato na lista de itens do usuário
            for (int c = 0; c < cboCampeonato.Items.Count; c++)
            {
                //Se encontrou o campeonato na lista
                if (string.Compare(cboCampeonato.Items[c].Value, nomeCampeonato, true) == 0)
                {
                    //Selecionando o campeonato
                    cboCampeonato.SelectedValue = nomeCampeonato;

                    //Mostrando os jogos do campeonato
                    ShowJogosCampeonato(nomeCampeonato);

                    //Se o usuário está autenticado, salva o bolão selecionado
                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        Business.Profile.CustomProfile profile = Business.Profile.CustomProfile.GetProfile(UserBasePage.CurrentUserName);
                        profile.NomeCampeonato = nomeCampeonato;
                        profile.Save();

                    }//endif usuário autenticado



                    //Carregando os detalhes do campeonato
                    Business.Campeonatos.Support.Campeonato entry =
                        new BolaoNet.Business.Campeonatos.Support.Campeonato(UserBasePage.CurrentUserName, nomeCampeonato);
                    entry.Load();
                    CampeonatoUserBasePage.CurrentCampeonato = (Model.Campeonatos.Campeonato)entry;


                    //Indicando que conseguiu encontrar o campeonato
                    return true;

                }//endif encontrou o campeonato
            }//end for items


            //Se não encontrou o registro, zerando-se os dados
            cboCampeonato.SelectedIndex = 0;
            CampeonatoUserBasePage.CurrentCampeonato = null;


            //Indicando que não conseguiu encontrar o campeonato
            return false;
        }
        public bool SelectBolao(string nomeBolao)
        {

            DropDownList cboBolao = (DropDownList)this.LoginViewMenuRigth.FindControl("cboBolao");
            DropDownList cboCampeonato = (DropDownList)this.LoginViewMenuRigth.FindControl("cboCampeonato");

            //Apagando os jogos do usuário
            ClearJogosCampeonato();

            //Buscando em todos os items do bolão
            for (int c = 0; c < cboBolao.Items.Count; c++)
            {
                //Se encontrou o bolão
                if (string.Compare(cboBolao.Items[c].Value, nomeBolao, true) == 0)
                {
                    //Atribuindo o bolão
                    cboBolao.SelectedValue = nomeBolao;

                    //ShowJogosCampeonato(nomeBolao);
                    
                    //Se o usuário está autenticado
                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        Business.Profile.CustomProfile profile = Business.Profile.CustomProfile.GetProfile(UserBasePage.CurrentUserName);
                        profile.NomeBolao = nomeBolao;
                        profile.Save();

                    }//endif usuário autenticado


                    //Buscando os detalhes do registro
                    Business.Boloes.Support.Bolao entry =
                        new BolaoNet.Business.Boloes.Support.Bolao(UserBasePage.CurrentUserName, nomeBolao);
                    entry.Load();
                    
                    
                    //Atribuindo os dados do usuário nas combos
                    BolaoUserBasePage.CurrentBolao = (Model.Boloes.Bolao)entry;
                    BolaoUserBasePage.CurrentCampeonato = entry.Campeonato;
                    CampeonatoUserBasePage.CurrentCampeonato = entry.Campeonato;
                    cboCampeonato.SelectedValue = entry.Campeonato.Nome;



                    //indicando que encontrou o bolão
                    return true;

                }//endif encontrou o bolão

            }//end for items
            
            //indicando que não conseguiu encontrar o bolão
            return false;

        }
        private void ShowJogosCampeonato(string nomeCampeonato)
        {
            int totalFinishedJogos = 10;
            int totalNextJogos = 10;

            //Buscando os dados de configuração
            string totalJogos = ConfigurationManager.AppSettings["TotalFinishedJogosView"];
            if (totalJogos != null)
                totalFinishedJogos = Convert.ToInt32(totalJogos);

            //Buscando os dados de configuração
            totalJogos = ConfigurationManager.AppSettings["TotalNextJogos"];
            if (totalJogos != null)
                totalNextJogos = Convert.ToInt32(totalJogos);



            DropDownList cboCampeonato = (DropDownList)this.LoginViewMenuRigth.FindControl("cboCampeonato");
            GridView grdFinishedJogos = (GridView)this.LoginViewMenuRigth.FindControl("grdFinishedJogos");
            GridView grdNextJogos = (GridView)this.LoginViewMenuRigth.FindControl("grdNextJogos");

            //Criando o objeto para buscar os dados
            Business.Campeonatos.Support.Jogo jogo = new BolaoNet.Business.Campeonatos.Support.Jogo(UserBasePage.CurrentUserName);
            jogo.Campeonato = new BolaoNet.Model.Campeonatos.Campeonato(cboCampeonato.Text);
            
            //Buscando os últimos jogos
            IList<Framework.DataServices.Model.EntityBaseData> listFinishedJogos = jogo.LoadFinishedJogos(jogo.Campeonato, totalFinishedJogos);
            grdFinishedJogos.DataSource = listFinishedJogos;
            grdFinishedJogos.DataBind();


            IList<Framework.DataServices.Model.EntityBaseData> listNextJogos = jogo.LoadNextJogos(jogo.Campeonato, totalNextJogos);
            grdNextJogos.DataSource = listNextJogos;
            grdNextJogos.DataBind();
            

        }
        private void ClearJogosCampeonato()
        {
            GridView grdFinishedJogos = (GridView)this.LoginViewMenuRigth.FindControl("grdFinishedJogos");
            GridView grdNextJogos = (GridView)this.LoginViewMenuRigth.FindControl("grdNextJogos");

            grdFinishedJogos.DataSource = null;
            grdFinishedJogos.DataBind();
            grdNextJogos.DataSource = null;
            grdNextJogos.DataBind();

        }
        
        private void BindComboCampeonato()
        {
            //Carregando os campeonatos disponíveis
            Business.Campeonatos.Support.Campeonato campeonato = 
                new BolaoNet.Business.Campeonatos.Support.Campeonato(UserBasePage.CurrentUserName);
            IList<Framework.DataServices.Model.EntityBaseData> campeonatos = campeonato.SelectAll(null);


            DropDownList cboCampeonato = (DropDownList)this.LoginViewMenuRigth.FindControl("cboCampeonato");

            //Carregando os dados encontrados
            cboCampeonato.Items.Add("<Selecione>");
            foreach (Model.Campeonatos.Campeonato entry in campeonatos)
            {
                //Adicionando o item na lista
                cboCampeonato.Items.Add(entry.Nome);

                //Se existe já um campeonato existente
                if (CampeonatoUserBasePage.CurrentCampeonato != null)
                {
                    //Se encontrou o campeonato que está sendo inserido no combo
                    if (string.Compare(CampeonatoUserBasePage.CurrentCampeonato.Nome, entry.Nome, true) == 0)                    
                        cboCampeonato.Items[cboCampeonato.Items.Count - 1].Selected = true;
                    
                }//endif currentcampeonato

            }//end foreach


            //Se tem algum item selecionado, mostra-se os jogos do campeonato
            if (cboCampeonato.SelectedIndex > 0)
                ShowJogosCampeonato(cboCampeonato.Text);
        }
        private void BindComboBolao()
        {

            //Carregando todos os bolões do usuário
            Business.Users.Support.User user = new BolaoNet.Business.Users.Support.User(UserBasePage.CurrentUserName);
            user.UserName = UserBasePage.CurrentUserName;
            IList<BolaoNet.Model.Users.UserBoloes> boloes = user.LoadBoloes();


            DropDownList cboBolao = (DropDownList)this.LoginViewMenuRigth.FindControl("cboBolao");


            //Inserindo os bolões no combo
            cboBolao.Items.Add("<Selecione>");
            foreach (BolaoNet.Model.Users.UserBoloes entry in boloes)
            {
                cboBolao.Items.Add(entry.Bolao.Nome);

                //Se já existe um bolão selecionado
                if (BolaoUserBasePage.CurrentBolao != null)
                {
                    //Se encontrou o bolão selecionado, seleciona-se a entrada
                    if (string.Compare(BolaoUserBasePage.CurrentBolao.Nome, entry.Bolao.Nome, true) == 0)                    
                        cboBolao.Items[cboBolao.Items.Count - 1].Selected = true;
                    
                }//endif currentbolao
            }//end foreach 


        }
        private void BindNextJogo()
        {
            Business.Campeonatos.Support.Jogo jogo = new Business.Campeonatos.Support.Jogo(UserBasePage.CurrentUserName);
            int result = jogo.NextJogo(CampeonatoUserBasePage.CurrentCampeonato);

            this.lblDias.Text = result.ToString();

        }
        protected void RaiseTrackDown()
        {

            string id = ConfigurationManager.AppSettings["GoogleAnalyticsId"];

            if (!string.IsNullOrEmpty(id))
            {
                string script = "";

                script += "<script type=\"text/javascript\">";

                script += "var _gaq = _gaq || [];";
                script += "_gaq.push(['_setAccount', '" + id + "']);";
                script += "_gaq.push(['_trackPageview']);";

                script += "(function() {";
                script += "  var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;";
                script += "  ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';";
                script += "  var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);";
                script += "})();";

                script += "</script>";


                //ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageAlert",
                //  "<script language=\"JavaScript\">" + Environment.NewLine +
                //  "alert(\'" + "TEST" + "\');" + Environment.NewLine +
                //  "</script>", false);


                ScriptManager.RegisterStartupScript(this, this.GetType(), "MessageAlert", script, false);

            }
        }
        #endregion

        #region Events
        protected override void OnLoad(EventArgs e)
        {
            RaiseTrackDown();

            if (!IsPostBack)
            {
                string name = ConfigurationManager.AppSettings["EnvironmentName"];

                if (!string.IsNullOrEmpty(name))
                {
                    this.lblHeaderEnvironment.Text = name;

                    string color = ConfigurationManager.AppSettings["EnvironmentColor"];

                    if (!string.IsNullOrEmpty(color))
                        this.lblHeaderEnvironment.ForeColor = System.Drawing.Color.FromName(color);
                }
            }

            base.OnLoad(e);
        }
        protected void cboCampeonato_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Buscando os controles a serem manipulados
            DropDownList cboCampeonato = (DropDownList)this.LoginViewMenuRigth.FindControl("cboCampeonato");
            DropDownList cboBolao = (DropDownList)this.LoginViewMenuRigth.FindControl("cboBolao");



            //Zerando os dados do bolão
            cboBolao.SelectedIndex = 0 ;
            BolaoUserBasePage.CurrentBolao = null;
            ClearJogosCampeonato();


            //Se retirou a seleção do campeonato
            if (cboCampeonato.SelectedIndex == 0)
            {
                //Zerando o conteúdo do campeonato
                CampeonatoUserBasePage.CurrentCampeonato = null;

                Response.Redirect("~/Users/Home.aspx");
            }
            else
            {
                //Buscando o campeonato selecionado
                Business.Campeonatos.Support.Campeonato business = new BolaoNet.Business.Campeonatos.Support.Campeonato(
                    UserBasePage.CurrentUserName, cboCampeonato.Text);

                business.Load();
                CampeonatoUserBasePage.CurrentCampeonato = (Model.Campeonatos.Campeonato)business;


                //Gravando a mudança do usuário
                Business.Profile.CustomProfile profile = Business.Profile.CustomProfile.GetProfile();
                profile.NomeCampeonato = cboCampeonato.Text;
                profile.Save();


                //Mostrando os jogos do campeonato
                //ShowJogosCampeonato(cboCampeonato.Text);


                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);


            }//endif retirou a seleção
        }
        protected void cboBolao_SelectedIndexChanged(object sender, EventArgs e)
        {


            //Buscando os controles a serem gerenciados
            DropDownList cboCampeonato = (DropDownList)this.LoginViewMenuRigth.FindControl("cboCampeonato");
            DropDownList cboBolao = (DropDownList)this.LoginViewMenuRigth.FindControl("cboBolao");

            //Apagando os jogos do campeonato
            ClearJogosCampeonato();


            //Se foi retirada a seleção do bolão
            if (cboBolao.SelectedIndex == 0)
            {
                //Zerando o conteúdo dos dados
                BolaoUserBasePage.CurrentBolao = null;
                CampeonatoUserBasePage.CurrentCampeonato = null;

                cboCampeonato.SelectedIndex = 0;


                Response.Redirect("~/Users/Home.aspx");

            }
            //Se selecionou um registro na combo
            else
            {
                //Carregando dados do bolão
                Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(
                    UserBasePage.CurrentUserName, cboBolao.Text);

                business.Load();

                //Atribuindo as alterações para a memória
                BolaoUserBasePage.CurrentBolao = (Model.Boloes.Bolao)business;
                BolaoUserBasePage.CurrentCampeonato = business.Campeonato;
                CampeonatoUserBasePage.CurrentCampeonato = business.Campeonato;

                //Atribuindo o campeonato selecionado
                cboCampeonato.SelectedValue = business.Campeonato.Nome;


                //Armazenando os dados no profile
                Business.Profile.CustomProfile profile = Business.Profile.CustomProfile.GetProfile();
                profile.NomeBolao = cboBolao.Text;
                profile.NomeCampeonato = cboCampeonato.Text;
                profile.Save();


                //ShowJogosCampeonato(business.Campeonato.Nome);



                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);



            }//endif encontrou registro selecionado
        }
        /// <summary>
        /// Handles the LoggingOut event of the LoginStatus control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.LoginCancelEventArgs"/> instance containing the event data.</param>
        protected void LoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            UserBasePage.CurrentUserName = null;
            BolaoUserBasePage.CurrentBolao = null;
            CampeonatoUserBasePage.CurrentCampeonato = null;

            Session.Clear();

        }
        #endregion
    }
}
