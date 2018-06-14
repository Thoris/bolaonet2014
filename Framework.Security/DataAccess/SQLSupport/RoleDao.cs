using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

namespace Framework.Security.DataAccess.SQLSupport
{
    public class RoleDao : Framework.DataServices.CommonDatabase, IRoleDao
    {


        #region Variables
        private string _applicationName;
        private string _currentUser;

        #endregion

        #region Constructors/Destructors
        public RoleDao()
            : base ()
        {
        }
        public RoleDao(string connectionName)
            : base(connectionName)
        {
        }
        public RoleDao(string applicationName, ConnectionStringSettings connectionStringSettings, string currentUser)   
            : base (connectionStringSettings.Name,
                    connectionStringSettings.ConnectionString,
                    connectionStringSettings.ProviderName)
        {
            _applicationName = applicationName;
            _currentUser = currentUser;
            

            
            
        }
        #endregion

        //#region Methods
        //public static List<Model.Role> ConvertToList(DataTable table)
        //{
        //    List<Model.Role> list = new List<Model.Role>();

        //    foreach (DataRow row in table.Rows)
        //    {
        //        list.Add(ConvertToObject(row));
        //    }

        //    return list;
        //}
        //public static Model.Role ConvertToObject(DataRow row)
        //{
        //    string nome = "";

        //    if (row.Table.Columns.Contains("RoleName") && !Convert.IsDBNull(row["RoleName"]))
        //    {
        //        nome = Convert.ToString(row["RoleName"]);
        //    }

        //    Model.Role entry = new Model.Role(nome);
        //    entry.LoadDataRow(row);

        //    if (row.Table.Columns.Contains("Description") && !Convert.IsDBNull(row["Description"]))
        //    {
        //        entry.Description = Convert.ToString(row["Description"]);
        //    }

        //    return entry;

        //}
        //#endregion

        #region IRoleDao Members

        public string ApplicationName
        {
            get
            {
                return _applicationName ;
            }
            set
            {
                _applicationName = value;
            }
        }

        public AddOneUserToOneRoleTypes AddUserToRole(string currentUser, Model.UserData user, Model.Role role, out int errorNumber, out string errorDescription)
        {
            errorDescription = null;
            errorNumber = 0;


            base.ExecuteNonQuery(CommandType.StoredProcedure, "Framework_AddUserToRole",
                true, _currentUser,
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null),
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@RoleName", DbType.String, role.RoleName),
                base.Parameters.Create("@UserName", DbType.String, user.UserName),
                base.Parameters.Create("@Description", DbType.String, role.Description));


            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;


            AddOneUserToOneRoleTypes result = (AddOneUserToOneRoleTypes)
                Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            return result;
        }
        public CreateRolesTypes CreateRole(string currentUser, Model.Role role, out int errorNumber, out string errorDescription)
        {
            errorDescription = null;
            errorNumber = 0;

            base.ExecuteNonQuery(CommandType.StoredProcedure, "Framework_CreateRole",
                true, _currentUser,
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null),
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@RoleName", DbType.String, role.RoleName),
                base.Parameters.Create("@Description", DbType.String, role.Description));

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            CreateRolesTypes result = (CreateRolesTypes)
                Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            return result;
        }
        public DeleteRolesTypes DeleteRole(string currentUser, Model.Role role, bool throwOnPopulatedRole, out int errorNumber, out string errorDescription)
        {
            errorDescription = null;
            errorNumber = 0;

            base.ExecuteNonQuery(CommandType.StoredProcedure, "Framework_DeleteRole",
                true, _currentUser,
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null),
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@RoleName", DbType.String, role.RoleName)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            DeleteRolesTypes result = (DeleteRolesTypes)
                Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            return result;
        }
        public List<Model.Role> GetAllRoles(string currentUser, out int errorNumber, out string errorDescription)
        {
            errorDescription = null;
            errorNumber = 0;

            DataTable table = base.ExecuteFill (CommandType.StoredProcedure, "Framework_GetAllRoles",
                true, _currentUser,
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null),
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return Convertion.Role.ConvertToList(table);

        }
        public List<Model.Role> GetRolesForUser(string currentUser, Model.UserData user, out int errorNumber, out string errorDescription)
        {
            errorDescription = null;
            errorNumber = 0;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "Framework_GetRolesForUser",
                true, _currentUser,
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null),
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@UserName", DbType.String, user.UserName)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            return Convertion.Role.ConvertToList(table);
        }
        public List<Model.UserData> GetUsersInRole(string currentUser, Model.Role role, out int errorNumber, out string errorDescription)
        {
            errorDescription = null;
            errorNumber = 0;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "Framework_GetUsersInRole",
                true, _currentUser,
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null),
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@RoleName", DbType.String, role.RoleName)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            List<Model.UserData> users = new List<Framework.Security.Model.UserData> ();

            foreach (DataRow row in table.Rows)
            {
                users.Add(Convertion.UserData.ConvertToModel(row));
            }

            return users;
        }
        public UserInRolesTypes IsUserInRole(string currentUser, Model.UserData user, Model.Role role, out int errorNumber, out string errorDescription)
        {
            errorDescription = null;
            errorNumber = 0;

            base.ExecuteFill(CommandType.StoredProcedure, "Framework_IsUserInRole",
                true, _currentUser,
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null),
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@RoleName", DbType.String, role.RoleName),
                base.Parameters.Create("@UserName", DbType.String, user.UserName)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            UserInRolesTypes result = (UserInRolesTypes)
                Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            return result;

        }
        public RemoveOneUserFromOneRole RemoveUserFromRole(string currentUser, Model.UserData user, Model.Role role, out int errorNumber, out string errorDescription)
        {
            errorDescription = null;
            errorNumber = 0;

            base.ExecuteNonQuery(CommandType.StoredProcedure, "Framework_RemoveUserFromRole",
                true, _currentUser,
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null),
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@RoleName", DbType.String, role.RoleName),
                base.Parameters.Create("@UserName", DbType.String, user.UserName)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            RemoveOneUserFromOneRole result = (RemoveOneUserFromOneRole)
                Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            return result;
        }
        public bool RoleExists(string currentUser, Model.Role role, out int errorNumber, out string errorDescription)
        {
            errorDescription = null;
            errorNumber = 0;

            base.ExecuteNonQuery(CommandType.StoredProcedure, "Framework_RoleExists",
                true, _currentUser,
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null),
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@RoleName", DbType.String, role.RoleName)
                );

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;


            int result = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value);

            if (result == 0)
                return false;
            else
                return true;

        }

        #endregion

    }
}
