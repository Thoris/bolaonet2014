using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Framework.Tests.Dao.DataAccess
{
    [TestFixture]
    public class User
    {
        #region Constants
        private const string WorkingUser = "Joe";
        private const string NotExistingUser = "UserNotFound";
        #endregion

        #region Constructors/Destructors
        public User()
        {
        }

        [TestFixtureSetUp]
        public void Init()
        {
        }

        [TearDown]
        public void Cleanup()
        {
        }
        #endregion

        #region Methods
        [Test]
        public void SelectExistingUser()
        {
            int errorNumber = 0;
            string errorDescription = string.Empty;

            Framework.Dao.DataAccess.User dataAccess = new Framework.Dao.DataAccess.User(
                DataServices.CommonDatabase.ConnectionName, 
                DataServices.CommonDatabase.ConnectionString, 
                DataServices.CommonDatabase.ProviderName);

            //Framework.Dao.Business.Object.User user = dataAccess.Select(
            //    DataServices.CommonDatabase.CurrentUser,
            //    WorkingUser, out errorNumber, out errorDescription);

            //Assert.IsNotNull(user, "User " + WorkingUser + " wasn't find in the datasource.");
            
        }

        [Test]
        public void SelectNotExistingUser()
        {
            int errorNumber = 0;
            string errorDescription = string.Empty;

            Framework.Dao.DataAccess.User dataAccess = new Framework.Dao.DataAccess.User(
                DataServices.CommonDatabase.ConnectionName,
                DataServices.CommonDatabase.ConnectionString,
                DataServices.CommonDatabase.ProviderName);

            //Framework.Dao.Business.Object.User user = dataAccess.Select(
            //    DataServices.CommonDatabase.CurrentUser,
            //    NotExistingUser, out errorNumber, out errorDescription);

            //Assert.IsNull(user, "User " + NotExistingUser + " found in the datasource.");

        }

        
        #endregion
    }
}
