using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Framework.Security.DataAccess.SQLSupport
{
    public class UserManagerDao : Framework.DataServices.PagingDatabase, IUserManagerDao
    {
        #region Variables
        //private IUserDao _userDao = null;

        private string _currentUser = null;
        private string _applicationName = null;
        #endregion

        #region Constructors/Destructors
        public UserManagerDao()
            : base ()
        {
        }
        public UserManagerDao(string connectionName)
            : base(connectionName)
        {
        }
        public UserManagerDao(string connectionName, string connectionString, string providerName)
            : base(connectionName, connectionString, providerName)
        {
        }
        #endregion

        #region Methods
        private IList<Model.UserData> ConvertToList(DataTable table)
        {
            IList<Model.UserData> list = new List<Model.UserData>();

            foreach (DataRow row in table.Rows)
            {
                Model.UserData userData = Convertion.UserData.ConvertToModel(row);

                list.Add(userData);
            }

            return list;
        }
        #endregion

        #region IUserManagerDao Members


        public IList<Model.UserData> FindUsersByEmail(string currentLogin, string emailToMatch, int pageIndex, int pageSize, out int totalRecords,  out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;


            totalRecords = 0;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "Framework_FindUsersByEmail",
                true, _currentUser,
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@EmailToMatch", DbType.String, emailToMatch),
                base.Parameters.Create("@PageIndex", DbType.Int32, pageIndex),
                base.Parameters.Create("@PageSize", DbType.Int32, pageSize),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null));


            totalRecords = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return ConvertToList(table);
          
        }
        public IList<Model.UserData> FindUsersByName(string currentLogin, string userNameToMatch, int pageIndex, int pageSize, out int totalRecords, out int errorNumber, out string errorDescription)
        {

            errorNumber = 0;
            errorDescription = null;

            totalRecords = 0;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "Framework_FindUsersByName",
                true, _currentUser,
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@UserNameToMatch", DbType.String, userNameToMatch),
                base.Parameters.Create("@PageIndex", DbType.Int32, pageIndex),
                base.Parameters.Create("@PageSize", DbType.Int32, pageSize),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null));

          
            totalRecords = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);


            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;


            return ConvertToList (table);
        }
        public IList<Model.UserData> GetAllUsers(string currentLogin, int pageIndex, int pageSize, out int totalRecords, out int errorNumber, out string errorDescription)
        {

            errorNumber = 0;
            errorDescription = null;

            totalRecords = 0;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "Framework_GetAllUsers",
                true, _currentUser,
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@PageIndex", DbType.Int32, pageIndex),
                base.Parameters.Create("@PageSize", DbType.Int32, pageSize),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null));

            totalRecords = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);


            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return ConvertToList (table);
        }
        public int GetNumberOfUsersOnline(string currentLogin, int userIsOnlineTimeWindow, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            int totalRecords = 0;

            object returnValue = base.ExecuteScalar(CommandType.StoredProcedure, "Framework_GetNumberOfUsersOnline",
                true, _currentUser,
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@MinutesSinceLastInActive", DbType.Int32, userIsOnlineTimeWindow),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null));

            totalRecords = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);


            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return totalRecords;
        }
        public string GetUserNameByEmail(string currentLogin, string email, out int errorNumber, out string errorDescription)
        {

            errorNumber = 0;
            errorDescription = null;

            int totalRecords = 0;

            object returnValue = base.ExecuteScalar(CommandType.StoredProcedure, "Framework_GetUserByEmail",
                true, _currentUser,
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@Email", DbType.String, email),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null));

            totalRecords = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);


            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return (string)returnValue;
        }
        public Model.UserData GetUser(string currentLogin, string userName, bool updateLastActivity, bool userIsOnline, out int errorNumber, out string errorDescription)
        {

            errorNumber = 0;
            errorDescription = null;

            int totalRecords = 0;

            DataTable table = base.ExecuteFill (CommandType.StoredProcedure, "Framework_GetUser",
                true, _currentUser,
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@UpdateLastActivity", DbType.Boolean, updateLastActivity),
                base.Parameters.Create("@UserIsOnline", DbType.Boolean, userIsOnline),
                base.Parameters.Create("@UserName", DbType.String, userName),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null));

            totalRecords = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);


            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            if (table.Rows.Count == 0)
                return null;


            return Convertion.UserData.ConvertToModel(table.Rows[0]);

        }



        public IList<Framework.Security.Model.UserData> LoadAllUsers(string currentLogin, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = null;

            
            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "Framework_LoadAllUsers",
                true, _currentUser,
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null));

            //totalRecords = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);


            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return ConvertToList(table);
        }

        #endregion
    }
}
