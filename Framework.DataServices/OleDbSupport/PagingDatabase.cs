using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Framework.DataServices.OleDbSupport
{
    public class PagingDatabase : CommonDatabase , IPagingDatabase
    {
        #region Constructors/Destructors
        public PagingDatabase()
            : base()
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

        #region IPagingDatabase Members

        public DataTable GetPage(string procedurePaging, string fields, string from, string where, string order, int pageNumber, int pageSize, bool defaultParameters, string currentUser, out int errorNumber, out string errorDescription)
        {
            throw new NotImplementedException();
        }

        public int GetCount(string procedurePaging, string from, string where, int pageNumber, int pageSize, bool defaultParameters, string currentUser, out int errorNumber, out string errorDescription)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
