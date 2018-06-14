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
    public class ApostaBolaoBasePage : BolaoUserBasePage, Source.INavigate , Source.IValidate
    {
        #region Navigate Methods
        public new void NavigateHome()
        {
            Response.Redirect("~/Apostas/HomeApostas.aspx");
        }
        #endregion

        #region IValidate Members

        public override bool IsValidToShow()
        {
            return true;
        }

        #endregion
    }
}
