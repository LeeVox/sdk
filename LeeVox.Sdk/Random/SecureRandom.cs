using System;
using System.Security.Cryptography;

namespace LeeVox.Sdk
{
    public static class SecureRandom
    {
        public static double NextDouble()
        {
            using (var crypto = new RNGCryptoServiceProvider())
            {
                var r = new byte[sizeof(double)];
                crypto.GetBytes(r);
                return BitConverter.ToDouble(r);
            }
        }
    }
}