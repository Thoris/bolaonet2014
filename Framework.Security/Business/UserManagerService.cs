using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Text;
using System.Configuration;
using System.Web.Configuration;
using Framework.Logging.Logger;

namespace Framework.Security.Business
{
    public class UserManagerService : MembershipProvider, IUserManagerService
    {
        #region Variables
        
        private string _currentUser = string.Empty;
        private Model.ISystemProperties _properties = null;
        private bool _initialized = false;

        private DataAccess.IUserManagerDao _userManagerDao = null;
        private DataAccess.IUserDao _userDao = null;

        #endregion

        #region Properties
        public bool Initialized
        {
            get { return _initialized; }
        }
        #endregion

        #region Constructors/Destructors
        public UserManagerService()
            : base ()
        {
            _initialized = false;
            _properties = new Model.SystemProperties();

            _userManagerDao = new DataAccess.SQLSupport.UserManagerDao();
            _userDao = new DataAccess.SQLSupport.UserDataDao();

        }
        public UserManagerService(Model.SystemProperties properties)
        {
            _initialized = true;
            _properties = properties;


            _userManagerDao = new DataAccess.SQLSupport.UserManagerDao();
            _userDao = new DataAccess.SQLSupport.UserDataDao();
        }

        public UserManagerService(DataAccess.IUserManagerDao userManagerDao, DataAccess.IUserDao userDao, Model.ISystemProperties properties)
            : base ()
        {
            _userDao = userDao;
            _userManagerDao = userManagerDao;

            _properties = properties;
        }
        #endregion

        #region Methods
        private MembershipUserCollection ConverToUserCollection(IList<Model.UserData> list)
        {
            MembershipUserCollection collection = new MembershipUserCollection();

            foreach (Model.UserData user in list)
            {
                Business.UserDataService userService = new UserDataService(_currentUser, user, _userDao, _properties);
                collection.Add ( new CustomMembershipUser(userService));
            }

            return collection;
        }
        #endregion

        #region MembershipProvider

        #region MembershipProvider Properties

        /// <summary>
        /// The name of the application using the custom membership provider.
        /// </summary>
        /// <value></value>
        /// <returns>The name of the application using the custom membership provider.</returns>
        public override string ApplicationName
        {
            get
            {
                return _properties.ApplicationName;
            }
            set
            {
                _properties.ApplicationName = value;
            }
        }
        /// <summary>
        /// Indicates whether the membership provider is configured to allow users to reset their passwords.
        /// </summary>
        /// <value></value>
        /// <returns>true if the membership provider supports password reset; otherwise, false. The default is true.</returns>
        public override bool EnablePasswordReset
        {
            get { return _properties.EnablePasswordReset; }
        }
        /// <summary>
        /// Indicates whether the membership provider is configured to allow users to retrieve their passwords.
        /// </summary>
        /// <value></value>
        /// <returns>true if the membership provider is configured to support password retrieval; otherwise, false. The default is false.</returns>
        public override bool EnablePasswordRetrieval
        {
            get { return _properties.EnablePasswordRetrieval; }
        }
        /// <summary>
        /// Gets the number of invalid password or password-answer attempts allowed before the membership user is locked out.
        /// </summary>
        /// <value></value>
        /// <returns>The number of invalid password or password-answer attempts allowed before the membership user is locked out.</returns>
        public override int MaxInvalidPasswordAttempts
        {
            get { return _properties.MaxInvalidPasswordAttempts; }
        }
        /// <summary>
        /// Gets the minimum number of special characters that must be present in a valid password.
        /// </summary>
        /// <value></value>
        /// <returns>The minimum number of special characters that must be present in a valid password.</returns>
        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return _properties.MinRequiredNonAlphanumericCharacters; }
        }
        /// <summary>
        /// Gets the minimum length required for a password.
        /// </summary>
        /// <value></value>
        /// <returns>The minimum length required for a password. </returns>
        public override int MinRequiredPasswordLength
        {
            get { return _properties.MinRequiredPasswordLength; }
        }
        /// <summary>
        /// Gets the number of minutes in which a maximum number of invalid password or password-answer attempts are allowed before the membership user is locked out.
        /// </summary>
        /// <value></value>
        /// <returns>The number of minutes in which a maximum number of invalid password or password-answer attempts are allowed before the membership user is locked out.</returns>
        public override int PasswordAttemptWindow
        {
            get { return _properties.PasswordAttemptWindow; }
        }
        /// <summary>
        /// Gets a value indicating the format for storing passwords in the membership data store.
        /// </summary>
        /// <value></value>
        /// <returns>One of the <see cref="T:System.Web.Security.MembershipPasswordFormat"/> values indicating the format for storing passwords in the data store.</returns>
        public override MembershipPasswordFormat PasswordFormat
        {
            get { return _properties.PasswordFormat; }
        }
        /// <summary>
        /// Gets the regular expression used to evaluate a password.
        /// </summary>
        /// <value></value>
        /// <returns>A regular expression used to evaluate a password.</returns>
        public override string PasswordStrengthRegularExpression
        {
            get { return _properties.PasswordStrengthRegularExpression; }
        }
        /// <summary>
        /// Gets a value indicating whether the membership provider is configured to require the user to answer a password question for password reset and retrieval.
        /// </summary>
        /// <value></value>
        /// <returns>true if a password answer is required for password reset and retrieval; otherwise, false. The default is true.</returns>
        public override bool RequiresQuestionAndAnswer
        {
            get { return _properties.RequiresQuestionAndAnswer; }
        }
        /// <summary>
        /// Gets a value indicating whether the membership provider is configured to require a unique e-mail address for each user name.
        /// </summary>
        /// <value></value>
        /// <returns>true if the membership provider requires a unique e-mail address; otherwise, false. The default is true.</returns>
        public override bool RequiresUniqueEmail
        {
            get { return _properties.RequiresUniqueEmail; }
        }
        /// <summary>
        /// Gets the friendly name used to refer to the provider during configuration.
        /// </summary>
        /// <value></value>
        /// <returns>The friendly name used to refer to the provider during configuration.</returns>
        public override string Name
        {
            get
            {
                return _properties.Name;
            }
        }
        /// <summary>
        /// Gets a brief, friendly description suitable for display in administrative tools or other user interfaces (UIs).
        /// </summary>
        /// <value></value>
        /// <returns>A brief, friendly description suitable for display in administrative tools or other UIs.</returns>
        public override string Description
        {
            get
            {
                return _properties.Description;
            }
        }
        #endregion

        #region MembershipProvider Methods
        /// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The friendly name of the provider.</param>
        /// <param name="config">A collection of the name/value pairs representing the provider-specific attributes specified in the configuration for this provider.</param>
        /// <exception cref="T:System.ArgumentNullException">The name of the provider is null.</exception>
        /// <exception cref="T:System.ArgumentException">The name of the provider has a length of zero.</exception>
        /// <exception cref="T:System.InvalidOperationException">An attempt is made to call <see cref="M:System.Configuration.Provider.ProviderBase.Initialize(System.String,System.Collections.Specialized.NameValueCollection)"/> on a provider after the provider has already been initialized.</exception>
        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            //base.Initialize(name, config);

            _properties.Initialize(name, config);

            _initialized = true;

        }        
        /// <summary>
        /// Gets user information from the data source based on the unique identifier for the membership user. Provides an option to update the last-activity date/time stamp for the user.
        /// </summary>
        /// <param name="providerUserKey">The unique identifier for the membership user to get information for.</param>
        /// <param name="userIsOnline">true to update the last-activity date/time stamp for the user; false to return user information without updating the last-activity date/time stamp for the user.</param>
        /// <returns>
        /// A <see cref="T:System.Web.Security.MembershipUser"/> object populated with the specified user's information from the data source.
        /// </returns>
        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            int errorNumber = 0;
            string errorDescription = null;


            Model.UserData userData = _userManagerDao.GetUser(_currentUser, providerUserKey.ToString(), false, userIsOnline, 
                out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentUser, this, "User could not be loaded.", errorDescription);
                return null;
            }

            if (userData == null)
            {
                LogManager.WriteWarning(_currentUser, this, "User could not be loaded.", null);
                return null;
            }
            else
            {
                LogManager.WriteTrace(_currentUser, this, "User " + providerUserKey.ToString() + " was loaded.", null);
            }

            Business.UserDataService userService = new UserDataService(_currentUser, userData, _userDao, _properties);

            return new CustomMembershipUser(userService);
        }
        /// <summary>
        /// Gets information from the data source for a user. Provides an option to update the last-activity date/time stamp for the user.
        /// </summary>
        /// <param name="username">The name of the user to get information for.</param>
        /// <param name="userIsOnline">true to update the last-activity date/time stamp for the user; false to return user information without updating the last-activity date/time stamp for the user.</param>
        /// <returns>
        /// A <see cref="T:System.Web.Security.MembershipUser"/> object populated with the specified user's information from the data source.
        /// </returns>
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {

            int errorNumber = 0;
            string errorDescription = null;

            Model.UserData userData = _userManagerDao.GetUser(_currentUser, username, false, userIsOnline, out errorNumber, out errorDescription);


            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentUser, this, "User " + username + " cannot be loaded.", errorDescription);
                return null;
            }

            if (userData == null)
            {
                LogManager.WriteWarning(_currentUser, this, "User " + username + " cannot be loaded.", null);
                return null;
            }
            else
            {
                LogManager.WriteTrace(_currentUser, this, "User " + username + " was loaded.", null);
            }

            Business.UserDataService userService = new UserDataService(_currentUser, userData, _userDao, _properties);

            return new CustomMembershipUser(userService);

        }
        /// <summary>
        /// Gets the number of users currently accessing the application.
        /// </summary>
        /// <returns>
        /// The number of users currently accessing the application.
        /// </returns>
        public override int GetNumberOfUsersOnline()
        {
            int errorNumber = 0;
            string errorDescription = null;

            int result = _userManagerDao.GetNumberOfUsersOnline(_currentUser, 1, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentUser, this, "Cannot get the number of users online", errorDescription);
                return -1;
            }

            LogManager.WriteTrace(_currentUser, this, "Getting number of users online.", null);

            return result;


            //UserManagerService userManager = new UserManagerService(_userManagerDao, _userDao, _properties);
            //return userManager.GetNumberOfUsersOnline();            
        }
        /// <summary>
        /// Gets a collection of membership users where the e-mail address contains the specified e-mail address to match.
        /// </summary>
        /// <param name="emailToMatch">The e-mail address to search for.</param>
        /// <param name="pageIndex">The index of the page of results to return. <paramref name="pageIndex"/> is zero-based.</param>
        /// <param name="pageSize">The size of the page of results to return.</param>
        /// <param name="totalRecords">The total number of matched users.</param>
        /// <returns>
        /// A <see cref="T:System.Web.Security.MembershipUserCollection"/> collection that contains a page of <paramref name="pageSize"/><see cref="T:System.Web.Security.MembershipUser"/> objects beginning at the page specified by <paramref name="pageIndex"/>.
        /// </returns>
        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {

            int errorNumber = 0;
            string errorDescription = null;

            totalRecords = 0;

            MembershipUserCollection collection = ConverToUserCollection(
                _userManagerDao.FindUsersByEmail(_currentUser, emailToMatch, pageIndex, pageSize,
                out totalRecords, out errorNumber, out errorDescription));

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentUser, this, "Could not find users by email", errorDescription);
                return null;
            }

            if (collection == null)
                LogManager.WriteWarning(_currentUser, this, "Could not find users by email", null);
            else
                LogManager.WriteTrace(_currentUser, this, "Finding users by email", null);

            return collection;

        }
        /// <summary>
        /// Gets a collection of membership users where the user name contains the specified user name to match.
        /// </summary>
        /// <param name="usernameToMatch">The user name to search for.</param>
        /// <param name="pageIndex">The index of the page of results to return. <paramref name="pageIndex"/> is zero-based.</param>
        /// <param name="pageSize">The size of the page of results to return.</param>
        /// <param name="totalRecords">The total number of matched users.</param>
        /// <returns>
        /// A <see cref="T:System.Web.Security.MembershipUserCollection"/> collection that contains a page of <paramref name="pageSize"/><see cref="T:System.Web.Security.MembershipUser"/> objects beginning at the page specified by <paramref name="pageIndex"/>.
        /// </returns>
        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {

            int errorNumber = 0;
            string errorDescription = null;

            totalRecords = 0;

            MembershipUserCollection collection = ConverToUserCollection(_userManagerDao.FindUsersByName(
                _currentUser, usernameToMatch, pageIndex, pageSize, out totalRecords, out errorNumber, out errorDescription));

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentUser, this, "Could not find users by name", errorDescription);                
                return null;
            }

            if (collection == null)
                LogManager.WriteWarning(_currentUser, this, "Could not find users by name", null);
            else
                LogManager.WriteTrace(_currentUser, this, "Finding users by name", null);

            return collection;

        }
        /// <summary>
        /// Gets a collection of all the users in the data source in pages of data.
        /// </summary>
        /// <param name="pageIndex">The index of the page of results to return. <paramref name="pageIndex"/> is zero-based.</param>
        /// <param name="pageSize">The size of the page of results to return.</param>
        /// <param name="totalRecords">The total number of matched users.</param>
        /// <returns>
        /// A <see cref="T:System.Web.Security.MembershipUserCollection"/> collection that contains a page of <paramref name="pageSize"/><see cref="T:System.Web.Security.MembershipUser"/> objects beginning at the page specified by <paramref name="pageIndex"/>.
        /// </returns>
        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {

            int errorNumber = 0;
            string errorDescription = null;

            totalRecords = 0;

            MembershipUserCollection collection = ConverToUserCollection(_userManagerDao.GetAllUsers(
                _currentUser, pageIndex, pageSize, out totalRecords, out errorNumber, out errorDescription));

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentUser, this, "Could not load all users", errorDescription);
                return null;
            }

            if (collection == null)
                LogManager.WriteWarning(_currentUser, this, "Could not load all users", null);
            else
                LogManager.WriteTrace(_currentUser, this, "Loaded all users", null);

            return collection;

        }
        /// <summary>
        /// Gets the user name associated with the specified e-mail address.
        /// </summary>
        /// <param name="email">The e-mail address to search for.</param>
        /// <returns>
        /// The user name associated with the specified e-mail address. If no match is found, return null.
        /// </returns>
        public override string GetUserNameByEmail(string email)
        {

            int errorNumber = 0;
            string errorDescription = null;

            string result = _userManagerDao.GetUserNameByEmail(_currentUser, email, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentUser, this, "Could not get user by email " + email, errorDescription);
                return null;
            }

            LogManager.WriteTrace(_currentUser, this, "Loaded user by email " + email, null);

            return result;
        }
        /// <summary>
        /// Adds a new membership user to the data source.
        /// </summary>
        /// <param name="username">The user name for the new user.</param>
        /// <param name="password">The password for the new user.</param>
        /// <param name="email">The e-mail address for the new user.</param>
        /// <param name="passwordQuestion">The password question for the new user.</param>
        /// <param name="passwordAnswer">The password answer for the new user</param>
        /// <param name="isApproved">Whether or not the new user is approved to be validated.</param>
        /// <param name="providerUserKey">The unique identifier from the membership data source for the user.</param>
        /// <param name="status">A <see cref="T:System.Web.Security.MembershipCreateStatus"/> enumeration value indicating whether the user was created successfully.</param>
        /// <returns>
        /// A <see cref="T:System.Web.Security.MembershipUser"/> object populated with the information for the newly created user.
        /// </returns>
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, password, true);
            OnValidatingPassword(args);

            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            UserDataService user = new UserDataService(_currentUser, _userDao, _properties);
            user.UserName = username;
            user.Password = password;
            user.Email = email;
            user.PasswordQuestion = passwordQuestion;
            user.PasswordAnswer = passwordAnswer;
            user.IsApproved = isApproved;
            
            CustomMembershipUser customUser = new CustomMembershipUser(user);
            status = user.CreateUser ();
            
            return GetUser(username, false);

        }
        /// <summary>
        /// Verifies that the specified user name and password exist in the data source.
        /// </summary>
        /// <param name="username">The name of the user to validate.</param>
        /// <param name="password">The password for the specified user.</param>
        /// <returns>
        /// true if the specified username and password are valid; otherwise, false.
        /// </returns>
        public override bool ValidateUser(string username, string password)
        {
            Business.UserDataService user = new UserDataService(_currentUser, _userDao, _properties);
            user.UserName = username;
            user.Password = password;

            return user.ValidateUser(password);
        }
        /// <summary>
        /// Processes a request to update the password for a membership user.
        /// </summary>
        /// <param name="username">The user to update the password for.</param>
        /// <param name="oldPassword">The current password for the specified user.</param>
        /// <param name="newPassword">The new password for the specified user.</param>
        /// <returns>
        /// true if the password was updated successfully; otherwise, false.
        /// </returns>
        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            Business.UserDataService userData = new UserDataService(_currentUser, _userDao, _properties);
            userData.UserName = username;
            userData.Password = oldPassword;

            if (userData.ValidateUser(oldPassword))
                return false;


            ValidatePasswordEventArgs args =
              new ValidatePasswordEventArgs(username, newPassword, true);

            OnValidatingPassword(args);

            if (args.Cancel)
            {
                if (args.FailureInformation != null)
                    throw args.FailureInformation;
                else
                    throw new MembershipPasswordException("Change password canceled due to new password validation failure.");
            }

            CustomMembershipUser customUser = new CustomMembershipUser(userData);
            return customUser.ChangePassword(oldPassword, newPassword);

            
        }
        /// <summary>
        /// Processes a request to update the password question and answer for a membership user.
        /// </summary>
        /// <param name="username">The user to change the password question and answer for.</param>
        /// <param name="password">The password for the specified user.</param>
        /// <param name="newPasswordQuestion">The new password question for the specified user.</param>
        /// <param name="newPasswordAnswer">The new password answer for the specified user.</param>
        /// <returns>
        /// true if the password question and answer are updated successfully; otherwise, false.
        /// </returns>
        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {            

            Business.UserDataService userData = new UserDataService (_currentUser, _userDao, _properties);
            userData.UserName = username;
            userData.Password = password;
            userData.PasswordQuestion = newPasswordQuestion;
            userData.PasswordAnswer = newPasswordAnswer;
            

            if (!userData.ValidateUser(password))
                return false;

            CustomMembershipUser customUser = new CustomMembershipUser(userData);
            return customUser.ChangePasswordQuestionAndAnswer(password, newPasswordQuestion, newPasswordAnswer);

        }
        /// <summary>
        /// Removes a user from the membership data source.
        /// </summary>
        /// <param name="username">The name of the user to delete.</param>
        /// <param name="deleteAllRelatedData">true to delete data related to the user from the database; false to leave data related to the user in the database.</param>
        /// <returns>
        /// true if the user was successfully deleted; otherwise, false.
        /// </returns>
        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            Business.UserDataService userData = new UserDataService(_currentUser, _userDao, _properties);
            userData.UserName = username;

            return userData.DeleteUser(deleteAllRelatedData) ;
        }
        /// <summary>
        /// Gets the password for the specified user name from the data source.
        /// </summary>
        /// <param name="username">The user to retrieve the password for.</param>
        /// <param name="answer">The password answer for the user.</param>
        /// <returns>
        /// The password for the specified user name.
        /// </returns>
        public override string GetPassword(string username, string answer)
        {
            string password = string.Empty;

            Business.UserDataService userData = new UserDataService(_currentUser, _userDao, _properties);
            userData.UserName = username;
            userData.PasswordAnswer = answer;



            if (!_properties.EnablePasswordRetrieval)
            {
                throw new ProviderException("Password Retrieval Not Enabled.");
            }

            if (_properties.PasswordFormat == MembershipPasswordFormat.Hashed)
            {
                throw new ProviderException("Cannot retrieve Hashed passwords.");
            }

            CustomMembershipUser customUser = new CustomMembershipUser(userData);
            password = customUser.GetPassword(answer);

            

            //if (_properties.RequiresQuestionAndAnswer && !CheckPassword(answer, passwordAnswer))
            //{
            //    UpdateFailureCount(username, FailureType.PasswordAnswer);

            //    throw new MembershipPasswordException("Incorrect password answer.");
            //}


            //if (_properties.PasswordFormat == MembershipPasswordFormat.Encrypted)
            //{
            //    password = UnEncodePassword(password);
            //}
            return password;

        }
        /// <summary>
        /// Resets a user's password to a new, automatically generated password.
        /// </summary>
        /// <param name="username">The user to reset the password for.</param>
        /// <param name="answer">The password answer for the specified user.</param>
        /// <returns>The new password for the specified user.</returns>
        public override string ResetPassword(string username, string answer)
        {

            Business.UserDataService userData = new UserDataService(_currentUser, _userDao, _properties);
            userData.UserName = username;
            userData.PasswordAnswer = answer;

            CustomMembershipUser customUser = new CustomMembershipUser(userData);



            if (!_properties.EnablePasswordReset)
            {
                throw new NotSupportedException("Password reset is not enabled.");
            }

            if (answer == null && _properties.RequiresQuestionAndAnswer)
            {
                //UpdateFailureCount(username, FailureType.PasswordAnswer);

                throw new ProviderException("Password answer required for password reset.");
            }

            string newPassword = System.Web.Security.Membership.GeneratePassword(
              _properties.MinRequiredPasswordLength, _properties.MinRequiredNonAlphanumericCharacters);


            ValidatePasswordEventArgs args =
              new ValidatePasswordEventArgs(username, newPassword, true);

            OnValidatingPassword(args);

            if (args.Cancel)
                if (args.FailureInformation != null)
                    throw args.FailureInformation;
                else
                    throw new MembershipPasswordException("Reset password canceled due to password validation failure.");



            return customUser.ResetPassword(answer);
        }
        /// <summary>
        /// Clears a lock so that the membership user can be validated.
        /// </summary>
        /// <param name="userName">The membership user whose lock status you want to clear.</param>
        /// <returns>
        /// true if the membership user was successfully unlocked; otherwise, false.
        /// </returns>
        public override bool UnlockUser(string userName)
        {
            Business.UserDataService userData = new UserDataService(_currentUser, _userDao, _properties);
            userData.UserName = userName;
            
            CustomMembershipUser customUser = new CustomMembershipUser(userData);


            return customUser.UnlockUser ();
        }
        /// <summary>
        /// Updates information about a user in the data source.
        /// </summary>
        /// <param name="user">A <see cref="T:System.Web.Security.MembershipUser"/> object that represents the user to update and the updated information for the user.</param>
        public override void UpdateUser(MembershipUser user)
        {
            CustomMembershipUser customUser = (CustomMembershipUser)user;

            customUser.UserData.UpdateUser();
            
        }
        /// <summary>
        /// Encrypts a password.
        /// </summary>
        /// <param name="password">A byte array that contains the password to encrypt.</param>
        /// <returns>
        /// A byte array that contains the encrypted password.
        /// </returns>
        /// <exception cref="T:System.Configuration.Provider.ProviderException">The <see cref="P:System.Web.Configuration.MachineKeySection.ValidationKey"/> property or <see cref="P:System.Web.Configuration.MachineKeySection.DecryptionKey"/> property is set to AutoGenerate.</exception>
        protected override byte[] EncryptPassword(byte[] password)
        {
            return base.EncryptPassword(password);
        }
        /// <summary>
        /// Decrypts an encrypted password.
        /// </summary>
        /// <param name="encodedPassword">A byte array that contains the encrypted password to decrypt.</param>
        /// <returns>
        /// A byte array that contains the decrypted password.
        /// </returns>
        /// <exception cref="T:System.Configuration.Provider.ProviderException">The <see cref="P:System.Web.Configuration.MachineKeySection.ValidationKey"/> property or <see cref="P:System.Web.Configuration.MachineKeySection.DecryptionKey"/> property is set to AutoGenerate.</exception>
        protected override byte[] DecryptPassword(byte[] encodedPassword)
        {
            return base.DecryptPassword(encodedPassword);
        }
        /// <summary>
        /// Raises the <see cref="E:System.Web.Security.MembershipProvider.ValidatingPassword"/> event if an event handler has been defined.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Web.Security.ValidatePasswordEventArgs"/> to pass to the <see cref="E:System.Web.Security.MembershipProvider.ValidatingPassword"/> event handler.</param>
        protected override void OnValidatingPassword(ValidatePasswordEventArgs e)
        {
            base.OnValidatingPassword(e);
        }        
        #endregion


        public IList<Model.UserData> LoadAllUsers()
        {

            int errorNumber = 0;
            string errorDescription = null;


            IList<Model.UserData> collection = _userManagerDao.LoadAllUsers(
                _currentUser, out errorNumber, out errorDescription);

            if (errorNumber != 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentUser, this, "Could not load all users", errorDescription);
                return null;
            }

            if (collection == null)
                LogManager.WriteWarning(_currentUser, this, "Could not load all users", null);
            else
                LogManager.WriteTrace(_currentUser, this, "Loaded all users", null);

            return collection;

        }

        #endregion
    }
}
