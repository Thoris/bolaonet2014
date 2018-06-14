using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections;
using System.Collections.Generic;
using BolaoNet.WebSite.Shared;


namespace BolaoNet.WebSite
{
    public class BasePage : System.Web.UI.Page
    {
        #region Variables
        private Business.Profile.CustomProfile profile;
        #endregion

        #region Properties
        public SiteMaster SiteMaster
        {
            get { return ( SiteMaster) Master; }
        }
        protected Business.Profile.CustomProfile Profile
        {
            get
            {
                if (profile == null)
                {
                    profile = Business.Profile.CustomProfile.GetProfile();
                }

                return profile;
            }

            set { profile = value; }
        }
        #endregion

        #region Constructors/Destructors
        public BasePage()
        {

            this.PreInit += new EventHandler(BasePage_PreInit);
            this.Init += new EventHandler(BasePage_Init);
            this.Load += new EventHandler(BasePage_Load);
            this.LoadComplete += new EventHandler(BasePage_LoadComplete);

            

        }

        
        #endregion

        #region Methods

        protected void SelectCampeonato(string nomeCampeonato)
        {
            SiteMaster.SelectCampeonato(nomeCampeonato);
        }
        protected void SelectBolao(string nomeBolao)
        {
            SiteMaster.SelectBolao(nomeBolao);
        }

        public void SetTitle(string pageName)
        {            
            Title = string.Format(" Workforce Administration Portal {0}", pageName);
        }
        protected void HideErrors()
        {
            if (SiteMaster != null)
            {
                SiteMaster.HideErrorText();
                SiteMaster.HideWarningText();
            }

        }
        protected void HideMessages()
        {
            if (SiteMaster != null)
                SiteMaster.HideWarningText();
        }

        protected void ShowMessages(string message)
        {
            IList<string> messages = new List<string>();
            messages.Add(message);

            ShowMessages(messages);
        }
        protected void ShowMessages(IList<string> messages)
        {
            SiteMaster.SetWarningMessages(messages);
        }

        protected void ShowErrors(string message)
        {
            IList<string> messages = new List<string>();
            messages.Add(message);

            ShowErrors(messages);
        }
        protected void ShowErrors(IList<string> messages)
        {
            SiteMaster.SetErrorMessages(messages);
        }
        protected void ShowErrors(ValidatorCollection validators)
        {
            IList<string> messages = new List<string>();

            foreach (IValidator validator in validators)
            {
                if (!validator.IsValid)
                {                    
                    messages.Add(validator.ErrorMessage);
                }
            }

            if (messages.Count > 0)
            {
                ShowErrors(messages);
            }

        }

       
        #endregion

        #region Events
        protected override void OnLoad(EventArgs e)
        {

            //RaiseTrackDown();

            //if (!IsPostBack)
            //{

            //    //Se tem um bolão como parâmetro
            //    if (Request.QueryString["Bolao"] != null)
            //    {
            //        SelectBolao(Request.QueryString["Bolao"].ToString());
            //    }
            //    //Se tiver um campeonato como parãmetro
            //    else if (Request.QueryString["Campeonato"] != null)
            //    {
            //        SelectCampeonato(Request.QueryString["Campeonato"].ToString());
            //    }

            //}



            base.OnLoad(e);


        }
        protected override void OnLoadComplete(EventArgs e)
        {

            


            base.OnLoadComplete(e);
        }

        private void BasePage_LoadComplete(object sender, EventArgs e)
        {
            ShowErrors(this.Validators);
        }
        private void BasePage_Init(object sender, System.EventArgs e)
        {


            //if (UserData.CurrentUser == null)
            //{
            //    string login = NTLogonFormatter.FormatNTLogon(HttpContext.Current.User.Identity.Name);
            //    CredentialsData creds = new CredentialsData(login, string.Empty);
            //    AuthenticationMgr.Authenticate(creds);
            //    LogManager.WriteSuccessAudit(login, "Authentication Success");
            //    NavigateHome();

            //}


        }
        private void BasePage_Load(object sender, System.EventArgs e)
        {
            HideErrors();


        }
        private void BasePage_PreInit(object sender, EventArgs e)
        {
            //Model.Providers.ProfileCommon profile = HttpContext.Current.Profile
            //                as Model.Providers.ProfileCommon;

            //if (!String.IsNullOrEmpty(profile.UI.MasterPage))
            //{
            //    MasterPageFile = profile.UI.MasterPage;
            //}

            //if (!String.IsNullOrEmpty(profile.UI.Theme))
            //{
            //    Theme = profile.UI.Theme;
            //}


        }
        #endregion
    }
}