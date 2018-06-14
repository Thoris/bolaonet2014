using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Framework.Security.DataAccess.Convertion
{
    public sealed class UserData
    {
        #region Methods
        public static Model.UserData ConvertToModel(DataRow row)
        {

            string userName = string.Empty;
            string fullname = string.Empty;
            string lastName = string.Empty;
            DateTime birthDate = DateTime.MinValue;
            bool male = false;
            string cellPhone = string.Empty;
            string phoneNumber = string.Empty;
            string companyPhone = string.Empty;
            string city = string.Empty;
            string country = string.Empty;
            string department = string.Empty;
            string street = string.Empty;
            int streetNumber = 0;
            string cPF = string.Empty;
            string rG = string.Empty;
            string mSN = string.Empty;
            string skype = string.Empty;
            string email = string.Empty;
            bool isApproved = false;
            bool isLockedOut = false;
            DateTime lastActivityDate = DateTime.MinValue;
            DateTime lastLockoutDate = DateTime.MinValue;
            DateTime lastLoginDate = DateTime.MinValue;
            DateTime lastPasswordChangedDate = DateTime.MinValue;
            string passwordQuestion = string.Empty;
            int failedPasswordAttemptCount = 0;
            DateTime failedPasswordAttemptWindowStart = DateTime.MinValue;
            int failedPasswordAnswerAttemptCount = 0;
            DateTime failedPasswordAnswerAttemptWindowStart = DateTime.MinValue;
            int passwordFormat = 0;
            string passwordAnswer = string.Empty;
            string password = string.Empty;
            string createdBy = string.Empty;
            DateTime createdDate = DateTime.MinValue;
            string modifiedBy = string.Empty;
            DateTime modifiedDate = DateTime.MinValue;
            string comments = string.Empty;
            string requestedBy = string.Empty;
            DateTime requestedDate = DateTime.MinValue;
            string approvedBy = string.Empty;
            DateTime approvedDate = DateTime.MinValue;
            string activateKey = string.Empty;
            bool receiveEmails = false;
            string postalCode = string.Empty;
            Model.UserData.MaritalStatus maritalStatus = Framework.Security.Model.UserData.MaritalStatus.NotDefined;

            if (row.Table.Columns.Contains("UserName") && !Convert.IsDBNull(row["UserName"]))
            {
                userName = Convert.ToString(row["UserName"]);
            }
            if (row.Table.Columns.Contains("FullName") && !Convert.IsDBNull(row["FullName"]))
            {
                fullname = Convert.ToString(row["FullName"]);
            }
            if (row.Table.Columns.Contains("BirthDate") && !Convert.IsDBNull(row["BirthDate"]))
            {
                birthDate = Convert.ToDateTime(row["BirthDate"]);
            }
            if (row.Table.Columns.Contains("Male") && !Convert.IsDBNull(row["Male"]))
            {
                male = Convert.ToBoolean(row["Male"]);
            }
            if (row.Table.Columns.Contains("CellPhone") && !Convert.IsDBNull(row["CellPhone"]))
            {
                cellPhone = Convert.ToString(row["CellPhone"]);
            }
            if (row.Table.Columns.Contains("PhoneNumber") && !Convert.IsDBNull(row["PhoneNumber"]))
            {
                phoneNumber = Convert.ToString(row["PhoneNumber"]);
            }
            if (row.Table.Columns.Contains("CompanyPhone") && !Convert.IsDBNull(row["CompanyPhone"]))
            {
                companyPhone = Convert.ToString(row["CompanyPhone"]);
            }
            if (row.Table.Columns.Contains("City") && !Convert.IsDBNull(row["City"]))
            {
                city = Convert.ToString(row["City"]);
            }
            if (row.Table.Columns.Contains("Country") && !Convert.IsDBNull(row["Country"]))
            {
                country = Convert.ToString(row["Country"]);
            }
            if (row.Table.Columns.Contains("State") && !Convert.IsDBNull(row["State"]))
            {
                department = Convert.ToString(row["State"]);
            }
            if (row.Table.Columns.Contains("Street") && !Convert.IsDBNull(row["Street"]))
            {
                street = Convert.ToString(row["Street"]);
            }
            if (row.Table.Columns.Contains("StreetNumber") && !Convert.IsDBNull(row["StreetNumber"]))
            {
                streetNumber = Convert.ToInt32(row["StreetNumber"]);
            }
            if (row.Table.Columns.Contains("CPF") && !Convert.IsDBNull(row["CPF"]))
            {
                cPF = Convert.ToString(row["CPF"]);
            }
            if (row.Table.Columns.Contains("RG") && !Convert.IsDBNull(row["RG"]))
            {
                rG = Convert.ToString(row["RG"]);
            }
            if (row.Table.Columns.Contains("MSN") && !Convert.IsDBNull(row["MSN"]))
            {
                mSN = Convert.ToString(row["MSN"]);
            }
            if (row.Table.Columns.Contains("Skype") && !Convert.IsDBNull(row["Skype"]))
            {
                skype = Convert.ToString(row["Skype"]);
            }
            if (row.Table.Columns.Contains("Email") && !Convert.IsDBNull(row["Email"]))
            {
                email = Convert.ToString(row["Email"]);
            }
            if (row.Table.Columns.Contains("IsApproved") && !Convert.IsDBNull(row["IsApproved"]))
            {
                isApproved = Convert.ToBoolean(row["IsApproved"]);
            }
            if (row.Table.Columns.Contains("IsLockedOut") && !Convert.IsDBNull(row["IsLockedOut"]))
            {
                isLockedOut = Convert.ToBoolean(row["IsLockedOut"]);
            }
            if (row.Table.Columns.Contains("LastActivityDate") && !Convert.IsDBNull(row["LastActivityDate"]))
            {
                lastActivityDate = Convert.ToDateTime(row["LastActivityDate"]);
            }
            if (row.Table.Columns.Contains("LastLockoutDate") && !Convert.IsDBNull(row["LastLockoutDate"]))
            {
                lastLockoutDate = Convert.ToDateTime(row["LastLockoutDate"]);
            }
            if (row.Table.Columns.Contains("LastLoginDate") && !Convert.IsDBNull(row["LastLoginDate"]))
            {
                lastLoginDate = Convert.ToDateTime(row["LastLoginDate"]);
            }
            if (row.Table.Columns.Contains("LastPasswordChangedDate") && !Convert.IsDBNull(row["LastPasswordChangedDate"]))
            {
                lastPasswordChangedDate = Convert.ToDateTime(row["LastPasswordChangedDate"]);
            }
            if (row.Table.Columns.Contains("PasswordQuestion") && !Convert.IsDBNull(row["PasswordQuestion"]))
            {
                passwordQuestion = Convert.ToString(row["PasswordQuestion"]);
            }
            if (row.Table.Columns.Contains("FailedPasswordAttemptCount") && !Convert.IsDBNull(row["FailedPasswordAttemptCount"]))
            {
                failedPasswordAttemptCount = Convert.ToInt32(row["FailedPasswordAttemptCount"]);
            }
            if (row.Table.Columns.Contains("FailedPasswordAttemptWindowStart") && !Convert.IsDBNull(row["FailedPasswordAttemptWindowStart"]))
            {
                failedPasswordAttemptWindowStart = Convert.ToDateTime(row["FailedPasswordAttemptWindowStart"]);
            }
            if (row.Table.Columns.Contains("FailedPasswordAnswerAttemptCount") && !Convert.IsDBNull(row["FailedPasswordAnswerAttemptCount"]))
            {
                failedPasswordAnswerAttemptCount = Convert.ToInt32(row["FailedPasswordAnswerAttemptCount"]);
            }
            if (row.Table.Columns.Contains("FailedPasswordAnswerAttemptWindowStart") && !Convert.IsDBNull(row["FailedPasswordAnswerAttemptWindowStart"]))
            {
                failedPasswordAnswerAttemptWindowStart = Convert.ToDateTime(row["FailedPasswordAnswerAttemptWindowStart"]);
            }
            if (row.Table.Columns.Contains("PasswordFormat") && !Convert.IsDBNull(row["PasswordFormat"]))
            {
                passwordFormat = Convert.ToInt32(row["PasswordFormat"]);
            }
            if (row.Table.Columns.Contains("PostalCode") && !Convert.IsDBNull(row["PostalCode"]))
            {
                postalCode = Convert.ToString(row["PostalCode"]);
            }
            if (row.Table.Columns.Contains("IDMaritalStatus") && !Convert.IsDBNull(row["IDMaritalStatus"]))
            {
                maritalStatus = (Model.UserData.MaritalStatus)Convert.ToInt32(row["IDMaritalStatus"]);
            }

            if (row.Table.Columns.Contains("PasswordAnswer") && !Convert.IsDBNull(row["PasswordAnswer"]))
            {
                passwordAnswer = Convert.ToString(row["PasswordAnswer"]);
            }
            if (row.Table.Columns.Contains("Password") && !Convert.IsDBNull(row["Password"]))
            {
                password = Convert.ToString(row["Password"]);
            }
            if (row.Table.Columns.Contains("CreatedBy") && !Convert.IsDBNull(row["CreatedBy"]))
            {
                createdBy = Convert.ToString(row["CreatedBy"]);
            }
            if (row.Table.Columns.Contains("CreatedDate") && !Convert.IsDBNull(row["CreatedDate"]))
            {
                createdDate = Convert.ToDateTime(row["CreatedDate"]);
            }
            if (row.Table.Columns.Contains("ModifiedBy") && !Convert.IsDBNull(row["ModifiedBy"]))
            {
                modifiedBy = Convert.ToString(row["ModifiedBy"]);
            }
            if (row.Table.Columns.Contains("ModifiedDate") && !Convert.IsDBNull(row["ModifiedDate"]))
            {
                modifiedDate = Convert.ToDateTime(row["ModifiedDate"]);
            }
            if (row.Table.Columns.Contains("Comments") && !Convert.IsDBNull(row["Comments"]))
            {
                comments = Convert.ToString(row["Comments"]);
            }

            if (row.Table.Columns.Contains("RequestedBy") && !Convert.IsDBNull(row["RequestedBy"]))
            {
                requestedBy = Convert.ToString(row["RequestedBy"]);
            }
            if (row.Table.Columns.Contains("RequestedDate") && !Convert.IsDBNull(row["RequestedDate"]))
            {
                requestedDate = Convert.ToDateTime(row["RequestedDate"]);
            }
            if (row.Table.Columns.Contains("ActivateKey") && !Convert.IsDBNull(row["ActivateKey"]))
            {
                activateKey = Convert.ToString(row["ActivateKey"]);
            }
            if (row.Table.Columns.Contains("ReceiveEmails") && !Convert.IsDBNull(row["ReceiveEmails"]))
            {
                receiveEmails = Convert.ToBoolean(row["ReceiveEmails"]);
            }
            if (row.Table.Columns.Contains("ApprovedBy") && !Convert.IsDBNull(row["ApprovedBy"]))
            {
                approvedBy = Convert.ToString(row["ApprovedBy"]);
            }
            if (row.Table.Columns.Contains("ApprovedDate") && !Convert.IsDBNull(row["ApprovedDate"]))
            {
                approvedDate = Convert.ToDateTime(row["ApprovedDate"]);
            }




            Model.UserData userData = new Model.UserData(userName);
            userData.FullName = fullname;
            userData.BirthDate = birthDate;
            userData.Male = male;
            userData.CellPhone = cellPhone;
            userData.PhoneNumber = phoneNumber;
            userData.CompanyPhone = companyPhone;
            userData.City = city;
            userData.Country = country;
            userData.State = department;
            userData.Street = street;
            userData.StreetNumber = streetNumber;
            userData.CPF = cPF;
            userData.RG = rG;
            userData.MSN = mSN;
            userData.Skype = skype;
            userData.Email = email;
            userData.IsApproved = isApproved;
            userData.IsLockedOut = isLockedOut;
            userData.LastActivityDate = lastActivityDate;
            userData.LastLockoutDate = lastLockoutDate;
            userData.LastLoginDate = lastLoginDate;
            userData.LastPasswordChangedDate = lastPasswordChangedDate;
            userData.PasswordQuestion = passwordQuestion;
            userData.FailedPasswordAttemptCount = failedPasswordAttemptCount;
            userData.FailedPasswordAttemptWindowStart = failedPasswordAttemptWindowStart;
            userData.FailedPasswordAnswerAttemptCount = failedPasswordAnswerAttemptCount;
            userData.FailedPasswordAnswerAttemptWindowStart = failedPasswordAnswerAttemptWindowStart;
            userData.PasswordFormat = passwordFormat;
            userData.PasswordAnswer = passwordAnswer;
            userData.Password = password;
            userData.CreatedBy = createdBy;
            userData.CreatedDate = createdDate;
            userData.ModifiedBy = modifiedBy;
            userData.ModifiedDate = modifiedDate;
            userData.Comments = comments;
            userData.ActivateKey = activateKey;
            userData.ApprovedBy = approvedBy;
            userData.ApprovedDate = approvedDate;
            userData.RequestedBy = requestedBy;
            userData.RequestedDate = requestedDate;
            userData.ReceiveEmails = receiveEmails;
            userData.PostalCode = postalCode;
            userData.Marital = maritalStatus;


            userData.LoadDataRow(row);

            return userData;



        }
        #endregion
    }
}
