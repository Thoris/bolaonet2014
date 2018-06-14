using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Framework.DataServices.Model
{
    public class DataColumnTable : DataColumn
    {
        #region Variables
        private bool _isPrimaryKey;
        #endregion

        #region Properties
        public bool IsPrimaryKey
        {
            get { return _isPrimaryKey; }
            set { _isPrimaryKey = value; }
        }
        #endregion

        #region Constructors/Destructurs
        public DataColumnTable()
            : base ()
        {
            
        }
        public DataColumnTable(string columnName)
            : base (columnName)
        {
        }
        public DataColumnTable(string columnName, bool isPrimaryKey)
            : base(columnName)
        {
            _isPrimaryKey = isPrimaryKey;
        }
        #endregion
    }
}
