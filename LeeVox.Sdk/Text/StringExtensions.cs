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
        /// This is shortcut to <c>(text ?? string.Empty).Trim()</c>
        /// </remarks>
        public static string SafeTrim(this string text)
        {
            return (text ?? string.Empty).Trim();
        }

        /// <summary>
        /// Removes all leading and trailing occurrences of a set of characters specified
        /// in an array from the current <c>System.String</c> object, returns <c>string.Empty</c>
        /// in case of <c>null</c>.
        /// </summary>
        /// <remarks>
        /// This is shortcut to <c>(text ?? string.Empty).Trim(trimChars)</c>
        /// </remarks>
        public static string SafeTrim(this string text, params char[] trimChars)
        {
            return (text ?? string.Empty).Trim(trimChars);
        }

        public static bool IsOrdinalEqual(this string x, string y)
        {
            return StringComparer.Ordinal.Compare(x, y) == 0;
        }

        public static bool IsOrdinalEqualIgnoreCase(this string x, string y)
        {
            return StringComparer.OrdinalIgnoreCase.Compare(x, y) == 0;
        }

        public static bool IsOrdinalEqualIgnoreSpaces(this string x, string y)
        {
            return StringComparerIgnoreSpaces.OrdinalIgnoreSpaces.Compare(x, y) == 0;
        }

        public static bool IsOrdinalEqualIgnoreCaseAndSpaces(this string x, string y)
        {
            return StringComparerIgnoreSpaces.OrdinalIgnoreCaseAndSpaces.Compare(x, y) == 0;
        }

        public static byte[] GetBytes(this string text)
            => GetBytes(text, Encoding.UTF8);

        public static byte[] GetBytes(this string text, byte[] returnValueIfError)
            => GetBytes(text, Encoding.UTF8, returnValueIfError);

        public static byte[] GetBytes(this string text, int charIndex, int charCount)
            => GetBytes(text, charIndex, charCount, Encoding.UTF8);

        public static byte[] GetBytes(this string text, int charIndex, int charCount, byte[] returnValueIfError)
            => GetBytes(text, charIndex, charCount, Encoding.UTF8, returnValueIfError);

        public static byte[] GetBytes(this string text, Encoding encoding)
        {
            return encoding.GetBytes(text);
        }

        public static byte[] GetBytes(this string text, Encoding encoding, byte[] returnValueIfError)
        {
            if (text == null)
            {
                return returnValueIfError;
            }
            
            try
            {
                return encoding.GetBytes(text);
            }
            catch
            {
                return returnValueIfError;
            }
        }

        public static byte[] GetBytes(this string text, int charIndex, int charCount, Encoding encoding)
        {
            var result = new byte[encoding.GetByteCount(text)];
            encoding.GetBytes(text, charIndex, charCount, result, 0);
            return result;
        }

        public static byte[] GetBytes(this string text, int charIndex, int charCount, Encoding encoding, byte[] returnValueIfError)
        {
            if (text == null)
            {
                return returnValueIfError;
            }

            try
            {
                var result = new byte[encoding.GetByteCount(text)];
                encoding.GetBytes(text, charIndex, charCount, result, 0);
                return result;
            }
            catch
            {
                return returnValueIfError;
            }
        }
    }
}