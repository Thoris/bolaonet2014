using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Security.DataAccess
{
    #region Enumerations
    public enum CreateRolesTypes
    {
        Error = -1,
        Sucessfull = 0,
        AlreadyExists = 1,
    }
    public enum DeleteRolesTypes
    {
        Error = -1,
        Sucessfull = 0,
        NotFound = 1,
        UserAssign = 2,
    }
    public enum AddUsersToRoleTypes
    {
        Error = -1,
        Sucess = 0,
        CouldNotSetAllRoles = 2,
        RoleIsAlready = 3,

    }
    public enum AddOneUserToOneRoleTypes
    {
        Error = -1,
        Sucess = 0,
        CouldNotFindUser = 1,
        CouldNotFindRole = 2,
        RoleIsAlready = 3,
    }
    public enum UserInRolesTypes
    {
        Error = -1,
        Sucess = 1,
        UserIsNotInRole = 0,
        UserNotFound = 2,
        RoleNotFound = 3,
    }

    public enum RemoveUserFromRoles
    {
        Error = -1,
        Sucess = 0,
        CouldNotSelectAllUsers = 1,
        CouldNotSelectAllRoles = 2,
        CouldNotDeleteRoles = 3,

    }
    public enum RemoveOneUserFromOneRole
    {
        Error = -1,
        Sucess = 0,
        CouldNotFindUser = 1,
        CouldNotFindRole = 2,
    }
    #endregion

    public interface IRoleDao
    {


        string ApplicationName { get; set; }

        AddOneUserToOneRoleTypes AddUserToRole(string currentUser, Model.UserData user, Model.Role role, out int errorNumber, out string errorDescription);
        CreateRolesTypes CreateRole(string currentUser, Model.Role role, out int errorNumber, out string errorDescription);
        DeleteRolesTypes DeleteRole(string currentUser, Model.Role role, bool throwOnPopulatedRole, out int errorNumber, out string errorDescription);
        List<Model.Role> GetAllRoles(string currentUser, out int errorNumber, out string errorDescription);
        List<Model.Role> GetRolesForUser(string currentUser, Model.UserData user, out int errorNumber, out string errorDescription);
        List<Model.UserData> GetUsersInRole(string currentUser, Model.Role role, out int errorNumber, out string errorDescription);
        UserInRolesTypes IsUserInRole(string currentUser, Model.UserData user, Model.Role role, out int errorNumber, out string errorDescription);
        RemoveOneUserFromOneRole RemoveUserFromRole(string currentUser, Model.UserData user, Model.Role role, out int errorNumber, out string errorDescription);
        bool RoleExists(string currentUser, Model.Role role, out int errorNumber, out string errorDescription);
        
    }
}
