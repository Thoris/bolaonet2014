using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BolaoNet.Tests
{
    public class Constants
    {
        #region Constants

        public const string ConnectionName = "DBProvider";
        //public const string ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Sources\BolaoNet.mdf;Integrated Security=True;User Instance=True";
        //public const string ProviderName = "System.Data.SqlClient";

        public static string ConnectionString
        {
            get
            {

                ConnectionStringSettings connectionStringFound =
                    ConfigurationManager.ConnectionStrings[ConnectionName];

                return connectionStringFound.ConnectionString;
            }
        }
        public static string ProviderName
        {
            get
            {

                ConnectionStringSettings connectionStringFound =
                    ConfigurationManager.ConnectionStrings[ConnectionName];

                return connectionStringFound.ProviderName;
            }
        }


        public const string CurrentUser = "Admin";


        #endregion
    }
}
