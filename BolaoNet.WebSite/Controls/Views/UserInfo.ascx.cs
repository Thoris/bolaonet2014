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

namespace BolaoNet.WebSite.Controls.Views
{
    public partial class UserInfo : System.Web.UI.UserControl
    {
        #region Enumerations
        public enum Mode
        {
            ReadOnly = 0,
            InsertUser = 1,
            EditUser = 2,
            AdminUser = 3,
        }
        #endregion

        #region Properties
        public Mode ModeView
        {
            get 
            {
                if (ViewState["UserInfo.Mode"] == null)
                    return Mode.ReadOnly;
                else
                    return (Mode)ViewState["UserInfo.Mode"]; 
            }
            set 
            {
                ChangeModeView(value);

                ViewState["UserInfo.Mode"] = value; 

                
            }
        }
        public Framework.Security.Model.UserData UserData
        {
            get { return (Framework.Security.Model.UserData)ViewState["UserInfo"]; }
            set 
            {
                if (ViewState["UserInfo"] != value && value != null)
                {
                    ShowUserData(value);
                }

                ViewState["UserInfo"] = value;
            }
        }
        #endregion

        #region Constructors/Destructors
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            ChangeModeView(ModeView);


            //string fileImage = Server.MapPath("~/Images/Database/Users/" + UserBasePage.CurrentUserName + ".jpg");


        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack && UserData != null)
                ShowUserData(UserData);
        }
        #endregion

        #region Methods
        private void EditMode(bool enable)
        {
            this.fileUploadPicture.Visible = enable;

            this.txtUserName.Visible = enable;
            this.txtBirthDate.Visible = enable;
            this.txtCellPhone.Visible = enable;
            this.txtCity.Visible = enable;
            this.txtCompanyPhone.Visible = enable;
            this.txtCountry.Visible = enable;
            this.txtCPF.Visible = enable;
            this.txtEmail.Visible = enable;
            this.txtFirstName.Visible = enable;
            this.txtLastName.Visible = enable;
            this.txtMiddleName.Visible = enable;
            this.txtMSN.Visible = enable;
            this.txtNumber.Visible = enable;
            this.txtPhoneNumber.Visible = enable;
            this.txtPostalCode.Visible = enable;
            this.txtRG.Visible = enable;
            this.txtSkype.Visible = enable;
            this.txtState.Visible = enable;
            this.txtStreet.Visible = enable;
            this.txtUserName.Visible = enable;
            this.txtWebSite.Visible = enable;
            this.cboMaritalStatus.Visible = enable;
            this.cboSex.Visible = enable;
            this.chkReceiveEmails.Visible = enable;
            this.PopCalendarBirthDate.Visible = enable;



            this.lblUserName.Visible = !enable;
            this.lblBirthDate.Visible = !enable;
            this.lblCellPhone.Visible = !enable;
            this.lblCity.Visible = !enable;
            this.lblCompanyPhone.Visible = !enable;
            this.lblCountry.Visible = !enable;
            this.lblCPF.Visible = !enable;
            this.lblEmail.Visible = !enable;
            this.lblFirstName.Visible = !enable;
            this.lblLastName.Visible = !enable;
            this.lblMiddleName.Visible = !enable;
            this.lblMSN.Visible = !enable;
            this.lblNumber.Visible = !enable;
            this.lblPhoneNumber.Visible = !enable;
            this.lblPostalCode.Visible = !enable;
            this.lblRG.Visible = !enable;
            this.lblSkype.Visible = !enable;
            this.lblState.Visible = !enable;
            this.lblStreet.Visible = !enable;
            this.lblUserName.Visible = !enable;
            this.lblWebSite.Visible = !enable;
            this.lblMarialStatus.Visible = !enable;
            this.lblSex.Visible = !enable;
            this.lblReceiveEmails.Visible = !enable;

        }
        public void ChangeModeView(Mode mode)
        {
            




            switch (mode)
            {
                case Mode.AdminUser:

                    EditMode(true);
                    this.ctlAdminUserInfo.Visible = true;

                    break;

                case Mode.EditUser:

                    EditMode(true);

                    this.lblUserName.Visible = true;
                    this.txtUserName.Visible = false;

                    this.ctlAdminUserInfo.Visible = false;
                    
                    break;

                
                case Mode.InsertUser:

                    EditMode(true);

                    this.lblUserName.Visible = false;
                    this.txtUserName.Visible = true;

                    this.ctlAdminUserInfo.Visible = false;
                    break;
                
                
                case Mode.ReadOnly:

                    EditMode(false);

                    this.ctlAdminUserInfo.Visible = false;

                    break;
            }
        }
        public void ShowUserData(Framework.Security.Model.UserData userInfo)
        {


            string fileImage = "~/Images/Database/Users/" + userInfo.UserName + ".jpg";

            if (!System.IO.File.Exists(Server.MapPath(fileImage)))
                fileImage = "~/Images/Database/Users/No-Image.png";

            this.imgUser.ImageUrl = fileImage;


            //string fileImage = Server.MapPath ("/Images/Database/Users/" + userInfo.UserName + ".jpg");

            //if (!System.IO.File.Exists(fileImage))
            //    fileImage = Server.MapPath ("/Images/Database/Users/No-Image.png");


            //this.imgUser.ImageUrl = fileImage;


            if (userInfo.BirthDate == DateTime.MinValue)
            {
                this.txtBirthDate.Text = "";
                this.lblBirthDate.Text = "-";            
            }
            else
            {
                this.txtBirthDate.Text = userInfo.BirthDate.ToString("dd/MM/yyyy");
                this.lblBirthDate.Text = this.txtBirthDate.Text;
            }


            this.txtCellPhone.Text = userInfo.CellPhone;
            if (string.IsNullOrEmpty(this.txtCellPhone.Text))
                this.lblCellPhone.Text = "-";
            else
                this.lblCellPhone.Text = this.txtCellPhone.Text;


            this.txtCity.Text = userInfo.City;
            if (string.IsNullOrEmpty(this.txtCity.Text))
                this.lblCity.Text = "-";
            else
                this.lblCity.Text = this.txtCity.Text ;

            
            this.txtCompanyPhone.Text = userInfo.CompanyPhone;
            if (string.IsNullOrEmpty(this.txtCompanyPhone.Text))
                this.lblCompanyPhone.Text = "-";
            else
                this.lblCompanyPhone.Text = this.txtCompanyPhone.Text;


            this.txtCountry.Text = userInfo.Country;
            if (string.IsNullOrEmpty(this.txtCountry.Text))
                this.lblCountry.Text = "-";
            else
                this.lblCountry.Text = this.txtCountry.Text;

            this.txtCPF.Text = userInfo.CPF;
            if (string.IsNullOrEmpty(this.txtCPF.Text))
                this.lblCPF.Text = "-";
            else
                this.lblCPF.Text = this.txtCPF.Text;
            
            this.txtEmail.Text = userInfo.Email;
            if (string.IsNullOrEmpty(this.txtEmail.Text))
                this.lblEmail.Text = "-";
            else
                this.lblEmail.Text = this.txtEmail.Text;
            

            this.txtFirstName.Text = userInfo.FirstName;
            if (string.IsNullOrEmpty(this.txtFirstName.Text))
                this.lblFirstName.Text = "-";
            else
                this.lblFirstName.Text = this.txtFirstName.Text;
            
            this.txtLastName.Text = userInfo.LastName;
            if (string.IsNullOrEmpty(this.txtLastName.Text))
                this.lblLastName.Text = "-";
            else
                this.lblLastName.Text = this.txtLastName.Text;
            

            this.txtMiddleName.Text = userInfo.MiddleName;
            if (string.IsNullOrEmpty(this.txtMiddleName.Text))
                this.lblMiddleName.Text = "-";
            else
                this.lblMiddleName.Text = this.txtMiddleName.Text;
            

            this.txtMSN.Text = userInfo.MSN ;
            if (string.IsNullOrEmpty(this.txtMSN.Text))
                this.lblMSN.Text = "-";
            else
                this.lblMSN.Text = this.txtMSN.Text;


            if (userInfo.StreetNumber == 0)
            {
                this.lblNumber.Text = "-";
                this.txtNumber.Text = "";
            }
            else
            {
                this.txtNumber.Text = userInfo.StreetNumber.ToString();            
                this.lblNumber.Text = this.txtNumber.Text;
            }

            this.txtPhoneNumber.Text = userInfo.PhoneNumber.ToString();
            if (string.IsNullOrEmpty(this.txtPhoneNumber.Text))
                this.lblPhoneNumber.Text = "-";
            else
                this.lblPhoneNumber.Text = this.txtPhoneNumber.Text;


            this.txtPostalCode.Text = userInfo.PostalCode;
            if (string.IsNullOrEmpty(this.txtPostalCode.Text))
                this.lblPostalCode.Text = "-";
            else
                this.lblPostalCode.Text = this.txtPostalCode.Text;
            
            this.txtRG.Text = userInfo.RG;
            if (string.IsNullOrEmpty(this.txtRG.Text))
                this.lblRG.Text = "-";
            else
                this.lblRG.Text = this.txtRG.Text;
            
            
            this.txtSkype.Text = userInfo.Skype;
            if (string.IsNullOrEmpty(this.txtSkype.Text))
                this.lblSkype.Text = "-";
            else
                this.lblSkype.Text = this.txtSkype.Text;
            
            this.txtState.Text = userInfo.State;
            if (string.IsNullOrEmpty(this.txtState.Text))
                this.lblState.Text = "-";
            else
                this.lblState.Text = this.txtState.Text;
            
            
            this.txtStreet.Text = userInfo.Street;
            if (string.IsNullOrEmpty(this.txtStreet.Text))
                this.lblStreet.Text = "-";
            else
                this.lblStreet.Text = this.txtStreet.Text;
            
            this.txtUserName.Text = userInfo.UserName;
            if (string.IsNullOrEmpty(this.txtUserName.Text))
                this.lblUserName.Text = "-";
            else
                this.lblUserName.Text = this.txtUserName.Text;
            
            
            this.txtWebSite.Text = "";
            if (string.IsNullOrEmpty(this.txtWebSite.Text))
                this.lblWebSite.Text = "-";
            else
                this.lblWebSite.Text = this.txtWebSite.Text;
            

            this.chkReceiveEmails.Checked = userInfo.ReceiveEmails;
            this.lblReceiveEmails.Text = userInfo.ReceiveEmails.ToString ();
            
            
            this.cboMaritalStatus.SelectedValue = ((int)userInfo.Marital).ToString();
            if (userInfo.Marital == Framework.Security.Model.UserData.MaritalStatus.NotDefined)
                this.lblMarialStatus.Text = "-";
            else
                this.lblMarialStatus.Text = this.cboMaritalStatus.Text;




            if (userInfo.Male)
                this.cboSex.SelectedValue = "1";
            else
                this.cboSex.SelectedValue = "2";


            this.lblSex.Text = this.cboSex.Text;



            this.ctlAdminUserInfo.ShowUserData(userInfo);
        }
        public Framework.Security.Model.UserData GetUserData()
        {
            Framework.Security.Model.UserData user = (Framework.Security.Model.UserData)ViewState["UserInfo"];

            if (ModeView == Mode.ReadOnly)
                return user;


            if (user == null)
                user = new Framework.Security.Model.UserData();


            string fullName = this.txtFirstName.Text + " " + this.txtMiddleName.Text;
            fullName = fullName.Trim();
            fullName += " " + this.txtLastName.Text;

            user.FullName = fullName;
            if (!string.IsNullOrEmpty(this.txtBirthDate.Text))
                user.BirthDate = Convert.ToDateTime(this.txtBirthDate.Text);

            user.CellPhone = this.txtCellPhone.Text;
            user.City = this.txtCity.Text;
            user.CompanyPhone = this.txtCompanyPhone.Text;
            user.Country = this.txtCountry.Text;
            user.CPF = this.txtCPF.Text;
            user.Email = this.txtEmail.Text;
            user.MSN = this.txtMSN.Text;

            if (!string.IsNullOrEmpty (this.txtNumber.Text))
                user.StreetNumber = Convert.ToInt32(this.txtNumber.Text);

            user.PhoneNumber = this.txtPhoneNumber.Text;
            user.PostalCode = this.txtPostalCode.Text;
            user.RG = this.txtRG.Text;
            user.Skype = this.txtSkype.Text;
            user.State = this.txtState.Text;
            user.Street = this.txtStreet.Text;
            user.UserName = this.txtUserName.Text;
            // this.txtWebSite.Text;


            user.Marital = (Framework.Security.Model.UserData.MaritalStatus)Convert.ToInt32(this.cboMaritalStatus.SelectedValue);

            if (this.cboSex.SelectedIndex == 2)
                user.Male = false;
            else
                user.Male = true;

            user.ReceiveEmails = this.chkReceiveEmails.Checked;




            return user;
        }

        public bool SavePictureFile()
        {
            if (this.fileUploadPicture.HasFile)
            {
                // BLOQUEIA A TRANSFERÊNCIA DE ARQUIVOS MAIOR QUE 1MB
                if (this.fileUploadPicture.PostedFile.ContentLength < 1048576)
                {
                    this.fileUploadPicture.SaveAs(Server.MapPath ("~/Images/Database/Users/" + UserBasePage.CurrentUserName + ".jpg"));
                    return true;
                }
                else
                {
                    return false;
                    //// MENSAGEM INFORMATIVA PARA O USUÁRIO
                    //ClientScript.RegisterStartupScript(
                    //    this.GetType(),
                    //    "arquivo",
                    //    "alert('Limite máximo para arquivo é de 1MB');",
                    //    true);
                }

            }

            return true;
        }
        #endregion
    }
}