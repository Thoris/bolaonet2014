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

namespace BolaoNet.WebSite.Boloes
{
    public partial class DownloadApostas : BolaoUserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["UserName"] != null &&
                    Request.QueryString["Bolao"] != null)
                {
                    WritePDF(Request.QueryString["Bolao"].ToString(), Request.QueryString["UserName"].ToString());
                    
                }//endif user e bolao
            }
        }
        #endregion

        #region Methods
        private void WritePDF(string bolao, string userName)
        {
            Business.Boloes.Support.Bolao bolaoModel= new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, bolao);
            Framework.Security.Model.UserData userModel = new Framework.Security.Model.UserData( userName);



            //Response.BinaryWrite(doc.DocContents);
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "inline; filename=ParProcess.pdf;");
            //Response.AppendHeader("content-disposition", "attachment; filename=item.pdf" );


            Business.PDF.Support.CopaMundoPdfCreator pdfCreator = new BolaoNet.Business.PDF.Support.CopaMundoPdfCreator(base.UserName);
            pdfCreator.CreateApostasUser(Response.OutputStream, 
                System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Images\\Database", bolaoModel, userModel);            
            Response.End();
        }
        #endregion
    }
}
