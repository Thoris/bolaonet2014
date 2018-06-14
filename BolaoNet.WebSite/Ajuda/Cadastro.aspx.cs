using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BolaoNet.WebSite.Ajuda
{
    public partial class Cadastro : System.Web.UI.Page
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lblSite.Text = System.Configuration.ConfigurationManager.AppSettings["MailTagUrl"];
                this.lblPageConfirm.Text = System.Configuration.ConfigurationManager.AppSettings["MailTagUrl"];
                this.lblConfirm.Text = System.Configuration.ConfigurationManager.AppSettings["MailTagActivationPage"];
            }
        }
        #endregion
    }
}