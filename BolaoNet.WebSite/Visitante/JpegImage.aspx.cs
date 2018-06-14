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

using System.Drawing;
using System.Drawing.Imaging;


namespace BolaoNet.WebSite.Visitante
{
    public partial class JpegImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Cria uma imagem CAPTCHA usando o texto armazenado na sessão

            string codigo = "";


            if (!IsPostBack || Session["CaptchaImageText"] == null)
            {
                Framework.Security.Util.Captcha c2 = new Framework.Security.Util.Captcha("", 1, 1);
                //Session["CaptchaImageText"] = c2.GerarStringRandomica(4);


                codigo = c2.GerarStringRandomica(4);
                Session["CaptchaImageText"] = codigo;
            }

            Framework.Security.Util.Captcha ci = new Framework.Security.Util.Captcha(
                this.Session["CaptchaImageText"].ToString(),
                200, 50, "Macoratti.net");


            // altera a resposta do header para a saida de imagem JPEG
            this.Response.Clear();
            this.Response.ContentType = "image/jpeg";


            // Escreve a imagem no stream de resposta no formato JPEG
            ci.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);


            // libera o objeto imagem CAPTCHA.
            ci.Dispose();
        }
    }
}
