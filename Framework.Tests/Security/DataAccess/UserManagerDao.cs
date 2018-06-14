using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using NUnit.Framework;

namespace Framework.Tests.Security.DataAccess
{
    [TestFixture]
    public class UserManagerDao
    {
        #region Constants
        public const string EmailToMatch = "User2_Test";
        public const string UserNameToMatch = "UserNameToMatchTest";

        public const int PageIndex = 0;
        public const int PageSize = 2;

        public readonly string [] ListOfUsersToInsert = {"User1_Test", "User2_Test", "User3_Test", UserNameToMatch, "User4_Test"};
        #endregion

        #region Variables

        private ConnectionStringSettings _connectionStringSettings = null;
        private Framework.DataServices.CommonDatabase _commonDatabase = null;
 
        #endregion

        #region Constructors/Destructors
        public UserManagerDao()
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
                "('" + userName + "','" + userName + "','"  + userName + "')",
                false,
                Framework.Tests.DataServices.CommonDatabase.CurrentUser);
        }


        [Test]
        public void GetUser()
        {
            //Framework.Security.DataAccess.UserManagerDao userManagerDao =
            //    new Framework.Security.DataAccess.UserManagerDao(
            //    _connectionStringSettings.Name, _connectionStringSettings.ConnectionString, _connectionStringSettings.ProviderName);

            
            //Framework.Security.Model.UserData userData = userManagerDao.GetUser (UserNameToMatch, false, false);

            //Assert.IsNotNull(userData, "Couldn't load the user by name");

            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT userName FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE UserName = '" + UserNameToMatch + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, userData.UserName);

        }
        [Test]
        public void GetUserNameByEmail()
        {
            //Framework.Security.DataAccess.UserManagerDao userManagerDao =
            //    new Framework.Security.DataAccess.UserManagerDao(
            //    _connectionStringSettings.Name, _connectionStringSettings.ConnectionString, _connectionStringSettings.ProviderName);

            //string userName = null;

            //userName = userManagerDao.GetUserNameByEmail (EmailToMatch);

            //Assert.IsNotNull(userName, "Couldn't find the user name specified.");


            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT userName FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE Email = '" + EmailToMatch + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, userName);

        }
        [Test]
        public void GetNumberOfUsersOnline()
        {
            //Framework.Security.DataAccess.UserManagerDao userManagerDao =
            //    new Framework.Security.DataAccess.UserManagerDao(
            //    _connectionStringSettings.Name, _connectionStringSettings.ConnectionString, _connectionStringSettings.ProviderName);

            //int totalUsers = -1;

            //totalUsers = userManagerDao.GetNumberOfUsersOnline(10);

            //Assert.AreNotEqual(totalUsers, -1);

            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT Count(*) FROM " + Framework.Dao.Constants.DefaultTableUsers +
            //    " WHERE LastactivityDate > DATEADD(minute,  -(" + 10 + "), GETDATE())",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, totalUsers);

        }
        [Test]
        public void GetAllUsers()
        {
            //Framework.Security.DataAccess.UserManagerDao userManagerDao =
            //    new Framework.Security.DataAccess.UserManagerDao(
            //    _connectionStringSettings.Name, _connectionStringSettings.ConnectionString, _connectionStringSettings.ProviderName);

            //int totalRecords = -1;

            //IList<Framework.Security.Model.UserData> list = userManagerDao.GetAllUsers(PageIndex, PageSize, out totalRecords);

            //Assert.IsNotNull(list);

            //Assert.AreNotEqual(totalRecords, -1);

            //Assert.AreEqual(totalRecords, list.Count);


            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT Count(*) FROM " + Framework.Dao.Constants.DefaultTableUsers,
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //TODO: Fix this test
            //Assert.AreEqual(result, totalRecords);                        


        }
        [Test]
        public void FindUsersByName()
        {
            //Framework.Security.DataAccess.UserManagerDao userManagerDao =
            //    new Framework.Security.DataAccess.UserManagerDao(
            //    _connectionStringSettings.Name, _connectionStringSettings.ConnectionString, _connectionStringSettings.ProviderName);

            //int totalRecords = -1;

            //IList<Framework.Security.Model.UserData> list = userManagerDao.FindUsersByName(
            //    UserNameToMatch, PageIndex, PageSize, out totalRecords);

            //Assert.IsNotNull(list);

            //Assert.AreNotEqual(totalRecords, -1);

            //Assert.AreEqual(totalRecords, list.Count);


            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT Count(*) FROM " + Framework.Dao.Constants.DefaultTableUsers
            //    + " WHERE UserName = '" + UserNameToMatch  + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, totalRecords);                 

        }
        [Test]
        public void FindUsersByEmail()
        {

            //Framework.Security.DataAccess.UserManagerDao  userManagerDao =
            //    new Framework.Security.DataAccess.UserManagerDao(
            //        _connectionStringSettings.Name, _connectionStringSettings.ConnectionString, _connectionStringSettings.ProviderName);

            //int totalRecords = -1;

            //IList<Framework.Security.Model.UserData> list = userManagerDao.FindUsersByEmail(
            //    EmailToMatch, PageIndex, PageSize, out totalRecords);


            //Assert.IsNotNull(list);

            //Assert.AreNotEqual(totalRecords, -1);

            //Assert.AreEqual(totalRecords, list.Count);


            //object result = _commonDatabase.ExecuteScalar(CommandType.Text,
            //    "SELECT Count(*) FROM " + Framework.Dao.Constants.DefaultTableUsers
            //    + " WHERE email = '" + EmailToMatch + "'",
            //    true, Framework.Tests.DataServices.CommonDatabase.CurrentUser);

            //Assert.AreEqual(result, totalRecords);
        }
        
        #endregion
    }
}
