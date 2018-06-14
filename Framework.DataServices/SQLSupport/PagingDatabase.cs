using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Framework.DataServices
{
    public class PagingDatabase : CommonDatabase , IPagingDatabase
    {
        #region Constructors/Destructors
        public PagingDatabase()
            : base ()
        {

        }
        public PagingDatabase(string connectionName)
            : base(connectionName)
        {

        }
        public PagingDatabase(string connectionName, string connectionString, string providerName)
            : base(connectionName, connectionString, providerName)
        {

        }
        #endregion

        #region Methods
        public DataTable GetPage(string procedurePaging, 
            string fields, string from, string where, string order, int pageNumber, int pageSize,
            bool defaultParameters, string currentUser,
            out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            DataTable table = null;

            if (string.IsNullOrEmpty (order))
                throw new ArgumentException ("order");

            if (fields == null)
                fields = "";

            if (where == null)
                where = "";



            table = ExecuteFill (CommandType.StoredProcedure, procedurePaging, defaultParameters, currentUser,
                base.Parameters.Create("Fields", DbType.String, ParameterDirection.Input, fields),
                base.Parameters.Create("From", DbType.String, ParameterDirection.Input, from),
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


        public int GetCount(string procedurePaging, 
            string from, string where, int pageNumber, int pageSize,
            bool defaultParameters, string currentUser,
            out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

           

            if (where == null)
                where = "";

            object result = ExecuteScalar(CommandType.StoredProcedure, procedurePaging, defaultParameters, currentUser,
                base.Parameters.Create("Where", DbType.String, ParameterDirection.Input, where),
                base.Parameters.Create("From", DbType.String, ParameterDirection.Input, from),
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
