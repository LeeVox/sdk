using System;
using System.Globalization;

namespace LeeVox.Sdk
{
    public static class StringParseExtensions
    {
        #region generic parsing

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

        public static TResult ParseTo<TResult>(this string text, TResult returnValueIfError, IFormatProvider provider)
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

        public static bool? ParseToBoolean(this string text)
        {
            return bool.TryParse(text, out bool result) ? result : (bool?)null;
        }

        public static bool ParseToBoolean(this string text, bool returnValueIfError)
        {
            return bool.TryParse(text, out bool result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to byte

        public static byte? ParseToByte(this string text)
        {
            return byte.TryParse(text, out byte result) ? result : (byte?)null;
        }

        public static byte? ParseToByte(this string text, NumberStyles style, IFormatProvider provider)
        {
            return byte.TryParse(text, style, provider, out byte result) ? result : (byte?)null;
        }

        public static byte ParseToByte(this string text, byte returnValueIfError)
        {
            return byte.TryParse(text, out byte result) ? result : returnValueIfError;
        }

        public static byte ParseToByte(this string text, NumberStyles style, IFormatProvider provider, byte returnValueIfError)
        {
            return byte.TryParse(text, style, provider, out byte result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to int

        public static int? ParseToInt(this string text)
        {
            return int.TryParse(text, out int result) ? result : (int?)null;
        }

        public static int? ParseToInt(this string text, NumberStyles style, IFormatProvider provider)
        {
            return int.TryParse(text, style, provider, out int result) ? result : (int?)null;
        }

        public static int ParseToInt(this string text, int returnValueIfError)
        {
            return int.TryParse(text, out int result) ? result : returnValueIfError;
        }

        public static int ParseToInt(this string text, NumberStyles style, IFormatProvider provider, int returnValueIfError)
        {
            return int.TryParse(text, style, provider, out int result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to long

        public static long? ParseToLong(this string text)
        {
            return long.TryParse(text, out long result) ? result : (long?)null;
        }

        public static long? ParseToLong(this string text, NumberStyles style, IFormatProvider provider)
        {
            return long.TryParse(text, style, provider, out long result) ? result : (long?)null;
        }

        public static long ParseToLong(this string text, long returnValueIfError)
        {
            return long.TryParse(text, out long result) ? result : returnValueIfError;
        }

        public static long ParseToLong(this string text, NumberStyles style, IFormatProvider provider, long returnValueIfError)
        {
            return long.TryParse(text, style, provider, out long result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to float

        public static float? ParseToFloat(this string text)
        {
            return float.TryParse(text, out float result) ? result : (float?)null;
        }

        public static float? ParseToFloat(this string text, NumberStyles style, IFormatProvider provider)
        {
            return float.TryParse(text, style, provider, out float result) ? result : (float?)null;
        }

        public static float ParseToFloat(this string text, float returnValueIfError)
        {
            return float.TryParse(text, out float result) ? result : returnValueIfError;
        }

        public static float ParseToFloat(this string text, NumberStyles style, IFormatProvider provider, float returnValueIfError)
        {
            return float.TryParse(text, style, provider, out float result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to double

        public static double? ParseToDouble(this string text)
        {
            return double.TryParse(text, out double result) ? result : (double?)null;
        }

        public static double? ParseToDouble(this string text, NumberStyles style, IFormatProvider provider)
        {
            return double.TryParse(text, style, provider, out double result) ? result : (double?)null;
        }

        public static double ParseToDouble(this string text, double returnValueIfError)
        {
            return double.TryParse(text, out double result) ? result : returnValueIfError;
        }

        public static double ParseToDouble(this string text, NumberStyles style, IFormatProvider provider, double returnValueIfError)
        {
            return double.TryParse(text, style, provider, out double result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to decimal

        public static decimal? ParseToDecimal(this string text)
        {
            return decimal.TryParse(text, out decimal result) ? result : (decimal?)null;
        }

        public static decimal? ParseToDecimal(this string text, NumberStyles style, IFormatProvider provider)
        {
            return decimal.TryParse(text, style, provider, out decimal result) ? result : (decimal?)null;
        }

        public static decimal ParseToDecimal(this string text, decimal returnValueIfError)
        {
            return decimal.TryParse(text, out decimal result) ? result : returnValueIfError;
        }

        public static decimal ParseToDecimal(this string text, NumberStyles style, IFormatProvider provider, decimal returnValueIfError)
        {
            return decimal.TryParse(text, style, provider, out decimal result) ? result : returnValueIfError;
        }

        #endregion

        #region parse to datetime

        public static DateTime? ParseToDateTime(this string text)
        {
            return DateTime.TryParse(text, out DateTime result) ? result : (DateTime?)null;
        }

        public static DateTime? ParseToDateTime(this string text, IFormatProvider provider, DateTimeStyles styles)
        {
            return DateTime.TryParse(text, provider, styles, out DateTime result) ? result : (DateTime?)null;
        }

        public static DateTime ParseToDateTime(this string text, DateTime returnValueIfError)
        {
            return DateTime.TryParse(text, out DateTime result) ? result : returnValueIfError;
        }

        public static DateTime ParseToDateTime(this string text, IFormatProvider provider, DateTimeStyles styles, DateTime returnValueIfError)
        {
            return DateTime.TryParse(text, provider, styles, out DateTime result) ? result : returnValueIfError;
        }

        #endregion
    }
}