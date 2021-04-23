using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using LeeVox.Sdk.Lib;

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
        private RNGCryptoServiceProvider _random;

        #region constructors

        public SecureRandom()
        {
            _random = new RNGCryptoServiceProvider();
        }

        #endregion

        #region bool

        /// <inheritdoc/>
        public bool NextBool()
            => NumberFactory.MakeBoolean(NextUInt());

        #endregion

        #region byte

        /// <inheritdoc/>
        public byte NextByte()
            => NextByte(0, byte.MaxValue);

        /// <inheritdoc/>
        public byte NextByte(byte maxValue)
            => NextByte(0, maxValue);

        /// <inheritdoc/>
        public byte NextByte(byte minValue, byte maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (byte)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region byte array

        /// <inheritdoc/>
        public byte[] NextBytes(int length)
        {
            var result = new byte[length];
            _random.GetBytes(result, 0, length);
            return result;
        }

        /// <inheritdoc/>
        public void FillBytes(byte[] data, int offset, int count)
            => _random.GetBytes(data, offset, count);

        #endregion

        #region sbyte

        /// <inheritdoc/>
        public sbyte NextSByte()
            => NextSByte(0, sbyte.MaxValue);

        /// <inheritdoc/>
        public sbyte NextSByte(sbyte maxValue)
            => NextSByte(0, maxValue);

        /// <inheritdoc/>
        public sbyte NextSByte(sbyte minValue, sbyte maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (sbyte)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region short

        /// <inheritdoc/>
        public short NextShort()
            => NextShort(0, short.MaxValue);

        /// <inheritdoc/>
        public short NextShort(short maxValue)
            => NextShort(0, maxValue);

        /// <inheritdoc/>
        public short NextShort(short minValue, short maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (short)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region ushort

        /// <inheritdoc/>
        public ushort NextUShort()
            => NextUShort(0, ushort.MaxValue);

        /// <inheritdoc/>
        public ushort NextUShort(ushort maxValue)
            => NextUShort(0, maxValue);

        /// <inheritdoc/>
        public ushort NextUShort(ushort minValue, ushort maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (ushort)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region int

        /// <inheritdoc/>
        public int NextInt()
            => NextInt(0, int.MaxValue);

        /// <inheritdoc/>
        public int NextInt(int maxValue)
            => NextInt(0, maxValue);

        /// <inheritdoc/>
        public int NextInt(int minValue, int maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (int)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region uint

        /// <inheritdoc/>
        public uint NextUInt()
            => NextUInt(0, uint.MaxValue);

        /// <inheritdoc/>
        public uint NextUInt(uint maxValue)
            => NextUInt(0, maxValue);

        /// <inheritdoc/>
        public uint NextUInt(uint minValue, uint maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (uint)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region long

        /// <inheritdoc/>
        public long NextLong()
            => NextLong(0, long.MaxValue);

        /// <inheritdoc/>
        public long NextLong(long maxValue)
            => NextLong(0, maxValue);

        /// <inheritdoc/>
        public long NextLong(long minValue, long maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (long)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region ulong

        /// <inheritdoc/>
        public ulong NextULong()
            => NextULong(0, ulong.MaxValue);

        /// <inheritdoc/>
        public ulong NextULong(ulong maxValue)
            => NextULong(0, maxValue);

        /// <inheritdoc/>
        public ulong NextULong(ulong minValue, ulong maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (ulong)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region float

        /// <inheritdoc/>
        public float NextFloat()
        {
            byte[] bytes = new byte[sizeof(uint)];
            _random.GetBytes(bytes);
            uint num = NumberFactory.MakeUInt(bytes);
            return NumberFactory.MakeFloat(num);
        }

        /// <inheritdoc/>
        public float NextFloat(float minValue, float maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (float)(minValue + (maxValue - minValue) * NextFloat());
        }

        #endregion

        #region double

        /// <inheritdoc/>
        public double NextDouble()
        {
            byte[] bytes = new byte[sizeof(ulong)];
            _random.GetBytes(bytes);
            ulong num = NumberFactory.MakeULong(bytes);
            return NumberFactory.MakeDouble(num);
        }

        /// <inheritdoc/>
        public double NextDouble(double minValue, double maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (double)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region decimal

        /// <inheritdoc/>
        public decimal NextDecimal()
            => new decimal(NextDouble());

        /// <inheritdoc/>
        public decimal NextDecimal(decimal minValue, decimal maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return minValue + (maxValue - minValue) * (decimal)NextDouble();
        }

        #endregion

        #region DateTime

        /// <inheritdoc/>
        public DateTime NextDateTime()
            => NextDateTime(DateTime.MinValue, DateTime.MaxValue);

        /// <inheritdoc/>
        public DateTime NextDateTime(DateTime minValue, DateTime maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return minValue.AddTicks(NextLong(0, (maxValue - minValue).Ticks));
        }

        #endregion

        #region char

        /// <inheritdoc/>
        public char NextChar()
            => NextChar(char.MinValue, char.MaxValue);

        /// <inheritdoc/>
        public char NextChar(char minValue, char maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (char)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region string

        /// <inheritdoc/>
        public string NextString(int length)
            => NextString(length, Const.ASCII_CHARS);

        /// <inheritdoc/>
        public string NextString(int length, string chars)
            => NextString(length, chars?.ToCharArray());

        /// <inheritdoc/>
        public string NextString(int length, IEnumerable<char> chars)
            => NextString(length, chars?.ToArray());

        /// <inheritdoc/>
        public string NextString(int length, params char[] chars)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), $"{nameof(length)} must greater than 0.");
            if (chars is null || chars.Length <= 0)
                throw new ArgumentNullException(nameof(chars), $"{nameof(chars)} must have at least 1 element.");

            var result = new char[length];
            for (var i = 0; i < length; i++)
            {
                result[i] = chars[NextInt(0, chars.Length)];
            }

            return new String(result);
        }

        #endregion

        #region disposable

        private bool _disposed = false;
        public void Dispose() => Dispose(true);
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _random?.Dispose();
            }

            _disposed = true;
        }

        #endregion
    }
}