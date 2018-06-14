using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BolaoNet.WebSite.Campeonatos
{
    public partial class DownloadJogos : CampeonatoUserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["NomeCampeonato"] != null)
                {
                    WritePDF(Request.QueryString["NomeCampeonato"].ToString());

                }//endif user e bolao
            }
        }
        #endregion

        #region Methods
        private void WritePDF(string nome)
        {
            Business.Campeonatos.Support.Campeonato campeonatoModel = new BolaoNet.Business.Campeonatos.Support.Campeonato(base.UserName, nome);
            
            //Response.BinaryWrite(doc.DocContents);
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "inline; filename=ParProcess.pdf;");
            //Response.AppendHeader("content-disposition", "attachment; filename=item.pdf" );


            Business.PDF.Support.CopaMundoPdfCreator pdfCreator = new BolaoNet.Business.PDF.Support.CopaMundoPdfCreator(base.UserName);
            pdfCreator.CreateJogos(Response.OutputStream,
                System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Images\\Database", campeonatoModel);
            Response.End();
        }
        #endregion
    }
}