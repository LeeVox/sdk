using System.Linq;

namespace LeeVox.Sdk
{
    internal static class Const
    {
        internal const sbyte BYTE_TO_NON_NEGATIVE_SBYTE_MASK   = 0b01111111;
        internal const short USHORT_TO_NON_NEGATIVE_SHORT_MASK = 0b01111111_11111111;
        internal const int   UINT_TO_NON_NEGATIVE_INT_MASK     = 0b01111111_11111111_11111111_11111111;
        internal const long  ULONG_TO_NON_NEGATIVE_LONG_MASK   = 0b01111111_11111111_11111111_11111111_11111111_11111111_11111111_11111111;

        internal const char ASCII_CHAR_MIN = (char)32;
        internal const char ASCII_CHAR_MAX = (char)127;

        /// <summary>
        /// A sequence of ASCII printable characters which are greater than or equal to <c>32</c>, and less than <c>127</c>.
        /// <para>See more: <see href="https://en.wikipedia.org/wiki/ASCII#Printable_characters"/></para>
        /// </summary>
        internal static readonly char[] ASCII_CHARS = Enumerable.Range(ASCII_CHAR_MIN, ASCII_CHAR_MAX - ASCII_CHAR_MIN).Select(x => (char)x).ToArray();
    }
}