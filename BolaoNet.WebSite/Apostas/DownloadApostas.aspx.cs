using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BolaoNet.WebSite.Apostas
{
    public partial class DownloadApostas : ApostaBolaoBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                    WritePDF (base.BaseCurrentBolao.Nome, base.UserName);

            }
        }
        #endregion

        #region Methods
        private void WritePDF(string bolao, string userName)
        {
            Business.Boloes.Support.Bolao bolaoModel = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, bolao);
            Framework.Security.Model.UserData userModel = new Framework.Security.Model.UserData(userName);



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