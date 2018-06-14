using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Text;

namespace Framework.Security.Business
{
    [Serializable]
    public class CustomMembershipUser : MembershipUser
    {
        #region Variables
        private Business.UserDataService _userData = null;
        #endregion

        #region Properties
        public Business.UserDataService UserData
        {
            get { return _userData; }
            set { _userData = value; }
        }
        public override string Comment
        {
            get
            {
                return base.Comment;
            }
            set
            {
                _userData.Comments = value;
                base.Comment = value;
            }
        }
        public override DateTime CreationDate
        {
            get
            {
                return base.CreationDate;
            }
        }
        public override string Email
        {
            get
            {
                return base.Email;
            }
            set
            {
                _userData.Email = value;
                base.Email = value;
            }
        }
        public override bool IsApproved
        {
            get
            {
                return base.IsApproved;
            }
            set
            {
                _userData.IsApproved = value;
                base.IsApproved = value;
            }
        }
        public override bool IsLockedOut
        {
            get
            {
                return base.IsLockedOut;
            }
        }
        public override DateTime LastActivityDate
        {
            get
            {
                return base.LastActivityDate;
            }
            set
            {
                _userData.LastActivityDate = value;
                base.LastActivityDate = value;
            }
        }
        public override DateTime LastLockoutDate
        {
            get
            {
                return base.LastLockoutDate;
            }
        }
        public override DateTime LastLoginDate
        {
            get
            {
                return base.LastLoginDate;
            }
            set
            {
                _userData.LastLoginDate = value;
                base.LastLoginDate = value;
            }
        }
        public override DateTime LastPasswordChangedDate
        {
            get
            {
                return base.LastPasswordChangedDate;
            }
        }
        public override string PasswordQuestion
        {
            get
            {
                return base.PasswordQuestion;
            }
        }
        public override string ProviderName
        {
            get
            {
                return base.ProviderName;
            }
        }
        public override object ProviderUserKey
        {
            get
            {
                return base.ProviderUserKey;
            }
        }
        public override string UserName
        {
            get
            {
                return _userData.UserName;
                //return base.UserName;
            }
        }
        #endregion

        #region Constructors/Destructors   
        public CustomMembershipUser(Model.UserData userData)
            : base(System.Web.Security.Membership.Provider.Name,
                userData.UserName, userData.UserName, userData.Email, userData.PasswordQuestion, userData.Comments,
                userData.IsApproved, userData.IsLockedOut, userData.CreatedDate, userData.LastLoginDate, 
                userData.LastActivityDate, userData.LastPasswordChangedDate, userData.LastLockoutDate)
        {
            DataAccess.IUserDao userDao = new DataAccess.SQLSupport.UserDataDao();
            Business.UserDataService userService = new UserDataService(System.Web.HttpContext.Current.User.Identity.Name,
                userData, userDao, new Model.SystemProperties());


            _userData = userService;
        }
        public CustomMembershipUser(Business.UserDataService userData)
            : base(System.Web.Security.Membership.Provider.Name,
                userData.UserName, userData.UserName, userData.Email, userData.PasswordQuestion, userData.Comments,
                userData.IsApproved, userData.IsLockedOut, userData.CreatedDate, userData.LastLoginDate,
                userData.LastActivityDate, userData.LastPasswordChangedDate, userData.LastLockoutDate)
        {
            _userData = userData;

        }
        public CustomMembershipUser(string providerName, Business.UserDataService userData)
            : base(providerName, userData.UserName, null, userData.Email, userData.PasswordQuestion, userData.Comments,
                userData.IsApproved, userData.IsLockedOut, userData.CreatedDate, userData.LastLoginDate, 
                userData.LastActivityDate, userData.LastPasswordChangedDate, userData.LastLockoutDate)
        {
            _userData = userData;
        }
        #endregion

        #region Methods
        public override bool ChangePassword(string oldPassword, string newPassword)
        {
            return _userData.ChangePassword(oldPassword, newPassword);            
        }
        public override bool ChangePasswordQuestionAndAnswer(string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            return _userData.ChangePasswordQuestionAndAnswer(password, newPasswordQuestion, newPasswordAnswer);
        }
        public override string GetPassword()
        {
            return _userData.GetPassword();
        }
        public override string GetPassword(string passwordAnswer)
        {
            return _userData.GetPasswordWithFormat(passwordAnswer, false);
        }
        public override string ResetPassword()
        {
            int newPasswordLength = _userData.Provider.MinRequiredPasswordLength;



            return _userData.ResetPassword(_userData.GetRandomPasswordUsingGUID (newPasswordLength), "");
        }
        public override string ResetPassword(string passwordAnswer)
        {

            int newPasswordLength = _userData.Provider.MinRequiredPasswordLength;


            return _userData.ResetPassword(_userData.GetRandomPasswordUsingGUID (newPasswordLength), passwordAnswer);
        }
        public override bool UnlockUser()
        {
            return _userData.UnlockUser();
        }


        #endregion
    }
}
