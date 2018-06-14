using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using Framework.Logging.Logger;
using System.Configuration;

namespace Framework.Security.Business
{
    public class CustomRoleProvider : RoleProvider
    {
        #region Variables
        private DataAccess.IRoleDao _roleDao = null;
        private string _currentLogin = null;
        private string _connectionName= null;
        private string _name = null;
        private string _description = null;
        #endregion

        #region Properties
        public override string Description
        {
            get
            {
                return _description;
            }
        }
        public override string Name
        {
            get
            {
                return _name;
            }
        }
        #endregion

        #region Constructors/Destructors
        public CustomRoleProvider(string currentLogin, DataAccess.IRoleDao roleDao)
            : base ()
        {
            if (roleDao == null)
                throw new ArgumentException("roleDao");

            _roleDao = roleDao;
            _currentLogin = currentLogin;
        }

        public CustomRoleProvider()
            : base()
        {
            _currentLogin = System.Web.HttpContext.Current.User.Identity.Name;
            _roleDao = new DataAccess.SQLSupport.RoleDao();
        }
        #endregion

        #region Methods
        private void SaveLog(string message)
        {
            //System.IO.StreamWriter writer = new System.IO.StreamWriter("C:\\temp\\log.log", true);
            //writer.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " - " + message);
            //writer.Close();
        }
        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (string.IsNullOrEmpty(configValue))
            {
                return defaultValue;
            }

            return configValue;
        }
        
        #endregion

        #region Abstract Members
        
        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {

            SaveLog("Initialize");

            base.Initialize(name, config);

            if (config == null)
                throw new ArgumentNullException("config");

            _name = name;

            if (string.IsNullOrEmpty(name))
            {
                name = "CustomRoleProvider";
            }

            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Provider used to make general connection");
            }

            //Initialize the abstract base class.
            //base.Initialize(name, config);

            _connectionName = GetConfigValue(config["connectionStringName"], "");

            if (string.IsNullOrEmpty(_connectionName))
                throw new ProviderException("ConnectionStringName was not find. This configuration is required");


            ConnectionStringSettings connectionStringSettings =
                ConfigurationManager.ConnectionStrings[_connectionName];

            if ((connectionStringSettings == null) ||
                (connectionStringSettings.ConnectionString.Trim() == String.Empty))
            {
                throw new ProviderException("Connection string cannot be blank.");
            }




            _roleDao.ApplicationName = GetConfigValue(config["applicationName"],
                System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);




            SaveLog("Initialize finished");

        }
        
        public override string ApplicationName
        {
            get
            {
                return _roleDao.ApplicationName;
            }
            set
            {
                _roleDao.ApplicationName = value;
            }
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {


            SaveLog("AddUsersToRoles");

            int errorNumber = 0;
            string errorDescription = null;


            foreach (string user in usernames)
            {
                Model.UserData userModel = new Framework.Security.Model.UserData(user);

                foreach (string role in roleNames)
                {
                    Model.Role roleModel = new Framework.Security.Model.Role(role);


                    LogManager.WriteDebug(_currentLogin, this, "Adding user " + user + " to role " + role, null);

                    DataAccess.AddOneUserToOneRoleTypes result = _roleDao.AddUserToRole(
                        _currentLogin, userModel, roleModel, out errorNumber, out errorDescription );

                    if (errorNumber > 0 || !string.IsNullOrEmpty(errorDescription))
                    {
                        LogManager.WriteWarning(_currentLogin, this, "Error adding user " + user + " to role " + role, errorDescription);
                        //throw new Exception(errorDescription);
                    }
                    



                    switch (result)
                    {
                        case Framework.Security.DataAccess.AddOneUserToOneRoleTypes.Sucess:
                            LogManager.WriteTrace(_currentLogin, this, "User " + user + " added to role " + role, null);

                            break;
                        case Framework.Security.DataAccess.AddOneUserToOneRoleTypes.CouldNotFindRole:
                            LogManager.WriteWarning(_currentLogin, this, "Could not find the role " + role + " to add user " + user, null);
                            throw new Exception("Could not find the role: " + roleModel.RoleName);

                        case Framework.Security.DataAccess.AddOneUserToOneRoleTypes.CouldNotFindUser:
                            LogManager.WriteWarning(_currentLogin, this, "Could not find the user " + user + " to be added in role " + role, null);
                            throw new Exception("Could not find the user: " + userModel.UserName);

                        case Framework.Security.DataAccess.AddOneUserToOneRoleTypes.Error:
                            LogManager.WriteWarning(_currentLogin, this, "Error to insert user " + user + " in role " + role, null);
                            throw new Exception();

                        case Framework.Security.DataAccess.AddOneUserToOneRoleTypes.RoleIsAlready:
                            LogManager.WriteWarning(_currentLogin, this, "User " + user + " is already in role " + role, null);
                            break;

                    }//end switch result
                    

                }//end foreach role

            }//end foreach user
        }
        public override void CreateRole(string roleName)
        {

            SaveLog("CreateRole");


            int errorNumber = 0;
            string errorDescription = null;

            Model.Role role = new Framework.Security.Model.Role(roleName);

            DataAccess.CreateRolesTypes result = _roleDao.CreateRole(
                _currentLogin, role, out errorNumber, out errorDescription);

            if (errorNumber > 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Error creating role " + role, errorDescription);
                throw new Exception(errorDescription);
            }

            switch (result)
            {
                case Framework.Security.DataAccess.CreateRolesTypes.Sucessfull:
                    LogManager.WriteTrace(_currentLogin, this, "Role " + role + " is created sucessfull.", null);
                    break;

                case Framework.Security.DataAccess.CreateRolesTypes.Error:
                    LogManager.WriteWarning(_currentLogin, this, "Error creating role " + role, null);
                    throw new Exception("Error creating role " + role);
                    //break;

                case Framework.Security.DataAccess.CreateRolesTypes.AlreadyExists:
                    LogManager.WriteWarning(_currentLogin, this, "Role " + role + " + is already exists", null);
                    break;

            }//end switch result

            
            
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {


            SaveLog("DeleteRole");

            int errorNumber = 0;
            string errorDescription = null;

            Model.Role role = new Framework.Security.Model.Role(roleName);

            DataAccess.DeleteRolesTypes result = _roleDao.DeleteRole(
                _currentLogin, role, throwOnPopulatedRole, out errorNumber, out errorDescription);

            if (errorNumber > 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Error deleting role " + roleName, errorDescription);
                return false;
            }

            switch (result)
            {
                case Framework.Security.DataAccess.DeleteRolesTypes.Sucessfull:
                    LogManager.WriteTrace(_currentLogin, this, "Role " + roleName + " is created sucessfull.", null);
                    return true;

                case Framework.Security.DataAccess.DeleteRolesTypes.Error:
                    LogManager.WriteWarning(_currentLogin, this, "Error deleting role " + roleName, null);
                    //throw new Exception("Error deleting role " + role);
                    break;

                case Framework.Security.DataAccess.DeleteRolesTypes.UserAssign:
                    LogManager.WriteWarning(_currentLogin, this, "There is user assign in the role " + role , null);
                    throw new Exception("There is user assign in the role " + roleName);
                    //break;

                case Framework.Security.DataAccess.DeleteRolesTypes.NotFound:
                    LogManager.WriteWarning(_currentLogin, this, "Role " + roleName + " + was not found", null);
                    //throw new Exception("Role " + role + " was not found.");
                    break;

            }//end switch result

            return false;
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {

            SaveLog("FindUsersInRole");

            //int errorNumber = 0;
            //string errorDescription = null;

            throw new NotImplementedException();
        }
        public override string[] GetAllRoles()
        {

            SaveLog("GetAllRoles");

            int errorNumber = 0;
            string errorDescription = null;

            List<Model.Role> list = _roleDao.GetAllRoles(_currentLogin, out errorNumber, out errorDescription);

            if (errorNumber > 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Error getting all roles", errorDescription);
                return null;
            }

            string[] result = new string[list.Count];

            for (int c = 0; c < list.Count; c++)
            {
                result[c] = list[c].RoleName;
            }

            return result;
        }
        public override string[] GetRolesForUser(string username)
        {

            SaveLog("GetRolesForUser");

            int errorNumber = 0;
            string errorDescription = null;

            Model.UserData user = new Framework.Security.Model.UserData (username);

            List<Model.Role> list = _roleDao.GetRolesForUser(_currentLogin, user, out errorNumber, out errorDescription);

            if (errorNumber > 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Error getting roles for user " + username, errorDescription);
                return null;
            }

            string[] result = new string[list.Count];

            for (int c = 0; c < list.Count; c++)
            {
                result[c] = list[c].RoleName;
            }

            return result;

        }
        public override string[] GetUsersInRole(string roleName)
        {

            SaveLog("GetUsersInRole");


            int errorNumber = 0;
            string errorDescription = null;

            Model.Role role = new Framework.Security.Model.Role(roleName);

            List<Model.UserData> list = _roleDao.GetUsersInRole(_currentLogin, role, out errorNumber, out errorDescription);

            if (errorNumber > 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Error getting users in role " + roleName, errorDescription);
                return null;
            }

            string[] result = new string[list.Count];

            for (int c = 0; c < list.Count; c++)
            {
                result[c] = list[c].UserName;
            }

            return result;
        }
        public override bool IsUserInRole(string username, string roleName)
        {

            SaveLog("IsUserInRole");

            int errorNumber = 0;
            string errorDescription = null;

            Model.Role role = new Framework.Security.Model.Role(roleName);
            Model.UserData user = new Framework.Security.Model.UserData(username);

            DataAccess.UserInRolesTypes result = _roleDao.IsUserInRole(_currentLogin, user, role, out errorNumber, out errorDescription);

            if (errorNumber > 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Error checking if the user " + username + " in role " + roleName, errorDescription);
                return false;
            }

            switch (result)
            {
                case Framework.Security.DataAccess.UserInRolesTypes.Error:
                    LogManager.WriteWarning(_currentLogin, this, "Error checking if user " + username + " is in role " + roleName, null);
                    return false;

                case Framework.Security.DataAccess.UserInRolesTypes.RoleNotFound:
                    LogManager.WriteWarning(_currentLogin, this, "Role " + roleName + " not found", null);
                    return false;

                case Framework.Security.DataAccess.UserInRolesTypes.Sucess:
                    LogManager.WriteTrace(_currentLogin, this, "User " + username + " is in role " + roleName, null);
                    return true;

                case Framework.Security.DataAccess.UserInRolesTypes.UserIsNotInRole:
                    LogManager.WriteWarning(_currentLogin, this, "User " + username + " is not in role " + roleName, null);
                    return false;

                case Framework.Security.DataAccess.UserInRolesTypes.UserNotFound:
                    LogManager.WriteWarning(_currentLogin, this, "User " + username + " was not found", null);
                    return false;

            }//end result


            return false;
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {

            SaveLog("RemoveUsersFromRoles");


            int errorNumber = 0;
            string errorDescription = null;


            foreach (string user in usernames)
            {
                Model.UserData userModel = new Framework.Security.Model.UserData(user);

                foreach (string role in roleNames)
                {
                    Model.Role roleModel = new Framework.Security.Model.Role(role);


                    LogManager.WriteDebug(_currentLogin, this, "Removing user " + user + " from role " + role, null);

                    DataAccess.RemoveOneUserFromOneRole result = _roleDao.RemoveUserFromRole(
                        _currentLogin, userModel, roleModel, out errorNumber, out errorDescription);

                    if (errorNumber > 0 || !string.IsNullOrEmpty(errorDescription))
                    {
                        LogManager.WriteWarning(_currentLogin, this, "Error removing user " + user + " from role " + role, errorDescription);
                        throw new Exception(errorDescription);
                    }




                    switch (result)
                    {
                        case Framework.Security.DataAccess.RemoveOneUserFromOneRole.Sucess:
                            LogManager.WriteTrace(_currentLogin, this, "User " + user + " removed from role " + role, null);

                            break;
                        case Framework.Security.DataAccess.RemoveOneUserFromOneRole.CouldNotFindRole:
                            LogManager.WriteWarning(_currentLogin, this, "Could not find the role " + role + " to remove user " + user, null);
                            throw new Exception("Could not find the role: " + roleModel.RoleName);

                        case Framework.Security.DataAccess.RemoveOneUserFromOneRole.CouldNotFindUser:
                            LogManager.WriteWarning(_currentLogin, this, "Could not find the user " + user + " to be removed in role " + role, null);
                            throw new Exception("Could not find the user: " + userModel.UserName);

                        case Framework.Security.DataAccess.RemoveOneUserFromOneRole.Error:
                            LogManager.WriteWarning(_currentLogin, this, "Error to remove user " + user + " in role " + role, null);
                            throw new Exception();

                        

                    }//end switch result


                }//end foreach role

            }//end foreach user
        }
        public override bool RoleExists(string roleName)
        {


            SaveLog("RoleExists");

            int errorNumber = 0;
            string errorDescription = null;

            Model.Role role = new Framework.Security.Model.Role(roleName);

            bool result = _roleDao.RoleExists(_currentLogin, role, out errorNumber, out errorDescription);

            if (errorNumber > 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Error checking if role " + roleName + " exists", errorDescription);
                return false;
            }

            if (result)
                LogManager.WriteTrace(_currentLogin, this, "Role " + roleName + " exists.", null);
            else
                LogManager.WriteTrace(_currentLogin, this, "Role " + roleName + " not exists.", null);
            


            return result;
        }
        #endregion
    }
}
