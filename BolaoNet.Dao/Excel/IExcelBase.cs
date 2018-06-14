using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.OleDb;

namespace BolaoNet.Dao.Excel
{
    public interface IExcelBase
    {
        OleDbConnection CreateConnection(string file);
        DataTable LoadSheet(OleDbConnection connection, string fields, string sheetName, string condition);
    }
}
