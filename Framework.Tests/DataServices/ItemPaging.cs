using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NUnit.Framework;

namespace Framework.Tests.DataServices
{
    [TestFixture]
    public class ItemPaging
    {
        #region Constants
        private const string DefaultTable = "Users";
        private const string StoredProcedurePageWithDefaultParameters = "sp_Users_PG_defaultparameters";
        private const string StoredProcedureCountWithDefaultParameters = "sp_Users_CT_defaultparameters";
        #endregion

        #region Constructors/Destructors
        public ItemPaging()
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

        #region Success

        [Test]
        public void GetPage()
        {
            int errorNumber = 0;
            string errorDescription = null;
            
            Framework.DataServices.ItemPaging dataAccess = 
                new Framework.DataServices.ItemPaging(DefaultTable);

            
            DataTable table = dataAccess.GetPage("*", null, "login", 1, 2, 
                false, Framework.Tests.DataServices.CommonDatabase.CurrentUser,
                out errorNumber, out errorDescription);

        }

        [Test]
        public void GetPageWithDefaultParameters()
        {
            int errorNumber = 0;
            string errorDescription = null;

            Framework.DataServices.ItemPaging dataAccess =
                new Framework.DataServices.ItemPaging(DefaultTable);

            dataAccess.CommandSelectPage = StoredProcedurePageWithDefaultParameters;

            DataTable table = dataAccess.GetPage("*", null, "login", 1, 2,
                true, Framework.Tests.DataServices.CommonDatabase.CurrentUser,
                out errorNumber, out errorDescription);


            
        }
        

        [Test]
        public void GetCount()
        {

            int errorNumber = 0;
            string errorDescription = null;

            Framework.DataServices.ItemPaging dataAccess =
                new Framework.DataServices.ItemPaging(DefaultTable);

            int result = dataAccess.GetCount (null, 
                false,Framework.Tests.DataServices.CommonDatabase.CurrentUser,
                out errorNumber, out errorDescription);

        }

        [Test]
        public void GetCountWithDefaultParameters()
        {
            int errorNumber = 0;
            string errorDescription = null;

            Framework.DataServices.ItemPaging dataAccess =
                new Framework.DataServices.ItemPaging(DefaultTable);

            dataAccess.CommandSelectCount = StoredProcedureCountWithDefaultParameters;

            int result = dataAccess.GetCount(null, 
                true, Framework.Tests.DataServices.CommonDatabase.CurrentUser,
                out errorNumber, out errorDescription);

        }
        #endregion

        #endregion
    }
}
