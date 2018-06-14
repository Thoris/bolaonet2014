using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Framework.Security.Util
{
    public sealed class RandomPasswordCreator
    {
        #region Constants
        private static readonly char[] _passwordChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

        private static readonly int _passwordCharLength = _passwordChars.Length;
        #endregion

        #region Constructors/Destructors
        private RandomPasswordCreator()
        {
        }
        #endregion

        #region Methods
        public static string CreatePassword(int length)
        {
            // Get the seed.
            int seed = GetSeed();
            // Create the random class
            Random rnd = new Random(seed);
            // Create array for password.
            char[] password = new char[length];



            for (int i = 0; i < password.Length; i++)
            {
                password[i] = _passwordChars[rnd.Next(0, _passwordCharLength - 1)];
            }
            return new string(password);
        }

        private static int GetSeed()
        {
            byte[] bytes = new byte[4];
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);

            return
                bytes[0] |
                bytes[1] << 8 |
                bytes[2] << 16 |
                bytes[3] << 24;
        }
        #endregion

    }
}
