using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace BolaoNet.Business.Excel
{
    public class ExcelBase : IExcelBase
    {
        #region Variables
        protected string _file;
        protected Dao.Excel.IExcelBase _dao;
        #endregion

        #region Constructors/Destructors
        public ExcelBase(string file)
        {
            if (string.IsNullOrEmpty(file))
                throw new ArgumentNullException("file");

            _file = file;

            _dao = new Dao.Excel.ExcelBase();

            
        }
        #endregion

        #region Methods
        #endregion

    }
}
