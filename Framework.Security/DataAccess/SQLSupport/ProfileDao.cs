using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Profile;
using System.Web.Configuration;
using System.Configuration;
using System.Data;
using System.IO ;
using System.Globalization;

namespace Framework.Security.DataAccess.SQLSupport
{
    public class ProfileDao : Framework.DataServices.CommonDatabase, IProfileDao
    {
        #region Variables
        private string _applicationName = null;
        
        #endregion

        #region Constructors/Destructors
        public ProfileDao()
            : base ()
        {
        }
        public ProfileDao(string connectionName)
            : base(connectionName)
        {
        }
        public ProfileDao(string applicationName, ConnectionStringSettings connectionStringSettings)   
            : base (connectionStringSettings.Name,
                    connectionStringSettings.ConnectionString,
                    connectionStringSettings.ProviderName)
        {
            _applicationName = applicationName;

            

            
            
        }
        #endregion

        #region Methods
        //public static ProfileInfoCollection ConvertToList(DataTable table)
        //{
        //    ProfileInfoCollection list = new ProfileInfoCollection();

        //    foreach (DataRow row in table.Rows)
        //    {
        //        list.Add(ConvertToObject(row));
        //    }

        //    return list;
        //}
        //public static ProfileInfo ConvertToObject(DataRow row)
        //{
        //    string userName = string.Empty;
        //    bool isAnonymous = false;
        //    DateTime lastActivityDate = DateTime.MinValue;
        //    DateTime lastUpdatedDate = DateTime.MinValue;
        //    long size = 0;


        //    if (row.Table.Columns.Contains("UserName") && !Convert.IsDBNull(row["UserName"]))
        //    {
        //        userName = Convert.ToString(row["UserName"]);
        //    }
        //    if (row.Table.Columns.Contains("IsAnonymous") && !Convert.IsDBNull(row["IsAnonymous"]))
        //    {
        //        isAnonymous = Convert.ToBoolean(row["IsAnonymous"]);
        //    }
        //    if (row.Table.Columns.Contains("LastActivityDate") && !Convert.IsDBNull(row["LastActivityDate"]))
        //    {
        //        lastActivityDate = Convert.ToDateTime(row["LastActivityDate"]);
        //    }
        //    if (row.Table.Columns.Contains("lastUpdatedDate") && !Convert.IsDBNull(row["lastUpdatedDate"]))
        //    {
        //        lastUpdatedDate = Convert.ToDateTime(row["lastUpdatedDate"]);
        //    }

        //    if (row.Table.Columns.Contains("Size") && !Convert.IsDBNull(row["Size"]))
        //    {
        //        size = Convert.ToInt64(row["Size"]);
        //    }

        //    ProfileInfo entry = new ProfileInfo(userName, isAnonymous, lastActivityDate, lastUpdatedDate, (int)size);


        //    return entry;

        //}

        /// <summary>
        /// Get a collection of profiles based upon a user name matching string and inactivity date.
        /// </summary>
        /// <param name="authenticationOption">Current authentication option setting.</param>
        /// <param name="userNameToMatch">Characters representing user name to match (L to R).</param>
        /// <param name="userInactiveSinceDate">Inactivity date for deletion.</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords">Total records found (output).</param>
        /// <returns>Collection of profiles.</returns>
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


        //private void DecodeProfileData(string[] names, string values, byte[] buf, SettingsPropertyValueCollection properties)
        //{
        //    if (names == null || values == null || buf == null || properties == null)
        //        return;

        //    int i = 0;
        //    while (i < names.Length - 1)
        //    {
        //        // Read the next property name from "names" and retrieve
        //        // the corresponding SettingsPropertyValue from
        //        // "properties"
        //        string name = names[i];
        //        SettingsPropertyValue pp = properties[name];

        //        if (pp == null)
        //            continue;

        //        // Get the length and index of the persisted property value
        //        int pos = Int32.Parse(names[i + 2], CultureInfo.InvariantCulture);
        //        int len = Int32.Parse(names[i + 3], CultureInfo.InvariantCulture);


        //        // If the length is -1 and the property is a reference
        //        // type, then the property value is null
        //        if (len == -1 && !(pp.Property.PropertyType.IsValueType))
        //        {
        //            pp.PropertyValue = null;
        //            pp.IsDirty = false;
        //            pp.Deserialized = true;


        //            // If the property value was peristed as a string,
        //            // restore it from "values"
        //        }
        //        else if (names[i + 1] == "S" && pos >= 0 && len > 0 && values.Length >= pos + len)
        //        {
        //            pp.SerializedValue = values.Substring(pos, len);

        //            // If the property value was peristed as a byte array,
        //            // restore it from "buf"
        //        }
        //        else if (names[i + 1] == "B" && pos >= 0 && len > 0 && buf.Length >= pos + len)
        //        {
        //            byte[] buf2 = new Byte[len - 1] ;
        //            Buffer.BlockCopy(buf, pos, buf2, 0, len);
        //            pp.SerializedValue = buf2;
        //        }
        //        i += 4;
        //    }
        //}
        //private void EncodeProfileData(bool allowAnonymous, out string allNames, out string allValues, out byte[] buf, SettingsPropertyValueCollection properties, bool userIsAuthenticated)
        //{
        //    StringBuilder names = new StringBuilder();
        //    StringBuilder values = new StringBuilder();
        //    MemoryStream stream = new MemoryStream();
        //    try
        //    {
        //        foreach (SettingsPropertyValue pp in properties)
        //        {

        //            // Ignore this property if the user is anonymous and
        //            // the property’s AllowAnonymous property is false
        //            if (!userIsAuthenticated && !allowAnonymous)
        //                continue;


        //            // Ignore this property if it’s not dirty and is
        //            // currently assigned its default value            
        //            if (!pp.IsDirty && pp.UsingDefaultValue)
        //                continue;

        //            int len = 0;
        //            int pos = 0;
        //            string propValue = string.Empty;

        //            // If Deserialized is true and PropertyValue is null,
        //            // then the property’s current value is null (which
        //            // we’ll represent by setting len to -1)
        //            if (pp.Deserialized && pp.PropertyValue == null)
        //            {
        //                len = -1;
        //                // Otherwise get the property value from
        //                // SerializedValue
        //            }
        //            else
        //            {
        //                object sVal = pp.SerializedValue;

        //                // If SerializedValue is null, then the property’s
        //                // current value is null
        //                if (sVal == null)
        //                {
        //                    len = -1;

        //                    // If sVal is a string, then encode it as a 
        //                    //string
        //                }
        //                else if (sVal.GetType() == typeof(string))
        //                {

        //                    propValue = sVal.ToString();
        //                    len = propValue.Length;
        //                    pos = values.Length;

        //                    // If sVal is binary, then encode it as a byte
        //                    // array
        //                }
        //                else
        //                {
        //                    byte[] b2 = (byte[])sVal;
        //                    pos = (int)stream.Position;
        //                    stream.Write(b2, 0, b2.Length);
        //                    stream.Position = pos + b2.Length;
        //                    len = b2.Length;
        //                }

        //            }

        //            // Add a string conforming to the following format
        //            // to "names:"
        //            //                
        //            // "name:B|S:pos:len"
        //            //    ^   ^   ^   ^
        //            //    |   |   |   |
        //            //    |   |   |   +--- Length of data
        //            //    |   |   +------- Offset of data
        //            //    |   +----------- Location (B="buf", S="values")
        //            //    +--------------- Property name


        //            if (propValue != null)
        //            {

        //                names.Append(pp.Name + ":" + ("S") +
        //                    ":" + pos.ToString(CultureInfo.InvariantCulture) +
        //                    ":" + len.ToString(CultureInfo.InvariantCulture) + ":");
        //            }
        //            else
        //            {
        //                names.Append(pp.Name + ":" + ("B") +
        //                    ":" + pos.ToString(CultureInfo.InvariantCulture) +
        //                    ":" + len.ToString(CultureInfo.InvariantCulture) + ":");
        //            }

        //            // If the propery value is encoded as a string,
        //            // add the string to "values"
        //            if (propValue != null)
        //            {
        //                values.Append(propValue);
        //            }
        //        }



        //        // Copy the binary property values written to the
        //        // stream to "buf"
        //        buf = stream.ToArray();
        //    }
        //    finally
        //    {
        //        if (stream != null)
        //            stream.Close();

        //    }

        //    allNames = names.ToString();
        //    allValues = values.ToString();

        //}

        #endregion

        #region IProfileDao Properties

        public string ApplicationName
        {
            get
            {
                return _applicationName ;
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
