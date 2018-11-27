using System;
using System.Globalization;

namespace LeeVox.Sdk
{
    public static class StringParseExtensions
    {
        #region generic parsing

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<TResult></c> type using <c>Convert.ChangeType</c> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static TResult? ParseTo<TResult>(this string text)
            where TResult : struct
#if NETCOREAPP || NETSTANDARD1_3_OR_ABOVE
            , IConvertible
#endif
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
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<TResult></c> type using <c>Convert.ChangeType</c> function and a <c>FormatProvider</c>.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static TResult? ParseTo<TResult>(this string text, IFormatProvider provider)
            where TResult : struct
#if NETCOREAPP || NETSTANDARD1_3_OR_ABOVE
            , IConvertible
#endif
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
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<TResult></c> type using <c>Convert.ChangeType</c> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static TResult ParseTo<TResult>(this string text, TResult returnValueIfError)
            where TResult : struct
#if NETCOREAPP || NETSTANDARD1_3_OR_ABOVE
            , IConvertible
#endif
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
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<TResult></c> type using <c>Convert.ChangeType</c> function and a <c>FormatProvider</c>.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static TResult ParseTo<TResult>(this string text, IFormatProvider provider, TResult returnValueIfError)
            where TResult : struct
#if NETCOREAPP || NETSTANDARD1_3_OR_ABOVE
            , IConvertible
#endif
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
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Boolean></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static bool? ParseToBoolean(this string text)
        {
            return bool.TryParse(text, out bool result) ? result : (bool?)null;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Boolean></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static bool ParseToBoolean(this string text, bool returnValueIfError)
        {
            return bool.TryParse(text, out bool result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to byte

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Byte></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static byte? ParseToByte(this string text)
        {
            return byte.TryParse(text, out byte result) ? result : (byte?)null;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Byte></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static byte? ParseToByte(this string text, NumberStyles styles, IFormatProvider provider)
        {
            return byte.TryParse(text, styles, provider, out byte result) ? result : (byte?)null;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Byte></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static byte ParseToByte(this string text, byte returnValueIfError)
        {
            return byte.TryParse(text, out byte result) ? result : returnValueIfError;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Byte></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static byte ParseToByte(this string text, NumberStyles styles, IFormatProvider provider, byte returnValueIfError)
        {
            return byte.TryParse(text, styles, provider, out byte result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to int

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Integer></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static int? ParseToInt(this string text)
        {
            return int.TryParse(text, out int result) ? result : (int?)null;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Integer></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static int? ParseToInt(this string text, NumberStyles styles, IFormatProvider provider)
        {
            return int.TryParse(text, styles, provider, out int result) ? result : (int?)null;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Integer></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static int ParseToInt(this string text, int returnValueIfError)
        {
            return int.TryParse(text, out int result) ? result : returnValueIfError;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Integer></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static int ParseToInt(this string text, NumberStyles styles, IFormatProvider provider, int returnValueIfError)
        {
            return int.TryParse(text, styles, provider, out int result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to long

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Long></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static long? ParseToLong(this string text)
        {
            return long.TryParse(text, out long result) ? result : (long?)null;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Long></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static long? ParseToLong(this string text, NumberStyles styles, IFormatProvider provider)
        {
            return long.TryParse(text, styles, provider, out long result) ? result : (long?)null;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Long></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static long ParseToLong(this string text, long returnValueIfError)
        {
            return long.TryParse(text, out long result) ? result : returnValueIfError;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Long></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static long ParseToLong(this string text, NumberStyles styles, IFormatProvider provider, long returnValueIfError)
        {
            return long.TryParse(text, styles, provider, out long result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to float

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Float></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static float? ParseToFloat(this string text)
        {
            return float.TryParse(text, out float result) ? result : (float?)null;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Float></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static float? ParseToFloat(this string text, NumberStyles styles, IFormatProvider provider)
        {
            return float.TryParse(text, styles, provider, out float result) ? result : (float?)null;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Float></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static float ParseToFloat(this string text, float returnValueIfError)
        {
            return float.TryParse(text, out float result) ? result : returnValueIfError;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Float></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static float ParseToFloat(this string text, NumberStyles styles, IFormatProvider provider, float returnValueIfError)
        {
            return float.TryParse(text, styles, provider, out float result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to double

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Double></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static double? ParseToDouble(this string text)
        {
            return double.TryParse(text, out double result) ? result : (double?)null;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Double></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static double? ParseToDouble(this string text, NumberStyles styles, IFormatProvider provider)
        {
            return double.TryParse(text, styles, provider, out double result) ? result : (double?)null;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Double></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static double ParseToDouble(this string text, double returnValueIfError)
        {
            return double.TryParse(text, out double result) ? result : returnValueIfError;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Double></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static double ParseToDouble(this string text, NumberStyles styles, IFormatProvider provider, double returnValueIfError)
        {
            return double.TryParse(text, styles, provider, out double result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to decimal

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Decimal></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static decimal? ParseToDecimal(this string text)
        {
            return decimal.TryParse(text, out decimal result) ? result : (decimal?)null;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Decimal></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static decimal? ParseToDecimal(this string text, NumberStyles styles, IFormatProvider provider)
        {
            return decimal.TryParse(text, styles, provider, out decimal result) ? result : (decimal?)null;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Decimal></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static decimal ParseToDecimal(this string text, decimal returnValueIfError)
        {
            return decimal.TryParse(text, out decimal result) ? result : returnValueIfError;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<Decimal></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static decimal ParseToDecimal(this string text, NumberStyles styles, IFormatProvider provider, decimal returnValueIfError)
        {
            return decimal.TryParse(text, styles, provider, out decimal result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to datetime

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<DateTime></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static DateTime? ParseToDateTime(this string text)
        {
            return DateTime.TryParse(text, out DateTime result) ? result : (DateTime?)null;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<DateTime></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <remarks>returns <c>null</c> if the conversion fails.</remarks>
        public static DateTime? ParseToDateTime(this string text, DateTimeStyles styles, IFormatProvider provider)
        {
            return DateTime.TryParse(text, provider, styles, out DateTime result) ? result : (DateTime?)null;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<DateTime></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static DateTime ParseToDateTime(this string text, DateTime returnValueIfError)
        {
            return DateTime.TryParse(text, out DateTime result) ? result : returnValueIfError;
        }

        /// <summary>
        /// Try to convert the specified <c>System.String</c> to <c>Nullable<DateTime></c> type using <c>TryParse</c> function.
        /// </summary>
        /// <param name="returnValueIfError">returns value if cannot convert</param>
        public static DateTime ParseToDateTime(this string text, DateTimeStyles styles, IFormatProvider provider, DateTime returnValueIfError)
        {
            return DateTime.TryParse(text, provider, styles, out DateTime result) ? result : returnValueIfError;
        }

        #endregion
    }
}