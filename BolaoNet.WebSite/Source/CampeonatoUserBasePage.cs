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
using System.Xml.Linq;

namespace BolaoNet.WebSite
{
    public class CampeonatoUserBasePage : UserBasePage, Source.INavigate
    {
        #region Variables
        //protected static Model.Campeonatos.Campeonato _currentCampeonato = null;
        #endregion

        #region Properties
        protected Model.Campeonatos.Campeonato BaseCurrentCampeonato
        {
            get { return CurrentCampeonato; }
            set { CurrentCampeonato = value; }
        }

        public static Model.Campeonatos.Campeonato CurrentCampeonato
        {
            get
            {

                if (HttpContext.Current.Session == null || HttpContext.Current.Session["CurrentCampeonato"] == null)
                    return null;

                return (Model.Campeonatos.Campeonato)HttpContext.Current.Session["CurrentCampeonato"];
                //return _currentCampeonato;
            }
            set 
            {
                if (HttpContext.Current.Session != null)
                    HttpContext.Current.Session["CurrentCampeonato"] = value;
                //_currentCampeonato = value; 
            }
        }
        #endregion

        #region Constructors/Destructors
        public CampeonatoUserBasePage()
        {
        }
        #endregion

        #region Events
        protected override void OnInit(EventArgs e)
        {

            base.OnInit(e);

            if (!IsPostBack)
            {
                if (Request.QueryString["Campeonato"] != null)
                {
                    if (CurrentCampeonato == null ||
                        string.Compare(Request.QueryString["Campeonato"].ToString(), CurrentCampeonato.Nome, true) != 0)
                    {
                        Business.Campeonatos.Support.Campeonato business = new
                            Business.Campeonatos.Support.Campeonato(
                            base.UserName, Request.QueryString["Campeonato"].ToString());

                        if (business.Load())
                        {
                            CurrentCampeonato = business;
                            BolaoUserBasePage.CurrentBolao = null;
                            BolaoUserBasePage.CurrentCampeonato = business;
                        }
                        else
                        {
                            CurrentCampeonato = null;
                            BolaoUserBasePage.CurrentCampeonato = null;
                            BolaoUserBasePage.CurrentBolao = null;
                        }
                    }//endif currentCampeonato = null

                }//if querystring != null
            }//endif postback

            if (CurrentCampeonato == null)
            {
                Response.Redirect("~\\Campeonatos\\SelectCampeonato.aspx?ReturnURL=" + 
                    HttpContext.Current.Request.CurrentExecutionFilePath);
                return;
            }


        }
        #endregion

        #region Navigate Methods
        public new void NavigateHome()
        {
            Response.Redirect("~/Campeonatos/CampeonatoHome.aspx");
        }
        #endregion
    }
}
