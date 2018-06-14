using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Profile;
using System.Configuration;
using Framework.Logging.Logger;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;

namespace Framework.Security.Business
{
    public class CustomProfileProvider : ProfileProvider
    {
        #region Variables
        private string _currentLogin = null;
        private string _name = string.Empty;
        private string _description = string.Empty;
        private string _connectionName = string.Empty;
        private DataAccess.IProfileDao _profileDao = null;
        #endregion

        #region Constructors/Destructors
        public CustomProfileProvider()
        {

            _currentLogin = System.Web.HttpContext.Current.User.Identity.Name;
            _profileDao = new DataAccess.SQLSupport.ProfileDao();
        }
        public CustomProfileProvider(string currentLogin, DataAccess.IProfileDao profileDao)
        {
            _currentLogin = currentLogin;
            _profileDao = profileDao;
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

        /// <summary>
        /// Verifies input parameters for page size and page index. 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <remarks></remarks>
        private void CheckParameters(int pageIndex, int pageSize)
        {
            if (pageIndex < 0)
            {
                throw new ArgumentException("Page index must 0 or greater.");
            }
            if (pageSize < 1)
            {
                throw new ArgumentException("Page size must be greater than 0.");
            }
        }


        private void DecodeProfileData(string[] names, string values, byte[] buf, SettingsPropertyValueCollection properties)
        {
            if (names == null || values == null || buf == null || properties == null)
                return;

            int i = 0;
            while (i < names.Length)
            {
                // Read the next property name from "names" and retrieve
                // the corresponding SettingsPropertyValue from
                // "properties"
                string name = names[i];
                SettingsPropertyValue pp = properties[name];

                if (pp == null)
                    continue;

                // Get the length and index of the persisted property value
                int pos = Int32.Parse(names[i + 2], CultureInfo.InvariantCulture);
                int len = Int32.Parse(names[i + 3], CultureInfo.InvariantCulture);


                // If the length is -1 and the property is a reference
                // type, then the property value is null
                if (len == -1 && !(pp.Property.PropertyType.IsValueType))
                {
                    pp.PropertyValue = null;
                    pp.IsDirty = false;
                    pp.Deserialized = true;


                    // If the property value was peristed as a string,
                    // restore it from "values"
                }
                else if (names[i + 1] == "S" && pos >= 0 && len > 0 && values.Length >= pos + len)
                {
                    pp.SerializedValue = values.Substring(pos, len);

                    // If the property value was peristed as a byte array,
                    // restore it from "buf"
                }
                else if (names[i + 1] == "B" && pos >= 0 && len > 0 && buf.Length >= pos + len)
                {
                    byte[] buf2 = new Byte[len - 1];
                    Buffer.BlockCopy(buf, pos, buf2, 0, len);
                    pp.SerializedValue = buf2;
                }
                i += 4;
            }
        }
        private void EncodeProfileData(bool allowAnonymous, string allNames, string allValues, byte[] buf, SettingsPropertyValueCollection properties, bool userIsAuthenticated)
        {
            StringBuilder names = new StringBuilder();
            StringBuilder values = new StringBuilder();
            MemoryStream stream = new MemoryStream();
            try
            {
                foreach (SettingsPropertyValue pp in properties)
                {

                    // Ignore this property if the user is anonymous and
                    // the property’s AllowAnonymous property is false
                    if (!userIsAuthenticated && !allowAnonymous)
                        continue;


                    // Ignore this property if it’s not dirty and is
                    // currently assigned its default value            
                    if (!pp.IsDirty && pp.UsingDefaultValue)
                        continue;

                    int len = 0;
                    int pos = 0;
                    string propValue = string.Empty;

                    // If Deserialized is true and PropertyValue is null,
                    // then the property’s current value is null (which
                    // we’ll represent by setting len to -1)
                    if (pp.Deserialized && pp.PropertyValue == null)
                    {
                        len = -1;
                        // Otherwise get the property value from
                        // SerializedValue
                    }
                    else
                    {
                        object sVal = pp.SerializedValue;

                        // If SerializedValue is null, then the property’s
                        // current value is null
                        if (sVal == null)
                        {
                            len = -1;

                            // If sVal is a string, then encode it as a 
                            //string
                        }
                        else if (sVal.GetType() == typeof(string))
                        {

                            propValue = sVal.ToString();
                            len = propValue.Length;
                            pos = values.Length;

                            // If sVal is binary, then encode it as a byte
                            // array
                        }
                        else
                        {
                            byte[] b2 = (byte[])sVal;
                            pos = (int)stream.Position;
                            stream.Write(b2, 0, b2.Length);
                            stream.Position = pos + b2.Length;
                            len = b2.Length;
                        }

                    }

                    // Add a string conforming to the following format
                    // to "names:"
                    //                
                    // "name:B|S:pos:len"
                    //    ^   ^   ^   ^
                    //    |   |   |   |
                    //    |   |   |   +--- Length of data
                    //    |   |   +------- Offset of data
                    //    |   +----------- Location (B="buf", S="values")
                    //    +--------------- Property name


                    if (propValue != null)
                    {

                        names.Append(pp.Name + ":" + ("S") +
                            ":" + pos.ToString(CultureInfo.InvariantCulture) +
                            ":" + len.ToString(CultureInfo.InvariantCulture) + ":");
                    }
                    else
                    {
                        names.Append(pp.Name + ":" + ("B") +
                            ":" + pos.ToString(CultureInfo.InvariantCulture) +
                            ":" + len.ToString(CultureInfo.InvariantCulture) + ":");
                    }

                    // If the propery value is encoded as a string,
                    // add the string to "values"
                    if (propValue != null)
                    {
                        values.Append(propValue);
                    }
                }



                // Copy the binary property values written to the
                // stream to "buf"
                buf = stream.ToArray();
            }
            finally
            {
                if (stream != null)
                    stream.Close();

            }

            allNames = names.ToString();
            allValues = values.ToString();

        }


        #endregion

        #region Abstract Members
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
        public override string ApplicationName
        {
            get
            {
                return _profileDao.ApplicationName;
            }
            set
            {
                _profileDao.ApplicationName = value;
            }
        }
        public override void Initialize(string name, NameValueCollection config)
        {
            SaveLog("Initialize");


            base.Initialize(name, config);

            if (config == null)
                throw new ArgumentNullException("config");

            _name = name;

            if (string.IsNullOrEmpty(name))
            {
                name = "CustomProfileProvider";
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




            _profileDao.ApplicationName = GetConfigValue(config["applicationName"],
                System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);




            SaveLog("Initialize finished");




        }
        public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            SaveLog("Deleting inactive Profiles");

            int errorNumber = 0;
            string errorDescription = null;

            int result = _profileDao.DeleteInactiveProfiles(_currentLogin, authenticationOption, userInactiveSinceDate,
                out errorNumber, out errorDescription);

            if (errorNumber > 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Error deleting inactive profiles.", errorDescription);
                return -1;
            }

            return result;
        }
        public override int DeleteProfiles(string[] usernames)
        {
            SaveLog("Deleting Profiles by vector");

            int errorNumber = 0;
            string errorDescription = null;

            int result = _profileDao.DeleteProfiles (_currentLogin, usernames,
                out errorNumber, out errorDescription);

            if (errorNumber > 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Error deleting profiles by vector.", errorDescription);
                return -1;
            }

            return result;
        }
        public override int DeleteProfiles(ProfileInfoCollection profiles)
        {

            SaveLog("Deleting Profiles by collection");

            int errorNumber = 0;
            string errorDescription = null;

            int result = _profileDao.DeleteProfiles(_currentLogin, profiles,
                out errorNumber, out errorDescription);

            if (errorNumber > 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Error deleting profiles by collection.", errorDescription);
                return -1;
            }

            return result;
        }
        public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {

            SaveLog("FindInactiveProfilesByUserName");

            totalRecords = 0;
            return null;
        }
        public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            SaveLog("FindProfilesByUserName");

            int errorNumber = 0;
            string errorDescription = string.Empty;


            ProfileInfoCollection list = _profileDao.FindProfilesByUserName(_currentLogin, authenticationOption, usernameToMatch, pageIndex,
                pageSize, out totalRecords, out errorNumber, out errorDescription);

            if (errorNumber > 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Error Finding profiles by user name", errorDescription);
                return null;
            }

            return list;
        }
        public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            SaveLog("GetAllInactiveProfiles");


            totalRecords = 0; return null;
        }
        public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords)
        {
            SaveLog("GetAllProfiles");


            totalRecords = 0; return null;
        }
        public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            SaveLog("GetNumberOfInactiveProfiles");

            int errorNumber = 0;
            string errorDescription = null;

            int result = _profileDao.GetNumberOfInactiveProfiles(_currentLogin, authenticationOption, userInactiveSinceDate,
                out errorNumber, out errorDescription);

            if (errorNumber > 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Error getting number of inactive profiles ", errorDescription);
                return -1;
            }

            return result;
        }
        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            SaveLog("GetPropertyValues");

            int errorNumber = 0;
            string errorDescription = string.Empty;

            

            SettingsPropertyValueCollection list = _profileDao.GetPropertyValues(
                _currentLogin, context, collection, out errorNumber, out errorDescription);


            if (errorNumber > 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Error Getting property values", errorDescription);
                return list;
            }

            return list;
        }
        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {
            SaveLog("SetPropertyValues");

            int errorNumber = 0;
            string errorDescription = string.Empty;

            string userName = (string)context["UserName"];
            bool authenticated = Convert.ToBoolean(context["IsAuthenticated"]);


            _profileDao.SetPropertyValues(_currentLogin, false, userName, authenticated, context, collection, 
                out errorNumber, out errorDescription);

            if (errorNumber > 0 || !string.IsNullOrEmpty(errorDescription))
            {
                LogManager.WriteWarning(_currentLogin, this, "Error Setting property values", errorDescription);
                return;
            }



        }
        #endregion
    }
}
