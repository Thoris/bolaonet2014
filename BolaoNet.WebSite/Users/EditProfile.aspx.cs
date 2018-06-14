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

namespace BolaoNet.WebSite.Users
{
    public partial class EditProfile : UserBasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.ctlUserInfo.UserData == null && base.UserName != null)
            {
                Framework.Security.Business.UserDataService business = new Framework.Security.Business.UserDataService(base.UserName);

                business.UserName = base.UserName;

                Framework.Security.Model.UserData user = business.LoadUser();

                this.ctlUserInfo.UserData = user;

            }            

        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.ctlUserInfo.ModeView = BolaoNet.WebSite.Controls.Views.UserInfo.Mode.EditUser;

            this.ctlMenuTools.ButtonClick += new CommandEventHandler(ctlMenuTools_ButtonClick);
            this.ctlNavigateHomeControl.ButtonClick += new CommandEventHandler(ctlNavigateHomeControl_ButtonClick);
        }

        #endregion

        #region Methods
        private void Save()
        {
            Framework.Security.Model.UserData userData = this.ctlUserInfo.GetUserData();

            Framework.Security.Business.UserDataService business = new Framework.Security.Business.UserDataService(base.UserName, userData);

            if (!this.ctlUserInfo.SavePictureFile())
            {
                base.ShowErrors("Não foi possível armazenar a imagem do usuário.");
            }


            if (business.UpdateUser())
            {                
                base.ShowMessages("Perfil atualizado com sucesso");

                this.ctlUserInfo.ShowUserData(business);
            }
            else
            {
                base.ShowErrors("Não foi possível atualizar o perfil.");
            }

        }
        #endregion

        #region Events
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

                default:
                    break;
            }
            
        }        
        #endregion
    }
}
