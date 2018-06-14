using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.OleDb;

namespace BolaoNet.Dao.Excel
{
    public class ExcelBase : IExcelBase
    {
        #region Constructors/Destructors
        public ExcelBase()
        {
        }
        #endregion

        #region IExcelBase Members

        public OleDbConnection CreateConnection(string file)
        {
            // Create connection string variable. Modify the "Data Source"
            // parameter as appropriate for your environment.
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                 "Data Source=" + file + ";" +
                 "Extended Properties=Excel 8.0;";

            // Create connection object by using the preceding connection string.
            OleDbConnection connection = new OleDbConnection(connectionString);

            return connection;
        }

        public DataTable LoadSheet(OleDbConnection connection, string fields, string sheetName, string condition)
        {
            if (connection == null)
                throw new ArgumentNullException ("connection");

            if (string.IsNullOrEmpty(sheetName))
                throw new ArgumentNullException ("sheetName");

            if (string.IsNullOrEmpty (fields))
                fields = "*";

            if (string.IsNullOrEmpty (condition))
                condition = "";

            try
            {
                OleDbCommand command = new OleDbCommand(
                    "SELECT " + fields + " FROM [" + sheetName + "$] " + (condition.Length > 0 ? "WHERE " + condition : ""),
                    connection);


                //connection.Open();


                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = command;


                DataTable table = new DataTable();

                adapter.Fill(table);

                return table;
            }
            finally
            {
                //connection.Close();
            }

        }

        #endregion
    }
}
