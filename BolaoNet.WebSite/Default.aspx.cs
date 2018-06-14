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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Business.Campeonatos.Jogo jogo = new BolaoNet.Business.Campeonatos.Jogo("Thoris");
            //jogo.InsertCampeonatoCopaMundo2010("Copa do Mundo 2010");

            //Framework.Security.Model.UserData user = new Framework.Security.Model.UserData("th");
            //user.Email = "thorisangelo@gmail.com";
            //Framework.Security.Util.Mail.Send(user, Framework.Security.Util.Mail.Template.Activation);


           //Framework.Logging.Logger.LogManager.WriteError("thoris", "Teste", new Exception("ERRO"));


            if (this.Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Users/Home.aspx");
            }
        }
    }
}
