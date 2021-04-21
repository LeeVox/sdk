using System;
using System.Collections.Generic;
using System.Linq;
using LeeVox.Sdk.Lib;

namespace LeeVox.Sdk
{
    internal interface IRandom
    {
        #region core functions

        /// <summary>
        /// Returns an array of non-negative random <see cref="byte"/> with a specified length.
        /// </summary>
        /// <param name="length">Length of the output array.</param>
        /// <returns>
        /// An array of <see cref="byte"/>.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> is less than <c>0</c>.</exception>
        byte[] NextBytes(int length);

        /// <summary>
        /// Returns a random <see cref="float"/> that is greater than or equal to <c>0</c>, and less than <c>1</c>.
        /// </summary>
        /// <returns>
        /// A single-precision floating-point number that is greater than or equal to <c>0</c>, and less than <c>1</c>;
        /// that is, the range of return values ordinarily includes <c>0</c> but not <c>1</c>.
        /// </returns>
        float NextFloat();

        /// <summary>
        /// Returns a random <see cref="double"/> that is greater than or equal to <c>0</c>, and less than <c>1</c>.
        /// </summary>
        /// <returns>
        /// A double-precision floating-point number that is greater than or equal to <c>0</c>, and less than <c>1</c>;
        /// that is, the range of return values ordinarily includes <c>0</c> but not <c>1</c>.
        /// </returns>
        double NextDouble();

        #endregion

        #region default implementations

        #region bool

        /// <summary>
        /// Returns a random <see cref="bool"/>.
        /// </summary>
        bool NextBool()
            => NumberFactory.MakeBoolean(NextUInt());

        #endregion

        #region byte

        /// <summary>
        /// Returns a non-negative random <see cref="byte"/>.
        /// </summary>
        /// <returns>
        /// A 8-bit unsigned integer that is greater than or equal to <c>0</c> and less than <see cref="byte.MaxValue"/>.
        /// </returns>
        byte NextByte()
            => NextByte(0, byte.MaxValue);

        /// <summary>
        /// Returns a non-negative random <see cref="byte"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the output random number.</param>
        /// <returns>
        /// A 8-bit unsigned integer that is greater than or equal to <c>0</c>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values includes <c>0</c> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <c>0</c>, <c>0</c> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <c>0</c>.</exception>
        byte NextByte(byte maxValue)
            => NextByte(0, maxValue);

        /// <summary>
        /// Returns a random <see cref="byte"/> that is within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the output random number.</param>
        /// <param name="maxValue">The exclusive upper bound of the output random number. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
        /// <returns>
        /// A 8-bit unsigned integer that is greater than or equal to <paramref name="minValue"/>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values ordinarily includes <paramref name="minValue"/> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <paramref name="minValue"/>, <paramref name="minValue"/> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <paramref name="minValue"/>.</exception>
        byte NextByte(byte minValue, byte maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (byte)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region sbyte

        /// <summary>
        /// Returns a non-negative random <see cref="sbyte"/>.
        /// </summary>
        /// <returns>
        /// A 8-bit signed integer that is greater than or equal to <c>0</c> and less than <see cref="sbyte.MaxValue"/>.
        /// </returns>
        sbyte NextSByte()
            => NextSByte(0, sbyte.MaxValue);

        /// <summary>
        /// Returns a non-negative random <see cref="sbyte"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the output random number.</param>
        /// <returns>
        /// A 8-bit signed integer that is greater than or equal to <c>0</c>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values includes <c>0</c> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <c>0</c>, <c>0</c> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <c>0</c>.</exception>
        sbyte NextSByte(sbyte maxValue)
            => NextSByte(0, maxValue);

        /// <summary>
        /// Returns a random <see cref="sbyte"/> that is within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the output random number.</param>
        /// <param name="maxValue">The exclusive upper bound of the output random number. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
        /// <returns>
        /// A 8-bit signed integer that is greater than or equal to <paramref name="minValue"/>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values ordinarily includes <paramref name="minValue"/> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <paramref name="minValue"/>, <paramref name="minValue"/> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <paramref name="minValue"/>.</exception>
        sbyte NextSByte(sbyte minValue, sbyte maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (sbyte)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region short

        /// <summary>
        /// Returns a non-negative random <see cref="short"/>.
        /// </summary>
        /// <returns>
        /// A 16-bit signed integer that is greater than or equal to <c>0</c> and less than <see cref="short.MaxValue"/>.
        /// </returns>
        short NextShort()
            => NextShort(0, short.MaxValue);

        /// <summary>
        /// Returns a non-negative random <see cref="short"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the output random number.</param>
        /// <returns>
        /// A 16-bit signed integer that is greater than or equal to <c>0</c>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values includes <c>0</c> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <c>0</c>, <c>0</c> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <c>0</c>.</exception>
        short NextShort(short maxValue)
            => NextShort(0, maxValue);

        /// <summary>
        /// Returns a random <see cref="short"/> that is within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the output random number.</param>
        /// <param name="maxValue">The exclusive upper bound of the output random number. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
        /// <returns>
        /// A 16-bit signed integer that is greater than or equal to <paramref name="minValue"/>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values ordinarily includes <paramref name="minValue"/> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <paramref name="minValue"/>, <paramref name="minValue"/> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <paramref name="minValue"/>.</exception>
        short NextShort(short minValue, short maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (short)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region ushort

        /// <summary>
        /// Returns a non-negative random <see cref="ushort"/>.
        /// </summary>
        /// <returns>
        /// A 16-bit unsigned integer that is greater than or equal to <c>0</c> and less than <see cref="ushort.MaxValue"/>.
        /// </returns>
        ushort NextUShort()
            => NextUShort(0, ushort.MaxValue);

        /// <summary>
        /// Returns a non-negative random <see cref="ushort"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the output random number.</param>
        /// <returns>
        /// A 16-bit unsigned integer that is greater than or equal to <c>0</c>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values includes <c>0</c> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <c>0</c>, <c>0</c> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <c>0</c>.</exception>
        ushort NextUShort(ushort maxValue)
            => NextUShort(0, maxValue);

        /// <summary>
        /// Returns a random <see cref="ushort"/> that is within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the output random number.</param>
        /// <param name="maxValue">The exclusive upper bound of the output random number. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
        /// <returns>
        /// A 16-bit unsigned integer that is greater than or equal to <paramref name="minValue"/>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values ordinarily includes <paramref name="minValue"/> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <paramref name="minValue"/>, <paramref name="minValue"/> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <paramref name="minValue"/>.</exception>
        ushort NextUShort(ushort minValue, ushort maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (ushort)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region int

        /// <summary>
        /// Returns a non-negative random <see cref="int"/>.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is greater than or equal to <c>0</c> and less than <see cref="int.MaxValue"/>.
        /// </returns>
        int NextInt()
            => NextInt(0, int.MaxValue);

        /// <summary>
        /// Returns a non-negative random <see cref="int"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the output random number.</param>
        /// <returns>
        /// A 32-bit signed integer that is greater than or equal to <c>0</c>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values includes <c>0</c> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <c>0</c>, <c>0</c> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <c>0</c>.</exception>
        int NextInt(int maxValue)
            => NextInt(0, maxValue);

        /// <summary>
        /// Returns a random <see cref="int"/> that is within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the output random number.</param>
        /// <param name="maxValue">The exclusive upper bound of the output random number. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
        /// <returns>
        /// A 32-bit signed integer that is greater than or equal to <paramref name="minValue"/>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values ordinarily includes <paramref name="minValue"/> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <paramref name="minValue"/>, <paramref name="minValue"/> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <paramref name="minValue"/>.</exception>
        int NextInt(int minValue, int maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (int)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region uint

        /// <summary>
        /// Returns a non-negative random <see cref="uint"/>.
        /// </summary>
        /// <returns>
        /// A 32-bit unsigned integer that is greater than or equal to <c>0</c> and less than <see cref="uint.MaxValue"/>.
        /// </returns>
        uint NextUInt()
            => NextUInt(0, uint.MaxValue);

        /// <summary>
        /// Returns a non-negative random <see cref="uint"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the output random number.</param>
        /// <returns>
        /// A 32-bit unsigned integer that is greater than or equal to <c>0</c>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values includes <c>0</c> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <c>0</c>, <c>0</c> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <c>0</c>.</exception>
        uint NextUInt(uint maxValue)
            => NextUInt(0, maxValue);

        /// <summary>
        /// Returns a random <see cref="uint"/> that is within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the output random number.</param>
        /// <param name="maxValue">The exclusive upper bound of the output random number. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
        /// <returns>
        /// A 32-bit unsigned integer that is greater than or equal to <paramref name="minValue"/>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values ordinarily includes <paramref name="minValue"/> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <paramref name="minValue"/>, <paramref name="minValue"/> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <paramref name="minValue"/>.</exception>
        uint NextUInt(uint minValue, uint maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (uint)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region long

        /// <summary>
        /// Returns a non-negative random <see cref="long"/>.
        /// </summary>
        /// <returns>
        /// A 64-bit signed integer that is greater than or equal to <c>0</c> and less than <see cref="long.MaxValue"/>.
        /// </returns>
        long NextLong()
            => NextLong(0, long.MaxValue);

        /// <summary>
        /// Returns a non-negative random <see cref="long"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the output random number.</param>
        /// <returns>
        /// A 64-bit signed integer that is greater than or equal to <c>0</c>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values includes <c>0</c> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <c>0</c>, <c>0</c> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <c>0</c>.</exception>
        long NextLong(long maxValue)
            => NextLong(0, maxValue);

        /// <summary>
        /// Returns a random <see cref="long"/> that is within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the output random number.</param>
        /// <param name="maxValue">The exclusive upper bound of the output random number. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
        /// <returns>
        /// A 64-bit signed integer that is greater than or equal to <paramref name="minValue"/>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values ordinarily includes <paramref name="minValue"/> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <paramref name="minValue"/>, <paramref name="minValue"/> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <paramref name="minValue"/>.</exception>
        long NextLong(long minValue, long maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (long)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region ulong

        /// <summary>
        /// Returns a non-negative random <see cref="ulong"/>.
        /// </summary>
        /// <returns>
        /// A 64-bit unsigned integer that is greater than or equal to <c>0</c> and less than <see cref="ulong.MaxValue"/>.
        /// </returns>
        ulong NextULong()
            => NextULong(0, ulong.MaxValue);

        /// <summary>
        /// Returns a non-negative random <see cref="ulong"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the output random number.</param>
        /// <returns>
        /// A 64-bit unsigned integer that is greater than or equal to <c>0</c>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values includes <c>0</c> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <c>0</c>, <c>0</c> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <c>0</c>.</exception>
        ulong NextULong(ulong maxValue)
            => NextULong(0, maxValue);

        /// <summary>
        /// Returns a random <see cref="ulong"/> that is within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the output random number.</param>
        /// <param name="maxValue">The exclusive upper bound of the output random number. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
        /// <returns>
        /// A 64-bit unsigned integer that is greater than or equal to <paramref name="minValue"/>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values ordinarily includes <paramref name="minValue"/> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <paramref name="minValue"/>, <paramref name="minValue"/> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <paramref name="minValue"/>.</exception>
        ulong NextULong(ulong minValue, ulong maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (ulong)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region float

        /// <summary>
        /// Returns a random <see cref="float"/> that is within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the output random number.</param>
        /// <param name="maxValue">The exclusive upper bound of the output random number. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
        /// <returns>
        /// A single-precision floating-point number that is greater than or equal to <paramref name="minValue"/>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values ordinarily includes <paramref name="minValue"/> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <paramref name="minValue"/>, <paramref name="minValue"/> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <paramref name="minValue"/>.</exception>
        float NextFloat(float minValue, float maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (float)(minValue + (maxValue - minValue) * NextFloat());
        }

        #endregion

        #region double

        /// <summary>
        /// Returns a random <see cref="double"/> that is within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the output random number.</param>
        /// <param name="maxValue">The exclusive upper bound of the output random number. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
        /// <returns>
        /// A double-precision floating-point number that is greater than or equal to <paramref name="minValue"/>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values ordinarily includes <paramref name="minValue"/> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <paramref name="minValue"/>, <paramref name="minValue"/> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <paramref name="minValue"/>.</exception>
        double NextDouble(double minValue, double maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (double)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region decimal

        /// <summary>
        /// Returns a random <see cref="decimal"/> that is greater than or equal to <c>0</c>, and less than <c>1</c>.
        /// </summary>
        /// <returns>
        /// A decimal floating-point number that is greater than or equal to <c>0</c>, and less than <c>1</c>;
        /// that is, the range of return values ordinarily includes <c>0</c> but not <c>1</c>.
        /// </returns>
        decimal NextDecimal()
            => new decimal(NextDouble());

        /// <summary>
        /// Returns a random <see cref="decimal"/> that is within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the output random number.</param>
        /// <param name="maxValue">The exclusive upper bound of the output random number. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
        /// <returns>
        /// A decimal floating-point number that is greater than or equal to <paramref name="minValue"/>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values ordinarily includes <paramref name="minValue"/> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <paramref name="minValue"/>, <paramref name="minValue"/> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <paramref name="minValue"/>.</exception>
        decimal NextDecimal(decimal minValue, decimal maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return minValue + (maxValue - minValue) * (decimal)NextDouble();
        }

        #endregion

        #region DateTime

        /// <summary>
        /// Returns a random <see cref="DateTime"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="DateTime"/> that is greater than or equal to <see cref="DateTime.MinValue"/> and less than <see cref="DateTime.MaxValue"/>.
        /// </returns>
        DateTime NextDateTime()
            => NextDateTime(DateTime.MinValue, DateTime.MaxValue);

        /// <summary>
        /// Returns a random <see cref="DateTime"/> that is within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the output random number.</param>
        /// <param name="maxValue">The exclusive upper bound of the output random number. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
        /// <returns>
        /// A <see cref="DateTime"/> that is greater than or equal to <paramref name="minValue"/>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values ordinarily includes <paramref name="minValue"/> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <paramref name="minValue"/>, <paramref name="minValue"/> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <paramref name="minValue"/>.</exception>
        DateTime NextDateTime(DateTime minValue, DateTime maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return minValue.AddTicks(NextLong(0, (maxValue - minValue).Ticks));
        }

        #endregion

        #region char

        /// <summary>
        /// Returns a random character.
        /// </summary>
        /// <returns>
        /// A character that is greater than or equal to <see cref="char.MinValue"/> and less than <see cref="char.MaxValue"/>.
        /// </returns>
        char NextChar()
            => NextChar(char.MinValue, char.MaxValue);

        /// <summary>
        /// Returns a random character that is within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the output random number.</param>
        /// <param name="maxValue">The exclusive upper bound of the output random number. <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.</param>
        /// <returns>
        /// A character that is greater than or equal to <paramref name="minValue"/>, and less than <paramref name="maxValue"/>;
        /// that is, the range of return values ordinarily includes <paramref name="minValue"/> but not <paramref name="maxValue"/>.
        /// <para>However, if <paramref name="maxValue"/> equals <paramref name="minValue"/>, <paramref name="minValue"/> is returned.</para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maxValue"/> is less than <paramref name="minValue"/>.</exception>
        char NextChar(char minValue, char maxValue)
        {
            if (maxValue < minValue)
                throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
            return (char)(minValue + (maxValue - minValue) * NextDouble());
        }

        #endregion

        #region string

        /// <summary>
        /// Returns a random ASCII string with a specified length.
        /// </summary>
        /// <param name="length">Length of the output string.</param>
        /// <returns>
        /// A sequence of ASCII printable characters which are greater than or equal to <c>32</c>, and less than <c>127</c>.
        /// <para>See more: <see href="https://en.wikipedia.org/wiki/ASCII#Printable_characters"/></para>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> is less than <c>0</c>.</exception>
        string NextString(int length)
            => NextString(length, Const.ASCII_CHARS);

        /// <summary>
        /// Returns a random string with a specified length and the specified characters collection.
        /// </summary>
        /// <param name="length">Length of the output string.</param>
        /// <param name="chars">Group of character to build the output string.</param>
        /// <returns>
        /// A sequence of characters which are existed in <paramref name="chars"/> collection.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> is less than <c>0</c>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="chars"/> is <c>null</c> or empty.</exception>
        string NextString(int length, string chars)
            => NextString(length, chars?.ToCharArray());

        /// <summary>
        /// Returns a random string with a specified length and the specified characters collection.
        /// </summary>
        /// <param name="length">Length of the output string.</param>
        /// <param name="chars">Group of character to build the output string.</param>
        /// <returns>
        /// A sequence of characters which are existed in <paramref name="chars"/> collection.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> is less than <c>0</c>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="chars"/> is <c>null</c> or empty.</exception>
        string NextString(int length, IEnumerable<char> chars)
            => NextString(length, chars?.ToArray());

        /// <summary>
        /// Returns a random string with a specified length and the specified characters collection.
        /// </summary>
        /// <param name="length">Length of the output string.</param>
        /// <param name="chars">Group of character to build the output string.</param>
        /// <returns>
        /// A sequence of characters which are existed in <paramref name="chars"/> collection.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="length"/> is less than <c>0</c>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="chars"/> is <c>null</c> or empty.</exception>
        string NextString(int length, params char[] chars)
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

        #endregion
    }
}
