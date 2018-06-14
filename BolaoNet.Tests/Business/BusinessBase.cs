using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace BolaoNet.Tests.Business
{

    public class BusinessBase
    {
        #region Variables

        private string _currentUser = null;
        private Framework.DataServices.CommonDatabase _commonDatabase = null;


        #endregion

        #region Properties
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
        public BusinessBase(string currentUser, System.Configuration.ConnectionStringSettings connectionStringSettings)
        {


            _currentUser = currentUser;


            _commonDatabase = new Framework.DataServices.CommonDatabase(
                connectionStringSettings.Name,
                connectionStringSettings.ConnectionString,
                connectionStringSettings.ProviderName);

        }

        public void Init(string[] queries)
        {
            foreach (string query in queries)
            {
                if (!string.IsNullOrEmpty(query))
                {
                    _commonDatabase.ExecuteNonQuery(System.Data.CommandType.Text, query, false, _currentUser);
                }
            }
        }

        public void CleanUp(string[] queries)
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
        public void Load(BolaoNet.Business.IBusinessBase entry)
        {
            bool result = entry.Load();

            if (result == false)
                throw new AssertTestException("It was not possible to load the object.");

        }
        public void Update(BolaoNet.Business.IBusinessBase entry, string compareQuery)
        {
            bool result = entry.Update();

            if (result == false)
                throw new AssertTestException("It was not possible to update the object.");

            object objResult = _commonDatabase.ExecuteScalar(
               System.Data.CommandType.Text, compareQuery, false, _currentUser);


            //if (string.Compare(((Model.Campeonato)entry).Descricao, objResult.ToString()) != 0)
            //    throw new AssertTestException("Incompatible results between database and object.");


        }
        public void Insert(BolaoNet.Business.IBusinessBase entry, string compareQuery)
        {
            bool result = entry.Insert();

            if (result == false)
                throw new AssertTestException("It was not possible to insert the object.");


            object objResult = _commonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, compareQuery, false, _currentUser);

            if ((int)objResult != 1)
                throw new AssertTestException("The row was not inserted in database."); 

        }
        public void Delete(BolaoNet.Business.IBusinessBase entry, string compareQuery)
        {
            bool result = entry.Delete();

            if (result == false)
                throw new AssertTestException("It was not possible to delete the object.");

            object objResult = _commonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, compareQuery, false, _currentUser);

            if ((int)objResult >= 1)
                throw new AssertTestException("The row was not deleted in database."); 

        }
        public void SelectAll(BolaoNet.Business.IBusinessBase entry, string condition, string compareQuery)
        {
            IList<Framework.DataServices.Model.EntityBaseData> result = entry.SelectAll(condition);

            if (result == null)
                throw new AssertTestException("It was not possible to select the items.");


            object objResult = _commonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, compareQuery, false, _currentUser);

            if (result.Count != (int)objResult)
                throw new AssertTestException("There are differences between database and list returned."); 

        }
        public void SelectPage(BolaoNet.Business.IBusinessBase entry, string condition, string order, string compareQuery)
        {
            IList<Framework.DataServices.Model.EntityBaseData> result = entry.SelectPage(
                condition, order, BolaoNet.Tests.Dao.Time.PagingPage, BolaoNet.Tests.Dao.Time.PagingPage);

            if (result == null)
                throw new AssertTestException("It was not possible to select the page.");


            if (result.Count > Tests.Dao.Time.PagingTotalRows + 1)
                throw new AssertTestException("There are more rows returned than allowed");


            object objResult = _commonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, compareQuery, false, _currentUser);

            if (result.Count > (int)objResult)
                throw new AssertTestException("There are more rows returned than the specific query.");

        }
        public void SelectCount(BolaoNet.Business.IBusinessBase entry, string condition, string compareQuery)
        {
            int result = entry.SelectCount(condition);

            if (result < 0)
                throw new AssertTestException("It was not possible to load the count of rows.");


            object objResult = _commonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, compareQuery, false, _currentUser);

            if (result != (int)objResult)
                throw new AssertTestException("There are more rows returned than the specific query.");

        }
        public void SelectCombo(BolaoNet.Business.IBusinessBase entry, string compareQuery, params object[] fields)
        {
            IList<Framework.DataServices.Model.EntityBaseData> result = entry.SelectCombo(fields);

            if (result == null)
                throw new AssertTestException("It was not possible to load the combo.");

            object objResult = _commonDatabase.ExecuteScalar(
                System.Data.CommandType.Text, compareQuery, false, _currentUser);

            if ((int)objResult != result.Count)
                throw new AssertTestException("The result contains the quantity rows different from oridinal database.");


        }
        #endregion
    }
}
