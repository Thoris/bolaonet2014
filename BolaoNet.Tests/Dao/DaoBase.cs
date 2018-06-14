using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BolaoNet.Tests.Dao
{
    public class DaoBase
    {
        #region Constants
        public const int PagingPage = 0;
        public const int PagingTotalRows = 2;
        #endregion

        #region Variables

        private BolaoNet.Dao.IDaoBase _daoBase = null;
        private string _currentUser = null;
        private Framework.DataServices.CommonDatabase _commonDatabase = null;

        #endregion

        #region Properties
        public BolaoNet.Dao.IDaoBase DaoObject
        {
            get { return _daoBase; }
        }
        public Framework.DataServices.CommonDatabase CommonDatabase
        {
            get { return _commonDatabase; }
        }
        public string CurrentUser
        {
            get { return _currentUser; }
        }
        #endregion

        #region Constructors/Destructors
        public DaoBase(string currentUser, System.Configuration.ConnectionStringSettings connectionStringSettings)
        {
            _currentUser = currentUser;


            _commonDatabase = new Framework.DataServices.CommonDatabase(
                connectionStringSettings.Name,
                connectionStringSettings.ConnectionString,
                connectionStringSettings.ProviderName);
        }
        public DaoBase(string currentUser, BolaoNet.Dao.IDaoBase daoBase)
        {
            if (daoBase == null)
                throw new ArgumentException("daoBase");


            _daoBase = daoBase;
            _currentUser = currentUser;


            _commonDatabase = new Framework.DataServices.CommonDatabase(
                daoBase.ConnectionStringSetting.Name,
                daoBase.ConnectionStringSetting.ConnectionString,
                daoBase.ConnectionStringSetting.ProviderName);

        }
        public void Init(string [] queries)
        {
            foreach (string query in queries)
            {
                if (!string.IsNullOrEmpty(query))
                {
                    _commonDatabase.ExecuteNonQuery(System.Data.CommandType.Text, query, false, _currentUser);
                }
            }
        }

        public void CleanUp(string [] queries)
        {
            foreach (string query in queries)
            {
                if (!string.IsNullOrEmpty(query))
                {
                    _commonDatabase.ExecuteNonQuery(System.Data.CommandType.Text, query, false, _currentUser);
                }
            }
        }
        #endregion

        #region Methods
        public void Load(Framework.DataServices.Model.EntityBaseData entry)
        {
            int errorNumber = 0;
            string errorDescription = null;

            Framework.DataServices.Model.EntityBaseData result = _daoBase.Load(
                _currentUser, entry, out errorNumber, out errorDescription);

            if (result == null)
                throw new AssertTestException("There is no result loaded");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);
            

            
        }
        public void Update(Framework.DataServices.Model.EntityBaseData entry, string compareQuery, object objToCompare)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.Update(
                _currentUser, entry, out errorNumber, out errorDescription);

            if (result == false)
                throw new AssertTestException("Couldn't update the item");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);


            object objResult = _commonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, compareQuery, false, _currentUser);
           

            if (string.Compare (objToCompare.ToString () ,objResult.ToString ()) != 0)
                throw new AssertTestException("Incompatible results between database and object.");



        }
        public void Insert(Framework.DataServices.Model.EntityBaseData entry, string compareQuery)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.Insert(
                _currentUser, entry, out errorNumber, out errorDescription);

            if (result == false)
                throw new AssertTestException("Couldn't insert the item");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);

            object objResult = _commonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, compareQuery, false, _currentUser);

            if ((int)objResult != 1)
                throw new AssertTestException("The row was not inserted in database."); 


        }
        public void Delete(Framework.DataServices.Model.EntityBaseData entry, string compareQuery)
        {
            int errorNumber = 0;
            string errorDescription = null;

            bool result = _daoBase.Delete(
                _currentUser, entry, out errorNumber, out errorDescription);

            if (result == false)
                throw new AssertTestException("Couldn't delete the item");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);

            object objResult = _commonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, compareQuery, false, _currentUser);

            if ((int)objResult >= 1)
                throw new AssertTestException("The row was not deleted in database."); 


        }
        public void SelectAll(string condition, string compareQuery)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> result = _daoBase.SelectAll(
                _currentUser, condition, out errorNumber, out errorDescription);

            
            if (result == null)
                throw new AssertTestException("Couldn't load all rows");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);


            object objResult = _commonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, compareQuery, false, _currentUser);

            if (result.Count != (int)objResult)
                throw new AssertTestException("There are differences between database and list returned."); 

        }
        public void SelectPage(string condition, string order, string compareQuery)
        {
            int errorNumber = 0;
            string errorDescription = null;


            IList<Framework.DataServices.Model.EntityBaseData> result = _daoBase.SelectPage(
                _currentUser, condition, order, PagingPage, PagingTotalRows, 
                out errorNumber, out errorDescription);

            if (result == null)
                throw new AssertTestException("Couldn't load the page");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);

            if (result.Count > PagingTotalRows + 1)
                throw new AssertTestException("There are more rows returned than allowed");


            object objResult = _commonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, compareQuery, false, _currentUser);

            if (result.Count > (int)objResult)
                throw new AssertTestException("There are more rows returned than the specific query.");


        }
        public void SelectCount(string condition, string compareQuery)
        {
            int errorNumber = 0;
            string errorDescription = null;

            int result = _daoBase.SelectCount(
                _currentUser, condition, out errorNumber, out errorDescription);

            if (result < 0)
                throw new AssertTestException("Couldn't load the page");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);

            object objResult = _commonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, compareQuery, false, _currentUser);

            if (result != (int)objResult)
                throw new AssertTestException("There are more rows returned than the specific query.");

        }
        public void SelectCombo(string compareQuery)
        {
            int errorNumber = 0;
            string errorDescription = null;

            IList<Framework.DataServices.Model.EntityBaseData> result = _daoBase.SelectCombo(
                _currentUser, out errorNumber, out errorDescription);

            if (result == null)
                throw new AssertTestException("Couldn't load the combo");

            if (errorNumber != 0)
                throw new AssertTestException("There is an error number = " + errorNumber);

            if (!string.IsNullOrEmpty(errorDescription))
                throw new AssertTestException("There is an error description = " + errorDescription);

            object objResult = _commonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, compareQuery, false, _currentUser);

            if ((int)objResult != result.Count)
                throw new AssertTestException("The result contains the quantity rows different from oridinal database.");

        }
        #endregion
    }
}
