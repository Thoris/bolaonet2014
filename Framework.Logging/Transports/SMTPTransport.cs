using System;
using System.IO;
using System.Globalization;
using System.Net.Mail;
using Framework.Logging.Logger;
using Framework.Logging.Logger.Settings;
using System.Net;

namespace Framework.Logging.Logger.Transports
{
    /// <summary>
    /// Summary description for LogFileTransport.
    /// </summary>
    internal class SMTPTransport : LoggerTransport
    {
        #region Constants
        private const string WAIT_TIME_KEY = "waittime"; //MILLISECONDS
        private const string SMTP_SERVER_KEY = "smtpserver";
        private const string SMTP_FROM_EMAIL_KEY = "smtpfromemail";
        private const string SMTP_TO_EMAILS_KEY = "smtptoemails";
        private const string EMAIL_SUBJECT_KEY = "emailsubject";
        private const string SSL_ENABLED = "SslEnabled";
        private const string SMTP_PORT = "smtpport";
        private const string SMTP_PASSWORD = "smtppassword";
        private const int MAX_BODY_LENGTH = 8192;
        private const int MAX_SUBJECT_LENGTH = 256;
        #endregion

        #region Variables
        private static DateTime _lastEmailSent = DateTime.MinValue;
        private static object lockObject = new object();
        #endregion

        #region Constructors/Destructors
        /// <summary>
        /// Sends an Email Using Configratuion information 
        /// defined in the KeyContactListSettings config.
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="emailSubject"></param>
        /// <param name="emailBody"></param>
        public SMTPTransport() { }
        #endregion

        #region Methods
        public override void WriteLog(LogRecord record, TransportSettings settings)
        {
            if (!settings.Configs.ContainsKey(WAIT_TIME_KEY) || string.IsNullOrEmpty(settings.Configs[WAIT_TIME_KEY].ToString()))
                throw new LoggerException(string.Format(CultureInfo.CurrentCulture, ResourceData.ConfigurationKeyDoesNotExist, WAIT_TIME_KEY));

            int waitTime = 0;
            int.TryParse(settings.Configs[WAIT_TIME_KEY].ToString(), out waitTime);

            if (waitTime < 0)
                waitTime = 0;

            if (!settings.Configs.ContainsKey(SMTP_SERVER_KEY) || string.IsNullOrEmpty(settings.Configs[SMTP_SERVER_KEY].ToString()))
                throw new LoggerException(string.Format(CultureInfo.CurrentCulture, ResourceData.ConfigurationKeyDoesNotExist, SMTP_SERVER_KEY));

            string smtpServer = settings.Configs[SMTP_SERVER_KEY].ToString();

            if (!settings.Configs.ContainsKey(SMTP_FROM_EMAIL_KEY) || string.IsNullOrEmpty(settings.Configs[SMTP_FROM_EMAIL_KEY].ToString()))
                throw new LoggerException(string.Format(CultureInfo.CurrentCulture, ResourceData.ConfigurationKeyDoesNotExist, SMTP_FROM_EMAIL_KEY));

            string smtpFromEmail = settings.Configs[SMTP_FROM_EMAIL_KEY].ToString();

            if (!settings.Configs.ContainsKey(SMTP_TO_EMAILS_KEY) || string.IsNullOrEmpty(settings.Configs[SMTP_TO_EMAILS_KEY].ToString()))
                throw new LoggerException(string.Format(CultureInfo.CurrentCulture, ResourceData.ConfigurationKeyDoesNotExist, SMTP_TO_EMAILS_KEY));

            string smtpToEmails = settings.Configs[SMTP_TO_EMAILS_KEY].ToString();

            string[] emails = smtpToEmails.Split(';');

            if (!settings.Configs.ContainsKey(EMAIL_SUBJECT_KEY) || string.IsNullOrEmpty(settings.Configs[EMAIL_SUBJECT_KEY].ToString()))
                throw new LoggerException(string.Format(CultureInfo.CurrentCulture, ResourceData.ConfigurationKeyDoesNotExist, EMAIL_SUBJECT_KEY));

            string emailSubject = GetSubject(settings.Configs[EMAIL_SUBJECT_KEY].ToString(), record);
            string emailBody = GetBody(record);

            bool sslEnabled = bool.Parse(settings.Configs[SSL_ENABLED].ToString());


            SmtpClient client = null;

            if (settings.Configs[SMTP_PORT] != null)
            {
                int port = int.Parse(settings.Configs[SMTP_PORT].ToString());

                client = new SmtpClient(smtpServer, port);
            }
            else
            {
                client = new SmtpClient(smtpServer);
            }

            client.EnableSsl = sslEnabled;


            if (settings.Configs[SMTP_PASSWORD] != null)
            {
                string password = settings.Configs[SMTP_PASSWORD].ToString();
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(smtpFromEmail, password);

                client.Credentials = credentials;
            }



            MailAddress from = new MailAddress(smtpFromEmail);



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
                    using (MailMessage message = new MailMessage(from, to))
                    {
                        message.Body = emailBody;
                        message.Subject = emailSubject;
                        message.BodyEncoding = System.Text.Encoding.UTF8;
                        client.Send(message);
                    }
                }
            }
        }

        private string GetSubject(string subject, LogRecord record)
        {
            string temp = string.Format(subject, LogLevelToString(record.LogLevel));

            if (temp.Length > MAX_SUBJECT_LENGTH)
            {
                return temp.Substring(0, MAX_SUBJECT_LENGTH);
            }
            else
            {
                return temp;
            }
        }

        private string LogLevelToString(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.LogLevelDebug:
                    return "Debug";
                case LogLevel.LogLevelError:
                    return "Error";
                case LogLevel.LogLevelFailureAudit:
                    return "Failure Audit";
                case LogLevel.LogLevelInformation:
                    return "Information";
                case LogLevel.LogLevelSuccessAudit:
                    return "Success Audit";
                case LogLevel.LogLevelTrace:
                    return "Trace";
                case LogLevel.LogLevelWarning:
                    return "Warning";
                default:
                    return "Unknown";
            }

        }

        private string GetBody(LogRecord record)
        {
            string body = record.Description + "\r\n\r\n" + record.Content;

            if (body.Length > MAX_BODY_LENGTH)
            {
                return body.Substring(0, MAX_BODY_LENGTH);
            }
            else
            {
                return body;
            }
        }
        #endregion

    }


}
