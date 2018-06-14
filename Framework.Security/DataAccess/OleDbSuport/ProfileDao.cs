using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Web.Profile;

namespace Framework.Security.DataAccess.OleDbSuport
{
    public class ProfileDao : Framework.DataServices.CommonDatabase, IProfileDao
    {
        #region Variables
        private string _applicationName = null;

        #endregion

        #region Constructors/Destructors
        public ProfileDao()
            : base()
        {
        }
        public ProfileDao(string connectionName)
            : base(connectionName)
        {
        }
        public ProfileDao(string applicationName, ConnectionStringSettings connectionStringSettings)
            : base(connectionStringSettings.Name,
                    connectionStringSettings.ConnectionString,
                    connectionStringSettings.ProviderName)
        {
            _applicationName = applicationName;





        }
        #endregion

        #region Methods
        private ProfileInfoCollection GetProfileInfo(string currentUser, ProfileAuthenticationOption authenticationOption, string usernameToMatch, object userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords, out int errorNumber, out string errorDescription)
        {
            errorDescription = null;
            errorNumber = 0;
            totalRecords = 0;

            if (userInactiveSinceDate == null)
                userInactiveSinceDate = DateTime.MinValue;

            DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "Framework_GetProfiles",
                true, currentUser,
                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null),
                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                base.Parameters.Create("@AuthenticationOption", DbType.Int32, (int)authenticationOption),
                base.Parameters.Create("@UserNameToMatch", DbType.String, usernameToMatch),
                base.Parameters.Create("@UserInactiveSinceDate", DbType.DateTime, userInactiveSinceDate),
                base.Parameters.Create("@PageIndex", DbType.Int32, pageIndex),
                base.Parameters.Create("@PageSize", DbType.Int32, pageSize),
                base.Parameters.Create("@TotalRecords", DbType.Int32, ParameterDirection.Output, totalRecords));

            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

            totalRecords = table.Rows.Count;

            return Convertion.Profile.ConvertToList(table);


        }

        #endregion


        #region IProfileDao Properties

        public string ApplicationName
        {
            get
            {
                return _applicationName;
            }
            set
            {
                _applicationName = value;
            }
        }


        #endregion

        #region IProfileDao Members
        public int DeleteInactiveProfiles(string currentUser, ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, out int errorNumber, out string errorDescription)
        {
            throw new NotImplementedException();
        }
        public int DeleteProfiles(string currentUser, string[] usernames, out int errorNumber, out string errorDescription)
        {
            throw new NotImplementedException();
        }
        public int DeleteProfiles(string currentUser, ProfileInfoCollection profiles, out int errorNumber, out string errorDescription)
        {
            throw new NotImplementedException();
        }
        public ProfileInfoCollection FindInactiveProfilesByUserName(string currentUser, ProfileAuthenticationOption authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords, out int errorNumber, out string errorDescription)
        {
            return GetProfileInfo(currentUser, authenticationOption, usernameToMatch, userInactiveSinceDate,
                pageIndex, pageSize, out totalRecords, out errorNumber, out errorDescription);
        }
        public ProfileInfoCollection FindProfilesByUserName(string currentUser, ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords, out int errorNumber, out string errorDescription)
        {

            return GetProfileInfo(currentUser, authenticationOption, usernameToMatch, null,
                pageIndex, pageSize, out totalRecords, out errorNumber, out errorDescription);
        }
        public ProfileInfoCollection GetAllInactiveProfiles(string currentUser, ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords, out int errorNumber, out string errorDescription)
        {

            return GetProfileInfo(currentUser, authenticationOption, null, userInactiveSinceDate,
                pageIndex, pageSize, out totalRecords, out errorNumber, out errorDescription);
        }
        public ProfileInfoCollection GetAllProfiles(string currentUser, ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords, out int errorNumber, out string errorDescription)
        {

            return GetProfileInfo(currentUser, authenticationOption, null, null,
                pageIndex, pageSize, out totalRecords, out errorNumber, out errorDescription);
        }
        public int GetNumberOfInactiveProfiles(string currentUser, ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, out int errorNumber, out string errorDescription)
        {
            throw new NotImplementedException();
        }
        public SettingsPropertyValueCollection GetPropertyValues(string currentUser, SettingsContext context, SettingsPropertyCollection collection, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = string.Empty;


            SettingsPropertyValueCollection settings = new SettingsPropertyValueCollection();

            if (collection == null || collection.Count == 0)
                return settings;

            foreach (SettingsProperty property in collection)
            {
                if (property.SerializeAs == SettingsSerializeAs.ProviderSpecific)
                {
                    if (property.PropertyType.IsPrimitive || property.PropertyType == typeof(System.String))
                    {
                        property.SerializeAs = SettingsSerializeAs.String;
                    }
                    else
                    {
                        property.SerializeAs = SettingsSerializeAs.Xml;
                    }
                }
                settings.Add(new SettingsPropertyValue(property));
            }





            // Get the user name or anonymous user ID
            string username = (string)context["UserName"];

            //' NOTE: Consider validating the user name here to prevent
            //' malicious user names such as "../Foo" from targeting
            //' directories other than ~/App_Data/Profile_Data

            //' Load the profile
            if (!string.IsNullOrEmpty(username))
            {
                string[] names;
                string values;
                byte[] buf;

                string databaseNames;
                string databaseValues;


                DataTable table = base.ExecuteFill(CommandType.StoredProcedure, "Framework_ProfileGetProperties",
                    true, currentUser,
                    base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null),
                    base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                    base.Parameters.Create("@UserName", DbType.String, username));


                errorNumber = base.ExecutionStatus.ErrorNumber;
                errorDescription = base.ExecutionStatus.ErrorDescription;

                if (errorNumber > 0 || !string.IsNullOrEmpty(errorDescription))
                {
                    return settings;
                }


                if (table.Rows.Count == 0)
                {
                    return settings;
                }

                databaseNames = Convert.ToString(table.Rows[0]["PropertyNames"]);
                databaseValues = Convert.ToString(table.Rows[0]["PropertyValuesString"]);
                buf = (byte[])table.Rows[0]["PropertyValuesBinary"];

                names = databaseNames.Split(':');
                values = databaseValues;


                // Decode names, values, and buf and initialize the
                // SettingsPropertyValueCollection returned to the caller
                Convertion.Profile.DecodeProfileData(names, values, buf, settings);


            }

            return settings;


        }
        public void SetPropertyValues(string currentUser, bool allowAnonymous, string userName, bool authenticated, SettingsContext context, SettingsPropertyValueCollection collection, out int errorNumber, out string errorDescription)
        {
            errorNumber = 0;
            errorDescription = string.Empty;


            // Get information about the user who owns the profile
            //string userName = (string)context["Username"];
            //bool authenticated = Convert.ToBoolean(context["IsAuthenticated"]);


            // NOTE: Consider validating the user name here to prevent
            // malicious user names such as "../Foo" from targeting
            // directories other than ~/App_Data/Profile_Data

            // Do nothing if there is no user name or no properties
            if (string.IsNullOrEmpty(userName) || collection.Count == 0)
                return;


            // Format the profile data for saving
            string names = string.Empty;
            string values = string.Empty;
            byte[] buf = null;

            Convertion.Profile.EncodeProfileData(allowAnonymous, out names, out values, out buf, collection, authenticated);

            // Do nothing if no properties need saving
            if (names == string.Empty)
                return;

            base.ExecuteNonQuery(CommandType.StoredProcedure, "Framework_ProfileSetProperties",
                                true, currentUser,
                                base.Parameters.Create("@ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, null),
                                base.Parameters.Create("@ApplicationName", DbType.String, _applicationName),
                                base.Parameters.Create("@UserName", DbType.String, userName),
                                base.Parameters.Create("@PropertyNames", DbType.String, names),
                                base.Parameters.Create("@PropertyValuesString", DbType.String, values),
                                base.Parameters.Create("@PropertyValuesBinary", DbType.Binary, buf),
                                base.Parameters.Create("@IsUserAnonymous", DbType.Boolean, false)
                                );


            errorNumber = base.ExecutionStatus.ErrorNumber;
            errorDescription = base.ExecutionStatus.ErrorDescription;

        }
        public bool SetPropertyValues(string currentUser, string names, string values, byte[] buf, bool allowAnonymous, out int errorNumber, out string errorDescription)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
