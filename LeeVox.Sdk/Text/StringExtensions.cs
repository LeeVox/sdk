using System;
using System.Text;

namespace LeeVox.Sdk
{
    public static class StringExtensions
    {
        /// <summary>
        /// Removes all leading and trailing white-space characters from the current
        /// <c>System.String</c> object, returns <c>string.Empty</c> in case of <c>null</c>.
        /// </summary>
        /// <remarks>
        /// This is shortcut to <c>text?.Trim() ?? string.Empty</c>
        /// </remarks>
        public static string SafeTrim(this string text)
            => text?.Trim() ?? string.Empty;

        /// <summary>
        /// Removes all leading and trailing occurrences of a set of characters specified
        /// in an array from the current <c>System.String</c> object, returns <c>string.Empty</c>
        /// in case of <c>null</c>.
        /// </summary>
        /// <remarks>
        /// This is shortcut to <c>text?.Trim(trimChars) ?? string.Empty</c>
        /// </remarks>
        public static string SafeTrim(this string text, params char[] trimChars)
            => text?.Trim(trimChars) ?? string.Empty;

        /// <summary>
        /// Determines whether a <c>string</c> has same value to another <c>string</c> using <c>StringComparison.Ordinal</c>
        /// </summary>
        public static bool OrdinalEquals(this string a, string b)
            => OrdinalEquals(a, b, false);

        /// <summary>
        /// Determines whether a <c>string</c> has same value to another <c>string</c> using <c>StringComparison.Ordinal</c>
        /// </summary>
        public static bool OrdinalEquals(this string a, string b, bool ignoreCase)
            => string.Equals(a, b, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

        /// <summary>
        /// Determines whether a <c>string</c> has same value (ignore trailing and leading spaces) to another <c>string</c> using <c>StringComparison.CurrentCulture</c>
        /// </summary>
        public static bool EqualsIgnoreSpaces(this string a, string b)
            => EqualsIgnoreSpaces(a, b, StringComparison.CurrentCulture);

        /// <summary>
        /// Determines whether a <c>string</c> has same value (ignore trailing and leading spaces) to another <c>string</c> using <c>StringComparison.CurrentCulture</c>
        /// </summary>
        public static bool EqualsIgnoreSpaces(this string a, string b, bool ignoreCase)
            => EqualsIgnoreSpaces(a, b, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);

        /// <summary>
        /// Determines whether a <c>string</c> has same value (ignore trailing and leading spaces) to another <c>string</c> using a specified <c>StringComparison</c>
        /// </summary>
        public static bool EqualsIgnoreSpaces(this string a, string b, StringComparison stringComparison)
            => string.Equals(a?.Trim(), b?.Trim(), stringComparison);

        /// <summary>
        /// Determines whether a <c>string</c> has same value (ignore trailing and leading spaces) to another <c>string</c> using <c>StringComparison.Ordinal</c>
        /// </summary>
        public static bool OrdinalEqualsIgnoreSpaces(this string a, string b)
            => OrdinalEqualsIgnoreSpaces(a, b, false);

        /// <summary>
        /// Determines whether a <c>string</c> has same value (ignore trailing and leading spaces) to another <c>string</c> using <c>StringComparison.Ordinal</c>
        /// </summary>
        public static bool OrdinalEqualsIgnoreSpaces(this string a, string b, bool ignoreCase)
            => string.Equals(a?.Trim(), b?.Trim(), ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

        /// <summary>
        /// Determines whether a <c>string</c> contains another <c>string</c> using <c>StringComparison.CurrentCulture</c>
        /// </summary>
        /// <remarks>return <c>false</c> if search string is <c>null</c></returns>
        public static bool Contains(this string text, string search)
            => Contains(text, search, StringComparison.CurrentCulture);

        /// <summary>
        /// Determines whether a <c>string</c> contains another <c>string</c> using <c>StringComparison.CurrentCulture</c>
        /// </summary>
        /// <remarks>return <c>false</c> if search string is <c>null</c></returns>
        public static bool Contains(this string text, string search, bool ignoreCase)
            => Contains(text, search, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture);

        /// <summary>
        /// Determines whether a <c>string</c> contains another <c>string</c> using a specified <c>StringComparison</c>
        /// </summary>
        /// <remarks>return <c>false</c> if search string is <c>null</c></returns>
        public static bool Contains(this string text, string search, StringComparison stringComparison)
            => search != null && text?.IndexOf(search, stringComparison) >= 0;

        /// <summary>
        /// Determines whether a <c>string</c> contains another <c>string</c> using <c>StringComparison.Ordinal</c>
        /// </summary>
        /// <remarks>return <c>false</c> if search string is <c>null</c></returns>
        public static bool OrdinalContains(this string text, string search)
            => OrdinalContains(text, search, false);

        /// <summary>
        /// Determines whether a <c>string</c> contains another <c>string</c> using <c>StringComparison.Ordinal</c>
        /// </summary>
        /// <remarks>return <c>false</c> if search string is <c>null</c></returns>
        public static bool OrdinalContains(this string text, string search, bool ignoreCase)
            => search != null && text?.IndexOf(search, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal) >= 0;
    }
}