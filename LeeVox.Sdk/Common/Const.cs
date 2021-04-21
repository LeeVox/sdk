using System.Linq;

namespace LeeVox.Sdk
{
    internal static class Const
    {
        /// <summary>
        /// A sequence of ASCII printable characters which are greater than or equal to <c>32</c>, and less than <c>127</c>.
        /// <para>See more: <see href="https://en.wikipedia.org/wiki/ASCII#Printable_characters"/></para>
        /// </summary>
        internal static readonly char[] ASCII_CHARS = Enumerable.Range(32, 126).Select(x => (char)x).ToArray();
    }
}