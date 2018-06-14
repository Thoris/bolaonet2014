using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

namespace BolaoNet.WebSite.Source.FaceManager
{
    public class PostToWall
    {

        #region Properties
        public string Message = "";
        public string AccessToken = "";
        public string ArticleTitle = "";
        public string FacebookProfileID = "";
        public string ErrorMessage { get; private set; }
        public string PostID { get; private set; }
        #endregion

        #region methods
        /// <summary>
        /// Perform the post
        /// </summary>
        public void Post()
        {
            if (string.IsNullOrEmpty(this.Message)) return;

            // Append the user's access token to the URL
            var url = "https://graph.facebook.com/me/feed?access_token=" + this.AccessToken;

            // The POST body is just a collection of key=value pairs, the same way a URL GET string might be formatted

            var parameters = string.Format ("name={0}&link={1}&caption={2}&description={3}&source={4}&actions={5}&privacy={6}&message={7}",
                "name",               
                "http://link.com",
                "a test caption",
                "a test description",
                "http://blackballsoftware.com/images/whitetheme/headerwhite.png",
                "{\"name\": \"View on Rate-It\", \"link\": \"http://www.rate-it.co.nz\"}",
                "{\"value\": \"EVERYONE\"}",
                this.Message);

            // Mark this request as a POST, and write the parameters to the method body (as opposed to the query string for a GET)
            var webRequest = WebRequest.Create(url);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(parameters);
            webRequest.ContentLength = bytes.Length;
            System.IO.Stream os = webRequest.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            os.Close();
            
            // Send the request to Facebook, and query the result to get the confirmation code
            try
            {
                var webResponse = webRequest.GetResponse();
                StreamReader sr = null;
                try
                {
                    sr = new StreamReader(webResponse.GetResponseStream());
                    this.PostID = sr.ReadToEnd();
                }
                finally
                {
                    if (sr != null) sr.Close();
                }
            }
            catch (WebException ex)
            {
                // To help with debugging, we grab the exception stream to get full error details
                StreamReader errorStream = null;
                try
                {
                    errorStream = new StreamReader(ex.Response.GetResponseStream());
                    this.ErrorMessage = errorStream.ReadToEnd();
                }
                finally
                {
                    if (errorStream != null) errorStream.Close();
                }
            }
        }
        #endregion
    }
}