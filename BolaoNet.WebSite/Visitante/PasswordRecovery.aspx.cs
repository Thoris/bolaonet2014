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

namespace BolaoNet.WebSite.Visitante
{
    public partial class PasswordRecovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PasswordRecoveryUser_SendingMail(object sender, MailMessageEventArgs e)
        {
            e.Cancel = true;

            //Buscando os dados do usuário
            Framework.Security.Business.UserDataService user = 
                new Framework.Security.Business.UserDataService(UserBasePage.CurrentUserName);
            user.UserName = this.PasswordRecoveryUser.UserName;
            Framework.Security.Model.UserData userModel = user.LoadUser();
           

            Framework.Security.Util.Mail.Send(e.Message.Body, userModel,  Framework.Security.Util.Mail.Template.ResetPassword);

        }

        protected void PasswordRecoveryUser_VerifyingAnswer(object sender, LoginCancelEventArgs e)
        {

        }

        protected void PasswordRecoveryUser_VerifyingUser(object sender, LoginCancelEventArgs e)
        {
            //e.Cancel = false;

            
        }

        protected void PasswordRecoveryUser_SendMailError(object sender, SendMailErrorEventArgs e)
        {

        }

        protected void PasswordRecoveryUser_UserLookupError(object sender, EventArgs e)
        {

        }

        protected void PasswordRecoveryUser_AnswerLookupError(object sender, EventArgs e)
        {

        }

    }
}
