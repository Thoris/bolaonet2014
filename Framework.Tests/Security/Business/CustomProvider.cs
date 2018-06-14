using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using NUnit.Framework;
using System.Web.Security;
using System.Data;

namespace Framework.Tests.Security.Business
{
    [TestFixture]
    public class CustomProvider
    {
        #region Variables
        private ConnectionStringSettings _connectionStringSettings = null;
        private Framework.DataServices.CommonDatabase _commonDatabase = null;
        private Framework.Security.Model.SystemProperties _provider = null;
        #endregion

        #region Constructors/Destructors
        public CustomProvider()
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


            //_userDao = new Framework.Security.DataAccess.UserDataDao(Constants.Application,
            //    _connectionStringSettings, Constants.CurrentUser);


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
        public void Test()
        {
            Membership.Provider.ChangePassword("", "", "");
            Membership.Provider.ChangePasswordQuestionAndAnswer("", "", "", "");

            MembershipCreateStatus status = MembershipCreateStatus.ProviderError;
            Membership.Provider.CreateUser("", "", "", "", "", true, null, out status);

            Membership.Provider.DeleteUser("", true);
            int totalRecords = 0;

            Membership.Provider.FindUsersByEmail("", 0, 10, out totalRecords);
            Membership.Provider.FindUsersByName("", 0, 10, out totalRecords);
            Membership.Provider.GetAllUsers(0, 10, out totalRecords);
            Membership.Provider.GetNumberOfUsersOnline();
            Membership.Provider.GetPassword("", "");
            Membership.Provider.GetUser("", false);
            Membership.Provider.GetUserNameByEmail("");
            Membership.Provider.ResetPassword("", "");
            Membership.Provider.UnlockUser("");
            Membership.Provider.UpdateUser(null);
            Membership.Provider.ValidateUser("", "");

        }
        #endregion
    }
}
