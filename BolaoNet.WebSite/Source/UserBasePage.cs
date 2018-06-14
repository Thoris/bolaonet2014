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
    public class UserBasePage : BasePage, Source.INavigate
    {
        #region Variables
        //private static string _currentUserName;
        #endregion

        #region Properties

        protected string UserName
        {
            get 
            {

                if (HttpContext.Current.Session == null || HttpContext.Current.Session["CurrentUserName"] == null)
                    return null;

                return (string)HttpContext.Current.Session["CurrentUserName"];
                //return _currentUserName; 
            }
            set 
            {
                if (HttpContext.Current.Session != null)
                    HttpContext.Current.Session["CurrentUserName"] = value;
                //_currentUserName = value; 
            }
        }

        public static string CurrentUserName
        {
            get
            {
                if (HttpContext.Current.Session == null || HttpContext.Current.Session["CurrentUserName"] == null)
                    return null;

                return (string)HttpContext.Current.Session["CurrentUserName"];
                //return _currentUserName; 
            }
            set
            {
                if (HttpContext.Current.Session != null)
                    HttpContext.Current.Session["CurrentUserName"] = value;
                //_currentUserName = value; 
            }
        }
 
        #endregion

        #region Constructors/Destructors
        public UserBasePage()
        {
            
           
        }
        #endregion

        #region Events
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (this.UserName == null)
            {
                Response.Redirect("~\\Visitante\\Login.aspx?ReturnURL=" +
                    HttpContext.Current.Request.CurrentExecutionFilePath);
                return;
            }
            

        }
        #endregion

        #region INavigate Members

        public void NavigateHome()
        {
            Response.Redirect("~/Users/Home.aspx");
        }

        #endregion
    }
}
