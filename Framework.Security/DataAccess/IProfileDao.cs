using System;
using System.Collections.Generic;
using System.Web.Profile;
using System.Text;
using System.Configuration;

namespace Framework.Security.DataAccess
{
    public interface IProfileDao
    {
        string ApplicationName{get;set;}
        
        int DeleteInactiveProfiles(string currentUser,  ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, out int errorNumber, out string errorDescription);
        int DeleteProfiles(string currentUser, string[] usernames, out int errorNumber, out string errorDescription);
        int DeleteProfiles(string currentUser, ProfileInfoCollection profiles, out int errorNumber, out string errorDescription);
        ProfileInfoCollection FindInactiveProfilesByUserName(string currentUser, ProfileAuthenticationOption authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords, out int errorNumber, out string errorDescription);
        ProfileInfoCollection FindProfilesByUserName(string currentUser, ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords, out int errorNumber, out string errorDescription);
        ProfileInfoCollection GetAllInactiveProfiles(string currentUser, ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords, out int errorNumber, out string errorDescription);
        ProfileInfoCollection GetAllProfiles(string currentUser, ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords, out int errorNumber, out string errorDescription);
        int GetNumberOfInactiveProfiles(string currentUser, ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, out int errorNumber, out string errorDescription);
        SettingsPropertyValueCollection GetPropertyValues(string currentUser, SettingsContext context, SettingsPropertyCollection collection, out int errorNumber, out string errorDescription);
        void SetPropertyValues(string currentUser, bool allowAnonymous, string userName, bool authenticated, SettingsContext context, SettingsPropertyValueCollection collection, out int errorNumber, out string errorDescription);



        bool SetPropertyValues(string currentUser, string names, string values, byte[] buf, bool allowAnonymous, out int errorNumber, out string errorDescription);
        
    }
}
