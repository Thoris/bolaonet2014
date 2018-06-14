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
    public partial class BolaoControl : System.Web.UI.UserControl
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (BolaoUserBasePage.CurrentBolao != null)
                {
                    string campeonatoImage = "~/Images/Database/Boloes/" +
                        BolaoUserBasePage.CurrentBolao.Nome + ".jpg";

                    //if (System.IO.File.Exists(campeonatoImage))
                    //{
                    //    campeonatoImage = "~/Images/Database/Campeonatos/" +
                    //        "noimage.jpg";
                    //}

                    this.lblNomeBolao.Text = BolaoUserBasePage.CurrentBolao.Nome;
                    this.imgBolao.ImageUrl = campeonatoImage;
                    this.imgBolao.DescriptionUrl = BolaoUserBasePage.CurrentBolao.Nome;




                    Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(
                        UserBasePage.CurrentUserName, BolaoUserBasePage.CurrentBolao.Nome);

                    this.mnuBolaoAux.Visible = !business.IsUserInBolao(
                        new Framework.Security.Model.UserData(UserBasePage.CurrentUserName));
                }
            }
        }
        #endregion

        protected void mnuBolaoAux_MenuItemClick(object sender, MenuEventArgs e)
        {
            switch (e.Item.Value.ToLower())
            {
                case "participar":

                    Response.Redirect("~/Apostas/BolaoParticipacao.aspx");


                    break;
            }
        }
    }
}