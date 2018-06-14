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
using System.IO;

namespace BolaoNet.WebSite.Visitante
{
    public partial class ReleaseNotes : System.Web.UI.Page
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadFile(Server.MapPath ("..") + "/ReleaseNotes.txt");
        }
        #endregion

        #region Methods
        private void LoadFile(string file)
        {
            if (!System.IO.File.Exists(file))
                return;


            StreamReader reader = new StreamReader(file);

            string fileString = reader.ReadToEnd();

            fileString = fileString.Replace("\n", "<br/>");

            reader.Close();

            this.lblNotes.Text = fileString;

        }
        #endregion
    }
}
