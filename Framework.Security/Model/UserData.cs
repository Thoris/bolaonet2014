using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Text;

namespace Framework.Security.Model
{
    [Serializable]
    public class UserData : Framework.DataServices.Model.EntityBaseData
    {
        #region Enumerations
        public enum MaritalStatus
        {
            NotDefined = 0,
            Casado = 1,
            Solteiro  = 2,
            EmRelacionamento = 3,
        }
        #endregion

        #region Variables
        private string _userName = string.Empty;

        protected string _password = string.Empty;
        protected int _passwordFormat;
        protected string _passwordAnswer = string.Empty;
        protected string _passwordQuestion = string.Empty;


        protected string _fullName = string.Empty;
        protected string _email = string.Empty;
        
        protected DateTime _birthDate;
        protected bool _male = false;

        protected string _cellPhone = string.Empty;
        protected string _phoneNumber = string.Empty;
        protected string _companyPhone = string.Empty;

        protected string _city = string.Empty;
        protected string _country = string.Empty;
        protected string _state = string.Empty;
        protected string _street = string.Empty;
        protected int _streetNumber;
        protected string _postalCode = string.Empty;

        protected MaritalStatus _maritalStatus;

        protected string _cpf;
        protected string _rg;

        protected string _msn;
        protected string _skype;




        protected bool _isLockedOut;
        protected bool _isApproved = false;

        protected DateTime _lastActivityDate;
        protected DateTime _lastLockoutDate;
        protected DateTime _lastPasswordChangedDate;
        protected DateTime _lastLoginDate;
        protected int _failedPasswordAttemptCount;
        protected DateTime _failedPasswordAttemptWindowStart;
        protected int _failedPasswordAnswerAttemptCount;
        protected DateTime _failedPasswordAnswerAttemptWindowStart;
        
        protected string _comments;


        protected bool _receiveEmails = false;
        protected string _activateKey = string.Empty;
        protected string _requestedBy = string.Empty;
        protected DateTime _requestedDate;

        protected string _approvedBy = string.Empty;
        protected DateTime _approvedDate;

        #endregion

        #region Properties
        public string FirstName
        {
            get 
            {
                string[] name = _fullName.Split(' ');

                return name[0];
            }
        }
        public string MiddleName
        {
            get 
            {
                string[] name = _fullName.Split(' ');

                string result = "";

                for (int c = 1; c < name.Length - 1; c++)
                    result += " " + name[c];

                return result.Trim();
            }
        }
        public string LastName
        {
            get
            {
                string[] name = _fullName.Split(' ');

                if (name.Length - 1 > 0)
                    return name[name.Length - 1];
                else
                    return "";

            }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password =value; }
        }
        public int PasswordFormat
        {
            get { return _passwordFormat; }
            set { _passwordFormat = value; }
        }
        public string PasswordQuestion
        {
            get { return _passwordQuestion; }
            set { _passwordQuestion = value; }
        }
        public string PasswordAnswer
        {
            get { return _passwordAnswer; }
            set { _passwordAnswer = value; }
        }
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public DateTime BirthDate
        {
            get { return _birthDate ; }
            set { _birthDate = value; }
        }
        public bool Male
        {
            get { return _male; }
            set { _male = value; }
        }
        public string CellPhone
        {
            get { return _cellPhone; }
            set { _cellPhone = value; }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public string CompanyPhone
        {
            get { return _companyPhone; }
            set { _companyPhone = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }
        public int StreetNumber
        {
            get { return _streetNumber; }
            set { _streetNumber = value; }
        }

        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }

        public MaritalStatus Marital
        {
            get { return _maritalStatus; }
            set { _maritalStatus = value; }
        }

        public string CPF
        {
            get { return _cpf; }
            set { _cpf = value; }
        }
        public string RG
        {
            get { return _rg; }
            set { _rg = value; }
        }
        public string MSN
        {
            get { return _msn; }
            set { _msn= value; }
        }
        public string Skype
        {
            get { return _skype; }
            set { _skype = value; }
        }                       
        public bool IsLockedOut
        {
            get { return _isLockedOut; }
            set { _isLockedOut = value; }
        }
        public bool IsApproved
        {
            get { return _isApproved; }
            set { _isApproved = value; }
        }
        public DateTime LastActivityDate
        {
            get { return _lastActivityDate; }
            set { _lastActivityDate = value; }
        }
        public DateTime LastLockoutDate
        {
            get { return _lastLockoutDate; }
            set { _lastLockoutDate = value; }
        }
        public DateTime LastPasswordChangedDate
        {
            get { return _lastPasswordChangedDate; }
            set { _lastPasswordChangedDate = value; }
        }
        public DateTime LastLoginDate
        {
            get { return _lastLoginDate; }
            set { _lastLoginDate = value; }
        }
        public int FailedPasswordAttemptCount
        {
            get { return _failedPasswordAttemptCount; }
            set { _failedPasswordAttemptCount = value; }
        }
        public DateTime FailedPasswordAttemptWindowStart
        {
            get { return _failedPasswordAttemptWindowStart; }
            set { _failedPasswordAttemptWindowStart = value; }
        }
        public int FailedPasswordAnswerAttemptCount
        {
            get { return _failedPasswordAnswerAttemptCount; }
            set { _failedPasswordAnswerAttemptCount = value; }
        }
        public DateTime FailedPasswordAnswerAttemptWindowStart
        {
            get { return _failedPasswordAnswerAttemptWindowStart; }
            set { _failedPasswordAnswerAttemptWindowStart = value; }
        }        
        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        public string ActivateKey
        {
            get { return _activateKey; }
            set { _activateKey = value; }
        }
        public bool ReceiveEmails
        {
            get { return _receiveEmails; }
            set { _receiveEmails = value; }
        }
        public string RequestedBy
        {
            get { return _requestedBy; }
            set { _requestedBy = value; }
        }
        public DateTime RequestedDate
        {
            get { return _requestedDate; }
            set { _requestedDate = value; }
        }
        public string ApprovedBy
        {
            get { return _approvedBy; }
            set { _approvedBy = value; }
        }
        public DateTime ApprovedDate
        {
            get { return _approvedDate; }
            set { _approvedDate = value; }
        }


        public bool IsOnline
        {
            get { return false; }
        }
         #endregion

        #region Constructors/Destructors
        public UserData()
            : base ()
        {
            
            
            
        }
        public UserData(string userName)
            : base ()
        {
            _userName = userName;
        }

        //public UserData (string UserName, string FirstName, string LastName, DateTime BirthDate, bool Male,
        //    string CellPhone, string PhoneNumber, string CompanyPhone, string City, string Country, string Department,
        //    string Street, int StreetNumber, string CPF, string RG, string MSN, string Skype, string Email,
        //    bool IsApproved, bool IsLockedOut, DateTime LastActivityDate, DateTime LastLockoutDate, DateTime LastLoginDate,
        //    DateTime LastPasswordChangedDate, string PasswordQuestion, int FailedPasswordAttemptCount,
        //    int FailedPasswordAttemptWindowStart, int FailedPasswordAnswerAttemptCount, int FailedPasswordAnswerAttemptWindowStart,
        //    int PasswordFormat, string PasswordAnswer, string Password, DateTime CreatedBy, DateTime CreatedDate,
        //    DateTime ModifiedBy, DateTime ModifiedDate, string Comments)
        //    : base (

 
        #endregion

        #region Methods
        public void Copy(UserData entry)
        {
    
            _birthDate = entry._birthDate;
            _cellPhone = entry._cellPhone;
            _city = entry._city;
            _comments = entry._comments;
            _companyPhone = entry._companyPhone;
            _country = entry._country;
            _cpf = entry._cpf;
            _email = entry._email;
            _failedPasswordAnswerAttemptCount = entry._failedPasswordAnswerAttemptCount;
            _failedPasswordAnswerAttemptWindowStart = entry._failedPasswordAnswerAttemptWindowStart;
            _failedPasswordAttemptCount = entry._failedPasswordAttemptCount;
            _failedPasswordAttemptWindowStart = entry._failedPasswordAttemptWindowStart;
            _fullName = entry._fullName;
            _isApproved = entry._isApproved;
            _isLockedOut = entry._isLockedOut;
            _lastActivityDate = entry._lastActivityDate;
            _lastLockoutDate = entry._lastLockoutDate;
            _lastLoginDate = entry._lastLoginDate;
            _lastPasswordChangedDate = entry._lastPasswordChangedDate;
            _male = entry._male;
            _msn = entry._msn;
            _password = entry._password;
            _passwordAnswer = entry._passwordAnswer;
            _passwordFormat = entry._passwordFormat;
            _passwordQuestion = entry._passwordQuestion;
            _phoneNumber = entry._phoneNumber;
            _rg = entry._rg;
            _skype = entry._skype;
            _state = entry._state;
            _street = entry._street;
            _streetNumber = entry._streetNumber;
            _userName = entry._userName;

            _approvedBy = entry._approvedBy;
            _approvedDate = entry._approvedDate;
            _requestedBy = entry._requestedBy;
            _requestedDate = entry._requestedDate;
            _receiveEmails = entry._receiveEmails;

            if (!string.IsNullOrEmpty (entry._activateKey ))
                _activateKey = entry._activateKey;

            _maritalStatus = entry._maritalStatus;
            _postalCode = entry._postalCode;

            base.Copy(entry);
        }


        public override string ToString()
        {
            if (string.IsNullOrEmpty(_userName))
            {
                return base.ToString();
            }
            else
            {
                return _userName;
            }
        }
        #endregion

    }
}
