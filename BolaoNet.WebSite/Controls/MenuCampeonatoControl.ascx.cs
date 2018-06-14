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
    public partial class CampeonatoControl : System.Web.UI.UserControl
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CampeonatoUserBasePage.CurrentCampeonato != null)
                {
                    string campeonatoImage = "~/Images/Database/Campeonatos/" +
                        CampeonatoUserBasePage.CurrentCampeonato.Nome + ".jpg";



                    this.lblNomeCampeonato.Text = CampeonatoUserBasePage.CurrentCampeonato.Nome;
                    this.imgCampeonato.ImageUrl = campeonatoImage;
                    this.imgCampeonato.DescriptionUrl = CampeonatoUserBasePage.CurrentCampeonato.Nome;
                }
            }
        }
        #endregion
    }
}