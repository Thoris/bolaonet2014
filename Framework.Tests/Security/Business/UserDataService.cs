using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Data;
using System.Configuration;
using System.Web.Security;

namespace Framework.Tests.Security.Business
{
    [TestFixture]
    public class UserDataService
    {
        #region Variables
        private ConnectionStringSettings _connectionStringSettings = null;
        private Framework.DataServices.CommonDatabase _commonDatabase = null;
        private Framework.Security.DataAccess.IUserDao _userDao = null;
        private Framework.Security.Model.SystemProperties _provider = null;
        #endregion

        #region Constructors/Destructors
        public UserDataService()
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


            _userDao = new Framework.Security.DataAccess.SQLSupport.UserDataDao(Constants.Application,
                _connectionStringSettings);


            _provider = new Framework.Security.Model.SystemProperties();


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
                "(UserName, Password) VALUES ('" + DataAccess.UserDataDao.ExistingUser + "','" + DataAccess.UserDataDao.OldPassword + "')",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //User to approve
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, IsApproved) VALUES ('" + DataAccess.UserDataDao.UserToApprove + "'," + "0" + ")",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //User to Change the password
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, Password) VALUES ('" + DataAccess.UserDataDao.UserToChangePassword + "','" + DataAccess.UserDataDao.OldPassword + "')",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);


            //User to Change the answer
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, Password, PasswordQuestion, PasswordAnswer) VALUES ('" +
                DataAccess.UserDataDao.UserToChangeAnswer + "','" + DataAccess.UserDataDao.OldPassword + "','" + 
                DataAccess.UserDataDao.OldQuestion + "','" + DataAccess.UserDataDao.OldAnswer + "')",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //User to desapprove
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, IsApproved) VALUES ('" + DataAccess.UserDataDao.UserToDesapprove + "'," + "1" + ")",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //User to get the password
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, Password, PasswordAnswer, IsLockedOut) VALUES ('" + DataAccess.UserDataDao.UserToGetPassword + "','"
                + DataAccess.UserDataDao.OldPassword + "','" + DataAccess.UserDataDao.OldAnswer + "', 0)",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);


            //User to lock
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, IsLockedOut) VALUES ('" + DataAccess.UserDataDao.UserToLock + "', 0)",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //User to Reset Password
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, Password, PasswordQuestion, PasswordAnswer, IsLockedOut) VALUES ('" +
                DataAccess.UserDataDao.UserToResetPassword + "','" + DataAccess.UserDataDao.OldPassword + "','" + 
                DataAccess.UserDataDao.OldQuestion + "','" + DataAccess.UserDataDao.OldAnswer + "', 0)",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //User to Set the password
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, Password) VALUES ('" + DataAccess.UserDataDao.UserToSetPassword + "','" + DataAccess.UserDataDao.OldPassword + "')",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);


            //User to Unlock
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, IsLockedOut) VALUES ('" + DataAccess.UserDataDao.UserToUnLock + "', 1)",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //User to Validate
            _commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers +
                "(UserName, Password) VALUES ('" + DataAccess.UserDataDao.UserToValidate + "', '" + 
                DataAccess.UserDataDao.OldPassword + "')",
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
                " WHERE UserName='" + DataAccess.UserDataDao.ExistingUser + "'",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);



        }
        #endregion

        #region Methods
        [Test]
        public void ApproveUser()
        {
            ////Framework.Security.Model.UserData userData =
            ////                new Framework.Security.Model.UserData(DataAccess.UserDataDao.UserToApprove);

            //Framework.Security.Business.UserDataService userDataService =
            //    new Framework.Security.Business.UserDataService(_userDao, _provider);
            //userDataService.UserName = DataAccess.UserDataDao.UserToApprove;


            ////Framework.Security.DataAccess.UserDataDao userDataDao =
            ////    new Framework.Security.DataAccess.UserDataDao(
            ////        Constants.Application, _connectionStringSettings,
            ////        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            ////        );

            ////Assert.AreEqual(true, userDataDao.ApproveUser(userData));
            //Assert.AreEqual(true, userDataService.ApproveUser());



            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT IsApproved FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + DataAccess.UserDataDao.UserToApprove + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, true);
        }
        [Test]
        public void ChangePassword()
        {
            ////Framework.Security.Model.UserData userData =
            ////                new Framework.Security.Model.UserData(DataAccess.UserDataDao.UserToChangePassword);


            //Framework.Security.Business.UserDataService userDataService =
            //    new Framework.Security.Business.UserDataService(_userDao, _provider);
            //userDataService.UserName = DataAccess.UserDataDao.UserToChangePassword;


            ////Framework.Security.DataAccess.UserDataDao userDataDao =
            ////    new Framework.Security.DataAccess.UserDataDao(
            ////        Constants.Application, _connectionStringSettings,
            ////        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            ////        );

            //Assert.AreEqual(true, userDataService.ChangePassword(DataAccess.UserDataDao.OldPassword, DataAccess.UserDataDao.NewPassword));

            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT Password FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + DataAccess.UserDataDao.UserToChangePassword + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, DataAccess.UserDataDao.NewPassword);
        }
        [Test]
        public void ChangePasswordQuestionAndAnswer()
        {
            //Framework.Security.Model.UserData userData =
            //    new Framework.Security.Model.UserData(DataAccess.UserDataDao.UserToChangeAnswer);


            //Framework.Security.DataAccess.UserDataDao userDataDao =
            //    new Framework.Security.DataAccess.UserDataDao(
            //        Constants.Application, _connectionStringSettings,
            //        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            //        );


            //Framework.Security.Business.UserDataService userDataService =
            //    new Framework.Security.Business.UserDataService(_userDao, _provider);
            //userDataService.UserName = DataAccess.UserDataDao.UserToChangeAnswer;



            //Assert.AreEqual(true, userDataService.ChangePasswordQuestionAndAnswer(
            //    DataAccess.UserDataDao.OldPassword,
            //    DataAccess.UserDataDao.NewQuestion, DataAccess.UserDataDao.NewAnswer));



            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT PasswordAnswer FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + DataAccess.UserDataDao.UserToChangeAnswer + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, DataAccess.UserDataDao.NewAnswer);


            //result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT PasswordQuestion FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + DataAccess.UserDataDao.UserToChangeAnswer + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, DataAccess.UserDataDao.NewQuestion);

        }
        [Test]
        public void CreateUser()
        {
            //Framework.Security.Model.UserData userData =
            //    new Framework.Security.Model.UserData(DataAccess.UserDataDao.NewUserName);


            //Framework.Security.Business.UserDataService userDataService =
            //    new Framework.Security.Business.UserDataService(_userDao, _provider);
            //userDataService.UserName = DataAccess.UserDataDao.NewUserName;


            ////Framework.Security.DataAccess.UserDataDao userDataDao =
            ////    new Framework.Security.DataAccess.UserDataDao(
            ////        Constants.Application, _connectionStringSettings,
            ////        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            ////        );

            //MembershipCreateStatus status = userDataService.CreateUser();

            //Assert.AreEqual(status, MembershipCreateStatus.Success);

            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT UserName FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + DataAccess.UserDataDao.NewUserName + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, DataAccess.UserDataDao.NewUserName);
        }
        [Test]
        public void DesapproveUser()
        {
            ////Framework.Security.Model.UserData userData =
            ////    new Framework.Security.Model.UserData(DataAccess.UserDataDao.UserToDesapprove);


            //Framework.Security.Business.UserDataService userDataService =
            //    new Framework.Security.Business.UserDataService(_userDao, _provider);
            //userDataService.UserName = DataAccess.UserDataDao.UserToDesapprove;

            ////Framework.Security.DataAccess.UserDataDao userDataDao =
            ////    new Framework.Security.DataAccess.UserDataDao(
            ////        Constants.Application, _connectionStringSettings,
            ////        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            ////        );

            //Assert.AreEqual(true, userDataService.DesapproveUser());


            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT IsApproved FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + DataAccess.UserDataDao.UserToDesapprove + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, false);
        }
        [Test]
        public void GetPassword()
        {
            ////Framework.Security.Model.UserData userData =
            ////    new Framework.Security.Model.UserData(DataAccess.UserDataDao.UserToGetPassword);


            //Framework.Security.Business.UserDataService userDataService =
            //    new Framework.Security.Business.UserDataService(_userDao, _provider);
            //userDataService.UserName = DataAccess.UserDataDao.UserToGetPassword;
            //userDataService.Password = DataAccess.UserDataDao.OldPassword;
            //userDataService.PasswordAnswer = DataAccess.UserDataDao.OldAnswer;



            ////Framework.Security.DataAccess.UserDataDao userDataDao =
            ////    new Framework.Security.DataAccess.UserDataDao(
            ////        Constants.Application, _connectionStringSettings,
            ////        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            ////        );

            //string password = userDataService.GetPassword();


            //Assert.AreEqual(password, DataAccess.UserDataDao.OldPassword);
        }
        [Test]
        public void GetPasswordWithFormat()
        {
            ////Framework.Security.Model.UserData userData =
            ////    new Framework.Security.Model.UserData(DataAccess.UserDataDao.UserToGetPasswordWithFormat);

            //Framework.Security.Business.UserDataService userDataService =
            //    new Framework.Security.Business.UserDataService(_userDao, _provider);
            //userDataService.UserName = DataAccess.UserDataDao.UserToGetPasswordWithFormat;


            ////Framework.Security.DataAccess.UserDataDao userDataDao =
            ////    new Framework.Security.DataAccess.UserDataDao(
            ////        Constants.Application, _connectionStringSettings,
            ////        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            ////        );

            //string password = userDataService.GetPasswordWithFormat(DataAccess.UserDataDao.OldAnswer);



        }
        [Test]
        public void LockUser()
        {
            ////Framework.Security.Model.UserData userData =
            ////                new Framework.Security.Model.UserData(DataAccess.UserDataDao.UserToLock);


            //Framework.Security.Business.UserDataService userDataService =
            //    new Framework.Security.Business.UserDataService(_userDao, _provider);
            //userDataService.UserName = DataAccess.UserDataDao.UserToLock;


            ////Framework.Security.DataAccess.UserDataDao userDataDao =
            ////    new Framework.Security.DataAccess.UserDataDao(
            ////        Constants.Application, _connectionStringSettings,
            ////        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            ////        );

            //Assert.AreEqual(true, userDataService.LockUser());


            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT IsLockedOut FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + DataAccess.UserDataDao.UserToLock + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, true);

        }
        [Test]
        public void ResetPassword()
        {
            ////Framework.Security.Model.UserData userData =
            ////                new Framework.Security.Model.UserData(DataAccess.UserDataDao.UserToResetPassword);


            //Framework.Security.Business.UserDataService userDataService =
            //    new Framework.Security.Business.UserDataService(_userDao, _provider);
            //userDataService.UserName = DataAccess.UserDataDao.UserToResetPassword;



            ////Framework.Security.DataAccess.UserDataDao userDataDao =
            ////    new Framework.Security.DataAccess.UserDataDao(
            ////        Constants.Application, _connectionStringSettings,
            ////        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            ////        );

            //Assert.AreEqual(DataAccess.UserDataDao.OldAnswer, userDataService.ResetPassword(
            //    DataAccess.UserDataDao.NewPassword, DataAccess.UserDataDao.OldAnswer));



            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT PasswordAnswer FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + DataAccess.UserDataDao.UserToResetPassword + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, DataAccess.UserDataDao.OldAnswer);


        }
        [Test]
        public void SetPassword()
        {
            ////Framework.Security.Model.UserData userData =
            ////                new Framework.Security.Model.UserData(DataAccess.UserDataDao.UserToSetPassword);


            //Framework.Security.Business.UserDataService userDataService =
            //    new Framework.Security.Business.UserDataService(_userDao, _provider);
            //userDataService.UserName = DataAccess.UserDataDao.UserToSetPassword;


            ////Framework.Security.DataAccess.UserDataDao userDataDao =
            ////    new Framework.Security.DataAccess.UserDataDao(
            ////        Constants.Application, _connectionStringSettings,
            ////        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            ////        );

            //Assert.AreEqual(true, userDataService.SetPassword(DataAccess.UserDataDao.NewPassword));


            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT Password FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + DataAccess.UserDataDao.UserToSetPassword + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, DataAccess.UserDataDao.NewPassword);


        }
        [Test]
        public void UnLockUser()
        {
            ////Framework.Security.Model.UserData userData =
            ////                new Framework.Security.Model.UserData(DataAccess.UserDataDao.UserToUnLock);


            //Framework.Security.Business.UserDataService userDataService =
            //    new Framework.Security.Business.UserDataService(_userDao, _provider);
            //userDataService.UserName = DataAccess.UserDataDao.UserToUnLock;

            ////Framework.Security.DataAccess.UserDataDao userDataDao =
            ////    new Framework.Security.DataAccess.UserDataDao(
            ////        Constants.Application, _connectionStringSettings,
            ////        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            ////        );

            //Assert.AreEqual(true, userDataService.UnlockUser());


            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT IsLockedOut FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + DataAccess.UserDataDao.UserToUnLock + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, false);
        }
        [Test]
        public void UpdateUser()
        {
            ////Framework.Security.Model.UserData userData =
            ////                new Framework.Security.Model.UserData(DataAccess.UserDataDao.ExistingUser);


            //Framework.Security.Business.UserDataService userDataService =
            //    new Framework.Security.Business.UserDataService(_userDao, _provider);
            //userDataService.UserName = DataAccess.UserDataDao.ExistingUser;

            ////Framework.Security.DataAccess.UserDataDao userDataDao =
            ////    new Framework.Security.DataAccess.UserDataDao(
            ////        Constants.Application, _connectionStringSettings,
            ////        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            ////        );

            //Assert.AreEqual(true, userDataService.UpdateUser());
        }
        [Test]
        public void UpdateUserInfo()
        {
            ////Framework.Security.Model.UserData userData =
            ////                new Framework.Security.Model.UserData(DataAccess.UserDataDao.ExistingUser);


            //Framework.Security.Business.UserDataService userDataService =
            //    new Framework.Security.Business.UserDataService(_userDao, _provider);
            //userDataService.UserName = DataAccess.UserDataDao.ExistingUser;


            ////Framework.Security.DataAccess.UserDataDao userDataDao =
            ////    new Framework.Security.DataAccess.UserDataDao(
            ////        Constants.Application, _connectionStringSettings,
            ////        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            ////        );

            //Assert.AreEqual(true, userDataService.UpdateUserInfo(true));
        }
        [Test]
        public void ValidateUser()
        {
            ////Framework.Security.Model.UserData userData =
            ////                new Framework.Security.Model.UserData(DataAccess.UserDataDao.ExistingUser);

            //Framework.Security.Business.UserDataService userDataService =
            //    new Framework.Security.Business.UserDataService(_userDao, _provider);
            //userDataService.UserName = DataAccess.UserDataDao.ExistingUser;


            ////Framework.Security.DataAccess.UserDataDao userDataDao =
            ////    new Framework.Security.DataAccess.UserDataDao(
            ////        Constants.Application, _connectionStringSettings,
            ////        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            ////        );

            //Assert.AreEqual(true, userDataService.ValidateUser(DataAccess.UserDataDao.OldPassword));
        }
        [Test]
        public void LoadUser()
        {
            ////Framework.Security.Model.UserData userData =
            ////                new Framework.Security.Model.UserData(ExistingUser);


            //Framework.Security.Business.UserDataService userDataService =
            //    new Framework.Security.Business.UserDataService(_userDao, _provider);
            //userDataService.UserName = DataAccess.UserDataDao.ExistingUser;

            ////Framework.Security.DataAccess.UserDataDao userDataDao =
            ////    new Framework.Security.DataAccess.UserDataDao(
            ////        Constants.Application, _connectionStringSettings,
            ////        Framework.Tests.DataServices.CommonDatabase.CurrentUser
            ////        );

            //userDataService.LoadUser();

            ////Assert.AreEqual(true, userDataDao.ValidateUser("Password", 1, 3));
        }
        #endregion
    }
}
