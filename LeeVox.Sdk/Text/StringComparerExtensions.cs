using System;

namespace LeeVox.Sdk
{
    public sealed class StringComparerIgnoreSpaces : StringComparer
    {
        public static readonly StringComparer OrdinalIgnoreSpaces = new StringComparerIgnoreSpaces(StringComparer.Ordinal);

        public static readonly StringComparer OrdinalIgnoreCaseAndSpaces = new StringComparerIgnoreSpaces(StringComparer.OrdinalIgnoreCase);

        public static readonly StringComparer CurrentCultureIgnoreSpaces = new StringComparerIgnoreSpaces(StringComparer.CurrentCulture);

        public static readonly StringComparer CurrentCultureIgnoreCaseAndSpaces = new StringComparerIgnoreSpaces(StringComparer.CurrentCultureIgnoreCase);

#if NETCOREAPP2_0_OR_ABOVE || NETSTANDARD2_0_OR_ABOVE
        public static readonly StringComparer InvariantCultureIgnoreSpaces = new StringComparerIgnoreSpaces(StringComparer.InvariantCulture);

        public static readonly StringComparer InvariantCultureIgnoreCaseAndSpaces = new StringComparerIgnoreSpaces(StringComparer.InvariantCultureIgnoreCase);
#endif

        private StringComparer InnerComparer { get; }

        private StringComparerIgnoreSpaces(StringComparer comparer)
        {
            InnerComparer = comparer;
        }

        public override int Compare(string x, string y)
        {
            return InnerComparer.Compare(x?.Trim(), y?.Trim());
        }

        public override bool Equals(string x, string y)
        {
            return InnerComparer.Equals(x?.Trim(), y?.Trim());
        }

        public override int GetHashCode(string obj)
        {
            return InnerComparer.GetHashCode(obj?.Trim());
        }
    }
}