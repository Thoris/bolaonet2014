using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Framework.DataServices.OleDbSupport
{
    public class ItemPaging : PagingDatabase, IItemPaging
    {
        #region Constants
        protected CommandType _commandType = CommandType.StoredProcedure;
        #endregion

        #region Variables
        protected string _commandUpdate = null;
        protected string _commandInsert = null;
        protected string _commandSelect = null;
        protected string _commandDelete = null;
        protected string _commandSelectAll = null;
        protected string _commandSelectPage = null;
        protected string _commandSelectCount = null;
        protected string _commandSelectCombo = null;
        
        

        private string _tableName = null;

        private List<Framework.DataServices.Model.DataColumnTable> _fields = new List<Framework.DataServices.Model.DataColumnTable>();
        #endregion

        #region Properties
        public string CommandUpdate
        {
            get { return _commandUpdate; }
            set { _commandUpdate = value; }
        }
        public string CommandInsert
        {
            get { return _commandInsert; }
            set { _commandInsert = value; }
        }
        public string CommandSelect
        {
            get { return _commandSelect; }
            set { _commandSelect = value; }
        }
        public string CommandDelete
        {
            get { return _commandDelete; }
            set { _commandDelete = value; }
        }
        public string CommandSelectAll
        {
            get { return _commandSelectAll; }
            set { _commandSelectAll = value; }
        }
        public string CommandSelectPage
        {
            get { return _commandSelectPage; }
            set { _commandSelectPage = value; }
        }
        public string CommandSelectCount
        {
            get { return _commandSelectCount; }
            set { _commandSelectCount = value; }
        }

        public string TableName
        {
            get { return _tableName; }
        }
        #endregion

        #region Constructors/Destructors
        public ItemPaging(string tableName)
            : base()
        {
            _tableName = tableName;

            SetDefaultStoredProcedureNames(_tableName);
        }

        public ItemPaging(string connectionName, string tableName)
            : base(connectionName)
        {
            _tableName = tableName;

            SetDefaultStoredProcedureNames(_tableName);
        }

        public ItemPaging(string connectionName, string connectionString, string providerName, string tableName)
            : base(connectionName, connectionString, providerName)
        {
            _tableName = tableName;

            SetDefaultStoredProcedureNames(_tableName);
        }

        #endregion

        #region Methods
        private void SetDefaultStoredProcedureNames(string tableName)
        {
            List<string> keyColumns = new List<string>();
            List<string> fields = new List<string>();

            string updateFields = "";
            string insertFields = "";
            string insertValuesFields = "";
            string whereCondition = "";



            //Getting key columns
            foreach (Framework.DataServices.Model.DataColumnTable column in _fields)
            {
                #region Insert Fields
                if (!string.IsNullOrEmpty(insertFields))
                {
                    insertFields += ", ";
                }
                insertFields += column.ColumnName;


                if (!string.IsNullOrEmpty(insertValuesFields))
                {
                    insertValuesFields += ", ";
                }
                insertValuesFields += "@" + column.ColumnName;


                #endregion


                if (column.IsPrimaryKey)
                {
                    keyColumns.Add(column.ColumnName);

                    #region Update Fields
                    if (!string.IsNullOrEmpty(updateFields))
                    {
                        updateFields += ",";
                    }

                    updateFields += column.ColumnName + " = @" + column.ColumnName;
                    #endregion

                    


                }
                else
                {
                    fields.Add(column.ColumnName);


                    if (!string.IsNullOrEmpty(whereCondition ))
                    {
                        whereCondition += " AND ";
                    }

                    whereCondition += column.ColumnName + " = @" + column.ColumnName;

                }

            }//end foreach


            #region Insert
            insertFields += "CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, ActiveFlag";
            insertValuesFields += "@CurrentLogin, Now(), @CurrentLogin, Now, 1";

            _commandInsert = "INSERT INTO " + _tableName + " (" + insertFields + ") VALUES (" + insertValuesFields + ")";
            #endregion

            #region Update
            updateFields += "ModifiedBy = @CurrentLogin AND ModifiedDate = Now()";

            _commandUpdate = "UPDATE " + _tableName + " SET " + updateFields + " WHERE " + whereCondition; 
            #endregion


            #region Delete
            _commandDelete = " DELETE * FROM " + _tableName + " WHERE " + whereCondition;

            #endregion

            #region Select All
            _commandSelectAll = "SELECT * FROM " + _tableName;
            #endregion

            #region Select Item
            _commandSelect = "SELECT * FROM " + _tableName + " WHERE " + whereCondition;
            #endregion

            #region Select Combo
            _commandSelectCombo = "SELECT * FROM " + _tableName;
            #endregion


        }
        #endregion

        #region IItemPaging Members


        public DataTable GetPage(string fields, string where, string order, int pageNumber, int pageSize, bool defaultParameters, string currentUser, out int errorNumber, out string errorDescription)
        {
            throw new NotImplementedException();
        }

        public int GetCount(string where, bool defaultParameters, string currentUser, out int errorNumber, out string errorDescription)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
