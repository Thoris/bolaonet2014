using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Framework.UI.Web.Utils
{
    public static class UIHelper
    {
        /// <summary>
        /// Converts selected file to binary array for upload to database.
        /// </summary>
        /// <param name="inputStream"></param>
        /// <returns></returns>
        public static byte[] FileContentsHelper(Stream inputStream)
        {
            BinaryReader binaryReader = new BinaryReader(inputStream);
            byte[] streamContents = binaryReader.ReadBytes((int)inputStream.Length);

            return streamContents;
        }

        /// <summary>
        /// Gets the associated Response.ContentType for the uploaded file.
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        public static string ContentTypeHelper(string extension)
        {
            switch (extension.ToUpper())
            {
                case "PDF":
                    return "application/pdf";
                case "DOC":
                    return "application/msword";
                case "DOCX":
                    goto case "DOC";
                case "XLS":
                    return "application/vnd.ms-excel";
                case "XLSX":
                    goto case "XLS";
                case "PPT":
                    return "application/vnd.ms-powerpoint";
                case "PPTX":
                    goto case "PPT";
                case "PPS":
                    goto case "PPT";
                case "PPSX":
                    goto case "PPT";
                case "PPTM":
                    goto case "PPT";
                case "TIF":
                    return "application";
                default:
                    return "text/html";
            }
        }
        /// <summary>
        /// Generates the object saved alert 
        /// </summary>
        /// <param name="objectName">Name of the object.</param>
        /// <returns></returns>
        public static void RegisterSavedAlertClickScript(Control control, string objectName)
        {
            RegisterAlertClickScript(control, objectName + " saved successfully");
        }

        public static void RegisterAlertClickScript(Control control, string message)
        {

            ScriptManager.RegisterStartupScript(control, control.GetType(), "MessageAlert",
              "<script language=\"JavaScript\">" + Environment.NewLine +
              "alert(\'" + message + "\');" + Environment.NewLine +
              "</script>", false);

        }


        public static void RegisterSavedAlertAndRedirectScript(Control control, string nameOfSavedObject, string redirectUrl)
        {
            string message = nameOfSavedObject + " saved successfully.";
            ScriptManager.RegisterStartupScript(control, control.GetType(), "MessageAlert",
              "<script language=\"JavaScript\">" + Environment.NewLine +
                "alert(\'" + message + "\');" + Environment.NewLine +
                "window.location=\'" + redirectUrl + "\';" + Environment.NewLine +
            "</script>", false);
        }
    }
}
