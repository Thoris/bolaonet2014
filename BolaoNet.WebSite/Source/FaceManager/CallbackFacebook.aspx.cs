﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BolaoNet.WebSite.Source.FaceManager
{
    public partial class CallbackFacebook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = "";
            AuthFacebook oAuth = new AuthFacebook();
            //oAuth.CallBack_Url = "http://localhost:1789/CallbackFacebook.aspx";

            if (Request["code"] == null)
            {
                Response.Redirect(oAuth.GetAuthorizationLink());
            }
            else
            {
                oAuth.GetAccessToken(Request["code"]);

                if (oAuth.Token.Length > 0)
                {
                    Session["token"] = oAuth.Token;


                    var post = new PostToWall();
                    post.Message = "Test message from Thoris";
                    post.ArticleTitle = "A new rating has been posted";
                    post.AccessToken = Session["token"].ToString();
                    post.Post();
                    Response.Write("The Facebook post successed with ID: " + post.PostID);
                    Response.Write("<br/>");
                    Response.Write("The error message was: " + post.ErrorMessage);

                    //oAuth.PublicarMensagem(Session["token"].ToString ());

                    Response.Redirect("~/Default.aspx");
                }
            }
        }
    }
}