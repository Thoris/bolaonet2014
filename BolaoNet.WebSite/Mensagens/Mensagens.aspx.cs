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
    public partial class Mensagens : ApostaBolaoBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            BindMensagens();
        }
        #endregion

        #region Methods
        private void BindMensagens()
        {
            Business.Boloes.Support.Mensagens business = new BolaoNet.Business.Boloes.Support.Mensagens(base.UserName);
            business.Bolao = CurrentBolao;
            IList<Framework.DataServices.Model.EntityBaseData> list = business.LoadMessagesUser(
                new Framework.Security.Model.UserData(base.UserName), CurrentBolao);


            this.dtlMessages.DataSource = list;
            this.dtlMessages.DataBind();

            if (list.Count == 0)
                this.lblSemMensagens.Visible = true;
            else
                this.lblSemMensagens.Visible = false;
        
        
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

                    break;

                case WebSite.Controls.MenuManager.MenuTools.AddNew:

                    Response.Redirect("~/Mensagens/MensagensAdd.aspx");

                    break;

                case WebSite.Controls.MenuManager.MenuTools.Return:

                    break;

                default:
                    break;
            }
        }
        protected void dtlMessages_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }
        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(((LinkButton)sender).CommandArgument))
                return;


            Business.Boloes.Support.Mensagens business = new BolaoNet.Business.Boloes.Support.Mensagens(base.UserName);
            business.Bolao = CurrentBolao;
            business.ToUser = base.UserName;
            business.MessageID = long.Parse(((LinkButton)sender).CommandArgument);

            if (business.Delete())
                base.ShowMessages("Mensagem excluída com sucesso.");
            else
                base.ShowErrors("Erro ao excluir a mensagem.");


            BindMensagens();


        }
        protected void dtlMessages_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            

            Model.Boloes.Mensagem mensagem = (Model.Boloes.Mensagem)e.Item.DataItem;


            //Atribuindo o ID da mensagem
            LinkButton lnkDelete = (LinkButton)e.Item.FindControl("lnkDelete");
            lnkDelete.CommandArgument = mensagem.MessageID.ToString();



            //Mostrando a imagem do usuário
            Image imgUser = (Image)e.Item.FindControl("imgUser");

            string fileImage = "~/Images/Database/Users/" + mensagem.FromUser + ".jpg";

            if (!System.IO.File.Exists(Server.MapPath(fileImage)))
                fileImage = "~/Images/Database/Users/No-Image.png";
            imgUser.ImageUrl = fileImage;

        }

        #endregion

     



    }
}
