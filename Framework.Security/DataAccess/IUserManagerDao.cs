using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Text;
using System.Configuration;

namespace Framework.Security.DataAccess
{
    #region Enumerations

    public enum FailureType
    {
        Password = 1,
        PasswordAnswer = 2
    }

    #endregion


    public interface IUserManagerDao
    {
        Model.UserData GetUser(string currentLogin, string userName, bool updateLastActivity, bool userIsOnline, out int errorNumber, out string errorDescription);
        string GetUserNameByEmail(string currentLogin, string email, out int errorNumber, out string errorDescription);
        int GetNumberOfUsersOnline(string currentLogin, int userIsOnlineTimeWindow, out int errorNumber, out string errorDescription);
        IList<Model.UserData> GetAllUsers(string currentLogin, int pageIndex, int pageSize, out int totalRecords, out int errorNumber, out string errorDescription);
        IList<Model.UserData> FindUsersByName(string currentLogin, string userNameToMatch, int pageIndex, int pageSize, out int totalRecords, out int errorNumber, out string errorDescription);
        IList<Model.UserData> FindUsersByEmail(string currentLogin, string emailToMatch, int pageIndex, int pageSize, out int totalRecords, out int errorNumber, out string errorDescription);

        IList<Model.UserData> LoadAllUsers(string currentLogin, out int errorNumber, out string errorDescription);

        ConnectionStringSettings ConnectionStringSetting { get; }

    }
}
