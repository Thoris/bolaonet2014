using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.Security;
using System.Text;
using System.Configuration;

namespace Framework.Security.Model
{
    public class SystemProperties : ISystemProperties
    {
        #region Variables
        private string _applicationName = string.Empty;
        private bool _enablePasswordReset = false;
        private bool _enablePasswordRetrieval = false;
        private int _maxInvalidPasswordAttempts = 3;
        private int _minRequiredNonAlphanumericCharacters = 0;
        private int _minRequiredPasswordLength = 0;
        private int _passwordAttemptWindow = 3;
        private MembershipPasswordFormat _passwordFormat = MembershipPasswordFormat.Clear;
        private string _passwordStrengthRegularExpression = null;
        private bool _requiresQuestionAndAnswer = false;
        private bool _requiresUniqueEmail = false;
        private string _connectionName = string.Empty;
        private int _userIsOnlineTimeWindow = 10;
        private MachineKeySection _machineKey;
        private string _name = string.Empty;
        private string _description = string.Empty;
        
        #endregion

        #region Properties
        public string ApplicationName
        {
            get { return _applicationName; }
            set { _applicationName = value; }
        }
        public bool EnablePasswordReset
        {
            get { return _enablePasswordReset; }
            //set { _enablePasswordReset = value; }
        }
        public bool EnablePasswordRetrieval
        {
            get { return _enablePasswordRetrieval; }
            //set { _enablePasswordRetrieval = value; }
        }
        public int MaxInvalidPasswordAttempts
        {
            get { return _maxInvalidPasswordAttempts; }
            //set { _maxInvalidPasswordAttempts = value; }
        }
        public int MinRequiredNonAlphanumericCharacters
        {
            get { return _minRequiredNonAlphanumericCharacters; }
            //set { _minRequiredNonAlphanumericCharacters = value; }
        }
        public int MinRequiredPasswordLength
        {
            get { return _minRequiredPasswordLength; }
            //set { _minRequiredPasswordLength = value; }
        }
        public int PasswordAttemptWindow
        {
            get { return _passwordAttemptWindow; }
            //set { _passwordAttemptWindow = value; }
        }
        public MembershipPasswordFormat PasswordFormat
        {
            get { return _passwordFormat; }
            //set { _passwordFormat = value; }
        }
        public string PasswordStrengthRegularExpression
        {
            get { return _passwordStrengthRegularExpression; }
            //set { _passwordStrengthRegularExpression = value; }
        }
        public bool RequiresQuestionAndAnswer
        {
            get { return _requiresQuestionAndAnswer; }
            //set { _requiresQuestionAndAnswer = value; }
        }
        public bool RequiresUniqueEmail
        {
            get { return _requiresUniqueEmail; }
            //set { _requiresUniqueEmail = value; }
        }
        public string ConnectionName
        {
            get { return _connectionName; }
            //set { _connectionName = value; }
        }
        public int UserIsOnlineTimeWindow
        {
            get { return _userIsOnlineTimeWindow; }
           // set { _userIsOnlineTimeWindow = value; }
        }
        public MachineKeySection MachineKey
        {
            get { return _machineKey; }
            //set { _machineKey = value; }
        }
        public string Description
        {
            get { return _description; }
        }

        public string Name
        {
            get { return _name; }
        }

        #endregion

        #region Constructors/Destructors
        public SystemProperties()
        {            
        }

        public SystemProperties(string applicationName,
            bool enablePasswordReset ,
            bool enablePasswordRetrieval ,
            int maxInvalidPasswordAttempts ,
            int minRequiredNonAlphanumericCharacters ,
            int minRequiredPasswordLength ,
            int passwordAttemptWindow ,
            MembershipPasswordFormat passwordFormat ,
            string passwordStrengthRegularExpression ,
            bool requiresQuestionAndAnswer ,
            bool requiresUniqueEmail ,
            string connectionName ,
            int userIsOnlineTimeWindow ,
            MachineKeySection machineKey)
        {
            _applicationName = applicationName;
            _enablePasswordReset = enablePasswordReset;
            _enablePasswordRetrieval = enablePasswordRetrieval;
            _maxInvalidPasswordAttempts = maxInvalidPasswordAttempts;
            _minRequiredNonAlphanumericCharacters = minRequiredNonAlphanumericCharacters;
            _minRequiredPasswordLength = minRequiredPasswordLength;
            _passwordAttemptWindow = passwordAttemptWindow;
            _passwordFormat = passwordFormat;
            _passwordStrengthRegularExpression = passwordStrengthRegularExpression;
            _requiresQuestionAndAnswer = requiresQuestionAndAnswer;
            _requiresUniqueEmail = requiresUniqueEmail;
            _connectionName = connectionName;
            _machineKey = machineKey;
        }
        #endregion

        #region Methods
        public void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {

            if (config == null)            
                throw new ArgumentNullException("config");

            _name = name;

            if (string.IsNullOrEmpty(name))
            {
                name = "CustomMemberShipProvider";
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




            _applicationName = GetConfigValue(config["applicationName"],
                System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);

            _maxInvalidPasswordAttempts = Convert.ToInt32(GetConfigValue(config["maxInvalidPasswordAttempts"], "5"));

            _passwordAttemptWindow = Convert.ToInt32(GetConfigValue(config["passwordAttemptWindow"], "10"));

            _minRequiredNonAlphanumericCharacters = Convert.ToInt32(GetConfigValue(config["minRequiredAlphaNumericCharacters"], "1"));

            _minRequiredPasswordLength = Convert.ToInt32(GetConfigValue(config["minRequiredPasswordLength"], "7"));

            _passwordStrengthRegularExpression = Convert.ToString(GetConfigValue(config["passwordStrengthRegularExpression"], String.Empty));

            _enablePasswordReset = Convert.ToBoolean(GetConfigValue(config["enablePasswordReset"], "true"));

            _enablePasswordRetrieval = Convert.ToBoolean(GetConfigValue(config["enablePasswordRetrieval"], "true"));

            _requiresQuestionAndAnswer = Convert.ToBoolean(GetConfigValue(config["requiresQuestionAndAnswer"], "false"));

            _requiresUniqueEmail = Convert.ToBoolean(GetConfigValue(config["requiresUniqueEmail"], "true"));

            _userIsOnlineTimeWindow = Convert.ToInt32(GetConfigValue(config["UserIsOnlineTimeWindow"], "10"));

            string tempFormat = config["passwordFormat"];
            if (string.IsNullOrEmpty(tempFormat))
            {
                tempFormat = "Hashed";
            }

            switch (tempFormat)
            {
                case "Hashed":
                    _passwordFormat = MembershipPasswordFormat.Hashed;
                    break;

                case "Encrypted":
                    _passwordFormat = MembershipPasswordFormat.Encrypted;
                    break;

                case "Clear":
                    _passwordFormat = MembershipPasswordFormat.Clear;
                    break;

                default:
                    throw new ProviderException("Password format not supported.");

            }//end switch format

            ConnectionStringSettings ConnectionStringSettings =
                ConfigurationManager.ConnectionStrings[config["connectionStringName"]];

            if ((ConnectionStringSettings == null) ||
                (ConnectionStringSettings.ConnectionString.Trim() == String.Empty))
            {
                throw new ProviderException("Connection string cannot be blank.");
            }


            //Get encryption and decryption key information from the configuration.
            System.Configuration.Configuration cfg =
                WebConfigurationManager.OpenWebConfiguration(
                System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);

            _machineKey = cfg.GetSection("system.web/machineKey") as MachineKeySection;

            if (_machineKey.ValidationKey.Contains("AutoGenerate"))
            {
                if (_passwordFormat != MembershipPasswordFormat.Clear)
                {
                    throw new ProviderException("Hashed or Encrypted passwords are not supported with auto-generated keys.");
                }
            }




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

    }
}
