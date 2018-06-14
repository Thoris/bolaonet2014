using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Configuration;
using System.Text;
using System.Web.Security;
using System.Data;

namespace Framework.Tests.Security.Business
{
    [TestFixture]
    public class UserManagerService
    {
        #region Constants
        public readonly string [] ListOfUsersToInsert = {"User1_Test", "User2_Test", "User3_Test", DataAccess.UserManagerDao.UserNameToMatch, "User4_Test"};
        #endregion

        #region Variables
        private ConnectionStringSettings _connectionStringSettings = null;
        private Framework.DataServices.CommonDatabase _commonDatabase = null;
        
        #endregion

        #region Constructors/Destructors
        public UserManagerService()
        {
        }
        [TestFixtureSetUp]
        public void Init()
        {
            _connectionStringSettings = new ConnectionStringSettings(
                Constants.ConnectionName, Constants.ConnectionString, Constants.ProviderName);


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





            foreach (string userName in ListOfUsersToInsert)
            {
                DeleteUserName(userName);
                InsertUserName(userName);
            }


        }
        [TearDown]
        public void Cleanup()
        {
        }
        #endregion

        #region Methods
        private void DeleteUserName(string userName)
        {
            _commonDatabase.ExecuteNonQuery(CommandType.Text,
                "DELETE " + Framework.Dao.Constants.DefaultTableUsers + " WHERE username = '" + userName + "'",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);
        }
        private void InsertUserName(string userName)
        {
            _commonDatabase.ExecuteNonQuery(CommandType.Text,
                "INSERT INTO " + Framework.Dao.Constants.DefaultTableUsers + " (UserName,Password,Email) VALUES " +
                "('" + userName + "','" + userName + "','" + userName + "')",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);
        }


        [Test]
        public void FindUsersByEmail()
        {
            int totalRecords = -1;

            MembershipProvider provider = new Framework.Security.Business.UserManagerService();

            MembershipUserCollection list = provider.FindUsersByEmail(DataAccess.UserManagerDao.EmailToMatch,
                DataAccess.UserManagerDao.PageIndex, DataAccess.UserManagerDao.PageSize, out totalRecords);


            Assert.IsNotNull(list);

            Assert.AreNotEqual(totalRecords, -1);

            Assert.AreEqual(totalRecords, list.Count);


            object result = _commonDatabase.ExecuteScalar(CommandType.Text,
                "SELECT Count(*) FROM " + Framework.Dao.Constants.DefaultTableUsers
                + " WHERE email = '" + DataAccess.UserManagerDao.EmailToMatch + "'",
                true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            Assert.AreEqual(result, totalRecords);


        }
        [Test]
        public void FindUsersByName()
        {

            int totalRecords = -1;

            MembershipProvider provider = new Framework.Security.Business.UserManagerService();

            MembershipUserCollection list = provider.FindUsersByName(DataAccess.UserManagerDao.UserNameToMatch,
                DataAccess.UserManagerDao.PageIndex, DataAccess.UserManagerDao.PageSize, out totalRecords);

            Assert.IsNotNull(list);

            Assert.AreNotEqual(totalRecords, -1);

            Assert.AreEqual(totalRecords, list.Count);


            object result = _commonDatabase.ExecuteScalar(CommandType.Text,
                "SELECT Count(*) FROM " + Framework.Dao.Constants.DefaultTableUsers
                + " WHERE UserName = '" + DataAccess.UserManagerDao.UserNameToMatch + "'",
                true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            Assert.AreEqual(result, totalRecords);  
        }
        [Test]
        public void GetAllUsers()
        {
            MembershipProvider provider = new Framework.Security.Business.UserManagerService();

            int totalRecords = -1;

            MembershipUserCollection list = provider.GetAllUsers(
                DataAccess.UserManagerDao.PageIndex, DataAccess.UserManagerDao.PageSize, out totalRecords);

            Assert.IsNotNull(list);

            Assert.AreNotEqual(totalRecords, -1);

            Assert.AreEqual(totalRecords, list.Count);


            object result = _commonDatabase.ExecuteScalar(CommandType.Text,
                "SELECT Count(*) FROM " + Framework.Dao.Constants.DefaultTableUsers,
                true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //TODO: Fix this test
            //Assert.AreEqual(result, totalRecords);        
        }
        [Test]
        public void GetNumberOfUsersOnline()
        {

            MembershipProvider provider = new Framework.Security.Business.UserManagerService();


            int totalUsers = -1;

            totalUsers = provider.GetNumberOfUsersOnline();

            Assert.AreNotEqual(totalUsers, -1);

            object result = _commonDatabase.ExecuteScalar(CommandType.Text,
                "SELECT Count(*) FROM " + Framework.Dao.Constants.DefaultTableUsers +
                " WHERE LastactivityDate > DATEADD(minute,  -(" + 10 + "), GETDATE())",
                true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            Assert.AreEqual(result, totalUsers);

        }
        [Test]
        public void GetUser()
        {

            MembershipProvider provider = new Framework.Security.Business.UserManagerService();


            MembershipUser userData = provider.GetUser(DataAccess.UserManagerDao.UserNameToMatch, false);

            Assert.IsNotNull(userData, "Couldn't load the user by name");

            object result = _commonDatabase.ExecuteScalar(CommandType.Text,
                "SELECT userName FROM " + Framework.Dao.Constants.DefaultTableUsers +
                " WHERE UserName = '" + DataAccess.UserManagerDao.UserNameToMatch + "'",
                true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            Assert.AreEqual(result, userData.UserName);
        }
        [Test]
        public void GetUserNameByEmail()
        {
            MembershipProvider provider = new Framework.Security.Business.UserManagerService();

            string userName = null;

            userName = provider.GetUserNameByEmail(DataAccess.UserManagerDao.EmailToMatch);

            Assert.IsNotNull(userName, "Couldn't find the user name specified.");


            object result = _commonDatabase.ExecuteScalar(CommandType.Text,
                "SELECT userName FROM " + Framework.Dao.Constants.DefaultTableUsers +
                " WHERE Email = '" + DataAccess.UserManagerDao.EmailToMatch + "'",
                true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            Assert.AreEqual(result, userName);
        }
        [Test]
        public void EncryptPassword()
        {
        }
        [Test]
        public void DecryptPassword()
        {
        }        
        [Test]
        public void Initialize()
        {            
        }
        
        [Test]
        public void ChangePassword()
        {
            MembershipProvider provider = new Framework.Security.Business.UserManagerService();
            
            Assert.AreEqual(true, provider.ChangePassword(DataAccess.UserDataDao.UserToChangePassword,
                DataAccess.UserDataDao.OldPassword,
                DataAccess.UserDataDao.NewPassword));

            object result = _commonDatabase.ExecuteScalar(CommandType.Text,
                "SELECT Password FROM " + Framework.Dao.Constants.DefaultTableUsers +
                " WHERE UserName = '" + DataAccess.UserDataDao.UserToChangePassword + "'",
                true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            Assert.AreEqual(result, DataAccess.UserDataDao.NewPassword);
        }
        [Test]
        public void ChangePasswordQuestionAndAnswer()
        {
            MembershipProvider provider = new Framework.Security.Business.UserManagerService();

            Assert.AreEqual(true, provider.ChangePasswordQuestionAndAnswer(
                DataAccess.UserDataDao.OldPassword,
                DataAccess.UserDataDao.UserToChangeAnswer,
                DataAccess.UserDataDao.NewQuestion,
                DataAccess.UserDataDao.NewAnswer));


            object result = _commonDatabase.ExecuteScalar(CommandType.Text,
                "SELECT PasswordAnswer FROM " + Framework.Dao.Constants.DefaultTableUsers +
                " WHERE UserName = '" + DataAccess.UserDataDao.UserToChangeAnswer + "'",
                true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            Assert.AreEqual(result, DataAccess.UserDataDao.NewAnswer);


            result = _commonDatabase.ExecuteScalar(CommandType.Text,
                "SELECT PasswordQuestion FROM " + Framework.Dao.Constants.DefaultTableUsers +
                " WHERE UserName = '" + DataAccess.UserDataDao.UserToChangeAnswer + "'",
                true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            Assert.AreEqual(result, DataAccess.UserDataDao.NewQuestion);
        }
        [Test]
        public void CreateUser()
        {
            MembershipProvider provider = new Framework.Security.Business.UserManagerService();
            
            MembershipCreateStatus status = MembershipCreateStatus.ProviderError;

            MembershipUser user = provider.CreateUser(
                DataAccess.UserDataDao.NewUserName,
                DataAccess.UserDataDao.OldPassword,
                "Email@email.com.br",
                DataAccess.UserDataDao.OldQuestion,
                DataAccess.UserDataDao.OldAnswer,
                true,
                null,
                out status);


            Assert.AreEqual(status, MembershipCreateStatus.Success);

            object result = _commonDatabase.ExecuteScalar(CommandType.Text,
                "SELECT UserName FROM " + Framework.Dao.Constants.DefaultTableUsers +
                " WHERE UserName = '" + DataAccess.UserDataDao.NewUserName + "'",
                true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            Assert.AreEqual(result, DataAccess.UserDataDao.NewUserName);
        }
        [Test]
        public void DeleteUser()
        {
        }
        [Test]
        public void GetPassword()
        {
            MembershipProvider provider = new Framework.Security.Business.UserManagerService();

            string password = provider.GetPassword(
                DataAccess.UserDataDao.UserToGetPassword,
                DataAccess.UserDataDao.OldAnswer);


            Assert.AreEqual(password, DataAccess.UserDataDao.OldPassword);
        }
        [Test]
        public void ResetPassword()
        {
            MembershipProvider provider = new Framework.Security.Business.UserManagerService();

            Assert.AreEqual(DataAccess.UserDataDao.OldAnswer, provider.ResetPassword(
                DataAccess.UserDataDao.UserToResetPassword,
                DataAccess.UserDataDao.OldAnswer));




            object result = _commonDatabase.ExecuteScalar(CommandType.Text,
                "SELECT PasswordAnswer FROM " + Framework.Dao.Constants.DefaultTableUsers +
                " WHERE UserName = '" + DataAccess.UserDataDao.UserToResetPassword + "'",
                true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            Assert.AreEqual(result, DataAccess.UserDataDao.OldAnswer);
        }
        [Test]
        public void UnlockUser()
        {

            MembershipProvider provider = new Framework.Security.Business.UserManagerService();
            Assert.AreEqual(true, provider.UnlockUser (DataAccess.UserDataDao.UserToUnLock));



            object result = _commonDatabase.ExecuteScalar(CommandType.Text,
                "SELECT IsLockedOut FROM " + Framework.Dao.Constants.DefaultTableUsers +
                " WHERE UserName = '" + DataAccess.UserDataDao.UserToUnLock + "'",
                true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            Assert.AreEqual(result, false);
        }
        [Test]
        public void UpdateUser()
        {
            MembershipProvider provider = new Framework.Security.Business.UserManagerService();
            
            


            //Framework.Security.Business.CustomMembershipUser user = new Framework.Security.Business.CustomMembershipUser (


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
        public void ValidateUser()
        {

            MembershipProvider provider = new Framework.Security.Business.UserManagerService();

            Assert.AreEqual(true, provider.ValidateUser(
                DataAccess.UserDataDao.ExistingUser, DataAccess.UserDataDao.OldPassword));

        }
        #endregion
    }
}
