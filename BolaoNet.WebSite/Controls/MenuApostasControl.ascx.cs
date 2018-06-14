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
    public partial class MenuApostasControl : System.Web.UI.UserControl
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (BolaoUserBasePage.CurrentBolao != null)
            {
                string campeonatoImage = "~/Images/Database/Boloes/" +
                        BolaoUserBasePage.CurrentBolao.Nome + ".jpg";

                this.imgBolao.ImageUrl = campeonatoImage;
                this.imgBolao.DescriptionUrl = BolaoUserBasePage.CurrentBolao.Nome;
            }
        }
        #endregion
    }
}