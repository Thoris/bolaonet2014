using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net;
using System.Web;
using System.Collections.Specialized;
using System.IO;
using Facebook;

namespace BolaoNet.WebSite.Source.FaceManager
{
    public class AuthFacebook
    {
        #region Enumeration/Constants

        public enum Method { GET, POST };
        public const string Authorize = "https://graph.facebook.com/oauth/authorize";
        public const string Access_Token = "https://graph.facebook.com/oauth/access_token";
        public string CallBack_Url = ConfigurationManager.AppSettings["Facebook_CallbackUrl"];

        #endregion

        #region Variables

        private string _applicationKey = "";
        private string _applicationSecret = "";
        private string _token = "";

        #endregion

        #region Properties

        public string ApplicationKey
        {
            get
            {
                if (_applicationKey.Length == 0)
                {
                    _applicationKey = ConfigurationManager.AppSettings["Facebook_aplicationKey"];
                }
                return _applicationKey;
            }
            set { _applicationKey = value; }
        }
        public string ApplicationSecret
        {
            get
            {
                if (_applicationSecret.Length == 0)
                {
                    _applicationSecret = ConfigurationManager.AppSettings["Facebook_aplicationSecret"];
                }
                return _applicationSecret;
            }
            set { _applicationSecret = value; }
        }
        public string Token { get; set; }

        #endregion

        #region Methods


        public string GetAuthorizationLink()
        {
            return string.Format("{0}?client_id={1}&redirect_uri={2}&scope={3}",
                Authorize, ApplicationKey, CallBack_Url, "publish_stream");
        }
        public string GetAuthorizationLinkPopup()
        {
            return string.Format("{0}?client_id={1}&display=popup&redirect_uri={2}&scope={3}",
                Authorize, ApplicationKey, CallBack_Url, "publish_stream");
        }
        public void GetAccessToken(string authToken)
        {
            this.Token = authToken;
            string accessTokenUrl = string.Format("{0}?client_id={1}&redirect_uri={2}&client_secret={3}&code={4}",
            Access_Token, this.ApplicationKey, CallBack_Url, this.ApplicationSecret, authToken);

            string response = Request(Method.GET, accessTokenUrl, String.Empty);

            if (response.Length > 0)
            {
                NameValueCollection qs = HttpUtility.ParseQueryString(response);

                if (qs["access_token"] != null)
                {
                    this.Token = qs["access_token"];
                }
            }
        }
        public string Request(Method method, string url, string postData)
        {
            HttpWebRequest webRequest = null;
            StreamWriter requestWriter = null;
            string responseData = "";

            webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = method.ToString();
            webRequest.ServicePoint.Expect100Continue = false;
            webRequest.UserAgent = "[Seu user agent]";
            webRequest.Timeout = 20000;

            if (method == Method.POST)
            {
                webRequest.ContentType = "application/x-www-form-urlencoded";

                //POST the data.
                requestWriter = new StreamWriter(webRequest.GetRequestStream());

                try
                {
                    requestWriter.Write(postData);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    requestWriter.Close();
                    requestWriter = null;
                }
            }

            responseData = GetWebResponse(webRequest);
            webRequest = null;
            return responseData;
        }
        public string GetWebResponse(HttpWebRequest webRequest)
        {
            StreamReader responseReader = null;
            string responseData = "";

            try
            {
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();
            }
            catch
            {
                throw;
            }
            finally
            {
                webRequest.GetResponse().GetResponseStream().Close();
                responseReader.Close();
                responseReader = null;
            }

            return responseData;
        }

        public string Publish(string code, string uri)
        {
            string scope = "publish_actions";







            Dictionary<string, string> tokens = new Dictionary<string, string>();

            string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                _applicationKey, uri, scope, code, _applicationSecret);

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string vals = reader.ReadToEnd();

                foreach (string token in vals.Split('&'))
                {
                    //meh.aspx?token1=steve&token2=jake&...
                    tokens.Add(token.Substring(0, token.IndexOf("=")),
                        token.Substring(token.IndexOf("=") + 1, token.Length - token.IndexOf("=") - 1));
                }
            }

            string access_token = tokens["access_token"];

            var client = new FacebookClient(access_token);
            //client.AppId = oAuth.ApplicationKey;
            //client.AppSecret = oAuth.ApplicationSecret;



            object result = client.Post("/me/feed", new { message = "Teste" });
            //{"time1":"Atlético-GO","time2":"palmeiras","gols1":"2","gols2":"3", 
            //    {"images":[{"src":"http://images.ig.com.br/placarus/escudos/atletico_goianiense_go.gif", "href":"http://images.ig.com.br/placarus/escudos/atletico_goianiense_go.gif"}, {"src": "http://images.ig.com.br/placarus/escudos/atletico_goianiense_go.gif", "href":"http://images.ig.com.br/placarus/escudos/atletico_goianiense_go.gif"}]},"comentario":"teste"}
            //

            if (result != null)
            {
            }

            return "";
        }


        #endregion
    }
}