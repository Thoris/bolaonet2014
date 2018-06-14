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

namespace BolaoNet.WebSite.Boloes
{
    public partial class ApostasUsuarios : BolaoUserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Business.Boloes.Support.Bolao bolao = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);
                IList<Framework.DataServices.Model.EntityBaseData> list = bolao.LoadMembros();

                this.cboUsuarios.DataSource = list;
                this.cboUsuarios.DataTextField = "UserName";
                this.cboUsuarios.DataValueField = "UserName";
                this.cboUsuarios.DataBind();


                this.cboUsuarios.SelectedValue = base.UserName;
                this.lblUsuarioSelecionado.Text = base.UserName;

                //for (int c = 0; c < this.cboUsuarios.Items.Count; c++)
                //{
                //    if (string.Compare(this.cboUsuarios.Items[0].Text, base.UserName, true) == 0)
                //    {
                //        this.cboUsuarios.Items[c].Selected = true;
                //        break;
                //    }
                //}


                lnkDownloaApostas.NavigateUrl = "~/Boloes/DownloadApostas.aspx?Bolao=" + CurrentBolao.Nome + "&UserName=" + this.lblUsuarioSelecionado.Text;

                
            }
            //lnkDownload.Attributes.Add("Target", "_blank");
        }
        #endregion

        #region Events
        protected void cboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ctlListJogo.UserNameToCheck = this.cboUsuarios.Text;
            this.ctlListJogo.BindGrid();

            this.lblUsuarioSelecionado.Text = this.cboUsuarios.Text;


            lnkDownloaApostas.NavigateUrl = "~/Boloes/DownloadApostas.aspx?Bolao=" + CurrentBolao.Nome + "&UserName=" + this.lblUsuarioSelecionado.Text;
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.ctlNavigateHomeControl.ButtonClick += new CommandEventHandler(ctlNavigateHomeControl_ButtonClick);
            this.ctlMenuTools.ButtonClick += new CommandEventHandler(ctlMenuTools_ButtonClick);
        }
        private void ctlNavigateHomeControl_ButtonClick(object sender, CommandEventArgs e)
        {
            base.NavigateHome();
        }
        private void ctlMenuTools_ButtonClick(object sender, CommandEventArgs e)
        {
        }

        protected void lnkDownload_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Boloes/DownloadApostas.aspx?Bolao=" + CurrentBolao.Nome + "&UserName=" + this.lblUsuarioSelecionado.Text);


            //string url = "<script language='javascript'> window.open('" + "~/Boloes/DownloadApostas.aspx?Bolao=" + CurrentBolao.Nome + "&UserName=" + this.lblUsuarioSelecionado.Text + "', 'CustomPopUp', 'menubar=yes, resizable=yes') </script>";

            //Page.RegisterStartupScript("PopupScript", url);


        }
        #endregion



    }
}
