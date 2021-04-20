using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace LeeVox.Sdk
{
    /// <summary>
    /// Generate sercure random numbers or string using <see cref="RNGCryptoServiceProvider"/> class.
    /// </summary>
    /// <remarks>
    /// WARNING: This class is not thread-safe.
    /// </remarks>
    public class SecureRandom : IRandom, IDisposable
    {
        #region constructor & dispose methods

        private bool _disposed = false;
        private RNGCryptoServiceProvider cryptoService;

        public SecureRandom()
        {
            cryptoService = new RNGCryptoServiceProvider();
        }

        public void Dispose() => Dispose(true);
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                cryptoService?.Dispose();
            }

            _disposed = true;
        }

        #endregion

        #region internal functions

        internal static byte[] GenerateSecureByteArray(int length)
        {
            using (var cryptoService = new RNGCryptoServiceProvider())
            {
                return GenerateSecureByteArray(length, cryptoService);
            }
        }

        internal static byte[] GenerateSecureByteArray(int length, RNGCryptoServiceProvider cryptoService)
        {
            var seed = new byte[length];
            cryptoService.GetBytes(seed);
            return seed;
        }

        #endregion

        public bool NextBool()
        {
            throw new NotImplementedException();
        }

        public byte NextByte()
        {
            throw new NotImplementedException();
        }

        public byte NextByte(byte maxValue)
        {
            throw new NotImplementedException();
        }

        public byte NextByte(byte minValue, byte maxValue)
        {
            throw new NotImplementedException();
        }

        public byte[] NextBytes(int length)
            => GenerateSecureByteArray(length, cryptoService);

        public char NextChar()
        {
            throw new NotImplementedException();
        }

        public char NextChar(char minValue, char maxValue)
        {
            throw new NotImplementedException();
        }

        public DateTime NextDateTime()
        {
            throw new NotImplementedException();
        }

        public DateTime NextDateTime(DateTime minValue, DateTime maxValue)
        {
            throw new NotImplementedException();
        }

        public decimal NextDecimal()
        {
            throw new NotImplementedException();
        }

        public decimal NextDecimal(decimal maxValue)
        {
            throw new NotImplementedException();
        }

        public decimal NextDecimal(decimal minValue, decimal maxValue)
        {
            throw new NotImplementedException();
        }

        public double NextDouble()
        {
            throw new NotImplementedException();
        }

        public double NextDouble(double maxValue)
        {
            throw new NotImplementedException();
        }

        public double NextDouble(double minValue, double maxValue)
        {
            throw new NotImplementedException();
        }

        public float NextFloat()
        {
            throw new NotImplementedException();
        }

        public float NextFloat(float maxValue)
        {
            throw new NotImplementedException();
        }

        public float NextFloat(float minValue, float maxValue)
        {
            throw new NotImplementedException();
        }

        public int NextInt()
        {
            throw new NotImplementedException();
        }

        public int NextInt(int maxValue)
        {
            throw new NotImplementedException();
        }

        public int NextInt(int minValue, int maxValue)
        {
            throw new NotImplementedException();
        }

        public long NextLong()
        {
            throw new NotImplementedException();
        }

        public long NextLong(long maxValue)
        {
            throw new NotImplementedException();
        }

        public long NextLong(long minValue, long maxValue)
        {
            throw new NotImplementedException();
        }

        public sbyte NextSByte()
        {
            throw new NotImplementedException();
        }

        public sbyte NextSByte(sbyte maxValue)
        {
            throw new NotImplementedException();
        }

        public sbyte NextSByte(sbyte minValue, sbyte maxValue)
        {
            throw new NotImplementedException();
        }

        public short NextShort()
        {
            throw new NotImplementedException();
        }

        public short NextShort(short maxValue)
        {
            throw new NotImplementedException();
        }

        public short NextShort(short minValue, short maxValue)
        {
            throw new NotImplementedException();
        }

        public string NextString(int length)
        {
            throw new NotImplementedException();
        }

        public string NextString(int length, params char[] chars)
        {
            throw new NotImplementedException();
        }

        public string NextString(int length, IEnumerable<char> chars)
        {
            throw new NotImplementedException();
        }

        public string NextString(int length, string chars)
        {
            throw new NotImplementedException();
        }

        public uint NextUInt()
        {
            throw new NotImplementedException();
        }

        public uint NextUInt(uint maxValue)
        {
            throw new NotImplementedException();
        }

        public uint NextUInt(uint minValue, uint maxValue)
        {
            throw new NotImplementedException();
        }

        public ulong NextULong()
        {
            throw new NotImplementedException();
        }

        public ulong NextULong(ulong maxValue)
        {
            throw new NotImplementedException();
        }

        public ulong NextULong(ulong minValue, ulong maxValue)
        {
            throw new NotImplementedException();
        }

        public ushort NextUShort()
        {
            throw new NotImplementedException();
        }

        public ushort NextUShort(ushort maxValue)
        {
            throw new NotImplementedException();
        }

        public ushort NextUShort(ushort minValue, ushort maxValue)
        {
            throw new NotImplementedException();
        }
    }
}