using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Text;

namespace Framework.Security.Business
{
    public interface IUserDataService
    {
        bool ApproveUser();
        bool ChangePassword(string oldPassword, string newPassword);
        bool ChangePasswordQuestionAndAnswer(string password, string newPasswordQuestion, string newPasswordAnswer);
        MembershipCreateStatus CreateUser();
        bool DesapproveUser();
        string GetPassword();
        string GetPasswordWithFormat(string passwordAnswer, bool updateLastLoginActivityDate);
        bool LockUser();
        string ResetPassword(string newPassword, string answer);
        bool SetPassword(string newPassword);
        bool UnlockUser();
        bool UpdateUser();
        bool UpdateUserInfo(bool updateLastLoginActivityDate);
        bool ValidateUser(string password);
        Model.UserData LoadUser();
        bool DeleteUser(bool deleteAllRelatedData);
    }
}
