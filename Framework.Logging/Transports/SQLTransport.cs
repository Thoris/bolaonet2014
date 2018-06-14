using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Transactions;
using Framework.Logging.Logger;
using Framework.Logging.Logger.Settings;
using System.Globalization;

namespace Framework.Logging.Logger.Transports
{
    /// <summary>
    /// Writes log messages to the SQL Logging Database
    /// </summary>
    internal class SQLTransport : LoggerTransport
    {
		private const string CONNECTIONNAME_KEY = "connectionname";
		private const string STORED_PROCEDURE_KEY = "storedprocedure";

        public SQLTransport() { }

        public override void WriteLog(LogRecord record, TransportSettings settings)
        {
            string connName = settings.Configs[CONNECTIONNAME_KEY] as string;
            string storedProc = settings.Configs[STORED_PROCEDURE_KEY] as string;

			if(string.IsNullOrEmpty(connName))
			{
                throw new LoggerException(string.Format(CultureInfo.CurrentCulture,ResourceData.ConfigurationKeyDoesNotExist,CONNECTIONNAME_KEY));
			}

			if(string.IsNullOrEmpty(storedProc))
			{
                throw new LoggerException(string.Format(CultureInfo.CurrentCulture, ResourceData.ConfigurationKeyDoesNotExist,STORED_PROCEDURE_KEY));
			}

            if(ConfigurationManager.ConnectionStrings[connName] == null ||
                string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings[connName].ConnectionString))
            {
                throw new LoggerException(string.Format(CultureInfo.CurrentCulture, ResourceData.ConfigurationKeyDoesNotExist,"ConnectionName:" + connName));
            }

            string connString = ConfigurationManager.ConnectionStrings[connName].ConnectionString;

            //DON'T INCLUDE THIS IN ANY TRANSACTIONS.
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(storedProc, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@class_name", GetMaxString(record.ClassName, 50));
                        cmd.Parameters.AddWithValue("@method_name", GetMaxString(record.MethodName, 50));
                        cmd.Parameters.AddWithValue("@source", GetMaxString(record.Source, 50));
                        cmd.Parameters.AddWithValue("@application_id", record.ApplicationId);
                        cmd.Parameters.AddWithValue("@description", GetMaxString(record.Description, 255));
                        cmd.Parameters.AddWithValue("@reference_id", GetMaxString(record.ReferenceId, 50));
                        cmd.Parameters.AddWithValue("@computer_name", GetMaxString(record.ComputerName, 50));
                        cmd.Parameters.AddWithValue("@userlogon", GetMaxString(record.UserLogon, 50));
                        cmd.Parameters.AddWithValue("@log_guid", record.LogGUID);
                        cmd.Parameters.AddWithValue("@time_stamp", record.TimeStamp);
                        cmd.Parameters.AddWithValue("@log_level", (int)record.LogLevel);
                        cmd.Parameters.AddWithValue("@content_type", (int)record.ContentType);
                        cmd.Parameters.AddWithValue("@content", record.Content != null ? record.Content : string.Empty);
                        cmd.Parameters.AddWithValue("@logging_context_guid", record.LoggingContextGUID);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
 		}

        private string GetMaxString(string value, int maxLen)
        {
            if (value == null)
            {
                return string.Empty;
            }
            else if (value.Length > maxLen)
            {
                return value.Substring(0, maxLen);
            }
            else
            {
                return value;
            }
        }


    }
}
