using System;
using System.Collections.Generic;

namespace LeeVox.Sdk
{
    internal interface IRandom
    {
        #region bool

        /// <summary>
        /// Returns a random <see cref="bool"/>.
        /// </summary>
        bool NextBool();

        #endregion

        #region byte

        /// <summary>
        /// Returns a non-negative random <see cref="byte"/>.
        /// </summary>
        /// <returns>
        /// A 8-bit unsigned integer that is greater than or equal to <c>0</c> and less than <see cref="byte.MaxValue"/>.
        /// </returns>
        byte NextByte();

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
        byte NextByte(byte maxValue);

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
        byte NextByte(byte minValue, byte maxValue);

        #endregion

        #region byte array

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
        /// Fills an array of <see cref="byte"/> with a sequence of random values
        /// starting at a specified index for a specified length.
        /// </summary>
        /// <param name="data">The array to fill with random bytes.</param>
        /// <param name="offset">The index of the array to start the fill operation.</param>
        /// <param name="count">The number of bytes to fill.</param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="offset"/> or <paramref name="count"/> is less than <c>0</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="offset"/> plus <paramref name="count"/> exceeds the length of <paramref name="data"/>.</exception>
        void FillBytes(byte[] data, int offset, int count);

        #endregion

        #region sbyte

        /// <summary>
        /// Returns a non-negative random <see cref="sbyte"/>.
        /// </summary>
        /// <returns>
        /// A 8-bit signed integer that is greater than or equal to <c>0</c> and less than <see cref="sbyte.MaxValue"/>.
        /// </returns>
        sbyte NextSByte();

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
        sbyte NextSByte(sbyte maxValue);

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
        sbyte NextSByte(sbyte minValue, sbyte maxValue);

        #endregion

        #region short

        /// <summary>
        /// Returns a non-negative random <see cref="short"/>.
        /// </summary>
        /// <returns>
        /// A 16-bit signed integer that is greater than or equal to <c>0</c> and less than <see cref="short.MaxValue"/>.
        /// </returns>
        short NextShort();

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
        short NextShort(short maxValue);

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
        short NextShort(short minValue, short maxValue);

        #endregion

        #region ushort

        /// <summary>
        /// Returns a non-negative random <see cref="ushort"/>.
        /// </summary>
        /// <returns>
        /// A 16-bit unsigned integer that is greater than or equal to <c>0</c> and less than <see cref="ushort.MaxValue"/>.
        /// </returns>
        ushort NextUShort();

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
        ushort NextUShort(ushort maxValue);

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
        ushort NextUShort(ushort minValue, ushort maxValue);

        #endregion

        #region int

        /// <summary>
        /// Returns a non-negative random <see cref="int"/>.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is greater than or equal to <c>0</c> and less than <see cref="int.MaxValue"/>.
        /// </returns>
        int NextInt();

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
        int NextInt(int maxValue);

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
        int NextInt(int minValue, int maxValue);

        #endregion

        #region uint

        /// <summary>
        /// Returns a non-negative random <see cref="uint"/>.
        /// </summary>
        /// <returns>
        /// A 32-bit unsigned integer that is greater than or equal to <c>0</c> and less than <see cref="uint.MaxValue"/>.
        /// </returns>
        uint NextUInt();

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
        uint NextUInt(uint maxValue);

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
        uint NextUInt(uint minValue, uint maxValue);

        #endregion

        #region long

        /// <summary>
        /// Returns a non-negative random <see cref="long"/>.
        /// </summary>
        /// <returns>
        /// A 64-bit signed integer that is greater than or equal to <c>0</c> and less than <see cref="long.MaxValue"/>.
        /// </returns>
        long NextLong();

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
        long NextLong(long maxValue);

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
        long NextLong(long minValue, long maxValue);

        #endregion

        #region ulong

        /// <summary>
        /// Returns a non-negative random <see cref="ulong"/>.
        /// </summary>
        /// <returns>
        /// A 64-bit unsigned integer that is greater than or equal to <c>0</c> and less than <see cref="ulong.MaxValue"/>.
        /// </returns>
        ulong NextULong();

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
        ulong NextULong(ulong maxValue);

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
        ulong NextULong(ulong minValue, ulong maxValue);

        #endregion

        #region float

        /// <summary>
        /// Returns a random <see cref="float"/> that is greater than or equal to <c>0</c>, and less than <c>1</c>.
        /// </summary>
        /// <returns>
        /// A single-precision floating-point number that is greater than or equal to <c>0</c>, and less than <c>1</c>;
        /// that is, the range of return values ordinarily includes <c>0</c> but not <c>1</c>.
        /// </returns>
        float NextFloat();

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
        float NextFloat(float minValue, float maxValue);

        #endregion

        #region double

        /// <summary>
        /// Returns a random <see cref="double"/> that is greater than or equal to <c>0</c>, and less than <c>1</c>.
        /// </summary>
        /// <returns>
        /// A double-precision floating-point number that is greater than or equal to <c>0</c>, and less than <c>1</c>;
        /// that is, the range of return values ordinarily includes <c>0</c> but not <c>1</c>.
        /// </returns>
        double NextDouble();

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
        double NextDouble(double minValue, double maxValue);

        #endregion

        #region decimal

        /// <summary>
        /// Returns a random <see cref="decimal"/> that is greater than or equal to <c>0</c>, and less than <c>1</c>.
        /// </summary>
        /// <returns>
        /// A decimal floating-point number that is greater than or equal to <c>0</c>, and less than <c>1</c>;
        /// that is, the range of return values ordinarily includes <c>0</c> but not <c>1</c>.
        /// </returns>
        decimal NextDecimal();

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
        decimal NextDecimal(decimal minValue, decimal maxValue);

        #endregion

        #region DateTime

        /// <summary>
        /// Returns a random <see cref="DateTime"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="DateTime"/> that is greater than or equal to <see cref="DateTime.MinValue"/> and less than <see cref="DateTime.MaxValue"/>.
        /// </returns>
        DateTime NextDateTime();

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
        DateTime NextDateTime(DateTime minValue, DateTime maxValue);

        #endregion

        #region char

        /// <summary>
        /// Returns a random character.
        /// </summary>
        /// <returns>
        /// A character that is greater than or equal to <see cref="char.MinValue"/> and less than <see cref="char.MaxValue"/>.
        /// </returns>
        char NextChar();

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
        char NextChar(char minValue, char maxValue);

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
        string NextString(int length);

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
        string NextString(int length, string chars);

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
        string NextString(int length, IEnumerable<char> chars);

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
        string NextString(int length, params char[] chars);

        #endregion
    }
}
