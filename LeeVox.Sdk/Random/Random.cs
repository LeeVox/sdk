using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeeVox.Sdk.Lib;

namespace LeeVox.Sdk
{
    /// <summary>Generate random numbers or string using XoShiRo256StarStar algorithm. </summary>
    /// <remarks>
    /// WARNING: This class is not thread-safe.
    /// </remarks>
    public class Random : IRandom, IDisposable
    {
        private XoShiRo256StarStar _random;

        #region constructors

        public Random()
        {
            _random = new XoShiRo256StarStar((ulong)DateTime.UtcNow.Ticks);
        }
        public Random(params int[] seed)
        {
            _random = new XoShiRo256StarStar(seed.Select(x => (ulong)x).ToArray());
        }
        public Random(params uint[] seed)
        {
            _random = new XoShiRo256StarStar(seed.Select(x => (ulong)x).ToArray());
        }
        public Random(params long[] seed)
        {
            _random = new XoShiRo256StarStar(seed.Select(x => (ulong)x).ToArray());
        }
        public Random(params ulong[] seed)
        {
            _random = new XoShiRo256StarStar(seed);
        }

        #endregion

        #region bool

        /// <inheritdoc/>
        public bool NextBool()
            => (NextByte() & 1) == 1;

        #endregion

        #region byte

        /// <inheritdoc/>
        public byte NextByte()
            => NextBytes(1)[0];

        /// <inheritdoc/>
        public byte NextByte(byte maxValue)
            => NextByte(0, maxValue);

        /// <inheritdoc/>
        public byte NextByte(byte minValue, byte maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            var nextDouble = NextDouble();
            return (byte)(minValue + maxValue*nextDouble - minValue*nextDouble);
        }

        #endregion

        #region byte array

        /// <inheritdoc/>
        public byte[] NextBytes(int length)
        {
            var result = new byte[length];
            _random.FillBytes(result, 0, length);
            return result;
        }

        /// <inheritdoc/>
        public void FillBytes(byte[] data, int offset, int count)
            => _random.FillBytes(data, offset, count);

        #endregion

        #region sbyte

        /// <inheritdoc/>
        public sbyte NextSByte()
            => (sbyte)(NextByte() & Const.BYTE_TO_NON_NEGATIVE_SBYTE_MASK);

        /// <inheritdoc/>
        public sbyte NextSByte(sbyte maxValue)
            => NextSByte(0, maxValue);

        /// <inheritdoc/>
        public sbyte NextSByte(sbyte minValue, sbyte maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            var nextDouble = NextDouble();
            return (sbyte)(minValue + maxValue*nextDouble - minValue*nextDouble);
        }

        #endregion

        #region short

        /// <inheritdoc/>
        public short NextShort()
            => (short)(NextUShort() & Const.USHORT_TO_NON_NEGATIVE_SHORT_MASK);

        /// <inheritdoc/>
        public short NextShort(short maxValue)
            => NextShort(0, maxValue);

        /// <inheritdoc/>
        public short NextShort(short minValue, short maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            var nextDouble = NextDouble();
            return (short)(minValue + maxValue*nextDouble - minValue*nextDouble);
        }

        #endregion

        #region ushort

        /// <inheritdoc/>
        public ushort NextUShort()
            => _random.NextUShort();

        /// <inheritdoc/>
        public ushort NextUShort(ushort maxValue)
            => NextUShort(0, maxValue);

        /// <inheritdoc/>
        public ushort NextUShort(ushort minValue, ushort maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            var nextDouble = NextDouble();
            return (ushort)(minValue + maxValue*nextDouble - minValue*nextDouble);
        }

        #endregion

        #region int

        /// <inheritdoc/>
        public int NextInt()
            => (int)(NextUInt() & Const.UINT_TO_NON_NEGATIVE_INT_MASK);

        /// <inheritdoc/>
        public int NextInt(int maxValue)
            => NextInt(0, maxValue);

        /// <inheritdoc/>
        public int NextInt(int minValue, int maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            var nextDouble = NextDouble();
            return (int)(minValue + maxValue*nextDouble - minValue*nextDouble);
        }

        #endregion

        #region uint

        /// <inheritdoc/>
        public uint NextUInt()
            => _random.NextUInt();

        /// <inheritdoc/>
        public uint NextUInt(uint maxValue)
            => NextUInt(0, maxValue);

        /// <inheritdoc/>
        public uint NextUInt(uint minValue, uint maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            var nextDouble = NextDouble();
            return (uint)(minValue + maxValue*nextDouble - minValue*nextDouble);
        }

        #endregion

        #region long

        /// <inheritdoc/>
        public long NextLong()
            => (long)(NextULong() & Const.ULONG_TO_NON_NEGATIVE_LONG_MASK);

        /// <inheritdoc/>
        public long NextLong(long maxValue)
            => NextLong(0, maxValue);

        /// <inheritdoc/>
        public long NextLong(long minValue, long maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            var nextDouble = NextDouble();
            return (long)(minValue + maxValue*nextDouble - minValue*nextDouble);
        }

        #endregion

        #region ulong

        /// <inheritdoc/>
        public ulong NextULong()
            => _random.NextULong();

        /// <inheritdoc/>
        public ulong NextULong(ulong maxValue)
            => NextULong(0, maxValue);

        /// <inheritdoc/>
        public ulong NextULong(ulong minValue, ulong maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            var nextDouble = NextDouble();
            return (ulong)(minValue + maxValue*nextDouble - minValue*nextDouble);
        }

        #endregion

        #region float

        /// <inheritdoc/>
        public float NextFloat()
            => _random.NextFloat();

        /// <inheritdoc/>
        public float NextFloat(float minValue, float maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            var nextFloat = NextFloat();
            return (float)(minValue + maxValue*nextFloat - minValue*nextFloat);
        }

        #endregion

        #region double

        /// <inheritdoc/>
        public double NextDouble()
            => _random.NextDouble();

        /// <inheritdoc/>
        public double NextDouble(double minValue, double maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            var nextDouble = NextDouble();
            return (double)(minValue + maxValue*nextDouble - minValue*nextDouble);
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
            var nextDouble = (decimal)NextDouble();
            return minValue + maxValue*nextDouble - minValue*nextDouble;
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
            => NextChar(Const.ASCII_CHAR_MIN, Const.ASCII_CHAR_MAX);

        /// <inheritdoc/>
        public char NextChar(char minValue, char maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            var nextDouble = NextDouble();
            return (char)(minValue + maxValue*nextDouble - minValue*nextDouble);
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

            var doubles = _random.NextDoubleArray(length);
            var builder = new StringBuilder(length);
            for (var i = 0; i < length; i++)
            {
                builder.Append(chars[(int)(doubles[i] * chars.Length)]);
            }

            return builder.ToString();
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