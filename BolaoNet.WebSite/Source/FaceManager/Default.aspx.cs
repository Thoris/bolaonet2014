using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using Facebook;

namespace BolaoNet.WebSite.Source.FaceManager
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {




            AuthFacebook oAuth = new AuthFacebook();







            CheckAuthorization();

            






            if (Session["token"] == null)
            {
                string url = oAuth.GetAuthorizationLink();
                Response.Redirect(url);
            }
            else
            {
                oAuth.Token = Session["token"].ToString();

                var url = "https://graph.facebook.com/me?access_token=" + oAuth.Token;
                string json = oAuth.Request(AuthFacebook.Method.GET, url, String.Empty);
                //ltrJson.Text = json;
            }
        }

        private void CheckAuthorization()
        {

            AuthFacebook oAuth = new AuthFacebook();
            

            string app_id = oAuth.ApplicationKey;
            string app_secret = oAuth.ApplicationSecret;
            //string scope = "publish_actions";
            //string scope = "email,user_likes,publish_stream,publish_actions";//email,publish_actions,publish_stream,manage_pages";


            string scope = "publish_stream,publish_actions,status_update,manage_pages"; 

            if (Request["code"] == null)
            {
                //scope = "manage_pages";
                Response.Redirect(string.Format(
                    "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                    app_id, Request.Url.AbsoluteUri, scope));
            }
            else
            {
                //scope = "publish_actions";
                Dictionary<string, string> tokens = new Dictionary<string, string>();

                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                    app_id, Request.Url.AbsoluteUri, scope, Request["code"].ToString(), app_secret);
                

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

                object resu = client.Get("me/permissions");

                var postParams = new
                {
                    message = "Na mosca! Acertei em cheio e ganhei 10 pontos.",
                    name = "BolãoNET",
                    caption = "Resultado: Portugal 1 x 0 Grécia<b>Local: Itaquerão<br>Data do Jogo: 21/01/2014 11:00",
                    description = "Minha Aposta: Portugal 1 x 1 Grécia",
                    link = "http://bolaonet.somee.com",
                    picture = "http://bolaonet.somee.com/Images/Database/Times/Portugal.gif"
                   
                };

                //object result = client.Post("/me/feed", postParams);
                  
                object result = client.Post("/me/feed", new { message = "Teste" });
                    //{"time1":"Atlético-GO","time2":"palmeiras","gols1":"2","gols2":"3", 
                    //    {"images":[{"src":"http://images.ig.com.br/placarus/escudos/atletico_goianiense_go.gif", "href":"http://images.ig.com.br/placarus/escudos/atletico_goianiense_go.gif"}, {"src": "http://images.ig.com.br/placarus/escudos/atletico_goianiense_go.gif", "href":"http://images.ig.com.br/placarus/escudos/atletico_goianiense_go.gif"}]},"comentario":"teste"}
                //

                if (result != null)
                {
                }
            }
        }
    }
}