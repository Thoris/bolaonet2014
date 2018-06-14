using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Profile;
using System.Web.Configuration;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;

namespace Framework.Security.DataAccess.Convertion
{
    public sealed class Profile
    {
        #region Methods
        public static ProfileInfoCollection ConvertToList(DataTable table)
        {
            ProfileInfoCollection list = new ProfileInfoCollection();

            foreach (DataRow row in table.Rows)
            {
                list.Add(ConvertToObject(row));
            }

            return list;
        }
        public static ProfileInfo ConvertToObject(DataRow row)
        {
            string userName = string.Empty;
            bool isAnonymous = false;
            DateTime lastActivityDate = DateTime.MinValue;
            DateTime lastUpdatedDate = DateTime.MinValue;
            long size = 0;


            if (row.Table.Columns.Contains("UserName") && !Convert.IsDBNull(row["UserName"]))
            {
                userName = Convert.ToString(row["UserName"]);
            }
            if (row.Table.Columns.Contains("IsAnonymous") && !Convert.IsDBNull(row["IsAnonymous"]))
            {
                isAnonymous = Convert.ToBoolean(row["IsAnonymous"]);
            }
            if (row.Table.Columns.Contains("LastActivityDate") && !Convert.IsDBNull(row["LastActivityDate"]))
            {
                lastActivityDate = Convert.ToDateTime(row["LastActivityDate"]);
            }
            if (row.Table.Columns.Contains("lastUpdatedDate") && !Convert.IsDBNull(row["lastUpdatedDate"]))
            {
                lastUpdatedDate = Convert.ToDateTime(row["lastUpdatedDate"]);
            }

            if (row.Table.Columns.Contains("Size") && !Convert.IsDBNull(row["Size"]))
            {
                size = Convert.ToInt64(row["Size"]);
            }

            ProfileInfo entry = new ProfileInfo(userName, isAnonymous, lastActivityDate, lastUpdatedDate, (int)size);


            return entry;

        }


        public static void DecodeProfileData(string[] names, string values, byte[] buf, SettingsPropertyValueCollection properties)
        {
            if (names == null || values == null || buf == null || properties == null)
                return;

            int i = 0;
            while (i < names.Length - 1)
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
        public static void EncodeProfileData(bool allowAnonymous, out string allNames, out string allValues, out byte[] buf, SettingsPropertyValueCollection properties, bool userIsAuthenticated)
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
    }
}
