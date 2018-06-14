using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using NUnit.Framework;

namespace Framework.Tests.DataServices
{
    [TestFixture]
    public class PagingDatabase
    {
        
        #region Constants
        public const string StoredProcedureCount = "sp_Select_Count";
        public const string StoredProcedurePage = "sp_Select_PG";
        public const string DefaultTable = "Users";


        public const string StoredProcedureCountWithDefaultParameters = "sp_Select_Count_defaultparameters";
        public const string StoredProcedurePageWithDefaultParameters = "sp_Select_PG_defaultparameters";

        #endregion

        #region Constructors/Destructors
        public PagingDatabase()
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

        #region Success

        [Test]
        public void ExecutePagingStoredProcedure()
        {
            DataTable table = null;
            int errorNumber = 0;
            string errorDescription = null;


            Framework.DataServices.PagingDatabase database = new Framework.DataServices.PagingDatabase(
                CommonDatabase.ConnectionName, CommonDatabase.ConnectionString, CommonDatabase.ProviderName);

            table = database.GetPage(StoredProcedurePage,
                "ID, FirstName, BirthDate",
                "Users",
                "Children > 0",
                "FirstName",
                0,
                2,
                false,
                CommonDatabase.CurrentUser,
                out errorNumber,
                out errorDescription);

        }

        [Test]
        public void ExecutePagingStoredProcedureWithDefaultParameters()
        {
            DataTable table = null;
            int errorNumber = 0;
            string errorDescription = null;


            Framework.DataServices.PagingDatabase database = new Framework.DataServices.PagingDatabase(
                CommonDatabase.ConnectionName, CommonDatabase.ConnectionString, CommonDatabase.ProviderName);

            table = database.GetPage(StoredProcedurePageWithDefaultParameters, 
                "ID, FirstName, BirthDate",
                "Users",
                "Children > 0",
                "FirstName",
                0,
                2,
                true,
                CommonDatabase.CurrentUser,
                out errorNumber,
                out errorDescription);
        }

        [Test]
        public void ExecutePagingStoredProcedureCount()
        {
            DataTable table = null;
            int errorNumber = 0;
            string errorDescription = null;


            Framework.DataServices.PagingDatabase database = new Framework.DataServices.PagingDatabase(
                CommonDatabase.ConnectionName, CommonDatabase.ConnectionString, CommonDatabase.ProviderName);

            int total = database.GetCount(StoredProcedureCount,
                "Users",
                "Children > 0",
                0,
                2,
                false,
                CommonDatabase.CurrentUser,
                out errorNumber,
                out errorDescription);
        }

        [Test]
        public void ExecutePagingStoredProcedureCountWithDefaultParameters()
        {
            DataTable table = null;
            int errorNumber = 0;
            string errorDescription = null;


            Framework.DataServices.PagingDatabase database = new Framework.DataServices.PagingDatabase(
                CommonDatabase.ConnectionName, CommonDatabase.ConnectionString, CommonDatabase.ProviderName);

            int result = database.GetCount(StoredProcedureCountWithDefaultParameters,                
                "Users",
                "Children > 0",
                0,
                2,
                true,
                CommonDatabase.CurrentUser,
                out errorNumber,
                out errorDescription);
        }



        
        #endregion
    }
}
