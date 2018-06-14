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

namespace BolaoNet.WebSite.Campeonatos
{
    public partial class CampeonatoJogos : CampeonatoUserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hlkDownload.NavigateUrl = "~/Campeonatos/DownloadJogos.aspx?NomeCampeonato=" + CurrentCampeonato.Nome;
            }
        }
        #endregion

        #region Events
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }
        #endregion
    }
}
