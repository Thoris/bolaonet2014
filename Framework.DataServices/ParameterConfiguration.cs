using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Framework.DataServices
{
    public class ParameterConfiguration
    {
        #region Constants

        public const string ParameterCurrentUser = "CurrentLogin";
        public const string ParameterDescriptionOutputName = "errorDescription";
        public const string ParameterNumberOutputName = "errorNumber";
        public const int MaxLenghtOutputDescription = 4000;

        #endregion

        #region Variables
        private DbProviderFactory _factory = null;
        #endregion

        #region Constructors/Destructors
        public ParameterConfiguration(DbProviderFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException("factory");

            _factory = factory;
        }
        #endregion

        #region Methods
        public IDataParameter Create(string parameterName, DbType dbType, object parameterValue)
        {            
            return Create(parameterName, dbType, ParameterDirection.Input, parameterValue);
        }
        public IDataParameter Create(string parameterName, DbType dbType, ParameterDirection parameterDirection, object parameterValue)
        {
            int size = 0;

            if (parameterDirection == ParameterDirection.Output)
            {
                if (dbType == DbType.String || dbType == DbType.StringFixedLength)
                {
                    if (parameterValue == null)
                        throw new ArgumentNullException("parameterValue");

                    size = parameterValue.ToString ().Length;
                }
            }

            return Create(parameterName, dbType, parameterDirection, parameterValue, size);
        }
        public IDataParameter Create(string parameterName, DbType dbType, ParameterDirection parameterDirection, object parameterValue, int size)
        {
            if (string.IsNullOrEmpty(parameterName))
                throw new ArgumentNullException("parameterName");



            DbParameter parameter = _factory.CreateParameter();

            parameter.ParameterName = parameterName;

            parameter.DbType = dbType;

            parameter.Direction = parameterDirection;

            parameter.Value = parameterValue;

            parameter.Size = size;




            switch (dbType)
            {
                case DbType.Date:
                case DbType.DateTime:
                case DbType.DateTime2:
                case DbType.DateTimeOffset:

                    if (!Convert.IsDBNull(parameterValue) &&
                        parameterValue != null &&
                        ((DateTime)parameterValue).Equals(DateTime.MinValue))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    break;


                default:

                    if (parameterValue == null)
                        parameter.Value = DBNull.Value;

                    break;
            }




            return parameter;
        }
        public IDataParameter CreateOutputDescription()
        {
            return Create(ParameterDescriptionOutputName, DbType.String, ParameterDirection.Output, DBNull.Value, MaxLenghtOutputDescription);
        }
        public IDataParameter CreateOutputNumber()
        {
            return Create(ParameterNumberOutputName, DbType.Int32, ParameterDirection.Output, DBNull.Value);
        }
        public IDataParameter CreateUser(string currentUser)
        {
            return Create(ParameterCurrentUser, DbType.String, ParameterDirection.Input, currentUser);
        }
        public void SetDefaultParameters(DbCommand command, string currentUser)
        {
            if (!command.Parameters.Contains(ParameterCurrentUser))
            {
                command.Parameters.Add(CreateUser (currentUser));
            }

            SetOutputParameters(command);
        }
        public void SetOutputParameters(DbCommand command)
        {
            if (!command.Parameters.Contains(ParameterDescriptionOutputName))
            {
                command.Parameters.Add(CreateOutputDescription());
            }


            if (!command.Parameters.Contains(ParameterNumberOutputName))
            {
                command.Parameters.Add(CreateOutputNumber());
            }
        }
        public int GetOutputStatus(DbCommand command, out string description)
        {
            description = null;

            if (command.Parameters.Contains(ParameterDescriptionOutputName))
            {
                if (Convert.IsDBNull(command.Parameters[ParameterDescriptionOutputName].Value) ||
                    command.Parameters[ParameterDescriptionOutputName].Value == null)
                {
                    description = ResourceData.MissingOutputDescription;
                }
                else
                {
                    description = command.Parameters[ParameterDescriptionOutputName].Value.ToString();
                }
            }



            if (command.Parameters.Contains(ParameterNumberOutputName))
            {
                if (Convert.IsDBNull(command.Parameters[ParameterNumberOutputName].Value) ||
                    command.Parameters[ParameterNumberOutputName].Value == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(command.Parameters[ParameterNumberOutputName].Value);
                }
            }


            return 0;

        }

        #endregion
    }
}
