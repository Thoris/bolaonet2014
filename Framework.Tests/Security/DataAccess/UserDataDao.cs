using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using NUnit.Framework;
using System.Data;
using System.Configuration;


namespace Framework.Tests.Security.DataAccess
{
    [TestFixture]
    public class UserDataDao
    {
        #region Constants
        public const string NewUserName = "NewUser";
        public const string ExistingUser = "ExistingUser";
        public const string UserToApprove = "UserToApprove";        
        public const string UserToChangePassword = "UserToChangePWD";
        public const string UserToChangeAnswer = "UserToChangeAnswer";
        
        public const string UserToDesapprove = "UserToDesapprove";
        public const string UserToGetPassword = "UserToGetPWD";
        public const string UserToGetPasswordWithFormat = "UserToGetPWDFormat";
        public const string UserToLock = "UserToLock";
        public const string UserToUnLock = "UserToUnLock";
        public const string UserToResetPassword = "UserToReset";
        public const string UserToSetPassword = "UserToSetPWD";
        public const string UserToValidate = "UserToValidate";


        public const string OldPassword = "lastPassword";
        public const string NewPassword = "NewPassword";

        public const string OldQuestion = "OldQuestion";
        public const string NewQuestion = "NewQuestion";
        public const string OldAnswer = "OldAnswer";
        public const string NewAnswer = "NewAnswer";



        //public const string Application = "Application";


        //public const string ConnectionName = "ConnectionName";
        //public const string ProviderName = "System.Data.SqlClient";
        //public const string ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Sources\BolaoNet.mdf;Integrated Security=True;User Instance=True";

        #endregion

        #region Variables

        private ConnectionStringSettings _connectionStringSettings = null;

        private Framework.DataServices.CommonDatabase _commonDatabase = null;

        #endregion

        #region Constructors/Destructors
        public UserDataDao()
        {
        }
        [TestFixtureSetUp]
        public void Init()
        {

            _connectionStringSettings = new ConnectionStringSettings(Constants.ConnectionName, Constants.ConnectionString, Constants.ProviderName);


            _commonDatabase = new Framework.DataServices.CommonDatabase(
                    _connectionStringSettings.Name, 
                    _connectionStringSettings.ConnectionString, 
                    _connectionStringSettings.ProviderName);

            //Delete all users
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "DELETE FROM " + Framework.Dao.Constants.DefaultTableUsers,
                false, 
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Manage user existing
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, Password) VALUES ('" + ExistingUser + "','" + OldPassword + "')",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //User to approve
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, IsApproved) VALUES ('" + UserToApprove + "'," + "0" + ")",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //User to Change the password
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, Password) VALUES ('" + UserToChangePassword + "','" + OldPassword + "')",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);


            //User to Change the answer
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, Password, PasswordQuestion, PasswordAnswer) VALUES ('" + 
                UserToChangeAnswer + "','" + OldPassword + "','" + OldQuestion + "','" + OldAnswer + "')",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //User to desapprove
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, IsApproved) VALUES ('" + UserToDesapprove + "'," + "1" + ")",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //User to get the password
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, Password, PasswordAnswer, IsLockedOut) VALUES ('" + UserToGetPassword + "','" + OldPassword + "','" + OldAnswer + "', 0)",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);


            //User to lock
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, IsLockedOut) VALUES ('" + UserToLock + "', 0)",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //User to Reset Password
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, Password, PasswordQuestion, PasswordAnswer, IsLockedOut) VALUES ('" + 
                UserToResetPassword + "','" + OldPassword + "','" + OldQuestion + "','" + OldAnswer + "', 0)",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //User to Set the password
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, Password) VALUES ('" + UserToSetPassword + "','" + OldPassword + "')",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);


            //User to Unlock
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, IsLockedOut) VALUES ('" + UserToUnLock + "', 1)",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //User to Validate
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, Password) VALUES ('" + UserToValidate + "', '" + OldPassword + "')",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);


        }
        [TearDown]
        public void Cleanup()
        {
            _connectionStringSettings = new ConnectionStringSettings(Constants.ConnectionName, Constants.ConnectionString, Constants.ProviderName);


            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(
                    _connectionStringSettings.Name,
                    _connectionStringSettings.ConnectionString,
                    _connectionStringSettings.ProviderName);


            commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "DELETE FROM " + Framework.Dao.Constants.DefaultTableUsers +
                " WHERE UserName='" + ExistingUser + "'",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);


        }
        #endregion

        #region Methods      
        [Test]
        public void ApproveUser()
        {
            //Framework.Security.Model.UserData userData =
            //                new Framework.Security.Model.UserData(UserToApprove);


            //Framework.Security.DataAccess.UserDataDao userDataDao =
            //    new Framework.Security.DataAccess.UserDataDao(
            //        Constants.Application, _connectionStringSettings,
            //        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            //        );

            //Assert.AreEqual(true, userDataDao.ApproveUser(userData));

            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT IsApproved FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + UserToApprove + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, true);
        }
        [Test]
        public void ChangePassword()
        {
            //Framework.Security.Model.UserData userData =
            //                new Framework.Security.Model.UserData(UserToChangePassword );


            //Framework.Security.DataAccess.UserDataDao userDataDao =
            //    new Framework.Security.DataAccess.UserDataDao(
            //        Constants.Application, _connectionStringSettings,
            //        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            //        );

            //Assert.AreEqual(true, userDataDao.ChangePassword(userData, MembershipPasswordFormat.Clear, OldPassword, NewPassword));

            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT Password FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + UserToChangePassword + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, NewPassword);
        }
        [Test]
        public void ChangePasswordQuestionAndAnswer()
        {
            //Framework.Security.Model.UserData userData =
            //    new Framework.Security.Model.UserData(UserToChangeAnswer);


            //Framework.Security.DataAccess.UserDataDao userDataDao =
            //    new Framework.Security.DataAccess.UserDataDao(
            //        Constants.Application, _connectionStringSettings,
            //        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            //        );

            //Assert.AreEqual(true, userDataDao.ChangePasswordQuestionAndAnswer(userData, MembershipPasswordFormat.Clear, NewQuestion, NewAnswer));



            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT PasswordAnswer FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + UserToChangeAnswer + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result,NewAnswer);


            //result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT PasswordQuestion FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + UserToChangeAnswer + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, NewQuestion);

        }
        [Test]
        public void CreateUser()
        {
            //Framework.Security.Model.UserData userData = 
            //    new Framework.Security.Model.UserData (NewUserName);

            
            //Framework.Security.DataAccess.UserDataDao userDataDao = 
            //    new Framework.Security.DataAccess.UserDataDao (
            //        Constants.Application, _connectionStringSettings,
            //        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            //        );

            //MembershipCreateStatus status = userDataDao.CreateUser(userData, MembershipPasswordFormat.Clear, true );

            //Assert.AreEqual(status, MembershipCreateStatus.Success);

            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT UserName FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + NewUserName + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, NewUserName);
        }
        [Test]
        public void DesapproveUser()
        {
            //Framework.Security.Model.UserData userData =
            //    new Framework.Security.Model.UserData(UserToDesapprove);


            //Framework.Security.DataAccess.UserDataDao userDataDao =
            //    new Framework.Security.DataAccess.UserDataDao(
            //        Constants.Application, _connectionStringSettings,
            //        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            //        );

            //Assert.AreEqual(true, userDataDao.DesapproveUser(userData));


            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT IsApproved FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + UserToDesapprove + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, false);
        }
        [Test]
        public void GetPassword()
        {
            //Framework.Security.Model.UserData userData =
            //    new Framework.Security.Model.UserData(UserToGetPassword);


            //Framework.Security.DataAccess.UserDataDao userDataDao =
            //    new Framework.Security.DataAccess.UserDataDao(
            //        Constants.Application, _connectionStringSettings,
            //        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            //        );

            //string password = userDataDao.GetPassword(userData, 3, 0, OldAnswer);


            //Assert.AreEqual(password, OldPassword);
        }
        [Test]
        public void GetPasswordWithFormat()
        {
            //Framework.Security.Model.UserData userData =
            //    new Framework.Security.Model.UserData(UserToGetPasswordWithFormat);


            //Framework.Security.DataAccess.UserDataDao userDataDao =
            //    new Framework.Security.DataAccess.UserDataDao(
            //        Constants.Application, _connectionStringSettings,
            //        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            //        );

            //string password = userDataDao.GetPasswordWithFormat(userData);

        }
        [Test]
        public void LockUser()
        {
            //Framework.Security.Model.UserData userData =
            //                new Framework.Security.Model.UserData(UserToLock);


            //Framework.Security.DataAccess.UserDataDao userDataDao =
            //    new Framework.Security.DataAccess.UserDataDao(
            //        Constants.Application, _connectionStringSettings,
            //        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            //        );

            //Assert.AreEqual(true, userDataDao.LockUser(userData));


            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT IsLockedOut FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + UserToLock + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, true);

        }
        [Test]
        public void ResetPassword()
        {
            //Framework.Security.Model.UserData userData =
            //                new Framework.Security.Model.UserData(UserToResetPassword);


            //Framework.Security.DataAccess.UserDataDao userDataDao =
            //    new Framework.Security.DataAccess.UserDataDao(
            //        Constants.Application, _connectionStringSettings,
            //        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            //        );

            //Assert.AreEqual(OldAnswer, userDataDao.ResetPassword(userData, MembershipPasswordFormat.Clear, 3, 1, NewPassword, OldAnswer));



            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT PasswordAnswer FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + UserToResetPassword + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, OldAnswer);


        }
        [Test]
        public void SetPassword()
        {
            //Framework.Security.Model.UserData userData =
            //                new Framework.Security.Model.UserData(UserToSetPassword);


            //Framework.Security.DataAccess.UserDataDao userDataDao =
            //    new Framework.Security.DataAccess.UserDataDao(
            //        Constants.Application, _connectionStringSettings,
            //        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            //        );

            //Assert.AreEqual(true, userDataDao.SetPassword(userData, MembershipPasswordFormat.Clear, NewPassword));


            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT Password FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + UserToSetPassword + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, NewPassword);


        }        
        [Test]
        public void UnLockUser()
        {
            //Framework.Security.Model.UserData userData =
            //                new Framework.Security.Model.UserData(UserToUnLock);


            //Framework.Security.DataAccess.UserDataDao userDataDao =
            //    new Framework.Security.DataAccess.UserDataDao(
            //        Constants.Application, _connectionStringSettings,
            //        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            //        );

            //Assert.AreEqual(true, userDataDao.UnlockUser(userData));


            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT IsLockedOut FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + UserToUnLock + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, false);
        }
        [Test]
        public void UpdateUser()
        {
            //Framework.Security.Model.UserData userData =
            //                new Framework.Security.Model.UserData(ExistingUser);


            //Framework.Security.DataAccess.UserDataDao userDataDao =
            //    new Framework.Security.DataAccess.UserDataDao(
            //        Constants.Application, _connectionStringSettings,
            //        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            //        );

            //Assert.AreEqual(true, userDataDao.UpdateUser(userData, false));
        }
        [Test]
        public void UpdateUserInfo()
        {
            //Framework.Security.Model.UserData userData =
            //                new Framework.Security.Model.UserData(ExistingUser);


            //Framework.Security.DataAccess.UserDataDao userDataDao =
            //    new Framework.Security.DataAccess.UserDataDao(
            //        Constants.Application, _connectionStringSettings,
            //        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            //        );

            //Assert.AreEqual(true, userDataDao.UpdateUserInfo(userData, true, 3, 1));
        }
        [Test]
        public void ValidateUser()
        {
            //Framework.Security.Model.UserData userData =
            //                new Framework.Security.Model.UserData(ExistingUser);


            //Framework.Security.DataAccess.UserDataDao userDataDao =
            //    new Framework.Security.DataAccess.UserDataDao(
            //        Constants.Application, _connectionStringSettings,
            //        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            //        );

            //Assert.AreEqual(true, userDataDao.ValidateUser(userData, OldPassword, 1, 3));
        }
        [Test]
        public void LoadUser()
        {
            ////Framework.Security.Model.UserData userData =
            ////                new Framework.Security.Model.UserData(ExistingUser);


            //Framework.Security.DataAccess.UserDataDao userDataDao =
            //    new Framework.Security.DataAccess.UserDataDao(
            //        Constants.Application, _connectionStringSettings,
            //        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            //        );

            //userDataDao.LoadUser(ExistingUser);

            ////Assert.AreEqual(true, userDataDao.ValidateUser("Password", 1, 3));
        }
        #endregion
    }
}
