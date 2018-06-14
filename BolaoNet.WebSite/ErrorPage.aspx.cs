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

namespace BolaoNet.WebSite
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Literal literal = new Literal();
            literal.Text = "<a href='mailto:thorisangelo@hotmail.com'> Por favor, entre em contato</a> ";
            this.ContactLabel.Text = literal.Text;

            Exception ex = Server.GetLastError();

            if (ex != null)
            {
                if (ex.InnerException != null)
                {
                    this.ErrorMessage.Text = ex.InnerException.Message;
                }
                else
                {
                    this.ErrorMessage.Text = ex.Message;
                }
            }

            Server.ClearError();
        }
    }
}
