using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web.Security;
using Framework.Logging.Logger;

namespace Framework.Security.Business
{
    public class UserDataService : Model.UserData, IUserDataService
    {      
        #region Variables
        private DataAccess.IUserDao _userDao = null;
        private Model.ISystemProperties _provider = null;
        private string _currentLogin = null;
        #endregion

        #region Properties
        public Model.ISystemProperties Provider
        {
            get { return _provider; }
        }
        #endregion

        #region Constructors/Destructors
        public UserDataService(string currentLogin)
        {
            _currentLogin = currentLogin;
            _userDao = new Framework.Security.DataAccess.SQLSupport.UserDataDao();
            _provider = new Framework.Security.Model.SystemProperties();
        }

        public UserDataService(string currentLogin, Model.UserData userData)
        {
            base.Copy(userData);

            _currentLogin = currentLogin;

            _userDao = new Framework.Security.DataAccess.SQLSupport.UserDataDao();
            _provider = new Framework.Security.Model.SystemProperties();
        }

        public UserDataService(string currentLogin, Model.UserData userData, DataAccess.IUserDao dao, Model.ISystemProperties provider)
            : this (currentLogin, dao, provider)
        {
            _currentLogin = currentLogin;

            base.Copy(userData);
        }

        public UserDataService(string currentLogin, DataAccess.IUserDao dao, Model.ISystemProperties provider)
        {
            _userDao = dao;
            _provider = provider;

            _currentLogin = currentLogin;
        }
        #endregion

        #region IUserDataService Methods
        public bool ApproveUser()
        {
            int errorNumber = 0;
            string errorDescription = "";

            bool result = _userDao.ApproveUser (_currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "User " + this.UserName + " cannot be approved", errorDescription); 
                return false;
            }

            if (result)            
                LogManager.WriteTrace(_currentLogin, this, "User " + this.UserName + " is approved", null);            
            else            
                LogManager.WriteWarning(_currentLogin, this, "User " + this.UserName + " cannot be approved", null);
            


            return result;

        }
        public bool ChangePassword(string oldPassword, string newPassword)
        {
            int errorNumber = 0;
            string errorDescription = "";

            bool result = _userDao.ChangePassword(_currentLogin, this, _provider.PasswordFormat, oldPassword, newPassword, 
                out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "User " + this.UserName + " cannot change the password", errorDescription);
                return false;
            }

            if (result)
                LogManager.WriteTrace(_currentLogin, this, "The password of user " + this.UserName + " has changed", null);
            else
                LogManager.WriteWarning(_currentLogin, this, "User " + this.UserName + " cannot change the password", null);


            return result;

        }
        public bool ChangePasswordQuestionAndAnswer(string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            int errorNumber = 0;
            string errorDescription = "";

            bool result = _userDao.ChangePasswordQuestionAndAnswer(_currentLogin, this, _provider.PasswordFormat, newPasswordQuestion, newPasswordAnswer,
                out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "User " + this.UserName + " cannot change the answer.", errorDescription);
                return false;
            }

            if (result)
                LogManager.WriteTrace(_currentLogin, this, "The answer of the user " + this.UserName + " has changed", null);
            else
                LogManager.WriteWarning(_currentLogin, this, "User " + this.UserName + " cannot change the answer.", null);


            return result;

        }
        public MembershipCreateStatus CreateUser()
        {
            int errorNumber = 0;
            string errorDescription = "";

            MembershipCreateStatus result = _userDao.CreateUser(_currentLogin, this, _provider.PasswordFormat, _provider.RequiresUniqueEmail, 
                out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "User " + this.UserName + " cannot be created.", errorDescription);
                return result;
            }

            if (result == MembershipCreateStatus.Success)
                LogManager.WriteTrace(_currentLogin, this, "User " + this.UserName + " has created.", null);
            else
                LogManager.WriteWarning(_currentLogin, this, "User " + this.UserName + " couldn't be created. Error: " + result.ToString(), null);



            return result;

        }
        public bool DesapproveUser()
        {
            int errorNumber = 0;
            string errorDescription = "";

            bool result = _userDao.DesapproveUser(_currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "User " + this.UserName + " cannot be desapproved.", errorDescription);
                return false;
            }

            if (result)
                LogManager.WriteTrace(_currentLogin, this, "User " + this.UserName + " has desapproved.", null);
            else
                LogManager.WriteWarning(_currentLogin, this, "User " + this.UserName + " cannot be desapproved.", null);


            return result;
        }
        public string GetPassword()
        {
            int errorNumber = 0;
            string errorDescription = "";

            string result = _userDao.GetPassword(_currentLogin, this, _provider.MaxInvalidPasswordAttempts, _provider.PasswordAttemptWindow, base.PasswordAnswer,
                out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Cannot get the password of the user " + this.UserName, errorDescription);
                return null;
            }

            LogManager.WriteTrace(_currentLogin, this, "User " +  this.UserName + " requested his password", null);

            return result;
        }
        public string GetPasswordWithFormat(string passwordAnswer, bool updateLastLoginActivityDate)
        {
            int errorNumber = 0;
            string errorDescription = "";

            base.PasswordAnswer = passwordAnswer;
            string result = _userDao.GetPasswordWithFormat(_currentLogin, this, updateLastLoginActivityDate, out errorNumber, out errorDescription);




            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Couldn't get the password with format from the user " + this.UserName, errorDescription);
                return null;
            }

            LogManager.WriteTrace(_currentLogin, this, "User " + this.UserName + " requested his password with format.", null);



            if (string.Compare(result, passwordAnswer, true) != 0)
                throw new MembershipPasswordException("The answer is invalid.");


            return result;
        }
        public bool LockUser()
        {
            int errorNumber = 0;
            string errorDescription = "";

            bool result = _userDao.LockUser(_currentLogin, this, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "User " + this.UserName + " cannot be locked.", errorDescription);
                return false;
            }

            if (result)
                LogManager.WriteTrace(_currentLogin, this, "User " + this.UserName + " has locked.", null);
            else
                LogManager.WriteWarning(_currentLogin, this, "User " + this.UserName + " cannot be locked.", null);

            return result;
        }
        public string ResetPassword(string newPassword, string answer)
        {
            int errorNumber = 0;
            string errorDescription = "";

            string result = _userDao.ResetPassword(_currentLogin, this, _provider.PasswordFormat, _provider.MaxInvalidPasswordAttempts, 
                _provider.PasswordAttemptWindow, newPassword, answer, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Password from user " + this.UserName + " cannot be reseted.", errorDescription);
                return null;
            }

            LogManager.WriteTrace(_currentLogin, this, "Password from user " + this.UserName + " has reseted.", null);

            return result;

        }
        public bool SetPassword(string newPassword)
        {
            int errorNumber = 0;
            string errorDescription = "";

            bool result = _userDao.SetPassword(_currentLogin, this, _provider.PasswordFormat, newPassword, 
                out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Cannot set the password from user " + this.UserName, errorDescription);
                return false;
            }

            if (result)
                LogManager.WriteTrace(_currentLogin, this, "Password from user " + this.UserName + " has set.", null);
            else
                LogManager.WriteWarning(_currentLogin, this, "Cannot set the password from user " + this.UserName, null);



            return result;
        }
        public bool UnlockUser()
        {
            int errorNumber = 0;
            string errorDescription = "";

            bool result = _userDao.UnlockUser(_currentLogin, this, out errorNumber, out errorDescription);


            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "User " + this.UserName + " cannot be unlocked.", errorDescription);
                return false;
            }

            if (result)
                LogManager.WriteTrace(_currentLogin, this, "User " + this.UserName + " has unlocked.", null);
            else
                LogManager.WriteWarning(_currentLogin, this, "User " + this.UserName + " cannot be unlocked.", null);

            return result;
        }
        public bool UpdateUser()
        {
            int errorNumber = 0;
            string errorDescription = "";

            bool result = _userDao.UpdateUser(_currentLogin, this, _provider.RequiresUniqueEmail, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "User " + this.UserName + " could not be updated.", errorDescription);
                return false;
            }

            if (result)
                LogManager.WriteTrace(_currentLogin, this, "User " + this.UserName + " has updated.", null);
            else
                LogManager.WriteWarning(_currentLogin, this, "User " + this.UserName + " could not be updated.", null);


            return result;
        }
        public bool UpdateUserInfo(bool updateLastLoginActivityDate)
        {
            int errorNumber = 0;
            string errorDescription = "";

            bool result = _userDao.UpdateUserInfo(_currentLogin, this, updateLastLoginActivityDate, _provider.MaxInvalidPasswordAttempts, 
                _provider.PasswordAttemptWindow, out errorNumber, out errorDescription);


            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Cannot update the user info from user " + this.UserName, errorDescription);
                return false;
            }

            if (result)
                LogManager.WriteTrace(_currentLogin, this, "User " + this.UserName + " had his data updated.", null);
            else
                LogManager.WriteWarning(_currentLogin, this, "Cannot update the user info from user " + this.UserName, null);


            return result;
        }
        public bool ValidateUser(string password)
        {
            int errorNumber = 0;
            string errorDescription = "";

            bool result = _userDao.ValidateUser(_currentLogin, this, password, _provider.PasswordAttemptWindow,
                _provider.MaxInvalidPasswordAttempts, out errorNumber, out errorDescription);

            if (result)            
                LogManager.WriteSuccessAudit(base.UserName, "Authentication Success.");
            else
                LogManager.WriteFailureAudit(base.UserName, "User credentials could not be authenticated.");
            

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
                return false;


            return result;
        }
        public Model.UserData LoadUser()
        {
            int errorNumber = 0;
            string errorDescription = "";

            Model.UserData result = _userDao.LoadUser(_currentLogin, this.UserName, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Cannot load the user " + this.UserName, errorDescription);
                return null;
            }

            LogManager.WriteTrace(_currentLogin, this, "User " + this.UserName + " loaded.", null);

            return result;
        }
        public bool DeleteUser(bool deleteAllRelatedData)
        {
            int errorNumber = 0;
            string errorDescription = "";

            bool result = _userDao.DeleteUser(_currentLogin, this, deleteAllRelatedData, out errorNumber, out errorDescription);


            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "User " + this.UserName + " cannot be deleted.", errorDescription);
                return false;
            }

            if (result)
                LogManager.WriteTrace (_currentLogin, this, "User " + this.UserName + " has deleted.", null);
            else
                LogManager.WriteWarning(_currentLogin, this, "User " + this.UserName + " cannot be deleted.", null);

            return result;

        }
        #endregion

        #region Methods
        public string GetRandomPasswordUsingGUID(int length)
        {
            // Get the GUID
            string guidResult = System.Guid.NewGuid().ToString();

            // Remove the hyphens
            guidResult = guidResult.Replace("-", string.Empty);

            // Make sure length is valid
            if (length <= 0 || length > guidResult.Length)
                throw new ArgumentException("Length must be between 1 and " + guidResult.Length);

            // Return the first length bytes
            return guidResult.Substring(0, length);
        }
        #endregion
    }
}
