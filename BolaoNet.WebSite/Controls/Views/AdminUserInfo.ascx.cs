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
    public partial class AdminUserInfo : System.Web.UI.UserControl
    {
        #region Properties
        public Framework.Security.Model.UserData UserInfo
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserInfo != null)
                ShowUserData(UserInfo);
        }
        #endregion

        #region Methods
        public void ShowUserData(Framework.Security.Model.UserData userInfo)
        {
            if (string.IsNullOrEmpty(userInfo.ApprovedBy))
                this.lblApprovedBy.Text = "-";
            else
                this.lblApprovedBy.Text = userInfo.ApprovedBy;


            if (userInfo.ApprovedDate == DateTime.MinValue)
                this.lblApprovedDate.Text = "-";
            else
                this.lblApprovedDate.Text = userInfo.ApprovedDate.ToString("dd/MM/yyyy HH:mm:ss");


            this.lblFailedPasswordAnswerAttemptCount.Text = userInfo.FailedPasswordAnswerAttemptCount.ToString();

            if (userInfo.FailedPasswordAnswerAttemptWindowStart == DateTime.MinValue)
                this.lblFailedPasswordAnswerAttemptDate.Text = "-";
            else
                this.lblFailedPasswordAnswerAttemptDate.Text = userInfo.FailedPasswordAnswerAttemptWindowStart.ToString("dd/MM/yyyy HH:mm:ss");
            
                       
            this.lblFailedPasswordAttemptCount.Text = userInfo.FailedPasswordAttemptCount.ToString();


            if (userInfo.FailedPasswordAttemptWindowStart == DateTime.MinValue)
                this.lblFailedPasswordAttemptDate.Text = "-";
            else
                this.lblFailedPasswordAttemptDate.Text = userInfo.FailedPasswordAttemptWindowStart.ToString("dd/MM/yyyy HH:mm:ss");


            if (userInfo.LastActivityDate == DateTime.MinValue)
                this.lblLastActivityDate.Text = "-";
            else
                this.lblLastActivityDate.Text = userInfo.LastActivityDate.ToString("dd/MM/yyyy HH:mm:ss");

            if (userInfo.LastLockoutDate == DateTime.MinValue)
                this.lblLastLockoutDate.Text = "-";
            else
                this.lblLastLockoutDate.Text = userInfo.LastLockoutDate.ToString("dd/MM/yyyy HH:mm:ss");

            if (userInfo.LastLoginDate == DateTime.MinValue)
                this.lblLastLoginDate.Text = "-";
            else
                this.lblLastLoginDate.Text = userInfo.LastLoginDate.ToString("dd/MM/yyyy HH:mm:ss");

            if (userInfo.LastPasswordChangedDate == DateTime.MinValue)
                this.lblLastPasswordChangedDate.Text = "-";
            else
                this.lblLastPasswordChangedDate.Text = userInfo.LastPasswordChangedDate.ToString("dd/MM/yyyy HH:mm:ss");


            if (string.IsNullOrEmpty(userInfo.RequestedBy))
                this.lblRequestedBy.Text = "-";
            else
                this.lblRequestedBy.Text = userInfo.RequestedBy;

            if (userInfo.RequestedDate == DateTime.MinValue)
                this.lblRequestedDate.Text = "-";
            else
                this.lblRequestedDate.Text = userInfo.RequestedDate.ToString("dd/MM/yyyy HH:mm:ss");
            
            this.chkIsLockedOut.Checked = userInfo.IsLockedOut;
            this.chkIsApproved.Checked = userInfo.IsApproved;

            this.ctlStatusRowInfo.ShowStatus((Framework.DataServices.Model.EntityBaseData)userInfo);

        }
        #endregion
    }
}