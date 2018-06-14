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

namespace BolaoNet.WebSite.Controls.MenuManager
{
    public partial class NavigateHomeControl : System.Web.UI.UserControl
    {
        #region Delegates/Events
        public event CommandEventHandler ButtonClick;
        #endregion

        #region Properties
        public bool ShowWarning
        {
            get
            {
                if (ViewState["ShowWarning"] == null)
                {
                    ViewState["ShowWarning"] = false;
                }

                return (bool)ViewState["ShowWarning"];
            }

            set
            {
                ViewState["ShowWarning"] = value;
            }
        }
        #endregion

        #region Constructors/Destructors

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Methods
        #endregion

        #region Events
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (ShowWarning)
            {
                lnkHome.OnClientClick = "if (!confirm('Warning - any changes made that have not been saved will be lost. Navigate to Home?')) return false;";
            }
        }

        protected void Button_Click(object sender, CommandEventArgs e)
        {
            if (ButtonClick != null)
                ButtonClick(sender, e);
        }
        #endregion







    }
}