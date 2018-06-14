using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Text;
using System.Configuration;
using System.Data;

namespace Framework.Security.DataAccess
{
    public interface IUserDao
    {
        bool ApproveUser(string currentLogin, Model.UserData userData, out int errorNumber, out string errorDescription);
        bool ChangePassword(string currentLogin, Model.UserData userData, MembershipPasswordFormat passwordFormatType, string oldPassword, string newPassword, out int errorNumber, out string errorDescription);
        bool ChangePasswordQuestionAndAnswer(string currentLogin, Model.UserData userData, MembershipPasswordFormat passwordFormatType, string newPasswordQuestion, string newPasswordAnswer, out int errorNumber, out string errorDescription);
        MembershipCreateStatus CreateUser(string currentLogin, Model.UserData userData, MembershipPasswordFormat passwordFormatType, bool requiresUniqueEmail, out int errorNumber, out string errorDescription);
        bool DesapproveUser(string currentLogin, Model.UserData userData, out int errorNumber, out string errorDescription);
        string GetPassword(string currentLogin, Model.UserData userData, int maxInvalidPasswordAttempts, int passwordAttemptWindow, string passwordAnswer, out int errorNumber, out string errorDescription);
        string GetPasswordWithFormat(string currentLogin, Model.UserData userData, bool updateLastLoginActivityDate, out int errorNumber, out string errorDescription);
        bool LockUser(string currentLogin, Model.UserData userData, out int errorNumber, out string errorDescription);
        string ResetPassword(string currentLogin, Model.UserData userData, MembershipPasswordFormat passwordFormatType, int maxInvalidPasswordAttempts, int passwordAttemptWindow, string newPassword, string answer, out int errorNumber, out string errorDescription);
        bool SetPassword(string currentLogin, Model.UserData userData, MembershipPasswordFormat passwordFormatType, string newPassword, out int errorNumber, out string errorDescription);
        bool UnlockUser(string currentLogin, Model.UserData userData, out int errorNumber, out string errorDescription);
        bool UpdateUser(string currentLogin, Model.UserData userData, bool requiresUniqueEmail, out int errorNumber, out string errorDescription);
        bool UpdateUserInfo(string currentLogin, Model.UserData userData, bool updateLastLoginActivityDate, int maxInvalidPasswordAttempts, int passwordAttemptWindow, out int errorNumber, out string errorDescription);
        bool ValidateUser(string currentLogin, Model.UserData userData, string password, int passwordAttemptWindow, int maxInvalidPasswordAttempts, out int errorNumber, out string errorDescription);
        Model.UserData LoadUser(string currentLogin, string userName, out int errorNumber, out string errorDescription);
        bool DeleteUser(string currentLogin, Model.UserData userData, bool deleteAllRelatedData, out int errorNumber, out string errorDescription);

        ConnectionStringSettings ConnectionStringSetting {get;}
    }
}
