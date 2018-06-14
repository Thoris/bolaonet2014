using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Net;

namespace Framework.Security.Util
{
    public class Mail
    {
        #region Constants/Enumeration
        public enum Template
        {
            Activation = 0,
            Welcome = 1,
            ResetPassword = 2,
            ApostasBolao = 3,
            ApostasRestantes = 4,
            PagamentosRestantes = 5,
        }

        public const string PageActivation = @"Activation.htm";
        public const string PageWelcome = @"Welcome.htm";
        public const string PageResetPassword = @"ResetPassword.htm";
        public const string PageApostasBolao = @"ApostasBolao.htm";
        public const string PageApostasRestantes = @"ApostasRestantes.htm";
        public const string PagePagamentosRestantes = @"PagamentosRestantes.htm";

        //public const string TagUrl = "http://localhost/BolaoNet/";
        //public const string TagActivationPage = "Visitante/ConfirmLogin.aspx";
        //public const string TagSignature = "Administrador do Bolão Net";
        #endregion

        #region Variables
        private static DateTime _lastEmailSent = DateTime.MinValue;
        private static object lockObject = new object();
        #endregion

        #region Constructors/Destructors
        public Mail()
        {

        }
        #endregion

        #region Methods
        public static bool SendToUsers(List<string> users, Template template, params string[] attachmentFiles)
        {

            SmtpClient client = new SmtpClient();


            System.Web.Mail.MailMessage message = new System.Web.Mail.MailMessage();
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "smtp.gmail.com");
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465");
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
            //sendusing: cdoSendUsingPort, value 2, for sending the message using         
            //the network.        
            //smtpauthenticate: Specifies the mechanism used when authenticating         
            //to an SMTP        
            //service over the network. Possible values are:        
            //- cdoAnonymous, value 0. Do not authenticate.        
            //- cdoBasic, value 1. Use basic clear-text authentication.        
            //When using this option you have to provide the user name and password         
            //through the sendusername and sendpassword fields.        
            //- cdoNTLM, value 2. The current process security context is used to         
            // authenticate with the service.        
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            //Use 0 for anonymous        
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "thorisangelo@gmail.com");
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "angelo");
            message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
            message.From = "thorisangelo@gmail.com";

            string toUsers = "";
            foreach (string user in users)
                toUsers += user + ";";


            message.Bcc = "thorisangelo@hotmail.com";

            message.To = toUsers;
            //message.Subject = "teste";
            message.BodyFormat = System.Web.Mail.MailFormat.Html;
            //message.Body = "BODY";
            //if ("".Trim() != "")
            //{
            //    MailAttachment MyAttachment = new MailAttachment(pAttachmentPath);
            //    myMail.Attachments.Add(MyAttachment);
            //    myMail.Priority = System.Web.Mail.MailPriority.High;
            //}


            if (attachmentFiles != null && attachmentFiles.Length > 0)
            {
                for (int c = 0; c < attachmentFiles.Length; c++)
                {
                    System.Web.Mail.MailAttachment attach = new System.Web.Mail.MailAttachment(attachmentFiles[c]);
                    message.Attachments.Add(attach);


                    //message.Attachments.Add(new System.Web.Mail.MailAttachment(attachmentFiles[c]));

                }
            }












            //message.To.Add(user.Email);


            switch (template)
            {
                case Template.Welcome:
                    message.Subject = "Welcome";
                    break;
                case Template.Activation:
                    message.Subject = "Activation";
                    break;
                case Template.ResetPassword:
                    message.Subject = "Reset Password";
                    break;
                case Template.ApostasBolao:
                    message.Subject = "Apostas dos Usuários";
                    break;
                case Template.ApostasRestantes:
                    message.Subject = "Apostas restantes";
                    break;
                case Template.PagamentosRestantes:
                    message.Subject = "Pagamento não efetuado";
                    break;

            }//end switch

            //message.IsBodyHtml = true;
            message.Body = LoadTemplates(template);
            message.Body = SetVariables(new Framework.Security.Model.UserData (), message.Body);


            string sslValue = System.Configuration.ConfigurationManager.AppSettings["MailEnableSSL"];

            if (!string.IsNullOrEmpty(sslValue))
            {
                try
                {
                    bool ssl = Convert.ToBoolean(sslValue);
                    client.EnableSsl = ssl;
                }
                catch
                {
                }
            }










            System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com:465";
            System.Web.Mail.SmtpMail.Send(message);



















            //client.Send(message);


            return true;
        }

        public static bool Send(Framework.Security.Model.UserData user, Template template, params string[] attachmentFiles)
        {
            return Send(null, user, template, attachmentFiles);
        }

        public static bool Send(string messageBody, Framework.Security.Model.UserData user, Template template, params string[] attachmentFiles)
        {

            string sslValue = System.Configuration.ConfigurationManager.AppSettings["MailEnableSSL"];
            string smtp = System.Configuration.ConfigurationManager.AppSettings["MailSmtp"];
            string port = System.Configuration.ConfigurationManager.AppSettings["MailPort"];
            string from = System.Configuration.ConfigurationManager.AppSettings["MailFrom"];
            string senderType = System.Configuration.ConfigurationManager.AppSettings["MailSenderType"];
            string password = System.Configuration.ConfigurationManager.AppSettings["MailPassword"];


            int waitTime = 20;
            

            if (waitTime < 0)
                waitTime = 0;

            SmtpClient client = null;

            if (!string.IsNullOrEmpty (port) != null)
            {
                int portValue = int.Parse(port);

                client = new SmtpClient(smtp, portValue);
            }
            else
            {
                client = new SmtpClient(smtp);
            }

            client.EnableSsl = bool.Parse(sslValue);


            if (!string.IsNullOrEmpty(password))
            {
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(from, password);

                client.Credentials = credentials;
            }

            MailAddress fromMail = new MailAddress(from);

            string[] emails = user.Email.Split(';');


            //Only allow sending by 1 thread at a time
            //This will throttle how many messages can be sent within
            //a certain amount of time by setting a static variable which
            //holds the time the last email was sent.
            lock (lockObject)
            {
                while (_lastEmailSent.AddMilliseconds(waitTime) > DateTime.Now)
                {
                    System.Threading.Thread.Sleep(waitTime);
                }

                _lastEmailSent = DateTime.Now;

                for (int i = 0; i < emails.Length; i++)
                {
                    MailAddress to = new MailAddress(emails[i]);

                    // Specify the message content.
                    using (MailMessage message = new MailMessage(fromMail, to))
                    {

                        if (attachmentFiles != null && attachmentFiles.Length > 0)
                        {
                            for (int c = 0; c < attachmentFiles.Length; c++)                            
                                message.Attachments.Add(new Attachment(attachmentFiles[c]));                       
                        }

                        switch (template)
                        {
                            case Template.Welcome:
                                message.Subject = "Welcome";
                                break;
                            case Template.Activation:
                                message.Subject = "Activation";
                                break;
                            case Template.ResetPassword:
                                message.Subject = "Reset Password";
                                break;
                            case Template.ApostasBolao:
                                message.Subject = "Apostas dos Usuários";
                                break;
                            case Template.ApostasRestantes:
                                message.Subject = "Apostas restantes";
                                break;
                            case Template.PagamentosRestantes:
                                message.Subject = "Pagamento não efetuado";
                                break;
                        }//end switch

                        message.Body = LoadTemplates(template);
                        message.Body = SetVariables(user, messageBody, message.Body);
                        message.IsBodyHtml = true;
            
                        client.Send(message);
                    }
                }
            }


            return true;
        }
        private static string SetVariables(Model.UserData user, string file)
        {
            return SetVariables(user, "", file);
        }
        
        private static string SetVariables(Model.UserData user, string messageBody, string file)
        {
            string result = file;

            result = result.Replace("[%NOME%]", user.FullName);            
            result = result.Replace("[%URL%]", ConfigurationManager.AppSettings["MailTagUrl"]);
            result = result.Replace("[%USER%]", user.UserName);
            result = result.Replace("[%PASSWORD%]", user.Password);
            result = result.Replace("[%URLACTIVATION%]",
                ConfigurationManager.AppSettings["MailTagUrl"] + ConfigurationManager.AppSettings["MailTagActivationPage"]);
            result = result.Replace("[%ACTIVATIONKEY%]", user.ActivateKey);
            result = result.Replace("[%SIGNATURE%]", ConfigurationManager.AppSettings["MailTagSignature"]);

            if (!string.IsNullOrEmpty (messageBody))
                result = result.Replace("[%MESSAGEBODY%]", messageBody.Replace ("\n", "<br/>"));

            return result;
        }
        private static string LoadTemplates(Template template)
        {
            string templateFile = "";

            switch (template)
            {
                case Template.Activation:
                    templateFile =LoadFile(PageActivation);
                    break;
                case Template.Welcome:
                    templateFile = LoadFile(PageWelcome);
                    break;

                case Template.ResetPassword:
                    templateFile = LoadFile(PageResetPassword);
                    break;

                case Template.ApostasBolao:
                    templateFile = LoadFile(PageApostasBolao);
                    break;

                case Template.ApostasRestantes:
                    templateFile = LoadFile(PageApostasRestantes);
                    break;

                case Template.PagamentosRestantes:
                    templateFile = LoadFile(PagePagamentosRestantes);
                    break;

            }

            return templateFile; 
        }
        private static string LoadFile(string htmlFile)
        {
            string file = null;


            string templatePath = System.Configuration.ConfigurationManager.AppSettings["TemplatesPath"];

            templatePath = System.IO.Path.Combine(
                System.Web.HttpContext.Current.Request.PhysicalApplicationPath + templatePath, htmlFile);

            System.IO.StreamReader reader = new System.IO.StreamReader(templatePath);

            file = reader.ReadToEnd();

            reader.Close();

            return file;
        }

        #endregion
    }
}
