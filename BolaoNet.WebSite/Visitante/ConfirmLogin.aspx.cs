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

namespace BolaoNet.WebSite.Visitante
{
    public partial class ConfirmLogin : BasePage
    {
        #region Constructors/Destructors

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string login = Request.QueryString["Login"];
                string key = Request.QueryString["Key"];


                if (!string.IsNullOrEmpty(login))
                {
                    ((TextBox)this.dtvLogin.FindControl("txtLogin")).Text = Request.QueryString["Login"];
                }

                if (!string.IsNullOrEmpty(key))
                {
                    ((TextBox)this.dtvLogin.FindControl("txtChave")).Text = Request.QueryString["Key"];
                }


                if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(key))
                {
                    this.MultiViewConfirm.ActiveViewIndex = 1;
                    this.lnkTentarNovamente.Visible = false;

                    ApproveUser(login, key);
                }
                else
                {
                    this.MultiViewConfirm.ActiveViewIndex = 0;
                }
            }

        }
        #endregion

        #region Methods
        private void ShowUserData(Framework.Security.Business.CustomMembershipUser userData)
        {
            

            if (userData.UserData.RequestedDate != DateTime.MinValue)
                this.lblDataRequisicao.Text = userData.UserData.RequestedDate.ToString("dd/MM/yyyy HH:mm:ss");
            else
                this.lblDataRequisicao.Text = "";

            if (userData.UserData.ApprovedDate != DateTime.MinValue)
                this.lblDataResposta.Text = userData.UserData.ApprovedDate.ToString("dd/MM/yyyy HH:mm:ss");
            else
                this.lblDataResposta.Text = "";


            this.lblLogin.Text = userData.UserData.UserName;
            this.lnlNome.Text = userData.UserData.FullName;

            this.chkAprovado.Checked = userData.UserData.IsApproved;
            this.chkAtivado.Checked = !userData.UserData.IsLockedOut;
            
        }
        private bool ApproveUser(string login, string key)
        {
            bool isApproved = false;


            Framework.Security.Business.UserDataService userService = 
                new Framework.Security.Business.UserDataService(HttpContext.Current.User.Identity.Name);
            userService.UserName = login;
            userService.ActivateKey = key;


            //Aprovando o usuário
            isApproved = userService.ApproveUser();


            //Buscando dados do usuário
            Framework.Security.Business.CustomMembershipUser customUser = 
                (Framework.Security.Business.CustomMembershipUser)Membership.Provider.GetUser(login, false);


            //Se o usuário não foi encontrado
            if (customUser == null)
            {
                base.ShowErrors("Usuário não encontrado na base de dados.");
                this.MultiViewConfirm.ActiveViewIndex = 0;

                return false;
            }
            //Se o usuário foi encontrado
            else
            {
                //inserindo as roles do usuário que está sendo inserido
                //string [] roles = new string[4];
                //roles[0] = "Apostador";
                //roles[1] = "Convidado";
                //roles[2] = "Visitante de Bolão";
                //roles[3] = "Visitante de Campeonato";

                string rolesToAdd = ConfigurationManager.AppSettings["RolesToAddAtConfirmation"];


                if (rolesToAdd != null)
                {
                    string[] roles = rolesToAdd.Split(new char[] { '|' });

                    System.Web.Security.Roles.AddUserToRoles(login, roles);
                }




                //Inserindo os usuários na lista de itens no momento da confirmação do login
                string listToAdd = ConfigurationManager.AppSettings["BolaoListToAddAtConfirmation"];

                if (!string.IsNullOrEmpty(listToAdd))
                {
                    string[] items = listToAdd.Split(new char [] {'|'});

                    foreach (string entry in items)
                    {
                        Business.Boloes.Support.Bolao bolao = new BolaoNet.Business.Boloes.Support.Bolao(login, entry);
                        bolao.Load();

                        if ( (!bolao.ApostasApenasAntes) || (bolao.ApostasApenasAntes && !bolao.IsIniciado))
                        {
                            bolao.InsertMembro(new Framework.Security.Model.UserData(login));
                        }
                    }
                }//endif items a serem inseridos







                this.MultiViewConfirm.ActiveViewIndex = 1;

                //Mostrando dados do usuário
                ShowUserData(customUser);

                this.lblChave.Text = userService.ActivateKey;

                //Se não foi aprovado
                if (!isApproved)
                {
                    base.ShowErrors("Chave do usuário inválido para aprovação.");
                    this.lblStatus.Text = "Chave do usuário inválido para aprovação.";
                    
                }
                //Se foi aprovado
                else
                {
                    base.ShowMessages("Usuário aprovado.");
                    this.lblStatus.Text = "Usuário aprovado.";

                    this.lnkTentarNovamente.Visible = false;

                    Framework.Security.Business.UserDataService userEntry =
                        new Framework.Security.Business.UserDataService("", customUser.UserData);



                    ////Salvando os dados do profile do usuário
                    //Business.Profile.CustomProfile profile = Business.Profile.CustomProfile.GetProfile();
                    //profile.NomeCampeonato = "";
                    //profile.NomeBolao = "";
                    //profile.Save();


                    Framework.Logging.Logger.LogManager.WriteInformation(null, this, "Usuário " + customUser.UserData.UserName + " aprovado.", null);


                    Framework.Security.Util.Mail.Send(userEntry.LoadUser(), Framework.Security.Util.Mail.Template.Welcome);


                }//endif se foi aprovado

            }//endif usuário encontrado



            return true;
        }
        #endregion

        #region Events

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;


            string login = string.Empty;
            string key = string.Empty;

            login = ((TextBox)this.dtvLogin.FindControl("txtLogin")).Text;
            key = ((TextBox)this.dtvLogin.FindControl("txtChave")).Text;

            ApproveUser(login, key);

        }
        protected void lnkTentarNovamente_Click(object sender, EventArgs e)
        {
            this.MultiViewConfirm.ActiveViewIndex = 0;
        }
        #endregion

    }
}
