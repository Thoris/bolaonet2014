using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NUnit.Framework;
using System.Data.Common;

namespace Framework.Tests.DataServices
{
    [TestFixture]
    public class CommonDatabase
    {
        #region Constants
        public const string ConnectionName = "ConnectionName";
        public const string ProviderName = "System.Data.SqlClient";
        public const string ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Sources\BolaoNet.mdf;Integrated Security=True;User Instance=True";

        private const string ProviderNameFail = "System.Data.SqlClient.Error";
        private const string ConnectionStringFail = "Data SourceFail=Fail to Test";

        public const string CurrentUser = Constants.CurrentUser;

        #endregion

        #region Constructors/Destructors
        public CommonDatabase()
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

        #region Connection

        #region Success
        [Test]
        public void CreateConnection()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);
        }

        [Test]
        public void CreateConnectionByConfigurationSettings()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase();
        }

        [Test]
        public void OpenAndCloseConnection()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            commonDatabase.Open();

            commonDatabase.Close();
        }

        #endregion

        #region Fail

        [Test]
        [ExpectedException()]
        public void FailToCreateConnection()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionStringFail, ProviderNameFail);

        }

        [Test]
        [ExpectedException()]
        public void FailToCreateConnectionInProviderName()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderNameFail);

        }

        [Test]
        [ExpectedException()]
        public void FailToCreateConnectionInConnectionString()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionStringFail, ProviderName);

        }

        #endregion

        #endregion

        #region DataSet Execution

        #region Success

        [Test]
        public void ExecuteTextToDataSetWithoutParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            DataSet dsResult = commonDatabase.ExecuteDataSet(
                CommandType.Text,
                "SELECT * FROM Users", false, CurrentUser);

        }

        [Test]
        public void ExecuteTextToDataSetWithDataParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            DataSet dsResult = commonDatabase.ExecuteDataSet(
                CommandType.Text,
                "SELECT * FROM Users WHERE BirthDate < @BirthDate",
                false, CurrentUser,
                parameterConfig.Create ("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }

        [Test]
        public void ExecuteTextToDataSetWithIntParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            DataSet dsResult = commonDatabase.ExecuteDataSet(
                CommandType.Text,
                "SELECT * FROM Users WHERE Children > @Children", false, CurrentUser,
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 0));

        }

        [Test]
        public void ExecuteTextToDataSetWithIntAndDataParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            DataSet dsResult = commonDatabase.ExecuteDataSet(
                CommandType.Text,
                "SELECT * FROM Users " + 
                " WHERE Children > @Children " +
                "   AND BirthDate < @BirthDate ", false, CurrentUser,
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 1), 
                parameterConfig.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }

        [Test]
        public void ExecuteStoredProcedureToDataSetWithoutParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            DataSet dsResult = commonDatabase.ExecuteDataSet(
                CommandType.StoredProcedure,
                "sp_select_users", false, CurrentUser);

        }

        [Test]
        public void ExecuteStoredProcedureToDataSetWithDataParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            DataSet dsResult = commonDatabase.ExecuteDataSet(
                CommandType.StoredProcedure,
                "sp_select_users", false, CurrentUser, 
                commonDatabase.Parameters.Create ("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));
        }

        [Test]
        public void ExecuteStoredProcedureToDataSetWithIntParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            DataSet dsResult = commonDatabase.ExecuteDataSet(
                CommandType.StoredProcedure,
                "sp_select_users", false, CurrentUser, 
                commonDatabase.Parameters.Create ("@Children", DbType.Int32, ParameterDirection.Input, 1));
        }

        [Test]
        public void ExecuteStoredProcedureToDataSetWithDataAndIntParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            DataSet dsResult = commonDatabase.ExecuteDataSet(
                CommandType.StoredProcedure,
                "sp_select_users", false, CurrentUser, 
                commonDatabase.Parameters.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now),
                commonDatabase.Parameters.Create("@Children", DbType.Int32, ParameterDirection.Input, 1));
        }

        [Test]
        public void ExecuteStoredProcedureToDataSetWithDefaultOutputParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            DataSet dsResult = commonDatabase.ExecuteDataSet(
                CommandType.StoredProcedure,
                "sp_select_users_outputparameters", true, CurrentUser);


            Assert.AreEqual(commonDatabase.ExecutionStatus.ErrorNumber, 10);
            Assert.AreEqual(commonDatabase.ExecutionStatus.ErrorDescription, "User: " +  CurrentUser +  " - Number: 10");
            Assert.AreEqual(commonDatabase.ExecutionStatus.CurrentUser, CurrentUser);
        }

        #endregion

        #region Fail

        [Test]
        [ExpectedException]
        public void FailedToExecuteTextToDataSetInWrongTable()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            DataSet dsResult = commonDatabase.ExecuteDataSet(
                CommandType.Text,
                "SELECT * FROM Users_Fail " +
                " WHERE Children > @Children " +
                "   AND BirthDate < @BirthDate ", false, CurrentUser, 
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 1),
                parameterConfig.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }

        [Test]
        [ExpectedException]
        public void FailedToExecuteTextToDataSetInWrongParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            DataSet dsResult = commonDatabase.ExecuteDataSet(
                CommandType.Text,
                "SELECT * FROM Users_Fail " +
                " WHERE Children > @Children " +
                "   AND BirthDate < @BirthDate ", false, CurrentUser, 
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 1),
                parameterConfig.Create("@BirthDateFail", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }

        [Test]
        [ExpectedException]
        public void FailedToExecuteTextToDataSetInWrongFieldName()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            DataSet dsResult = commonDatabase.ExecuteDataSet(
                CommandType.Text,
                "SELECT * FROM Users_Fail " +
                " WHERE Children > @Children " +
                "   AND BirthDateFail < @BirthDate ", false, CurrentUser, 
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 1),
                parameterConfig.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }






        [Test]
        [ExpectedException]
        public void FailedToExecutStoredProcedureToDataSetInWrongStoredProcedure()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                 new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            DataSet dsResult = commonDatabase.ExecuteDataSet(
                CommandType.StoredProcedure,
                "sp_select_users_fail", false, CurrentUser, 
                commonDatabase.Parameters.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now),
                commonDatabase.Parameters.Create("@Children", DbType.Int32, ParameterDirection.Input, 1));

        }

        [Test]
        [ExpectedException]
        public void FailedToExecuteStoredProcedureToDataSetInWrongParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            DataSet dsResult = commonDatabase.ExecuteDataSet(
                CommandType.StoredProcedure,
                "sp_select_users", false, CurrentUser, 
                commonDatabase.Parameters.Create("@BirthDate_fail", DbType.Date, ParameterDirection.Input, DateTime.Now),
                commonDatabase.Parameters.Create("@Children", DbType.Int32, ParameterDirection.Input, 1));
        }
     
        

        #endregion

        #endregion

        #region Scalar Execution

        #region Success

        [Test]
        public void ExecuteTextToScalarWithoutParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            object objResult = commonDatabase.ExecuteScalar(
                CommandType.Text,
                "SELECT count(*) FROM Users", false, CurrentUser);

        }

        [Test]
        public void ExecuteTextToScalarWithDataParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            object objResult = commonDatabase.ExecuteScalar(
                CommandType.Text,
                "SELECT COUNT(*) FROM Users WHERE BirthDate < @BirthDate", false, CurrentUser, 
                parameterConfig.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }

        [Test]
        public void ExecuteTextToScalarWithIntParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            object objResult = commonDatabase.ExecuteScalar(
                CommandType.Text,
                "SELECT count(*) FROM Users WHERE Children > @Children", false, CurrentUser, 
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 0));

        }

        [Test]
        public void ExecuteTextToScalarWithIntAndDataParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            object objResult = commonDatabase.ExecuteScalar(
                CommandType.Text,
                "SELECT count(*) FROM Users " +
                " WHERE Children > @Children " +
                "   AND BirthDate < @BirthDate ", false, CurrentUser, 
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 1),
                parameterConfig.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }


        [Test]
        public void ExecuteStoredProcedureToScalarWithoutParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            object objResult = commonDatabase.ExecuteScalar(
                CommandType.StoredProcedure,
                "sp_select_users_scalar", false, CurrentUser);

        }

        [Test]
        public void ExecuteStoredProcedureToScalarWithDataParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            object objResult = commonDatabase.ExecuteScalar(
                CommandType.StoredProcedure,
                "sp_select_users_scalar", false, CurrentUser, 
                commonDatabase.Parameters.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));
        }

        [Test]
        public void ExecuteStoredProcedureToScalarWithIntParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            object objResult = commonDatabase.ExecuteScalar(
                CommandType.StoredProcedure,
                "sp_select_users_scalar", false, CurrentUser, 
                commonDatabase.Parameters.Create("@Children", DbType.Int32, ParameterDirection.Input, 1));
        }

        [Test]
        public void ExecuteStoredProcedureToScalarWithDataAndIntParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            object objResult = commonDatabase.ExecuteScalar(
                CommandType.StoredProcedure,
                "sp_select_users_scalar", false, CurrentUser, 
                commonDatabase.Parameters.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now),
                commonDatabase.Parameters.Create("@Children", DbType.Int32, ParameterDirection.Input, 1));
        }




        #endregion

        #region Fail

        [Test]
        [ExpectedException]
        public void FailedToExecuteTextToScalarInWrongTable()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            object objResult = commonDatabase.ExecuteScalar(
                CommandType.Text,
                "SELECT count(*) FROM Users_Fail " +
                " WHERE Children > @Children " +
                "   AND BirthDate < @BirthDate ", false, CurrentUser, 
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 1),
                parameterConfig.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }

        [Test]
        [ExpectedException]
        public void FailedToExecuteTextToScalarInWrongParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            object objResult = commonDatabase.ExecuteScalar(
                CommandType.Text,
                "SELECT count(*) FROM Users_Fail " +
                " WHERE Children > @Children " +
                "   AND BirthDate < @BirthDate ", false, CurrentUser, 
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 1),
                parameterConfig.Create("@BirthDateFail", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }

        [Test]
        [ExpectedException]
        public void FailedToExecuteTextToScalarInWrongFieldName()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            object objResult = commonDatabase.ExecuteScalar(
                CommandType.Text,
                "SELECT count(*) FROM Users_Fail " +
                " WHERE Children > @Children " +
                "   AND BirthDateFail < @BirthDate ", false, CurrentUser, 
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 1),
                parameterConfig.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }






        [Test]
        [ExpectedException]
        public void FailedToExecutStoredProcedureToScalarInWrongStoredProcedure()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                 new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            object objResult = commonDatabase.ExecuteScalar(
                CommandType.StoredProcedure,
                "sp_select_users_fail", false, CurrentUser, 
                commonDatabase.Parameters.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now),
                commonDatabase.Parameters.Create("@Children", DbType.Int32, ParameterDirection.Input, 1));

        }

        [Test]
        [ExpectedException]
        public void FailedToExecuteStoredProcedureToScalarInWrongParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            object objResult = commonDatabase.ExecuteScalar(
                CommandType.StoredProcedure,
                "sp_select_users_scalar", false, CurrentUser, 
                commonDatabase.Parameters.Create("@BirthDate_fail", DbType.Date, ParameterDirection.Input, DateTime.Now),
                commonDatabase.Parameters.Create("@Children", DbType.Int32, ParameterDirection.Input, 1));
        }



        #endregion

        #endregion

        #region NonQuery Execution

        #region Success

        [Test]
        public void ExecuteTextToNonQueryWithoutParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            int result = commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "SELECT * FROM Users", false, CurrentUser);

        }

        [Test]
        public void ExecuteTextToNonQueryWithDataParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            int result = commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "SELECT * FROM Users WHERE BirthDate < @BirthDate", false, CurrentUser, 
                parameterConfig.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }

        [Test]
        public void ExecuteTextToNonQueryWithIntParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            int result = commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "SELECT * FROM Users WHERE Children > @Children", false, CurrentUser, 
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 0));

        }

        [Test]
        public void ExecuteTextToNonQueryWithIntAndDataParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            int result = commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "SELECT * FROM Users " +
                " WHERE Children > @Children " +
                "   AND BirthDate < @BirthDate ", false, CurrentUser, 
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 1),
                parameterConfig.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }

        [Test]
        public void ExecuteStoredProcedureToNonQueryWithoutParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            int result = commonDatabase.ExecuteNonQuery(
                CommandType.StoredProcedure,
                "sp_select_users_nonquery", false, CurrentUser);

        }

        [Test]
        public void ExecuteStoredProcedureToNonQueryWithDataParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            int result = commonDatabase.ExecuteNonQuery(
                CommandType.StoredProcedure,
                "sp_select_users_nonquery", false, CurrentUser,
                commonDatabase.Parameters.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));
        }

        [Test]
        public void ExecuteStoredProcedureToNonQueryWithIntParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            int result = commonDatabase.ExecuteNonQuery(
                CommandType.StoredProcedure,
                "sp_select_users_nonquery", false, CurrentUser,
                commonDatabase.Parameters.Create("@Children", DbType.Int32, ParameterDirection.Input, 1));
        }

        [Test]
        public void ExecuteStoredProcedureToNonQueryWithDataAndIntParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            int result = commonDatabase.ExecuteNonQuery(
                CommandType.StoredProcedure,
                "sp_select_users_scalar", false, CurrentUser, 
                commonDatabase.Parameters.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now),
                commonDatabase.Parameters.Create("@Children", DbType.Int32, ParameterDirection.Input, 1));
        }

        [Test]
        public void ExecuteStoredProcedureToNonQueryWithDefaultOutputParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            int result = commonDatabase.ExecuteNonQuery(
                CommandType.StoredProcedure,
                "sp_select_users_outputparameters", true, CurrentUser);


            Assert.AreEqual(commonDatabase.ExecutionStatus.ErrorNumber, 10);
            Assert.AreEqual(commonDatabase.ExecutionStatus.ErrorDescription, "User: " + CurrentUser + " - Number: 10");
            Assert.AreEqual(commonDatabase.ExecutionStatus.CurrentUser, CurrentUser);
        }

        #endregion

        #region Fail

        [Test]
        [ExpectedException]
        public void FailedToExecuteTextToNonQueryInWrongTable()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            int result = commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "SELECT * FROM Users_Fail " +
                " WHERE Children > @Children " +
                "   AND BirthDate < @BirthDate ", false, CurrentUser, 
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 1),
                parameterConfig.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }

        [Test]
        [ExpectedException]
        public void FailedToExecuteTextToNonQueryInWrongParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            int result = commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "SELECT * FROM Users_Fail " +
                " WHERE Children > @Children " +
                "   AND BirthDate < @BirthDate ", false, CurrentUser, 
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 1),
                parameterConfig.Create("@BirthDateFail", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }

        [Test]
        [ExpectedException]
        public void FailedToExecuteTextToNonQueryInWrongFieldName()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            int result = commonDatabase.ExecuteNonQuery(
                CommandType.Text,
                "SELECT * FROM Users_Fail " +
                " WHERE Children > @Children " +
                "   AND BirthDateFail < @BirthDate ", false, CurrentUser, 
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 1),
                parameterConfig.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }






        [Test]
        [ExpectedException]
        public void FailedToExecutStoredProcedureToNonQueryInWrongStoredProcedure()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                 new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            int result = commonDatabase.ExecuteNonQuery(
                CommandType.StoredProcedure,
                "sp_select_users_fail", false, CurrentUser, 
                commonDatabase.Parameters.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now),
                commonDatabase.Parameters.Create("@Children", DbType.Int32, ParameterDirection.Input, 1));

        }

        [Test]
        [ExpectedException]
        public void FailedToExecuteStoredProcedureToNonQueryInWrongParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            int result = commonDatabase.ExecuteNonQuery(
                CommandType.StoredProcedure,
                "sp_select_users_nonquery", false, CurrentUser, 
                commonDatabase.Parameters.Create("@BirthDate_fail", DbType.Date, ParameterDirection.Input, DateTime.Now),
                commonDatabase.Parameters.Create("@Children", DbType.Int32, ParameterDirection.Input, 1));
        }



        #endregion

        #endregion

        #region ExecuteReader Execution

        #region Success

        [Test]
        public void ExecuteTextToReaderWithoutParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            DbDataReader result = (DbDataReader)commonDatabase.ExecuteReader(
                CommandType.Text,
                "SELECT * FROM Users", false, CurrentUser, true);

        }

        [Test]
        public void ExecuteTextToReaderWithDataParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            DbDataReader result = (DbDataReader)commonDatabase.ExecuteReader(
                CommandType.Text,
                "SELECT * FROM Users WHERE BirthDate < @BirthDate", false, CurrentUser, true,
                parameterConfig.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }

        [Test]
        public void ExecuteTextToReaderWithIntParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            DbDataReader result = (DbDataReader)commonDatabase.ExecuteReader(
                CommandType.Text,
                "SELECT * FROM Users WHERE Children > @Children", false, CurrentUser, true,
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 0));

        }

        [Test]
        public void ExecuteTextToReaderWithIntAndDataParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            DbDataReader result = (DbDataReader)commonDatabase.ExecuteReader(
                CommandType.Text,
                "SELECT * FROM Users " +
                " WHERE Children > @Children " +
                "   AND BirthDate < @BirthDate ", false, CurrentUser, true,
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 1),
                parameterConfig.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }

        [Test]
        public void ExecuteStoredProcedureToReaderWithoutParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            DbDataReader result = (DbDataReader)commonDatabase.ExecuteReader(
                CommandType.StoredProcedure,
                "sp_select_users_reader", false, CurrentUser, true );

        }

        [Test]
        public void ExecuteStoredProcedureToReaderWithDataParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            DbDataReader result = (DbDataReader)commonDatabase.ExecuteReader(
                CommandType.StoredProcedure,
                "sp_select_users_reader", false, CurrentUser, true,
                commonDatabase.Parameters.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));
        }

        [Test]
        public void ExecuteStoredProcedureToReaderWithIntParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            DbDataReader result = (DbDataReader)commonDatabase.ExecuteReader(
                CommandType.StoredProcedure,
                "sp_select_users_reader", false, CurrentUser, true,
                commonDatabase.Parameters.Create("@Children", DbType.Int32, ParameterDirection.Input, 1));
        }

        [Test]
        public void ExecuteStoredProcedureToReaderWithDataAndIntParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            DbDataReader result = (DbDataReader)commonDatabase.ExecuteReader(
                CommandType.StoredProcedure,
                "sp_select_users_reader", false, CurrentUser, true, 
                commonDatabase.Parameters.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now),
                commonDatabase.Parameters.Create("@Children", DbType.Int32, ParameterDirection.Input, 1));
        }

        [Test]
        public void ExecuteStoredProcedureToReaderWithDefaultOutputParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            DbDataReader result =  (DbDataReader) commonDatabase.ExecuteReader (
                CommandType.StoredProcedure,
                "sp_select_users_outputparameters", true, CurrentUser, true);


            Assert.AreEqual(commonDatabase.ExecutionStatus.ErrorNumber, 10);
            Assert.AreEqual(commonDatabase.ExecutionStatus.ErrorDescription, "User: " + CurrentUser + " - Number: 10");
            Assert.AreEqual(commonDatabase.ExecutionStatus.CurrentUser, CurrentUser);
        }

        #endregion

        #region Fail

        [Test]
        [ExpectedException]
        public void FailedToExecuteTextToReaderInWrongTable()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            DbDataReader result = (DbDataReader)commonDatabase.ExecuteReader(
                CommandType.Text,
                "SELECT * FROM Users_Fail " +
                " WHERE Children > @Children " +
                "   AND BirthDate < @BirthDate ", false, CurrentUser, true,
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 1),
                parameterConfig.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }

        [Test]
        [ExpectedException]
        public void FailedToExecuteTextToReaderInWrongParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            DbDataReader result = (DbDataReader)commonDatabase.ExecuteReader(
                CommandType.Text,
                "SELECT * FROM Users_Fail " +
                " WHERE Children > @Children " +
                "   AND BirthDate < @BirthDate ", false, CurrentUser, true,
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 1),
                parameterConfig.Create("@BirthDateFail", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }

        [Test]
        [ExpectedException]
        public void FailedToExecuteTextToReaderInWrongFieldName()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);


            Framework.DataServices.ParameterConfiguration parameterConfig =
                new Framework.DataServices.ParameterConfiguration(commonDatabase.GetProvider());


            DbDataReader result = (DbDataReader)commonDatabase.ExecuteReader(
                CommandType.Text,
                "SELECT * FROM Users_Fail " +
                " WHERE Children > @Children " +
                "   AND BirthDateFail < @BirthDate ", false, CurrentUser, true,
                parameterConfig.Create("@Children", DbType.Int32, ParameterDirection.Input, 1),
                parameterConfig.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now));

        }






        [Test]
        [ExpectedException]
        public void FailedToExecutStoredProcedureToReaderInWrongStoredProcedure()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                 new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            DbDataReader result = (DbDataReader)commonDatabase.ExecuteReader(
                CommandType.StoredProcedure,
                "sp_select_users_fail", false, CurrentUser, true,
                commonDatabase.Parameters.Create("@BirthDate", DbType.Date, ParameterDirection.Input, DateTime.Now),
                commonDatabase.Parameters.Create("@Children", DbType.Int32, ParameterDirection.Input, 1));

        }

        [Test]
        [ExpectedException]
        public void FailedToExecuteStoredProcedureToReaderInWrongParameters()
        {
            Framework.DataServices.CommonDatabase commonDatabase =
                new Framework.DataServices.CommonDatabase(ConnectionName, ConnectionString, ProviderName);

            DbDataReader result = (DbDataReader)commonDatabase.ExecuteReader(
                CommandType.StoredProcedure,
                "sp_select_users_reader", false, CurrentUser, true,
                commonDatabase.Parameters.Create("@BirthDate_fail", DbType.Date, ParameterDirection.Input, DateTime.Now),
                commonDatabase.Parameters.Create("@Children", DbType.Int32, ParameterDirection.Input, 1));
        }



        #endregion

        #endregion
        
        #endregion
    }
}
