using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Collections.Generic;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using Framework.Security.Model;


namespace BolaoNet.WebSite.Boloes.Admin
{
    public partial class BolaoIniciarParar : BolaoUserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Framework.Security.Business.UserManagerService business = new Framework.Security.Business.UserManagerService();
                //ViewState["Users"] = business.LoadAllUsers();

                Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);
                IList<Framework.DataServices.Model.EntityBaseData> list = business.LoadApostasRestantes();


                ViewState["Users"] = list;

            }

            ShowStatusPDFFile();
            ShowStatusPDFFileFim();
            BindUsers();
            ShowBolaoData();
        }
        #endregion

        #region Methods
        private void ShowBolaoData()
        {
            Business.Boloes.Support.Bolao bolao = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);
            bolao.Load();


            this.lblStatus.Text = bolao.IsIniciado ? "Iniciado" : "Aguardando Início";
            this.lblIniciadoPor.Text = bolao.IniciadoBy;

            if (bolao.DataIniciado != DateTime.MinValue)
                this.lblDataInicio.Text = bolao.DataIniciado.ToString("dd/MM/yyyy HH:mm:ss");
            else
                this.lblDataInicio.Text = "-";


            if (bolao.IsIniciado)
            {
                this.btnIniciar.Enabled = false;
                this.btnVoltar.Enabled = true;
            }
            else
            {

                this.btnIniciar.Enabled = true;
                this.btnVoltar.Enabled = false;
            }

        }
        private void BindUsers()
        {
            if (ViewState["Users"] == null)
            {
                this.grdUsers.DataSource = null;
                this.grdUsers.DataBind();
            }
            else
            {
                this.grdUsers.DataSource = ViewState["Users"];
                this.grdUsers.DataBind();
           
            }
        }
        private void ShowStatusPDFFile()
        {

            string filePDF = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Images\\Database\\PDF\\" + CurrentBolao.Nome + ".pdf";
            string fileZIP = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Images\\Database\\PDF\\" + CurrentBolao.Nome + ".zip";

            #region PDF Files
            if (System.IO.File.Exists(filePDF))
            {
                this.lnkDownloadBolaoPDF.Visible = true;

                FileInfo fileInfo = new FileInfo(filePDF);
                this.lnkDownloadBolaoPDF.Text = "PDF: " + fileInfo.LastWriteTime.ToString("dd/MM/yy HH:mm:ss") +
                    " - Tam.: " + ((double)((double)fileInfo.Length / (double)1024) / (double)1024).ToString("0.00") + " MBytes";
            }
            else
            {
                this.lnkDownloadBolaoPDF.Visible = false;
            }
            #endregion

            #region ZIP files
            if (System.IO.File.Exists(fileZIP))
            {
                this.lnkDownloadBolaoZIP.Visible = true;

                FileInfo fileInfo = new FileInfo(fileZIP);
                this.lnkDownloadBolaoZIP.Text = "ZIP: " + fileInfo.LastWriteTime.ToString("dd/MM/yy HH:mm:ss") +
                    " - Tam.: " + ((double)((double)fileInfo.Length / (double)1024) / (double)1024).ToString("0.00") + " MBytes";

                this.btnEnviarEmails.Enabled = true;
            }
            else
            {

                this.lnkDownloadBolaoZIP.Visible = false;

                this.btnEnviarEmails.Enabled = false;
            }
            #endregion

        }
        private void ShowStatusPDFFileFim()
        {

            string filePDF = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Images\\Database\\PDF\\" + CurrentBolao.Nome + "fim.pdf";
            string fileZIP = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Images\\Database\\PDF\\" + CurrentBolao.Nome + "fim.zip";

            #region PDF Files
            if (System.IO.File.Exists(filePDF))
            {
                this.lnkDownloadBolaoPDFFim.Visible = true;

                FileInfo fileInfo = new FileInfo(filePDF);
                this.lnkDownloadBolaoPDFFim.Text = "PDF: " + fileInfo.LastWriteTime.ToString("dd/MM/yy HH:mm:ss") +
                    " - Tam.: " + ((double)((double)fileInfo.Length / (double)1024) / (double)1024).ToString("0.00") + " MBytes";
            }
            else
            {
                this.lnkDownloadBolaoPDFFim.Visible = false;
            }
            #endregion

            #region ZIP files
            if (System.IO.File.Exists(fileZIP))
            {
                this.lnkDownloadBolaoZIPFim.Visible = true;

                FileInfo fileInfo = new FileInfo(fileZIP);
                this.lnkDownloadBolaoZIPFim.Text = "ZIP: " + fileInfo.LastWriteTime.ToString("dd/MM/yy HH:mm:ss") +
                    " - Tam.: " + ((double)((double)fileInfo.Length / (double)1024) / (double)1024).ToString("0.00") + " MBytes";

                //this.btnEnviarEmails.Enabled = true;
            }
            else
            {

                this.lnkDownloadBolaoZIPFim.Visible = false;

                //this.btnEnviarEmails.Enabled = false;
            }
            #endregion

        }
        #endregion

        #region Events
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            this.ctlMenuTools.ButtonClick += new CommandEventHandler(ctlMenuTools_ButtonClick);
            this.ctlNavigateHomeControl.ButtonClick += new CommandEventHandler(ctlNavigateHomeControl_ButtonClick);

        }
        private void ctlNavigateHomeControl_ButtonClick(object sender, CommandEventArgs e)
        {
            base.NavigateHome();
        }
        private void ctlMenuTools_ButtonClick(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case WebSite.Controls.MenuManager.MenuTools.Save:
                    //Save();
                    break;

                default:
                    break;
            }
        }
        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);
            business.IniciadoBy = base.UserName;
            if (business.Iniciar())
            {
                base.ShowMessages("Bolão iniciado com sucesso.");
            }
            else
            {
                base.ShowErrors("Erro ao iniciar o bolão.");
            }

            business.Load();
            CurrentBolao = (Model.Boloes.Bolao)business;


            ShowBolaoData();
        }
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);
            if (business.Aguardar())
            {
                base.ShowMessages("Alterado o status do bolão com sucesso.");
            }
            else
            {
                base.ShowErrors("Erro ao mudar o status do bolão.");
            }


            business.Load();
            CurrentBolao = (Model.Boloes.Bolao)business;

            ShowBolaoData();
        }
        protected void grdUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            IList<Framework.DataServices.Model.EntityBaseData> list = (IList<Framework.DataServices.Model.EntityBaseData>)ViewState["Users"];

            
            Business.Boloes.Support.Bolao bolao = new Business.Boloes.Support.Bolao(CurrentUserName, base.BaseCurrentBolao.Nome);

            UserData user = new UserData(this.grdUsers.Rows[e.RowIndex].Cells[0].Text);


            bool result = bolao.DeleteMembro (user);

            list.RemoveAt(e.RowIndex);



            BindUsers();
        }
        protected void btnInserir_Click(object sender, EventArgs e)
        {
            IList<Framework.DataServices.Model.EntityBaseData> list = (IList<Framework.DataServices.Model.EntityBaseData>)ViewState["Users"];


            Model.Boloes.ApostasRestantesUser user = new Model.Boloes.ApostasRestantesUser();
            user.Email = this.txtEmail.Text;
            user.FullName = this.txtUserName.Text;

            list.Add(user);

            ViewState["Users"] = list;

            BindUsers();



        }
        protected void btnEnviarEmails_Click(object sender, EventArgs e)
        {
            List<string> emails = new List<string>();

            IList<Framework.DataServices.Model.EntityBaseData> list = (IList<Framework.DataServices.Model.EntityBaseData>)ViewState["Users"];

            foreach (Model.Boloes.ApostasRestantesUser user in list)
            {
                if (!emails.Contains(user.Email))
                    emails.Add(user.Email);

            }//end foreach

            string file = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Images\\Database\\PDF\\" + CurrentBolao.Nome + ".zip";


            if (Framework.Security.Util.Mail.SendToUsers(emails, Framework.Security.Util.Mail.Template.ApostasBolao, file))
                base.ShowMessages("Emails enviados com sucesso.");
            else
                base.ShowErrors("Erro ao enviar emails.");





        }
        protected void btnGerarApostas_Click(object sender, EventArgs e)
        {
            List<Framework.Security.Model.UserData> users = new List<Framework.Security.Model.UserData>();

            IList<Framework.DataServices.Model.EntityBaseData> list = (IList<Framework.DataServices.Model.EntityBaseData>)ViewState["Users"];

            foreach (Model.Boloes.ApostasRestantesUser user in list)
            {
                if (!string.IsNullOrEmpty(user.UserName))
                    users.Add(user);
            }

            #region Criando o pdf
            string file = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Images\\Database\\PDF\\" + CurrentBolao.Nome + ".pdf";

            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);

            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                Business.PDF.Support.CopaMundoPdfCreator pdf = new BolaoNet.Business.PDF.Support.CopaMundoPdfCreator(base.UserName);
                pdf.CreateApostasUsers(fs,
                    System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Images\\Database",
                    CurrentBolao,
                    users);
            }
            #endregion

            #region Criando o ZIP

            // Zip up the files - From SharpZipLib Demo Code
            using (ZipOutputStream s = new ZipOutputStream(File.Create(file.Replace (".pdf", ".zip"))))
            {
                s.SetLevel(9); // 0-9, 9 being the highest compression

                byte[] buffer = new byte[4096];


                ZipEntry entry = new ZipEntry(Path.GetFileName(file));

                entry.DateTime = DateTime.Now;
                s.PutNextEntry(entry);

                using (FileStream fs = File.OpenRead(file))
                {
                    int sourceBytes;
                    do
                    {
                        sourceBytes = fs.Read(buffer, 0, buffer.Length);

                        s.Write(buffer, 0, sourceBytes);

                    } while (sourceBytes > 0);
                }
           
                s.Finish();
                s.Close();
            }

            #endregion


            ShowStatusPDFFile();

        }
        protected void grdUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            HyperLink lnkDownload = (HyperLink)e.Row.FindControl("lnkDownload");


            Model.Boloes.ApostasRestantesUser  user = (Model.Boloes.ApostasRestantesUser )e.Row.DataItem;

            lnkDownload.NavigateUrl = "~/Boloes/DownloadApostas.aspx?Bolao=" + CurrentBolao.Nome + "&UserName=" + user.UserName;

            if (string.IsNullOrEmpty(user.UserName))
                lnkDownload.Visible = false;


            if (!user.IsPago)
            {
                e.Row.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                if (user.ApostasRestantes > 0)
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
            }



        }
        protected void lnkDownloadBolaoZIP_Click(object sender, EventArgs e)
        {
            string file = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Images\\Database\\PDF\\" + CurrentBolao.Nome + ".zip";


            FileInfo arquivo = new FileInfo(file);


            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment; filename=" + CurrentBolao.Nome + ".zip");

            Response.WriteFile(file);
        }
        protected void lnkDownloadBolaoPDF_Click(object sender, EventArgs e)
        {
            string file = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Images\\Database\\PDF\\" + CurrentBolao.Nome + ".pdf";


            FileInfo arquivo = new FileInfo(file);


            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment; filename=" + CurrentBolao.Nome + ".pdf");

            Response.WriteFile(file);
        }
        protected void btnEnviarPagamentos_Click(object sender, EventArgs e)
        {
            List<string> emails = new List<string>();

            IList<Framework.DataServices.Model.EntityBaseData> list = (IList<Framework.DataServices.Model.EntityBaseData>)ViewState["Users"];

            foreach (Model.Boloes.ApostasRestantesUser user in list)
            {
                if (!user.IsPago)
                {
                    if (!emails.Contains(user.Email))
                    {
                        emails.Add(user.Email);
                    }
                }
            }//end foreach

            if (Framework.Security.Util.Mail.SendToUsers(emails, Framework.Security.Util.Mail.Template.PagamentosRestantes))
                base.ShowMessages("Emails enviados com sucesso.");
            else
                base.ShowErrors("Erro ao enviar emails.");

        }
        protected void btnEnviarApostasNaoFeitas_Click(object sender, EventArgs e)
        {
            List<string> emails = new List<string>();

            IList<Framework.DataServices.Model.EntityBaseData> list = (IList<Framework.DataServices.Model.EntityBaseData>)ViewState["Users"];

            foreach (Model.Boloes.ApostasRestantesUser user in list)
            {
                if (user.ApostasRestantes > 0)
                {
                    if (!emails.Contains(user.Email))
                    {
                        emails.Add(user.Email);
                    }
                }
            }//end foreach

            if (Framework.Security.Util.Mail.SendToUsers(emails, Framework.Security.Util.Mail.Template.ApostasRestantes))
                base.ShowMessages("Emails enviados com sucesso.");
            else
                base.ShowErrors("Erro ao enviar emails.");
        }
        protected void btnGerarApostasFinais_Click(object sender, EventArgs e)
        {
            List<Framework.Security.Model.UserData> users = new List<Framework.Security.Model.UserData>();

            IList<Framework.DataServices.Model.EntityBaseData> list = (IList<Framework.DataServices.Model.EntityBaseData>)ViewState["Users"];

            foreach (Model.Boloes.ApostasRestantesUser user in list)
            {
                if (!string.IsNullOrEmpty(user.UserName))
                    users.Add(user);
            }

            #region Criando o pdf
            string file = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Images\\Database\\PDF\\" + CurrentBolao.Nome + "fim.pdf";

            if (System.IO.File.Exists(file))
                System.IO.File.Delete(file);

            using (FileStream fs = new FileStream(file, FileMode.Create))
            {
                Business.PDF.Support.CopaMundoPdfCreator pdf = new BolaoNet.Business.PDF.Support.CopaMundoPdfCreator(base.UserName);
                pdf.CreateApostasUsersFim(fs,
                    System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Images\\Database",
                    CurrentCampeonato,
                    CurrentBolao,
                    users);
            }
            #endregion

            #region Criando o ZIP

            // Zip up the files - From SharpZipLib Demo Code
            using (ZipOutputStream s = new ZipOutputStream(File.Create(file.Replace(".pdf", ".zip"))))
            {
                s.SetLevel(9); // 0-9, 9 being the highest compression

                byte[] buffer = new byte[4096];


                ZipEntry entry = new ZipEntry(Path.GetFileName(file));

                entry.DateTime = DateTime.Now;
                s.PutNextEntry(entry);

                using (FileStream fs = File.OpenRead(file))
                {
                    int sourceBytes;
                    do
                    {
                        sourceBytes = fs.Read(buffer, 0, buffer.Length);

                        s.Write(buffer, 0, sourceBytes);

                    } while (sourceBytes > 0);
                }

                s.Finish();
                s.Close();
            }

            #endregion


            ShowStatusPDFFileFim();
        }
        protected void lnkDownloadBolaoPDFFim_Click(object sender, EventArgs e)
        {
            string file = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Images\\Database\\PDF\\" + CurrentBolao.Nome + "fim.pdf";


            FileInfo arquivo = new FileInfo(file);


            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment; filename=" + CurrentBolao.Nome + "fim.pdf");

            Response.WriteFile(file);
        }
        protected void lnkDownloadBolaoZIPFim_Click(object sender, EventArgs e)
        {
            string file = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Images\\Database\\PDF\\" + CurrentBolao.Nome + "fim.zip";


            FileInfo arquivo = new FileInfo(file);


            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment; filename=" + CurrentBolao.Nome + "fim.zip");

            Response.WriteFile(file);
        }
        #endregion
    }
}
