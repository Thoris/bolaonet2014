using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Configuration;

namespace Framework.DataServices
{
    interface IDataService
    {
        void Open();
        void Close();

        DataTable ExecuteFill(CommandType commandType, string commandText, bool defaultParameters, string currentUser, params object[] commandParameters);
        DataSet ExecuteDataSet(CommandType commandType, string commandText, bool defaultParameters, string currentUser, params object[] commandParameters);
        object ExecuteScalar(CommandType commandType, string commandText, bool defaultParameters, string currentUser, params object[] commandParameters);
        int ExecuteNonQuery(CommandType commandType, string commandText, bool defaultParameters, string currentUser, params object[] commandParameters);
        IDataReader ExecuteReader(CommandType commandType, string commandText, bool defaultParameters, string currentUser, bool closeConnection, params object[] commandParameters);


        ConnectionStringSettings ConnectionStringSetting { get; }
        
    }
}
