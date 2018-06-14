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

namespace BolaoNet.WebSite.Controls
{
    public partial class UserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(UserBasePage.CurrentUserName))
                {
                    string fileImage = "~/Images/Database/Users/" + UserBasePage.CurrentUserName + ".jpg";

                    if (!System.IO.File.Exists(Server.MapPath(fileImage)))
                        fileImage = "~/Images/Database/Users/No-Image.png";

                    this.imgUser.ImageUrl = fileImage;


                }
            }

        }
    }
}