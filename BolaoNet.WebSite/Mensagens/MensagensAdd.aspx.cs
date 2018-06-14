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

namespace BolaoNet.WebSite.Mensagens
{
    public partial class MensagensAdd : ApostaBolaoBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Business.Boloes.Support.Bolao business = new BolaoNet.Business.Boloes.Support.Bolao(base.UserName, CurrentBolao.Nome);
                IList<Framework.DataServices.Model.EntityBaseData> list = business.LoadMembros();


                this.cboUsers.DataSource = list;
                this.cboUsers.DataTextField = "UserName";
                this.cboUsers.DataValueField = "UserName";
                this.cboUsers.DataBind();

                this.cboUsers.Items.Insert(0, new ListItem("Todos", ""));

            }
        }
        #endregion

        #region Methods
        private void ShowUserPicture()
        {
            string fileImage = "~/Images/Database/Users/No-Image.png";

            if (this.cboUsers.SelectedIndex > 0)
            {
                fileImage = "~/Images/Database/Users/" + this.cboUsers.SelectedValue + ".jpg";

                if (!System.IO.File.Exists(Server.MapPath(fileImage)))
                    fileImage = "~/Images/Database/Users/No-Image.png";

            }
            
            this.imgUser.ImageUrl = fileImage;

        }
        private Model.Boloes.Mensagem GetMensagem()
        {
            Model.Boloes.Mensagem mensagem = new BolaoNet.Model.Boloes.Mensagem();
            mensagem.Bolao = new BolaoNet.Model.Boloes.Bolao(CurrentBolao.Nome);
            mensagem.FromUser = base.UserName;
            mensagem.Private = this.chkPrivate.Checked;
            mensagem.ToUser = this.cboUsers.SelectedValue;
            mensagem.Title = this.txtTitle.Text;
            mensagem.Message = this.txtMessage.Text;

            return mensagem;

        }
        private void Save()
        {
            if (!IsValid)
                return;


            Model.Boloes.Mensagem mensagem = GetMensagem();

            Business.Boloes.Support.Mensagens business = new BolaoNet.Business.Boloes.Support.Mensagens(base.UserName);
            business.Copy((Model.Boloes.Mensagem)mensagem);

            if (business.AddMessage())
            {
                base.ShowMessages("Mensagem enviada com sucesso.");
            }
            else
            {
                base.ShowErrors("Erro ao enviar a mensagem.");
            }
        }
        #endregion

        #region Events
        protected void cboUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowUserPicture();
        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Save();
        }

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
                    Save();
                    break;

                case WebSite.Controls.MenuManager.MenuTools.AddNew:


                    break;

                case WebSite.Controls.MenuManager.MenuTools.Return:
                    Response.Redirect("~/Mensagens/Mensagens.aspx");
                    break;

                default:
                    break;
            }
        }
        #endregion


    }
}
