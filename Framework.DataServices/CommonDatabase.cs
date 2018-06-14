using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Configuration;
using System.Text;
using System.IO;

namespace Framework.DataServices
{
    public class CommonDatabase : IDataService
    {

        #region Variables
        
        private DbConnection _connection = null;
        private DbProviderFactory _providerFactory = null;
        private ConnectionStringSettings _connectionStringSettings = null;
        private ParameterConfiguration _parameterConfiguration = null;
        private Model.ExecutionStatus _executionStatus = null;

        #endregion

        #region Properties
        public Model.ExecutionStatus ExecutionStatus
        {
            get { return _executionStatus;}
        }
        public ParameterConfiguration Parameters
        {
            get 
            {
                //if (_parameterConfiguration == null)
                //{
                //    _parameterConfiguration = new ParameterConfiguration(_providerFactory);
                //}

                return _parameterConfiguration;
            }
        }
        public System.Configuration.ConnectionStringSettings ConnectionStringSetting
        {
            get
            {
                return _connectionStringSettings;
            }
        }

        #endregion

        #region Constructors/Destructors
        public CommonDatabase()
            : this (Constants.DefaultConnectionName)
        {
        }        
        public CommonDatabase(string connectionName)
        {
            if (string.IsNullOrEmpty(connectionName))
                throw new ArgumentNullException("connectionName");

            _connectionStringSettings = GetConnectionString(connectionName);


            _providerFactory = GetProvider();
            _connection = GetConnection();

            _parameterConfiguration = new ParameterConfiguration(_providerFactory);

        }
        public CommonDatabase(string connectionName, string connectionString, string providerName)
        {

            if (string.IsNullOrEmpty(connectionName))
                throw new ArgumentNullException("connectionName");

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("connectionString");

            if (string.IsNullOrEmpty(providerName))
                throw new ArgumentNullException("providerName");


            _connectionStringSettings = 
                new ConnectionStringSettings(connectionName, connectionString, providerName);


            _providerFactory = GetProvider();
            _connection = GetConnection();

            _parameterConfiguration = new ParameterConfiguration(_providerFactory);

        }
        #endregion

        #region Methods
        private ConnectionStringSettings GetConnectionString(string connectionName)
        {
            if (string.IsNullOrEmpty(connectionName))
                throw new ArgumentNullException("connectionName");

            ConnectionStringSettings connectionStringFound =
                ConfigurationManager.ConnectionStrings[connectionName];

            return connectionStringFound;
        }
        public DbProviderFactory GetProvider()
        {
            return DbProviderFactories.GetFactory(_connectionStringSettings.ProviderName);
        }
        public DbConnection GetConnection()
        {
            DbConnection connection = null;       


            if (_providerFactory == null)
            {
                _providerFactory = GetProvider();
            }

            connection = _providerFactory.CreateConnection();

            //if (connection.State != ConnectionState.Closed)
            //    connection.Close();

            connection.ConnectionString = _connectionStringSettings.ConnectionString;


            return connection;
        }
        public DbCommand GetCommand()
        {
            if (_providerFactory == null)
            {
                _providerFactory = GetProvider();
            }

            _connection = GetConnection();

            //if (_connection == null)
            //{
            //    _connection = GetConnection();
            //}

            DbCommand command = _providerFactory.CreateCommand();

            command.Connection = _connection;

            return command;
        }
        public DbDataAdapter GetDataAdapter()
        {
            if (_providerFactory == null)
            {
                _providerFactory = GetProvider();

            }
            
            if (_connection == null)
            {
                _connection = GetConnection();
            }

            DbDataAdapter adapter = _providerFactory.CreateDataAdapter();

            adapter.SelectCommand = GetCommand();

            return adapter;

        }
        private void SetDefaultParameters(DbCommand command, string currentUser)
        {
            if (command == null)
                throw new ArgumentNullException("command");

            if (!command.Parameters.Contains(ParameterConfiguration.ParameterCurrentUser))
            {
                command.Parameters.Add (_parameterConfiguration.CreateUser(currentUser));
            }

            if (!command.Parameters.Contains(ParameterConfiguration.ParameterDescriptionOutputName))
            {
                command.Parameters.Add(_parameterConfiguration.CreateOutputDescription());
            }

            if (!command.Parameters.Contains(ParameterConfiguration.ParameterNumberOutputName))
            {
                command.Parameters.Add(_parameterConfiguration.CreateOutputNumber());
            }
        }
        private void PrepareCommand(DbCommand command, CommandType commandType, string commandText, bool defaultParameters, string currentUser, params object [] commandParameters)
        {

            _executionStatus = new Model.ExecutionStatus (command);

            if (command == null)
                throw new ArgumentNullException("command");

            if (string.IsNullOrEmpty(commandText))
                throw new ArgumentNullException("commandText");

            command.CommandText = commandText;
            command.CommandType = commandType;


            foreach (DbParameter parameter in commandParameters)
            {
                command.Parameters.Add(parameter);
            }


            if (defaultParameters)
            {
                SetDefaultParameters(command, currentUser);
            }

        }
        private int GetNumberError(DbCommand command, out string errorDescription)
        {
            if (command == null)
                throw new ArgumentNullException("command");


            int errorNumber = 0;
            errorDescription = null;



            object errorNumberAux = 
                command.Parameters[ParameterConfiguration.ParameterNumberOutputName].Value;

            if (!Convert.IsDBNull(errorNumberAux) && errorNumberAux != null)
            {
                errorNumber = (int)errorNumberAux;
            }



            object errorDescriptionAux =
                command.Parameters[ParameterConfiguration.ParameterDescriptionOutputName].Value;

            if (!Convert.IsDBNull(errorDescriptionAux) && errorDescriptionAux != null)
            {
                errorDescription = (string)errorDescriptionAux;
            }


            return errorNumber;

        }
        private Model.ExecutionStatus GetExecutionResults(DbCommand command)
        {
            string errorDescription = null;
            int errorNumber = 0;
            string currentUser = null;

            errorNumber = GetNumberError(command, out errorDescription );

            object currentUserAux =
                command.Parameters[ParameterConfiguration.ParameterCurrentUser].Value;

            if (!Convert.IsDBNull(currentUserAux) && currentUserAux != null)
            {
                currentUser = (string)currentUserAux;
            }


            return new Model.ExecutionStatus(command, currentUser, errorNumber, errorDescription);
        }
        private void SaveLog(string message)
        {
            //StreamWriter writer = new StreamWriter("C:\\temp\\datasource.txt", true);
            //writer.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " - " + message);
            //writer.Close();
        }
        #endregion

        #region IDataService Members
        public void Open()
        {
            _connection.Open();
        }
        public void Close()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }
        public DataTable ExecuteFill(CommandType commandType, string commandText, bool defaultParameters, string currentUser, params object[] commandParameters)
        {
            DataSet dsResult = ExecuteDataSet(commandType, commandText, defaultParameters, currentUser, commandParameters);

            return dsResult.Tables[0];
        }
        public DataSet ExecuteDataSet(CommandType commandType, string commandText, bool defaultParameters, string currentUser, params object[] commandParameters)
        {
            SaveLog("ExecuteDataSet - " + commandText);
            DataSet dataset = new DataSet();

            DbDataAdapter adapter = GetDataAdapter();

            lock (adapter.SelectCommand.Connection)
            {

                PrepareCommand(adapter.SelectCommand, commandType, commandText, defaultParameters, currentUser, commandParameters);

                adapter.Fill(dataset);

                if (defaultParameters)
                {
                    _executionStatus = GetExecutionResults(adapter.SelectCommand);
                }
            }

            return dataset;

        }
        public object ExecuteScalar(CommandType commandType, string commandText, bool defaultParameters, string currentUser, params object[] commandParameters)
        {
            SaveLog("ExecuteScalar - " + commandText);
            DbCommand command = GetCommand();

            PrepareCommand(command, commandType, commandText, defaultParameters, currentUser, commandParameters);

            lock (command.Connection)
            {
                try
                {
                    Open();

                    return command.ExecuteScalar();
                }
                finally
                {
                    Close();

                    if (defaultParameters)
                    {
                        _executionStatus = GetExecutionResults(command);
                    }
                }
            }
        }
        public int ExecuteNonQuery(CommandType commandType, string commandText, bool defaultParameters, string currentUser, params object[] commandParameters)
        {
            SaveLog("ExecuteNonQuery - " + commandText);
            DbCommand command = GetCommand();

            PrepareCommand(command, commandType, commandText, defaultParameters, currentUser, commandParameters);

            lock (command.Connection)
            {
                try
                {
                    Open();

                    return command.ExecuteNonQuery();
                }
                finally
                {
                    Close();

                    if (defaultParameters)
                    {
                        _executionStatus = GetExecutionResults(command);
                    }
                }
            }
        }
        public IDataReader ExecuteReader(CommandType commandType, string commandText, bool defaultParameters, string currentUser, bool closeConnection, params object[] commandParameters)
        {
            SaveLog("ExecuteReader - " + commandText);
            DbCommand command = GetCommand();

            PrepareCommand(command, commandType, commandText, defaultParameters, currentUser, commandParameters);

            lock (command.Connection)
            {
                try
                {
                    Open();

                    return command.ExecuteReader();
                }
                finally
                {
                    if (closeConnection)
                    {
                        Close();
                    }

                    if (defaultParameters)
                    {
                        _executionStatus = GetExecutionResults(command);
                    }
                }
            }
        }
        #endregion
    }
}
