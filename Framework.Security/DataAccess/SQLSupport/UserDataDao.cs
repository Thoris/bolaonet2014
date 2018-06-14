using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.Common;
using System.Web.Security;
using System.Configuration;
using Framework.Logging.Logger;

namespace Framework.Security.DataAccess.SQLSupport
{
    public class UserDataDao : Framework.DataServices.CommonDatabase, IUserDao
    {
        #region Variables
        private ConnectionStringSettings _connectionStringSettings = null;
        private string _applicationName = null;
        #endregion

        #region Constructors/Destructors
        public UserDataDao()
            : base ()
        {
        }
        public UserDataDao(string connectionName)
            : base(connectionName)
        {
        }
        public UserDataDao(string applicationName, ConnectionStringSettings connectionStringSettings)   
            : base (connectionStringSettings.Name,
                    connectionStringSettings.ConnectionString,
                    connectionStringSettings.ProviderName)
        {
            _applicationName = applicationName;
            _connectionStringSettings = connectionStringSettings;

            
        }

        #endregion

        #region IUserDao Members

        public bool ApproveUser(string currentLogin, Model.UserData userData, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = "";

            base.ExecuteNonQuery(CommandType.StoredProcedure, "Framework_ApproveUser",
                true, currentLogin,
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null),
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),                
                base.Parameters.Create("@ActivateKey", DbType.String, userData.ActivateKey),
                base.Parameters.Create("@Email", DbType.String, userData.Email),                
                base.Parameters.Create("@UserName", DbType.String, userData.UserName));


            errorDescription =  base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;

            return Convert.ToInt32 (base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 0 ? true : false;

        }
        public bool ChangePassword(string currentLogin, Model.UserData userData, MembershipPasswordFormat passwordFormatType, string oldPassword, string newPassword, out int errorNumber, out string errorDescription)
        {

            errorNumber = 0;
            errorDescription = "";

            int passwordFormat = 0;


            switch (passwordFormatType)
            {
                case MembershipPasswordFormat.Clear:
                    passwordFormat = 0;
                    break;
                case MembershipPasswordFormat.Encrypted:
                    passwordFormat = 1;
                    break;
                case MembershipPasswordFormat.Hashed:
                    passwordFormat = 2;
                    break;
            }

            base.ExecuteNonQuery(CommandType.StoredProcedure, "Framework_ChangePassword",
                true, currentLogin,
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null),
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@UserName", DbType.String, userData.UserName),
                base.Parameters.Create("@Password", DbType.String, Framework.Security.Util.Cryptography.EncodePassword(passwordFormatType, newPassword)),
                base.Parameters.Create("@OldPassword", DbType.String, Framework.Security.Util.Cryptography.EncodePassword(passwordFormatType, oldPassword)),
                base.Parameters.Create("@PasswordFormat", DbType.Int32, passwordFormat));


            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 0 ? true : false;

        }
        public bool ChangePasswordQuestionAndAnswer(string currentLogin, Model.UserData userData, MembershipPasswordFormat passwordFormatType, string newPasswordQuestion, string newPasswordAnswer, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = "";

            int passwordFormat = 0;

            switch (passwordFormatType)
            {
                case MembershipPasswordFormat.Clear:
                    passwordFormat = 0;
                    break;
                case MembershipPasswordFormat.Encrypted:
                    passwordFormat = 1;
                    break;
                case MembershipPasswordFormat.Hashed:
                    passwordFormat = 2;
                    break;
            }


            int result = base.ExecuteNonQuery(CommandType.StoredProcedure, "Framework_ChangePasswordQuestionAndAnswer",
                true, currentLogin,
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@UserName", DbType.String, userData.UserName),
                base.Parameters.Create("@NewPasswordQuestion", DbType.String, newPasswordQuestion),
                base.Parameters.Create("@NewPasswordAnswer", DbType.String, Framework.Security.Util.Cryptography.EncodePassword(passwordFormatType, newPasswordAnswer)),
                base.Parameters.Create("@PasswordFormat", DbType.Int32, passwordFormat),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value));

            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 0 ? true : false;


        }
        public MembershipCreateStatus CreateUser(string currentLogin, Model.UserData userData, MembershipPasswordFormat passwordFormatType, bool requiresUniqueEmail, out int errorNumber, out string errorDescription)
        {

            errorNumber = 0;
            errorDescription = "";


            MembershipCreateStatus status;
            int passwordFormat = 0;

            switch (passwordFormatType)
            {
                case MembershipPasswordFormat.Clear:
                    passwordFormat = 0;
                    break;
                case MembershipPasswordFormat.Encrypted:
                    passwordFormat = 1;
                    break;
                case MembershipPasswordFormat.Hashed:
                    passwordFormat = 2;
                    break;
            }

            if (string.IsNullOrEmpty(userData.ActivateKey))
            {
                userData.ActivateKey = Framework.Security.Util.RandomPasswordCreator.CreatePassword(50);
            }


            int result = base.ExecuteNonQuery(CommandType.StoredProcedure, "Framework_CreateUser",
                true, currentLogin,
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value),
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@UserName", DbType.String, userData.UserName),
                base.Parameters.Create("@Email", DbType.String, userData.Email),
                base.Parameters.Create("@Password", DbType.String, Framework.Security.Util.Cryptography.EncodePassword(passwordFormatType, userData.Password)),
                base.Parameters.Create("@FullName", DbType.String, userData.FullName),
                base.Parameters.Create("@BirthDate", DbType.DateTime, userData.BirthDate),
                base.Parameters.Create("@CellPhone", DbType.String, userData.CellPhone),
                base.Parameters.Create("@PhoneNumber", DbType.String, userData.PhoneNumber),
                base.Parameters.Create("@CompanyPhone", DbType.String, userData.CompanyPhone),
                base.Parameters.Create("@Country", DbType.String, userData.Country),
                base.Parameters.Create("@City", DbType.String, userData.City),
                base.Parameters.Create("@State", DbType.String, userData.State),
                base.Parameters.Create("@Street", DbType.String, userData.Street),
                base.Parameters.Create("@StreetNumber", DbType.Int32, userData.StreetNumber),
                base.Parameters.Create("@CPF", DbType.String, userData.CPF),
                base.Parameters.Create("@RG", DbType.String, userData.RG),
                base.Parameters.Create("@MSN", DbType.String, userData.MSN),
                base.Parameters.Create("@Skype", DbType.String, userData.Skype),
                base.Parameters.Create("@Male", DbType.Boolean, userData.Male),
                base.Parameters.Create("@IsApproved", DbType.Boolean, userData.IsApproved),
                base.Parameters.Create("@IsLockedOut", DbType.Boolean, userData.IsLockedOut),
                base.Parameters.Create("@PasswordQuestion", DbType.String, userData.PasswordQuestion),
                base.Parameters.Create("@PasswordAnswer", DbType.String, Framework.Security.Util.Cryptography.EncodePassword(passwordFormatType, userData.PasswordAnswer)),
                base.Parameters.Create("@UniqueEmail", DbType.Boolean, requiresUniqueEmail),
                base.Parameters.Create("@PasswordFormat", DbType.Int32, passwordFormat),
                base.Parameters.Create("@IDMaritalStatus", DbType.Int32, (int)userData.Marital),
                base.Parameters.Create("@PostalCode", DbType.String, userData.PostalCode),
                base.Parameters.Create("@ActivateKey", DbType.String, userData.ActivateKey)
                );


            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            int returnValue = (int)base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value;

            if (returnValue == 0)
            {
                status = MembershipCreateStatus.Success;
            }
            else
            {
                //status = MembershipCreateStatus.UserRejected;
                status = (MembershipCreateStatus)returnValue;
            }

            return status;
        }
        public bool DesapproveUser(string currentLogin, Model.UserData userData, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = "";

            base.ExecuteNonQuery(CommandType.StoredProcedure, "Framework_DesapproveUser",
                true, currentLogin,
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@UserName", DbType.String, userData.UserName),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value));


            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 0 ? true : false;
            
        }
        public string GetPassword(string currentLogin, Model.UserData userData, int maxInvalidPasswordAttempts, int passwordAttemptWindow, string passwordAnswer, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = "";

            string password = string.Empty;

            try
            {
                DbDataReader reader = (DbDataReader)base.ExecuteReader(CommandType.StoredProcedure, "Framework_GetPassword",
                    true, currentLogin, false,
                    base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                    base.Parameters.Create("@UserName", DbType.String, userData.UserName),
                    base.Parameters.Create("@MaxInvalidPasswordAttempts", DbType.Int32, maxInvalidPasswordAttempts),
                    base.Parameters.Create("@PasswordAttemptWindow", DbType.Int32, passwordAttemptWindow),
                    base.Parameters.Create("@PasswordAnswer", DbType.String, passwordAnswer),
                    base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value));


                errorDescription = base.ExecutionStatus.ErrorDescription;
                errorNumber = base.ExecutionStatus.ErrorNumber;



                if (reader.HasRows)
                {
                    reader.Read();

                    if (Convert.ToBoolean(reader["IsLockedOut"]))
                    {
                        throw new MembershipPasswordException("The supplied user is locked out.");
                    }

                    password = reader["password"].ToString();
                }
                else
                {
                    throw new MembershipPasswordException("The supplied user name is not found.");
                }
            }
            finally
            {
                base.Close();
            }


            return password;
        }
        public string GetPasswordWithFormat(string currentLogin, Model.UserData userData, bool updateLastLoginActivityDate, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = "";

            string password = string.Empty;

            try
            {
                DbDataReader reader = (DbDataReader)base.ExecuteReader(CommandType.StoredProcedure, "Framework_GetPasswordWithFormat",
                    true, currentLogin, false,
                    base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                    base.Parameters.Create("@UserName", DbType.String, userData.UserName),
                    base.Parameters.Create("@UpdateLastLoginActivityDate", DbType.Boolean, updateLastLoginActivityDate),
                    base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value));


                errorDescription = base.ExecutionStatus.ErrorDescription;
                errorNumber = base.ExecutionStatus.ErrorNumber;



                //if (reader.HasRows)
                if (reader.Read ())
                {
                   // reader.Read();

                    if (Convert.ToBoolean(reader["IsLockedOut"]))
                    {
                        throw new MembershipPasswordException("The supplied user is locked out.");
                    }

                    password = reader["password"].ToString();
                }
                else
                {
                    throw new MembershipPasswordException("The supplied user name is not found.");
                }
            }
            finally
            {
                base.Close();
            }


            return password;

        }
        public bool LockUser(string currentLogin, Model.UserData userData, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = "";


            base.ExecuteNonQuery(CommandType.StoredProcedure, "Framework_LockUser",
                true, currentLogin,
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@UserName", DbType.String, userData.UserName),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value));


            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 0 ? true : false;
        }
        public string ResetPassword(string currentLogin, Model.UserData userData, MembershipPasswordFormat passwordFormatType, int maxInvalidPasswordAttempts, int passwordAttemptWindow, string newPassword, string answer, out int errorNumber, out string errorDescription)
        {

            errorNumber = 0;
            errorDescription = "";


            string password = string.Empty;
            string passwordAnswer = string.Empty;
            int passwordFormat = 0;

            switch (passwordFormatType)
            {
                case MembershipPasswordFormat.Clear:
                    passwordFormat = 0;
                    break;
                case MembershipPasswordFormat.Encrypted:
                    passwordFormat = 1;
                    break;
                case MembershipPasswordFormat.Hashed:
                    passwordFormat = 2;
                    break;
            }

            try
            {
                DbDataReader reader = (DbDataReader)base.ExecuteReader(CommandType.StoredProcedure,
                    "Framework_ResetPassword", true, currentLogin, false,
                    base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                    base.Parameters.Create("@UserName", DbType.String, userData.UserName),
                    base.Parameters.Create("@NewPassword", DbType.String, Framework.Security.Util.Cryptography.EncodePassword(newPassword)),
                    base.Parameters.Create("@MaxInvalidPasswordAttempts", DbType.Int32, maxInvalidPasswordAttempts),
                    base.Parameters.Create("@PasswordAttemptWindow", DbType.Int32, passwordAttemptWindow),
                    base.Parameters.Create("@PasswordFormat", DbType.Int32, passwordFormat),
                    base.Parameters.Create("@PasswordAnswer", DbType.String, Framework.Security.Util.Cryptography.EncodePassword(answer)),
                    base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value));

                if (reader.Read())
                {
                    if (Convert.ToBoolean(reader["IsLockedOut"]))
                    {
                        throw new MembershipPasswordException("The supplied user is locked out.");
                    }

                    passwordAnswer = reader["Password"].ToString();


                    errorDescription = base.ExecutionStatus.ErrorDescription;
                    errorNumber = base.ExecutionStatus.ErrorNumber;


                }
                else
                {
                    throw new MembershipPasswordException("The supplied user name is not found.");
                }
            }
            finally
            {
                base.Close();
            }

            return passwordAnswer;

        }
        public bool SetPassword(string currentLogin, Model.UserData userData, MembershipPasswordFormat passwordFormatType, string newPassword, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = "";

            int passwordFormat = 0;

            switch (passwordFormatType)
            {
                case MembershipPasswordFormat.Clear:
                    passwordFormat = 0;
                    break;
                case MembershipPasswordFormat.Encrypted:
                    passwordFormat = 1;
                    break;
                case MembershipPasswordFormat.Hashed:
                    passwordFormat = 2;
                    break;
            }

            int result = base.ExecuteNonQuery(CommandType.StoredProcedure, "Framework_SetPassword",
                true, currentLogin,
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@UserName", DbType.String, userData.UserName),                
                base.Parameters.Create("@NewPassword", DbType.String, newPassword),                
                base.Parameters.Create("@PasswordFormat", DbType.Int32, passwordFormat),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value));

            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 0 ? true : false;
        }
        public bool UnlockUser(string currentLogin, Model.UserData userData, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = "";

            int result = (int)base.ExecuteNonQuery(CommandType.StoredProcedure, "Framework_UnlockUser",
                true, currentLogin,
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@UserName", DbType.String, userData.UserName),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value));


            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 0 ? true : false;
        }
        public bool UpdateUser(string currentLogin, Model.UserData userData, bool requiresUniqueEmail, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = "";


            int result = base.ExecuteNonQuery(CommandType.StoredProcedure, "Framework_UpdateUser",
                   true, currentLogin,
                   base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value),
                   base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                   base.Parameters.Create("@UserName", DbType.String, userData.UserName),
                   base.Parameters.Create("@Email", DbType.String, userData.Email),
                   base.Parameters.Create("@Comment", DbType.String, userData.Comments),                   
                   base.Parameters.Create("@IsApproved", DbType.Boolean, userData.IsApproved),
                   base.Parameters.Create("@LastLoginDate", DbType.DateTime, userData.LastLoginDate),                                     
                   base.Parameters.Create("@UniqueEmail", DbType.Boolean, requiresUniqueEmail),
                    base.Parameters.Create("@FullName", DbType.String, userData.FullName),
                    base.Parameters.Create("@BirthDate", DbType.DateTime, userData.BirthDate),
                    base.Parameters.Create("@CellPhone", DbType.String, userData.CellPhone),
                    base.Parameters.Create("@PhoneNumber", DbType.String, userData.PhoneNumber),
                    base.Parameters.Create("@CompanyPhone", DbType.String, userData.CompanyPhone),
                    base.Parameters.Create("@Country", DbType.String, userData.Country),
                    base.Parameters.Create("@City", DbType.String, userData.City),
                    base.Parameters.Create("@State", DbType.String, userData.State),
                    base.Parameters.Create("@Street", DbType.String, userData.Street),
                    base.Parameters.Create("@StreetNumber", DbType.Int32, userData.StreetNumber),
                    base.Parameters.Create("@CPF", DbType.String, userData.CPF),
                    base.Parameters.Create("@RG", DbType.String, userData.RG),
                    base.Parameters.Create("@MSN", DbType.String, userData.MSN),
                    base.Parameters.Create("@Skype", DbType.String, userData.Skype),
                    base.Parameters.Create("@Male", DbType.Boolean, userData.Male),
                    base.Parameters.Create("@ActivateKey", DbType.String, userData.ActivateKey),
                    base.Parameters.Create("@IDMaritalStatus", DbType.Int32, (int)userData.Marital),
                    base.Parameters.Create("@PostalCode", DbType.String, userData.PostalCode),
                    base.Parameters.Create("@ReceiveEmails", DbType.Boolean, userData.ReceiveEmails),
                   base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value));


            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 0 ? true : false;
        }
        public bool UpdateUserInfo(string currentLogin, Model.UserData userData, bool updateLastLoginActivityDate, int maxInvalidPasswordAttempts, int passwordAttemptWindow, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = "";


            int result = base.ExecuteNonQuery(CommandType.StoredProcedure, "Framework_UpdateUserInfo",
                   true, currentLogin,
                   base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value),
                   base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                   base.Parameters.Create("@UserName", DbType.String, userData.UserName),
                   base.Parameters.Create("@IsPasswordCorrect", DbType.Boolean, true),
                   base.Parameters.Create("@UpdateLastLoginActivityDate", DbType.Boolean, updateLastLoginActivityDate),
                   base.Parameters.Create("@MaxInvalidPasswordAttempts", DbType.Int32, maxInvalidPasswordAttempts),
                   base.Parameters.Create("@PasswordAttemptWindow", DbType.Int32, passwordAttemptWindow),

                   base.Parameters.Create("@LastLoginDate", DbType.DateTime, userData.LastLoginDate),
                   base.Parameters.Create("@LastActivityDate", DbType.DateTime, userData.LastActivityDate),
                   base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value));


            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 0 ? true : false;

        }
        public bool ValidateUser(string currentLogin, Model.UserData userData, string password, int passwordAttemptWindow, int maxInvalidPasswordAttempts, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = "";

            base.ExecuteNonQuery(CommandType.StoredProcedure, "Framework_ValidateUser",
                   true, currentLogin,
                   base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value),
                   base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                   base.Parameters.Create("@UserName", DbType.String, userData.UserName),
                   base.Parameters.Create("@Password", DbType.String, password),
                   base.Parameters.Create("@PasswordAttemptWindow", DbType.Int32, passwordAttemptWindow),
                   base.Parameters.Create("@MaxInvalidPasswordAttempts", DbType.Int32, maxInvalidPasswordAttempts)
                   );


            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;
            

            bool result = Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 0 ? true : false;



            return result;
        }
        public Model.UserData LoadUser(string currentLogin, string userName, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = "";

            //Model.UserData userData = new Framework.Security.Model.UserData();

            DataTable table = base.ExecuteFill (CommandType.StoredProcedure, "Framework_LoadUser",
                true, currentLogin,
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@UserName", DbType.String, userName));


            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            return Convertion.UserData.ConvertToModel(table.Rows[0]);
        }
        public bool DeleteUser(string currentLogin, Model.UserData userData, bool deleteAllRelatedData, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = "";

            int result = (int)base.ExecuteNonQuery(CommandType.StoredProcedure, "Framework_DeleteUser",
                true, currentLogin,
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@UserName", DbType.String, userData.UserName),
                base.Parameters.Create("@DeleteAllRelatedData", DbType.Boolean, deleteAllRelatedData),
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, DBNull.Value));


            errorDescription = base.ExecutionStatus.ErrorDescription;
            errorNumber = base.ExecutionStatus.ErrorNumber;


            return Convert.ToInt32(base.ExecutionStatus.Command.Parameters["@ReturnValue"].Value) == 0 ? true : false;
        }
        //public static Model.UserData ConvertToModel(DataRow row)
        //{

        //    string userName = string.Empty;
        //    string fullname = string.Empty;
        //    string lastName = string.Empty;
        //    DateTime birthDate = DateTime.MinValue;
        //    bool male = false;
        //    string cellPhone = string.Empty;
        //    string phoneNumber = string.Empty;
        //    string companyPhone = string.Empty;
        //    string city = string.Empty;
        //    string country = string.Empty;
        //    string department = string.Empty;
        //    string street = string.Empty;
        //    int streetNumber= 0;
        //    string cPF = string.Empty;
        //    string rG = string.Empty;
        //    string mSN = string.Empty;
        //    string skype = string.Empty;
        //    string email = string.Empty;
        //    bool isApproved = false;
        //    bool isLockedOut = false;
        //    DateTime lastActivityDate = DateTime.MinValue;
        //    DateTime lastLockoutDate = DateTime.MinValue;
        //    DateTime lastLoginDate = DateTime.MinValue;
        //    DateTime lastPasswordChangedDate = DateTime.MinValue;
        //    string passwordQuestion = string.Empty;
        //    int failedPasswordAttemptCount = 0;
        //    DateTime failedPasswordAttemptWindowStart=DateTime.MinValue;
        //    int failedPasswordAnswerAttemptCount=0;
        //    DateTime failedPasswordAnswerAttemptWindowStart=DateTime.MinValue;
        //    int passwordFormat = 0;
        //    string passwordAnswer = string.Empty;
        //    string password = string.Empty;
        //    string createdBy = string.Empty;
        //    DateTime createdDate = DateTime.MinValue;
        //    string modifiedBy = string.Empty;
        //    DateTime modifiedDate = DateTime.MinValue;
        //    string comments = string.Empty;
        //    string requestedBy = string.Empty;
        //    DateTime requestedDate = DateTime.MinValue;
        //    string approvedBy = string.Empty;
        //    DateTime approvedDate = DateTime.MinValue;
        //    string activateKey = string.Empty;
        //    bool receiveEmails = false;
        //    string postalCode = string.Empty;
        //    Model.UserData.MaritalStatus maritalStatus = Framework.Security.Model.UserData.MaritalStatus.NotDefined;

        //    if (row.Table.Columns.Contains("UserName") && !Convert.IsDBNull(row["UserName"]))
        //    {
        //        userName = Convert.ToString(row["UserName"]);
        //    }
        //    if (row.Table.Columns.Contains("FullName") && !Convert.IsDBNull(row["FullName"]))
        //    {
        //        fullname = Convert.ToString(row["FullName"]);
        //    }
        //    if (row.Table.Columns.Contains("BirthDate") && !Convert.IsDBNull(row["BirthDate"]))
        //    {
        //        birthDate = Convert.ToDateTime(row["BirthDate"]);
        //    }
        //    if (row.Table.Columns.Contains("Male") && !Convert.IsDBNull(row["Male"]))
        //    {
        //        male = Convert.ToBoolean(row["Male"]);
        //    }
        //    if (row.Table.Columns.Contains("CellPhone") && !Convert.IsDBNull(row["CellPhone"]))
        //    {
        //        cellPhone = Convert.ToString(row["CellPhone"]);
        //    }
        //    if (row.Table.Columns.Contains("PhoneNumber") && !Convert.IsDBNull(row["PhoneNumber"]))
        //    {
        //        phoneNumber = Convert.ToString(row["PhoneNumber"]);
        //    }
        //    if (row.Table.Columns.Contains("CompanyPhone") && !Convert.IsDBNull(row["CompanyPhone"]))
        //    {
        //        companyPhone = Convert.ToString(row["CompanyPhone"]);
        //    }
        //    if (row.Table.Columns.Contains("City") && !Convert.IsDBNull(row["City"]))
        //    {
        //        city = Convert.ToString(row["City"]);
        //    }
        //    if (row.Table.Columns.Contains("Country") && !Convert.IsDBNull(row["Country"]))
        //    {
        //        country = Convert.ToString(row["Country"]);
        //    }
        //    if (row.Table.Columns.Contains("State") && !Convert.IsDBNull(row["State"]))
        //    {
        //        department = Convert.ToString(row["State"]);
        //    }
        //    if (row.Table.Columns.Contains("Street") && !Convert.IsDBNull(row["Street"]))
        //    {
        //        street  = Convert.ToString(row["Street"]);
        //    }
        //    if (row.Table.Columns.Contains("StreetNumber") && !Convert.IsDBNull(row["StreetNumber"]))
        //    {
        //        streetNumber = Convert.ToInt32(row["StreetNumber"]);
        //    }
        //    if (row.Table.Columns.Contains("CPF") && !Convert.IsDBNull(row["CPF"]))
        //    {
        //        cPF = Convert.ToString(row["CPF"]);
        //    }
        //    if (row.Table.Columns.Contains("RG") && !Convert.IsDBNull(row["RG"]))
        //    {
        //        rG = Convert.ToString(row["RG"]);
        //    }
        //    if (row.Table.Columns.Contains("MSN") && !Convert.IsDBNull(row["MSN"]))
        //    {
        //        mSN = Convert.ToString(row["MSN"]);
        //    }
        //    if (row.Table.Columns.Contains("Skype") && !Convert.IsDBNull(row["Skype"]))
        //    {
        //        skype = Convert.ToString(row["Skype"]);
        //    }
        //    if (row.Table.Columns.Contains("Email") && !Convert.IsDBNull(row["Email"]))
        //    {
        //        email = Convert.ToString(row["Email"]);
        //    }
        //    if (row.Table.Columns.Contains("IsApproved") && !Convert.IsDBNull(row["IsApproved"]))
        //    {
        //        isApproved = Convert.ToBoolean(row["IsApproved"]);
        //    }
        //    if (row.Table.Columns.Contains("IsLockedOut") && !Convert.IsDBNull(row["IsLockedOut"]))
        //    {
        //        isLockedOut = Convert.ToBoolean(row["IsLockedOut"]);
        //    }
        //    if (row.Table.Columns.Contains("LastActivityDate") && !Convert.IsDBNull(row["LastActivityDate"]))
        //    {
        //        lastActivityDate = Convert.ToDateTime(row["LastActivityDate"]);
        //    }
        //    if (row.Table.Columns.Contains("LastLockoutDate") && !Convert.IsDBNull(row["LastLockoutDate"]))
        //    {
        //        lastLockoutDate = Convert.ToDateTime(row["LastLockoutDate"]);
        //    }
        //    if (row.Table.Columns.Contains("LastLoginDate") && !Convert.IsDBNull(row["LastLoginDate"]))
        //    {
        //        lastLoginDate = Convert.ToDateTime(row["LastLoginDate"]);
        //    }
        //    if (row.Table.Columns.Contains("LastPasswordChangedDate") && !Convert.IsDBNull(row["LastPasswordChangedDate"]))
        //    {
        //        lastPasswordChangedDate = Convert.ToDateTime(row["LastPasswordChangedDate"]);
        //    }
        //    if (row.Table.Columns.Contains("PasswordQuestion") && !Convert.IsDBNull(row["PasswordQuestion"]))
        //    {
        //        passwordQuestion = Convert.ToString(row["PasswordQuestion"]);
        //    }
        //    if (row.Table.Columns.Contains("FailedPasswordAttemptCount") && !Convert.IsDBNull(row["FailedPasswordAttemptCount"]))
        //    {
        //        failedPasswordAttemptCount = Convert.ToInt32(row["FailedPasswordAttemptCount"]);
        //    }
        //    if (row.Table.Columns.Contains("FailedPasswordAttemptWindowStart") && !Convert.IsDBNull(row["FailedPasswordAttemptWindowStart"]))
        //    {
        //        failedPasswordAttemptWindowStart = Convert.ToDateTime(row["FailedPasswordAttemptWindowStart"]);
        //    }
        //    if (row.Table.Columns.Contains("FailedPasswordAnswerAttemptCount") && !Convert.IsDBNull(row["FailedPasswordAnswerAttemptCount"]))
        //    {
        //        failedPasswordAnswerAttemptCount = Convert.ToInt32(row["FailedPasswordAnswerAttemptCount"]);
        //    }
        //    if (row.Table.Columns.Contains("FailedPasswordAnswerAttemptWindowStart") && !Convert.IsDBNull(row["FailedPasswordAnswerAttemptWindowStart"]))
        //    {
        //        failedPasswordAnswerAttemptWindowStart = Convert.ToDateTime(row["FailedPasswordAnswerAttemptWindowStart"]);
        //    }
        //    if (row.Table.Columns.Contains("PasswordFormat") && !Convert.IsDBNull(row["PasswordFormat"]))
        //    {
        //        passwordFormat = Convert.ToInt32(row["PasswordFormat"]);
        //    }
        //    if (row.Table.Columns.Contains("PostalCode") && !Convert.IsDBNull(row["PostalCode"]))
        //    {
        //        postalCode = Convert.ToString(row["PostalCode"]);
        //    }
        //    if (row.Table.Columns.Contains("IDMaritalStatus") && !Convert.IsDBNull(row["IDMaritalStatus"]))
        //    {
        //        maritalStatus = (Model.UserData.MaritalStatus)Convert.ToInt32(row["IDMaritalStatus"]);
        //    }

        //    if (row.Table.Columns.Contains("PasswordAnswer") && !Convert.IsDBNull(row["PasswordAnswer"]))
        //    {
        //        passwordAnswer = Convert.ToString(row["PasswordAnswer"]);
        //    }
        //    if (row.Table.Columns.Contains("Password") && !Convert.IsDBNull(row["Password"]))
        //    {
        //        password  = Convert.ToString(row["Password"]);
        //    }
        //    if (row.Table.Columns.Contains("CreatedBy") && !Convert.IsDBNull(row["CreatedBy"]))
        //    {
        //        createdBy = Convert.ToString(row["CreatedBy"]);
        //    }
        //    if (row.Table.Columns.Contains("CreatedDate") && !Convert.IsDBNull(row["CreatedDate"]))
        //    {
        //        createdDate = Convert.ToDateTime(row["CreatedDate"]);
        //    }
        //    if (row.Table.Columns.Contains("ModifiedBy") && !Convert.IsDBNull(row["ModifiedBy"]))
        //    {
        //        modifiedBy = Convert.ToString(row["ModifiedBy"]);
        //    }
        //    if (row.Table.Columns.Contains("ModifiedDate") && !Convert.IsDBNull(row["ModifiedDate"]))
        //    {
        //        modifiedDate = Convert.ToDateTime(row["ModifiedDate"]);
        //    }
        //    if (row.Table.Columns.Contains("Comments") && !Convert.IsDBNull(row["Comments"]))
        //    {
        //        comments = Convert.ToString(row["Comments"]);
        //    } 

        //    if (row.Table.Columns.Contains("RequestedBy") && !Convert.IsDBNull(row["RequestedBy"]))
        //    {
        //        requestedBy = Convert.ToString(row["RequestedBy"]);
        //    } 
        //    if (row.Table.Columns.Contains("RequestedDate") && !Convert.IsDBNull(row["RequestedDate"]))
        //    {
        //        requestedDate = Convert.ToDateTime(row["RequestedDate"]);
        //    } 
        //    if (row.Table.Columns.Contains("ActivateKey") && !Convert.IsDBNull(row["ActivateKey"]))
        //    {
        //        activateKey = Convert.ToString(row["ActivateKey"]);
        //    } 
        //    if (row.Table.Columns.Contains("ReceiveEmails") && !Convert.IsDBNull(row["ReceiveEmails"]))
        //    {
        //        receiveEmails = Convert.ToBoolean(row["ReceiveEmails"]);
        //    } 
        //    if (row.Table.Columns.Contains("ApprovedBy") && !Convert.IsDBNull(row["ApprovedBy"]))
        //    {
        //        approvedBy = Convert.ToString(row["ApprovedBy"]);
        //    } 
        //    if (row.Table.Columns.Contains("ApprovedDate") && !Convert.IsDBNull(row["ApprovedDate"]))
        //    {
        //        approvedDate = Convert.ToDateTime(row["ApprovedDate"]);
        //    } 

        


        //    Model.UserData userData = new Model.UserData(userName);
        //    userData.FullName = fullname;
        //    userData.BirthDate = birthDate;
        //    userData.Male = male;
        //    userData.CellPhone = cellPhone;
        //    userData.PhoneNumber = phoneNumber;
        //    userData.CompanyPhone = companyPhone;
        //    userData.City = city;
        //    userData.Country = country;
        //    userData.State = department;
        //    userData.Street = street ;
        //    userData.StreetNumber =streetNumber ;
        //    userData.CPF = cPF;
        //    userData.RG = rG;
        //    userData.MSN = mSN;
        //    userData.Skype = skype;
        //    userData.Email = email;
        //    userData.IsApproved = isApproved;
        //    userData.IsLockedOut = isLockedOut;
        //    userData.LastActivityDate = lastActivityDate;
        //    userData.LastLockoutDate = lastLockoutDate;
        //    userData.LastLoginDate = lastLoginDate ;
        //    userData.LastPasswordChangedDate = lastPasswordChangedDate;
        //    userData.PasswordQuestion = passwordQuestion;
        //    userData.FailedPasswordAttemptCount = failedPasswordAttemptCount;
        //    userData.FailedPasswordAttemptWindowStart = failedPasswordAttemptWindowStart;
        //    userData.FailedPasswordAnswerAttemptCount = failedPasswordAnswerAttemptCount;
        //    userData.FailedPasswordAnswerAttemptWindowStart = failedPasswordAnswerAttemptWindowStart;
        //    userData.PasswordFormat = passwordFormat;
        //    userData.PasswordAnswer = passwordAnswer;
        //    userData.Password = password;
        //    userData.CreatedBy = createdBy;
        //    userData.CreatedDate = createdDate;
        //    userData.ModifiedBy = modifiedBy;
        //    userData.ModifiedDate = modifiedDate;            
        //    userData.Comments = comments;
        //    userData.ActivateKey = activateKey;
        //    userData.ApprovedBy = approvedBy;
        //    userData.ApprovedDate = approvedDate;
        //    userData.RequestedBy = requestedBy;
        //    userData.RequestedDate = requestedDate;
        //    userData.ReceiveEmails = receiveEmails;
        //    userData.PostalCode = postalCode;
        //    userData.Marital = maritalStatus;
            

        //    userData.LoadDataRow(row);

        //    return userData;



        //}


        #endregion
    }
}
