using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography;
using System.Web.Security;
using System.Text;
using System.Web.Configuration;

namespace Framework.Security.Util
{
    public class Cryptography
    {
        public static string EncodePassword(string password)
        {
            return EncodePassword(MembershipPasswordFormat.Clear, password, null);
        }
        public static string EncodePassword(MembershipPasswordFormat passwordFormat, string password)
        {
            return EncodePassword(passwordFormat, password, null);
        }
        public static string EncodePassword(MembershipPasswordFormat passwordFormat, string password, MachineKeySection machineKey)
        {
            string encodedPassword = password;

            switch (passwordFormat)
            {
                case MembershipPasswordFormat.Clear:

                    break;

                case MembershipPasswordFormat.Encrypted:

                    //encodedPassword =
                    //  Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)));

                    encodedPassword =
                     Convert.ToBase64String(Encoding.Unicode.GetBytes(password));


                    break;

                case MembershipPasswordFormat.Hashed:

                    HMACSHA1 hash = new HMACSHA1();

                    hash.Key = HexToByte(machineKey.ValidationKey);

                    encodedPassword =
                      Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));

                    break;

                default:
                    throw new ProviderException("Unsupported password format.");
            }

            return encodedPassword;
        }

        public static string UnEncodePassword(MembershipPasswordFormat passwordFormat, string encodedPassword)
        {
            string password = encodedPassword;

            switch (passwordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    break;

                case MembershipPasswordFormat.Encrypted:

                    //password =
                    //  Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(password)));


                    password =
                      Encoding.Unicode.GetString(Convert.FromBase64String(password));

                    break;

                case MembershipPasswordFormat.Hashed:
                    throw new ProviderException("Cannot unencode a hashed password.");

                default:
                    throw new ProviderException("Unsupported password format.");
            }

            return password;
        }

        private static byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];

            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return returnBytes;
        }

    }
}
