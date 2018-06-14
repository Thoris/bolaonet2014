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
    public partial class RequestLogin : BasePage
    {
        #region Constructors/Destructors
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Framework.Security.Util.Captcha ci = new Framework.Security.Util.Captcha("", 1, 1);
                //Session["CaptchaImageText"] = ci.GerarStringRandomica(4);
            }
            else
            {
                //ViewState["CaptchaImageText"] = Session["CaptchaImageText"];
            }
        }
        #endregion

        #region Methods
        private Framework.Security.Model.UserData LoadUserDataFromPage()
        {
            Framework.Security.Model.UserData user = null;

            string codigo = ((TextBox)this.dtvNewUser.FindControl("txtCodigo")).Text;            
            string login = ((TextBox)this.dtvNewUser.FindControl("txtLogin")).Text;

            user = new Framework.Security.Model.UserData(login);
            user.FullName = ((TextBox)this.dtvNewUser.FindControl("txtNome")).Text;

            switch (((DropDownList)this.dtvNewUser.FindControl("cboSexo")).SelectedIndex)
            {
                case 1:
                    user.Male = true;
                    break;
                case 2:
                    user.Male = false;
                    break;
            }

            DropDownList cboDia = ((DropDownList)this.dtvNewUser.FindControl("cboDia"));
            DropDownList cboMes = ((DropDownList)this.dtvNewUser.FindControl("cboMes"));
            DropDownList cboAno = ((DropDownList)this.dtvNewUser.FindControl("cboAno"));

            if (cboDia.SelectedIndex == 0 ||
                cboMes.SelectedIndex == 0 ||
                cboAno.SelectedIndex == 0)
            {
                user.BirthDate = DateTime.MinValue;
            }
            else
            {
                DateTime nascimento = new DateTime(
                    int.Parse(cboAno.SelectedValue),
                    cboMes.SelectedIndex,
                    int.Parse(cboDia.SelectedValue));

                user.BirthDate = nascimento;
            }

            user.CPF = ((TextBox)this.dtvNewUser.FindControl("txtCPF")).Text;
            user.Email = ((TextBox)this.dtvNewUser.FindControl("txtEmail")).Text;
            user.Password = ((TextBox)this.dtvNewUser.FindControl("txtSenha")).Text;
            //user.PasswordQuestion = ((TextBox)this.dtvNewUser.FindControl("txtPergunta")).Text;
            user.PasswordAnswer = ((TextBox)this.dtvNewUser.FindControl("txtResposta")).Text;
            bool receberNotificacao = ((CheckBox)this.dtvNewUser.FindControl("chkReceberNotificacao")).Checked;




            return user;
        }
        #endregion

        #region Events
        protected void dtvNewUser_DataBound(object sender, EventArgs e)
        {
            DropDownList cboDia = (DropDownList)this.dtvNewUser.FindControl("cboDia");
            DropDownList cboMes = (DropDownList)this.dtvNewUser.FindControl("cboMes");
            DropDownList cboAno = (DropDownList)this.dtvNewUser.FindControl("cboAno");


            cboDia.Items.Add(new ListItem("<Escolha>", null));
            for (int c = 1; c <= 31; c++)
            {
                cboDia.Items.Add(new ListItem(c.ToString(), c.ToString()));
            }


            cboMes.Items.Add(new ListItem("<Escolha>", null));
            cboMes.Items.Add(new ListItem("Janeiro", "1"));
            cboMes.Items.Add(new ListItem("Fevereiro", "2"));
            cboMes.Items.Add(new ListItem("Março", "3"));
            cboMes.Items.Add(new ListItem("Abril", "4"));
            cboMes.Items.Add(new ListItem("Maio", "5"));
            cboMes.Items.Add(new ListItem("Junho", "6"));
            cboMes.Items.Add(new ListItem("Julho", "7"));
            cboMes.Items.Add(new ListItem("Agosto", "8"));
            cboMes.Items.Add(new ListItem("Setembro", "9"));
            cboMes.Items.Add(new ListItem("Outubro", "10"));
            cboMes.Items.Add(new ListItem("Novembro", "11"));
            cboMes.Items.Add(new ListItem("Dezembro", "12"));



            cboAno.Items.Add(new ListItem("<Escolha>", null));
            for (int c = 1900; c <= DateTime.Now.Year; c++)
            {
                cboAno.Items.Add(new ListItem(c.ToString(), c.ToString()));
            }


        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            
            

            if (Page.IsValid)
            {
                Framework.Security.Model.UserData user = LoadUserDataFromPage();


                MembershipCreateStatus status = MembershipCreateStatus.ProviderError;

                //Criando o usuário
                MembershipUser memberUser = Membership.Provider.CreateUser(
                    user.UserName, 
                    user.Password, 
                    user.Email,
                    user.PasswordQuestion,
                    user.PasswordAnswer,
                    user.IsApproved,
                    user.UserName,
                    out status);

                switch (status)
                {
                    case MembershipCreateStatus.DuplicateEmail:
                        base.ShowErrors("O email especificado já existe cadastrado para um usuário, por favor, entre com outro email.");
                        //((RegularExpressionValidator)this.dtvNewUser.FindControl("revEmail")).IsValid = false;
                        return;
                    case MembershipCreateStatus.DuplicateProviderUserKey:
                        base.ShowErrors("O usuário já existe no banco de dados, por favor, entre com outro.");
                        return; ;
                    case MembershipCreateStatus.DuplicateUserName:
                        base.ShowErrors("O login do usuário já existe no banco de dados, por favor, entre com outro login.");
                        //((IValidator)this.dtvNewUser.FindControl("rfvLogin")).IsValid = false;
                        return; ;
                    case MembershipCreateStatus.InvalidAnswer:
                        base.ShowErrors("Resposta inválida, por favor entre com uma resposta que atenda aos requisitos de segurança.");
                        return;
                    case MembershipCreateStatus.InvalidEmail:
                        base.ShowErrors("Formato de email incorreto.");
                        return;
                    case MembershipCreateStatus.InvalidPassword:
                        base.ShowErrors("Senha inválida, por favor entre com uma senha que atenda aos requisitos de segurança.");
                        return;
                    case MembershipCreateStatus.InvalidProviderUserKey:
                        base.ShowErrors("Chave do usuário inválida.");
                        return;
                    case MembershipCreateStatus.InvalidQuestion:
                        base.ShowErrors("Pergunta inválida, por favor entre com uma pergunta que atenda aos requisitos de segurança.");
                        return;
                    case MembershipCreateStatus.InvalidUserName:
                        base.ShowErrors("Usuário inválido.");
                        return;
                    case MembershipCreateStatus.ProviderError:
                        base.ShowErrors("Erro de provider.");
                        return;
                    case MembershipCreateStatus.UserRejected:
                        base.ShowErrors("Usuário rejeitado.");
                        return;
                    case MembershipCreateStatus.Success:
                        break;
                }



                Framework.Security.Business.CustomMembershipUser customUser =
                    (Framework.Security.Business.CustomMembershipUser)memberUser;

                customUser.UserData.Copy(user);

                Membership.UpdateUser(customUser);



                Framework.Security.Business.UserDataService userModel = 
                    new Framework.Security.Business.UserDataService("", user);
                Framework.Security.Model.UserData userDataItem= userModel.LoadUser();




                try
                {

                    if (Framework.Security.Util.Mail.Send(userDataItem, Framework.Security.Util.Mail.Template.Activation))
                    {
                        this.MultiViewNewLogin.ActiveViewIndex = 1;



                        Framework.Logging.Logger.LogManager.WriteInformation(null, this, "Usuário " + userModel.UserName + " foi criado.", null);
                    }
                    else
                    {
                        this.MultiViewNewLogin.ActiveViewIndex = 2;

                        base.ShowErrors("Não foi possível enviar o email para o usuário criado.");

                        //Excluindo o usuário pois o mesmo não foi possível enviar o email
                        Membership.DeleteUser(user.UserName);
                    }

                }
                catch (Exception ex)
                {
                    this.lblErrorSendMail.Text = "Erro: " + ex.Message;
                    this.MultiViewNewLogin.ActiveViewIndex = 2;

                    base.ShowErrors("Não foi possível enviar o email para o usuário criado.");

                    //Excluindo o usuário pois o mesmo não foi possível enviar o email
                    Membership.DeleteUser(user.UserName);
                }

            }
        }
        protected void cvEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            TextBox txtEmail = (TextBox)this.dtvNewUser.FindControl("txtEmail");
            TextBox txtConfirmEmail = (TextBox)this.dtvNewUser.FindControl("txtConfirmEmail");

            if (string.Compare(txtConfirmEmail.Text, txtEmail.Text) != 0)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }


        }
        protected void cvSenha_ServerValidate(object source, ServerValidateEventArgs args)
        {
            TextBox txtSenha = (TextBox)this.dtvNewUser.FindControl("txtSenha");
            TextBox txtConfirmSenha = (TextBox)this.dtvNewUser.FindControl("txtConfirmSenha");

            if (string.Compare(txtConfirmSenha.Text, txtSenha.Text) != 0)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
        protected void cvNascimento_ServerValidate(object source, ServerValidateEventArgs args)
        {

            DropDownList cboDia = ((DropDownList)this.dtvNewUser.FindControl("cboDia"));
            DropDownList cboMes = ((DropDownList)this.dtvNewUser.FindControl("cboMes"));
            DropDownList cboAno = ((DropDownList)this.dtvNewUser.FindControl("cboAno"));



            if (cboDia.SelectedIndex > 0 ||
                cboMes.SelectedIndex > 0 ||
                cboAno.SelectedIndex > 0)
            {
                try
                {
                    DateTime nascimento = new DateTime(
                        int.Parse(cboAno.SelectedValue),
                        cboMes.SelectedIndex,
                        int.Parse(cboDia.SelectedValue));

                    args.IsValid = true;
                }
                catch
                {
                    args.IsValid = false;
                }
            }

        }
        protected void cvTermos_ServerValidate(object source, ServerValidateEventArgs args)
        {
            CheckBox chkConcordo = (CheckBox)this.dtvNewUser.FindControl("chkConcordo");

            args.IsValid = chkConcordo.Checked;
        }
        protected void cvCodigo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //If there is no code to be checked
            args.IsValid = true;
            return;



            TextBox txtCodigo = (TextBox)this.dtvNewUser.FindControl ("txtCodigo");
            string codigo = "";

            if (Session["CaptchaImageText"] != null)
                codigo = Session["CaptchaImageText"].ToString ();



            //if (string.Compare (txtCodigo.Text, Session["CaptchaImageText"].ToString (), true) != 0)
            if (string.Compare(txtCodigo.Text, codigo, true) != 0)
            {
                args.IsValid = false;                
            }
            else
            {
                args.IsValid = true;
            }
        }
        protected void lnkTenteNovamente_Click(object sender, EventArgs e)
        {
            this.MultiViewNewLogin.ActiveViewIndex = 0;
        }
        #endregion

     
 
    }
}
