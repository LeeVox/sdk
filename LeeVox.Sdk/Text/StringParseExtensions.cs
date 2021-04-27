using System;
using System.Globalization;

namespace LeeVox.Sdk
{
    public static class StringParseExtensions
    {
        #region generic parsing

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{TResult}"/> type using <see cref="Convert.ChangeType"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static TResult? ParseTo<TResult>(this string text)
            where TResult : struct, IConvertible
        {
            try
            {
                return (TResult?)Convert.ChangeType(text, typeof(TResult));
            }
            catch
            {
                return (TResult?)null;
            }
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{TResult}"/> type using <see cref="Convert.ChangeType"/> function and a <see cref="FormatProvider"/>.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static TResult? ParseTo<TResult>(this string text, IFormatProvider provider)
            where TResult : struct, IConvertible
        {
            try
            {
                return (TResult?)Convert.ChangeType(text, typeof(TResult), provider);
            }
            catch
            {
                return (TResult?)null;
            }
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{TResult}"/> type using <see cref="Convert.ChangeType"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static TResult ParseTo<TResult>(this string text, TResult returnValueIfError)
            where TResult : struct, IConvertible
        {
            try
            {
                return (TResult)Convert.ChangeType(text, typeof(TResult));
            }
            catch
            {
                return returnValueIfError;
            }
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{TResult}"/> type using <see cref="Convert.ChangeType"/> function and a <see cref="FormatProvider"/>.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static TResult ParseTo<TResult>(this string text, IFormatProvider provider, TResult returnValueIfError)
            where TResult : struct, IConvertible
        {
            try
            {
                return (TResult)Convert.ChangeType(text, typeof(TResult), provider);
            }
            catch
            {
                return returnValueIfError;
            }
        }

        #endregion

        #region parse to boolean

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Boolean}"/> type using <see cref="bool.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static bool? ParseToBoolean(this string text)
        {
            return bool.TryParse(text, out bool result) ? result : (bool?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Boolean}"/> type using <see cref="bool.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static bool ParseToBoolean(this string text, bool returnValueIfError)
        {
            return bool.TryParse(text, out bool result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to byte

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Byte}"/> type using <see cref="byte.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static byte? ParseToByte(this string text)
        {
            return byte.TryParse(text, out byte result) ? result : (byte?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Byte}"/> type using <see cref="byte.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static byte? ParseToByte(this string text, NumberStyles styles, IFormatProvider provider)
        {
            return byte.TryParse(text, styles, provider, out byte result) ? result : (byte?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Byte}"/> type using <see cref="byte.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static byte ParseToByte(this string text, byte returnValueIfError)
        {
            return byte.TryParse(text, out byte result) ? result : returnValueIfError;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Byte}"/> type using <see cref="byte.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static byte ParseToByte(this string text, NumberStyles styles, IFormatProvider provider, byte returnValueIfError)
        {
            return byte.TryParse(text, styles, provider, out byte result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to sbyte

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{sbyte}"/> type using <see cref="sbyte.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static sbyte? ParseToSByte(this string text)
        {
            return sbyte.TryParse(text, out sbyte result) ? result : (sbyte?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{sbyte}"/> type using <see cref="sbyte.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static sbyte? ParseToSByte(this string text, NumberStyles styles, IFormatProvider provider)
        {
            return sbyte.TryParse(text, styles, provider, out sbyte result) ? result : (sbyte?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{sbyte}"/> type using <see cref="sbyte.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static sbyte ParseToSByte(this string text, sbyte returnValueIfError)
        {
            return sbyte.TryParse(text, out sbyte result) ? result : returnValueIfError;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{sbyte}"/> type using <see cref="sbyte.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static sbyte ParseToSByte(this string text, NumberStyles styles, IFormatProvider provider, sbyte returnValueIfError)
        {
            return sbyte.TryParse(text, styles, provider, out sbyte result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to short

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{short}"/> type using <see cref="short.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static short? ParseToShort(this string text)
        {
            return short.TryParse(text, out short result) ? result : (short?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{short}"/> type using <see cref="short.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static short? ParseToShort(this string text, NumberStyles styles, IFormatProvider provider)
        {
            return short.TryParse(text, styles, provider, out short result) ? result : (short?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{short}"/> type using <see cref="short.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static short ParseToShort(this string text, short returnValueIfError)
        {
            return short.TryParse(text, out short result) ? result : returnValueIfError;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{short}"/> type using <see cref="short.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static short ParseToShort(this string text, NumberStyles styles, IFormatProvider provider, short returnValueIfError)
        {
            return short.TryParse(text, styles, provider, out short result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to ushort

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{ushort}"/> type using <see cref="ushort.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static ushort? ParseToUShort(this string text)
        {
            return ushort.TryParse(text, out ushort result) ? result : (ushort?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{ushort}"/> type using <see cref="ushort.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static ushort? ParseToUShort(this string text, NumberStyles styles, IFormatProvider provider)
        {
            return ushort.TryParse(text, styles, provider, out ushort result) ? result : (ushort?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{ushort}"/> type using <see cref="ushort.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static ushort ParseToUShort(this string text, ushort returnValueIfError)
        {
            return ushort.TryParse(text, out ushort result) ? result : returnValueIfError;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{ushort}"/> type using <see cref="ushort.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static ushort ParseToUShort(this string text, NumberStyles styles, IFormatProvider provider, ushort returnValueIfError)
        {
            return ushort.TryParse(text, styles, provider, out ushort result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to int

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Integer}"/> type using <see cref="int.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static int? ParseToInt(this string text)
        {
            return int.TryParse(text, out int result) ? result : (int?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Integer}"/> type using <see cref="int.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static int? ParseToInt(this string text, NumberStyles styles, IFormatProvider provider)
        {
            return int.TryParse(text, styles, provider, out int result) ? result : (int?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Integer}"/> type using <see cref="int.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static int ParseToInt(this string text, int returnValueIfError)
        {
            return int.TryParse(text, out int result) ? result : returnValueIfError;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Integer}"/> type using <see cref="int.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static int ParseToInt(this string text, NumberStyles styles, IFormatProvider provider, int returnValueIfError)
        {
            return int.TryParse(text, styles, provider, out int result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to uint

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{uint}"/> type using <see cref="uint.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static uint? ParseToUInt(this string text)
        {
            return uint.TryParse(text, out uint result) ? result : (uint?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{uint}"/> type using <see cref="uint.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static uint? ParseToUInt(this string text, NumberStyles styles, IFormatProvider provider)
        {
            return uint.TryParse(text, styles, provider, out uint result) ? result : (uint?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{uint}"/> type using <see cref="uint.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static uint ParseToUInt(this string text, uint returnValueIfError)
        {
            return uint.TryParse(text, out uint result) ? result : returnValueIfError;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{uint}"/> type using <see cref="uint.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static uint ParseToUInt(this string text, NumberStyles styles, IFormatProvider provider, uint returnValueIfError)
        {
            return uint.TryParse(text, styles, provider, out uint result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to long

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Long}"/> type using <see cref="long.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static long? ParseToLong(this string text)
        {
            return long.TryParse(text, out long result) ? result : (long?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Long}"/> type using <see cref="long.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static long? ParseToLong(this string text, NumberStyles styles, IFormatProvider provider)
        {
            return long.TryParse(text, styles, provider, out long result) ? result : (long?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Long}"/> type using <see cref="long.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static long ParseToLong(this string text, long returnValueIfError)
        {
            return long.TryParse(text, out long result) ? result : returnValueIfError;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Long}"/> type using <see cref="long.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static long ParseToLong(this string text, NumberStyles styles, IFormatProvider provider, long returnValueIfError)
        {
            return long.TryParse(text, styles, provider, out long result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to ulong

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{ulong}"/> type using <see cref="ulong.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static ulong? ParseToULong(this string text)
        {
            return ulong.TryParse(text, out ulong result) ? result : (ulong?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{ulong}"/> type using <see cref="ulong.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static ulong? ParseToULong(this string text, NumberStyles styles, IFormatProvider provider)
        {
            return ulong.TryParse(text, styles, provider, out ulong result) ? result : (ulong?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{ulong}"/> type using <see cref="ulong.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static ulong ParseToULong(this string text, ulong returnValueIfError)
        {
            return ulong.TryParse(text, out ulong result) ? result : returnValueIfError;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{ulong}"/> type using <see cref="ulong.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static ulong ParseToULong(this string text, NumberStyles styles, IFormatProvider provider, ulong returnValueIfError)
        {
            return ulong.TryParse(text, styles, provider, out ulong result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to float

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Float}"/> type using <see cref="float.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static float? ParseToFloat(this string text)
        {
            return float.TryParse(text, out float result) ? result : (float?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Float}"/> type using <see cref="float.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static float? ParseToFloat(this string text, NumberStyles styles, IFormatProvider provider)
        {
            return float.TryParse(text, styles, provider, out float result) ? result : (float?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Float}"/> type using <see cref="float.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static float ParseToFloat(this string text, float returnValueIfError)
        {
            return float.TryParse(text, out float result) ? result : returnValueIfError;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Float}"/> type using <see cref="float.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static float ParseToFloat(this string text, NumberStyles styles, IFormatProvider provider, float returnValueIfError)
        {
            return float.TryParse(text, styles, provider, out float result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to double

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Double}"/> type using <see cref="double.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static double? ParseToDouble(this string text)
        {
            return double.TryParse(text, out double result) ? result : (double?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Double}"/> type using <see cref="double.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static double? ParseToDouble(this string text, NumberStyles styles, IFormatProvider provider)
        {
            return double.TryParse(text, styles, provider, out double result) ? result : (double?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Double}"/> type using <see cref="double.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static double ParseToDouble(this string text, double returnValueIfError)
        {
            return double.TryParse(text, out double result) ? result : returnValueIfError;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Double}"/> type using <see cref="double.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static double ParseToDouble(this string text, NumberStyles styles, IFormatProvider provider, double returnValueIfError)
        {
            return double.TryParse(text, styles, provider, out double result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to decimal

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Decimal}"/> type using <see cref="decimal.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static decimal? ParseToDecimal(this string text)
        {
            return decimal.TryParse(text, out decimal result) ? result : (decimal?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Decimal}"/> type using <see cref="decimal.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static decimal? ParseToDecimal(this string text, NumberStyles styles, IFormatProvider provider)
        {
            return decimal.TryParse(text, styles, provider, out decimal result) ? result : (decimal?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Decimal}"/> type using <see cref="decimal.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static decimal ParseToDecimal(this string text, decimal returnValueIfError)
        {
            return decimal.TryParse(text, out decimal result) ? result : returnValueIfError;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{Decimal}"/> type using <see cref="decimal.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static decimal ParseToDecimal(this string text, NumberStyles styles, IFormatProvider provider, decimal returnValueIfError)
        {
            return decimal.TryParse(text, styles, provider, out decimal result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to datetime

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{DateTime}"/> type using <see cref="DateTime.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static DateTime? ParseToDateTime(this string text)
        {
            return DateTime.TryParse(text, out DateTime result) ? result : (DateTime?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{DateTime}"/> type using <see cref="DateTime.TryParse"/> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static DateTime? ParseToDateTime(this string text, DateTimeStyles styles, IFormatProvider provider)
        {
            return DateTime.TryParse(text, provider, styles, out DateTime result) ? result : (DateTime?)null;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{DateTime}"/> type using <see cref="DateTime.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static DateTime ParseToDateTime(this string text, DateTime returnValueIfError)
        {
            return DateTime.TryParse(text, out DateTime result) ? result : returnValueIfError;
        }

        /// <summary>
        /// Try to convert the specified <see cref="String"/> to <see cref="Nullable{DateTime}"/> type using <see cref="DateTime.TryParse"/> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static DateTime ParseToDateTime(this string text, DateTimeStyles styles, IFormatProvider provider, DateTime returnValueIfError)
        {
            return DateTime.TryParse(text, provider, styles, out DateTime result) ? result : returnValueIfError;
        }

        #endregion
    }
}