using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Framework.DataServices
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
            : base ()
        {
            _tableName = tableName;

            SetDefaultStoredProcedureNames(_tableName);
        }

        public ItemPaging(string connectionName, string tableName)
            : base (connectionName)
        {
            _tableName = tableName;

            SetDefaultStoredProcedureNames(_tableName);
        }

        public ItemPaging(string connectionName, string connectionString, string providerName, string tableName)
            : base (connectionName, connectionString, providerName)
        {
            _tableName = tableName;

            SetDefaultStoredProcedureNames(_tableName);
        }

        #endregion

        #region Methods
        public void SetDefaultStoredProcedureNames(string tableName)
        {
            _commandDelete = "sp_" + tableName + "_DE";
            _commandInsert = "sp_" + tableName + "_IN";
            _commandSelect = "sp_" + tableName + "_DT";
            _commandSelectAll = "sp_" + tableName + "_ALL";
            _commandSelectCount = "sp_" + tableName + "_CT";
            _commandSelectPage = "sp_" + tableName + "_PG";
            _commandUpdate = "sp_" + tableName + "_UP";
            _commandSelectCombo = "sp_" + tableName + "_CBO";
        }

        public DataTable GetPage(
            string fields, string where, string order, int pageNumber, int pageSize,
            bool defaultParameters, string currentUser,
            out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            DataTable table = null;

            //if (string.IsNullOrEmpty(order))
            //    throw new ArgumentException("order");

            //if (fields == null)
            //    fields = "";

            //if (where == null)
            //    where = "";



            table = ExecuteFill(CommandType.StoredProcedure, _commandSelectPage, defaultParameters, currentUser,
                base.Parameters.Create("Fields", DbType.String, ParameterDirection.Input, fields),
                base.Parameters.Create("Where", DbType.String, ParameterDirection.Input, where),
                base.Parameters.Create("Order", DbType.String, ParameterDirection.Input, order),
                base.Parameters.Create("PageNumber", DbType.Int32, ParameterDirection.Input, pageNumber),
                base.Parameters.Create("PageSize", DbType.Int32, ParameterDirection.Input, pageSize));

            if (defaultParameters)
            {
                errorDescription = base.ExecutionStatus.ErrorDescription;
                errorNumber = base.ExecutionStatus.ErrorNumber;
            }
            return table;
        }


        public int GetCount(
            string where, 
            bool defaultParameters, string currentUser,
            out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;


            if (where == null)
                where = "";

            object result = ExecuteScalar(CommandType.StoredProcedure, _commandSelectCount, defaultParameters, currentUser,
                base.Parameters.Create("Where", DbType.String, ParameterDirection.Input, where),
                base.Parameters.Create("TotalRows", DbType.Int32, ParameterDirection.Output, DBNull.Value));

            if (defaultParameters)
            {
                errorDescription = base.ExecutionStatus.ErrorDescription;
                errorNumber = base.ExecutionStatus.ErrorNumber;
            }

            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["TotalRows"].Value);
        }
        #endregion

    }
}
