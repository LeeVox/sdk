using System;

namespace LeeVox.Sdk
{
    public sealed class StringComparerIgnoreSpaces
    {
        /// <summary>
        /// Gets a <see cref="StringComparer"/> object that performs a case-sensitive ordinal string comparison
        /// and ignores trailing + leading white spaces.
        /// </summary>
        public static StringComparer Ordinal
        {
            // always create new instance to make it thread-safe
            get => new IgnoreSpacesComparer(StringComparer.Ordinal);
        }

        /// <summary>
        /// Gets a <see cref="StringComparer"/> object that performs a case-insensitive ordinal string comparison
        /// and ignores trailing + leading white spaces.
        /// </summary>
        public static StringComparer OrdinalIgnoreCase
        {
            // always create new instance to make it thread-safe
            get => new IgnoreSpacesComparer(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Gets a <see cref="StringComparer"/> object that performs a case-sensitive string comparison
        /// using the word comparison rules of the current culture and ignores trailing + leading whitespaces.
        /// </summary>
        public static StringComparer CurrentCulture
        {
            // always create new instance to make it thread-safe
            get => new IgnoreSpacesComparer(StringComparer.CurrentCulture);
        }

        /// <summary>
        /// Gets a <see cref="StringComparer"/> object that performs a case-insensitive string comparison
        /// using the word comparison rules of the current culture and ignores trailing + leading whitespaces.
        /// </summary>
        public static StringComparer CurrentCultureIgnoreCase
        {
            // always create new instance to make it thread-safe
            get => new IgnoreSpacesComparer(StringComparer.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Gets a <see cref="StringComparer"/> object that performs a case-sensitive string comparison
        /// using the word comparison rules of the invariant culture and ignores trailing + leading whitespaces.
        /// </summary>
        public static StringComparer InvariantCulture
        {
            // always create new instance to make it thread-safe
            get => new IgnoreSpacesComparer(StringComparer.InvariantCulture);
        }

        /// <summary>
        /// Gets a <see cref="StringComparer"/> object that performs a case-insensitive string comparison
        /// using the word comparison rules of the invariant culture and ignores trailing + leading whitespaces.
        /// </summary>
        public static StringComparer InvariantCultureIgnoreCase
        {
            // always create new instance to make it thread-safe
            get => new IgnoreSpacesComparer(StringComparer.InvariantCultureIgnoreCase);
        }

        internal sealed class IgnoreSpacesComparer : StringComparer
        {
            internal StringComparer InnerComparer { get; }

            internal IgnoreSpacesComparer(StringComparer comparer)
            {
                InnerComparer = comparer;
            }

            /// <summary>
            /// When overridden in a derived class, compares two strings and returns an indication of their relative sort order.
            /// </summary>
            public override int Compare(string x, string y)
            {
                return InnerComparer.Compare(x?.Trim(), y?.Trim());
            }

            /// <summary>
            /// When overridden in a derived class, indicates whether two strings are equal.
            /// </summary>
            public override bool Equals(string x, string y)
            {
                return InnerComparer.Equals(x?.Trim(), y?.Trim());
            }

            /// <summary>
            /// When overridden in a derived class, gets the hash code for the specified string.
            /// </summary>
            public override int GetHashCode(string obj)
            {
                return InnerComparer.GetHashCode(obj?.Trim());
            }
        }
    }
}