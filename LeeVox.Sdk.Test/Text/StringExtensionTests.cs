using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeeVox.Sdk.Test
{
    [TestClass]
    public class StringExtensionTests
    {
        const string US = "en-US";
        const string SE = "se-SE";

        const string NULL_STRING_1 = null;
        const string NULL_STRING_2 = null;
        const string STRING_1 = "EncycLopædia";
        const string STRING_1_UPPER = "ENCYCLOPÆDIA";
        const string STRING_1_SPACES = "\t EncycLopædia\r\n ";
        const string STRING_1_SPACES_UPPER = "\t ENCYCLOPÆDIA\r\n ";
        const string STRING_2 = "EncycLopaedia";
        const string STRING_2_LOWER = "encyclopaedia";
        const string STRING_2_SPACES = "\r\n EncycLopaedia\t ";
        const string STRING_2_SPACES_LOWER = "\r\n encyclopaedia\t ";

        static readonly char[] ALL_WHITESPACES = Enumerable.Range(0, ushort.MaxValue)
            .Where(c =>
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory((char)c);
                return unicodeCategory == UnicodeCategory.SpaceSeparator
                    || unicodeCategory == UnicodeCategory.LineSeparator
                    || unicodeCategory == UnicodeCategory.ParagraphSeparator;
            }).Select(c => Convert.ToChar(c)).ToArray();

        [TestMethod]
        public void SafeTrimTests()
        {
            string actual, expected;
            string NULL_STRING = null;
            string UNICODE_STRING = "\t Đây là Unicode.\r\n ";
            string ALL_WHITESPACES_STRING = String.Join("", ALL_WHITESPACES);
            string SAMPLE_STRING = "# Markdown header\r\n  ## xxyyyzzz";
            char[] TRIM_CHARS = new[] { '#', ' ', '\r', '\n', 'x', 'y', 'z' };

            expected = string.Empty;
            actual = NULL_STRING.SafeTrim();
            Assert.AreEqual(expected, actual, "Should returns empty string if text is null.");

            expected = string.Empty;
            actual = NULL_STRING.SafeTrim('a', 'b', 'c');
            Assert.AreEqual(expected, actual, "Should returns empty string if text is null.");

            expected = UNICODE_STRING.Trim();
            actual = UNICODE_STRING.SafeTrim();
            Assert.AreEqual(expected, actual, "Should able to trim basic whitespaces.");

            expected = ALL_WHITESPACES_STRING.Trim();
            actual = ALL_WHITESPACES_STRING.SafeTrim();
            Assert.AreEqual(expected, actual, "Should able to trim all whitespace chars.");
            // ref: https://docs.microsoft.com/en-us/dotnet/api/system.char.iswhitespace

            expected = SAMPLE_STRING.Trim(TRIM_CHARS);
            actual = SAMPLE_STRING.SafeTrim(TRIM_CHARS);
            Assert.AreEqual(expected, actual, "Should able to trim specified chars.");
        }

        [TestMethod]
        [DataRow(US, STRING_1, STRING_1_UPPER)]
        [DataRow(US, STRING_1, STRING_1_SPACES)]
        [DataRow(US, STRING_1, STRING_1_SPACES_UPPER)]
        [DataRow(US, STRING_1_SPACES, STRING_1_SPACES_UPPER)]
        [DataRow(US, STRING_2, STRING_1)]
        [DataRow(US, STRING_2_SPACES, STRING_1_UPPER)]
        [DataRow(US, STRING_2_LOWER, STRING_1_SPACES_UPPER)]
        [DataRow(US, STRING_2_SPACES_LOWER, STRING_1_SPACES_UPPER)]

        [DataRow(SE, STRING_1, STRING_1_UPPER)]
        [DataRow(SE, STRING_1, STRING_1_SPACES)]
        [DataRow(SE, STRING_1, STRING_1_SPACES_UPPER)]
        [DataRow(SE, STRING_1_SPACES, STRING_1_SPACES_UPPER)]
        [DataRow(SE, STRING_2, STRING_1)]
        [DataRow(SE, STRING_2_SPACES, STRING_1_UPPER)]
        [DataRow(SE, STRING_2_LOWER, STRING_1_SPACES_UPPER)]
        [DataRow(SE, STRING_2_SPACES_LOWER, STRING_1_SPACES_UPPER)]
        public void EqualsTests_NotNullString(string cultureName, string a, string b)
        {
            var currentCultureName = CultureInfo.CurrentCulture.Name;
            CultureInfo.CurrentCulture = new CultureInfo(cultureName);

            Assert.AreEqual(string.Equals(a, b, StringComparison.CurrentCulture), a.IsEqual(b));
            Assert.AreEqual(string.Equals(a, b, StringComparison.CurrentCulture), a.IsEqual(b, false));
            Assert.AreEqual(string.Equals(a.ToUpper(), b.ToLower(), StringComparison.CurrentCultureIgnoreCase), a.IsEqual(b, true));

            Assert.AreEqual(string.Equals(a, b, StringComparison.Ordinal), a.IsOrdinalEqual(b));
            Assert.AreEqual(string.Equals(a, b, StringComparison.Ordinal), a.IsOrdinalEqual(b, false));
            Assert.AreEqual(string.Equals(a.ToUpper(), b.ToLower(), StringComparison.OrdinalIgnoreCase), a.IsOrdinalEqual(b, true));

            Assert.AreEqual(string.Equals(a.Trim(), b.Trim(), StringComparison.CurrentCulture), a.IsEqualIgnoreSpaces(b));
            Assert.AreEqual(string.Equals(a.Trim(), b.Trim(), StringComparison.CurrentCulture), a.IsEqualIgnoreSpaces(b, false));
            Assert.AreEqual(string.Equals(a.ToUpper().Trim(), b.Trim(), StringComparison.CurrentCultureIgnoreCase), a.IsEqualIgnoreSpaces(b, true));
            Assert.AreEqual(string.Equals(a.Trim(), b.ToLower().Trim(), StringComparison.CurrentCultureIgnoreCase), a.IsEqualIgnoreSpaces(b, true));

            Assert.AreEqual(string.Equals(a.Trim(), b.Trim(), StringComparison.CurrentCulture), a.IsEqualIgnoreSpaces(b, StringComparison.CurrentCulture));
            Assert.AreEqual(string.Equals(a.ToUpper().Trim(), b.ToLower().Trim(), StringComparison.CurrentCultureIgnoreCase), a.IsEqualIgnoreSpaces(b, StringComparison.CurrentCultureIgnoreCase));
#if NETCOREAPP2_0_OR_ABOVE || NETSTANDARD2_0_OR_ABOVE
            Assert.AreEqual(string.Equals(a.Trim(), b.Trim(), StringComparison.InvariantCulture), a.IsEqualIgnoreSpaces(b, StringComparison.InvariantCulture));
            Assert.AreEqual(string.Equals(a.ToUpper().Trim(), b.ToLower().Trim(), StringComparison.InvariantCultureIgnoreCase), a.IsEqualIgnoreSpaces(b, StringComparison.InvariantCultureIgnoreCase));
#endif

            Assert.AreEqual(string.Equals(a.Trim(), b.Trim(), StringComparison.Ordinal), a.IsOrdinalEqualIgnoreSpaces(b));
            Assert.AreEqual(string.Equals(a.Trim(), b.Trim(), StringComparison.Ordinal), a.IsOrdinalEqualIgnoreSpaces(b, false));
            Assert.AreEqual(string.Equals(a.ToUpper().Trim(), b.Trim(), StringComparison.OrdinalIgnoreCase), a.IsOrdinalEqualIgnoreSpaces(b, true));
            Assert.AreEqual(string.Equals(a.Trim(), b.ToLower().Trim(), StringComparison.OrdinalIgnoreCase), a.IsOrdinalEqualIgnoreSpaces(b, true));

            CultureInfo.CurrentCulture = new CultureInfo(currentCultureName);
        }

        [TestMethod]
        [DataRow(US, NULL_STRING_1, NULL_STRING_2)]
        [DataRow(US, NULL_STRING_2, STRING_2)]
        [DataRow(US, STRING_1, NULL_STRING_1)]

        [DataRow(SE, NULL_STRING_1, NULL_STRING_2)]
        [DataRow(SE, NULL_STRING_2, STRING_2)]
        [DataRow(SE, STRING_1, NULL_STRING_1)]
        public void EqualsTests_WithNull(string cultureName, string a, string b)
        {
            var currentCultureName = CultureInfo.CurrentCulture.Name;
            CultureInfo.CurrentCulture = new CultureInfo(cultureName);

            Assert.AreEqual(string.Equals(a, b, StringComparison.CurrentCulture), a.IsEqual(b));
            Assert.AreEqual(string.Equals(a, b, StringComparison.CurrentCulture), a.IsEqual(b, false));
            Assert.AreEqual(string.Equals(a, b, StringComparison.CurrentCultureIgnoreCase), a.IsEqual(b, true));

            Assert.AreEqual(string.Equals(a, b, StringComparison.Ordinal), a.IsOrdinalEqual(b));
            Assert.AreEqual(string.Equals(a, b, StringComparison.Ordinal), a.IsOrdinalEqual(b, false));
            Assert.AreEqual(string.Equals(a, b, StringComparison.OrdinalIgnoreCase), a.IsOrdinalEqual(b, true));

            Assert.AreEqual(string.Equals(a, b, StringComparison.CurrentCulture), a.IsEqualIgnoreSpaces(b));
            Assert.AreEqual(string.Equals(a, b, StringComparison.CurrentCulture), a.IsEqualIgnoreSpaces(b, false));
            Assert.AreEqual(string.Equals(a, b, StringComparison.CurrentCulture), a.IsEqualIgnoreSpaces(b, StringComparison.CurrentCulture));
            Assert.AreEqual(string.Equals(a, b, StringComparison.CurrentCultureIgnoreCase), a.IsEqualIgnoreSpaces(b, StringComparison.CurrentCultureIgnoreCase));
#if NETCOREAPP2_0_OR_ABOVE || NETSTANDARD2_0_OR_ABOVE
            Assert.AreEqual(string.Equals(a, b, StringComparison.InvariantCulture), a.IsEqualIgnoreSpaces(b, StringComparison.InvariantCulture));
            Assert.AreEqual(string.Equals(a, b, StringComparison.InvariantCultureIgnoreCase), a.IsEqualIgnoreSpaces(b, StringComparison.InvariantCultureIgnoreCase));
#endif

            Assert.AreEqual(string.Equals(a, b, StringComparison.Ordinal), a.IsOrdinalEqualIgnoreSpaces(b));
            Assert.AreEqual(string.Equals(a, b, StringComparison.OrdinalIgnoreCase), a.IsOrdinalEqualIgnoreSpaces(b, false));

            CultureInfo.CurrentCulture = new CultureInfo(currentCultureName);
        }

        [TestMethod]
        public void ContainsTests()
        {
            var currentCultureName = CultureInfo.CurrentCulture.Name;
            CultureInfo.CurrentCulture = new CultureInfo(US);

            Assert.IsTrue(STRING_1_SPACES.Contains(STRING_1));
            Assert.IsFalse(STRING_1_SPACES.Contains(STRING_1_UPPER, false));
            Assert.AreEqual(STRING_1_SPACES.IndexOf(STRING_1_UPPER, StringComparison.CurrentCultureIgnoreCase) >= 0, STRING_1_SPACES.Contains(STRING_1_UPPER, StringComparison.CurrentCultureIgnoreCase));
#if NETCOREAPP2_0_OR_ABOVE || NETSTANDARD2_0_OR_ABOVE
            Assert.AreEqual(STRING_2_SPACES.IndexOf(STRING_2_LOWER, StringComparison.InvariantCulture) >= 0, STRING_2_SPACES.Contains(STRING_2_LOWER, StringComparison.InvariantCulture));
#endif
            Assert.IsTrue(STRING_2_SPACES.Contains(STRING_2_LOWER, true));

            Assert.IsTrue(STRING_1_SPACES.OrdinalContains(STRING_1));
            Assert.IsFalse(STRING_1_SPACES.OrdinalContains(STRING_1_UPPER, false));
            Assert.IsTrue(STRING_2_SPACES.OrdinalContains(STRING_2_LOWER, true));

            CultureInfo.CurrentCulture = new CultureInfo(SE);

            Assert.IsTrue(STRING_1_SPACES.Contains(STRING_1));
            Assert.IsFalse(STRING_1_SPACES.Contains(STRING_1_UPPER, false));
            Assert.AreEqual(STRING_2_SPACES.IndexOf(STRING_2_LOWER, StringComparison.CurrentCultureIgnoreCase) >= 0, STRING_2_SPACES.Contains(STRING_2_LOWER, StringComparison.CurrentCultureIgnoreCase));
            #if NETCOREAPP2_0_OR_ABOVE || NETSTANDARD2_0_OR_ABOVE
            Assert.AreEqual(STRING_1_SPACES.IndexOf(STRING_1_UPPER, StringComparison.InvariantCultureIgnoreCase) >= 0, STRING_1_SPACES.Contains(STRING_1_UPPER, StringComparison.InvariantCultureIgnoreCase));
#endif
            Assert.IsTrue(STRING_2_SPACES.Contains(STRING_2_LOWER, true));

            Assert.IsTrue(STRING_1_SPACES.OrdinalContains(STRING_1));
            Assert.IsFalse(STRING_1_SPACES.OrdinalContains(STRING_1_UPPER, false));
            Assert.IsTrue(STRING_2_SPACES.OrdinalContains(STRING_2_LOWER, true));

            CultureInfo.CurrentCulture = new CultureInfo(currentCultureName);
        }

        [TestMethod]
        public void ContainsTests_WithNull()
        {
            Assert.ThrowsException<NullReferenceException>(() => NULL_STRING_1.Contains(STRING_1));
            Assert.ThrowsException<NullReferenceException>(() => NULL_STRING_1.Contains(STRING_2, false));
            Assert.ThrowsException<NullReferenceException>(() => NULL_STRING_2.Contains(STRING_1, StringComparison.CurrentCulture));
            Assert.ThrowsException<NullReferenceException>(() => NULL_STRING_1.Contains(NULL_STRING_2));
            Assert.ThrowsException<NullReferenceException>(() => NULL_STRING_2.Contains(NULL_STRING_1, false));
            Assert.ThrowsException<NullReferenceException>(() => NULL_STRING_2.Contains(NULL_STRING_1, StringComparison.CurrentCultureIgnoreCase));
            Assert.ThrowsException<ArgumentNullException>(() => STRING_2.Contains(NULL_STRING_1));
            Assert.ThrowsException<ArgumentNullException>(() => STRING_1.Contains(NULL_STRING_2, true));
            Assert.ThrowsException<ArgumentNullException>(() => STRING_2.Contains(NULL_STRING_2, StringComparison.CurrentCulture));

            Assert.ThrowsException<NullReferenceException>(() => NULL_STRING_1.OrdinalContains(STRING_1));
            Assert.ThrowsException<NullReferenceException>(() => NULL_STRING_1.OrdinalContains(STRING_2, false));
            Assert.ThrowsException<NullReferenceException>(() => NULL_STRING_1.OrdinalContains(NULL_STRING_2));
            Assert.ThrowsException<NullReferenceException>(() => NULL_STRING_2.OrdinalContains(NULL_STRING_1, false));
            Assert.ThrowsException<ArgumentNullException>(() => STRING_2.OrdinalContains(NULL_STRING_1));
            Assert.ThrowsException<ArgumentNullException>(() => STRING_1.OrdinalContains(NULL_STRING_2, true));
        }

        [TestMethod]
        [DataRow(US, STRING_1, STRING_1_UPPER)]
        [DataRow(US, STRING_1, STRING_1_SPACES)]
        [DataRow(US, STRING_1, STRING_1_SPACES_UPPER)]
        [DataRow(US, STRING_1_SPACES, STRING_1_SPACES_UPPER)]
        [DataRow(US, STRING_2, STRING_1)]
        [DataRow(US, STRING_2_SPACES, STRING_1_UPPER)]
        [DataRow(US, STRING_2_LOWER, STRING_1_SPACES_UPPER)]
        [DataRow(US, STRING_2_SPACES_LOWER, STRING_1_SPACES_UPPER)]

        [DataRow(SE, STRING_1, STRING_1_UPPER)]
        [DataRow(SE, STRING_1, STRING_1_SPACES)]
        [DataRow(SE, STRING_1, STRING_1_SPACES_UPPER)]
        [DataRow(SE, STRING_1_SPACES, STRING_1_SPACES_UPPER)]
        [DataRow(SE, STRING_2, STRING_1)]
        [DataRow(SE, STRING_2_SPACES, STRING_1_UPPER)]
        [DataRow(SE, STRING_2_LOWER, STRING_1_SPACES_UPPER)]
        [DataRow(SE, STRING_2_SPACES_LOWER, STRING_1_SPACES_UPPER)]
        public void StringComparerTests(string cultureName, string left, string right)
        {
            var currentCultureName = CultureInfo.CurrentCulture.Name;
            CultureInfo.CurrentCulture = new CultureInfo(cultureName);

            Assert.AreEqual(StringComparer.Ordinal.Compare(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.Ordinal.Compare(left, right));
            Assert.AreEqual(StringComparer.Ordinal.Equals(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.Ordinal.Equals(left, right));
            Assert.AreEqual(StringComparer.Ordinal.GetHashCode(left?.Trim()), StringComparerIgnoreSpaces.Ordinal.GetHashCode(left));
            Assert.AreEqual(StringComparer.Ordinal.GetHashCode(right?.Trim()), StringComparerIgnoreSpaces.Ordinal.GetHashCode(right));

            Assert.AreEqual(StringComparer.OrdinalIgnoreCase.Compare(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.OrdinalIgnoreCase.Compare(left, right));
            Assert.AreEqual(StringComparer.OrdinalIgnoreCase.Equals(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.OrdinalIgnoreCase.Equals(left, right));
            Assert.AreEqual(StringComparer.OrdinalIgnoreCase.GetHashCode(left?.Trim()), StringComparerIgnoreSpaces.OrdinalIgnoreCase.GetHashCode(left));
            Assert.AreEqual(StringComparer.OrdinalIgnoreCase.GetHashCode(right?.Trim()), StringComparerIgnoreSpaces.OrdinalIgnoreCase.GetHashCode(right));

            Assert.AreEqual(StringComparer.CurrentCulture.Compare(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.CurrentCulture.Compare(left, right));
            Assert.AreEqual(StringComparer.CurrentCulture.Equals(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.CurrentCulture.Equals(left, right));
            Assert.AreEqual(StringComparer.CurrentCulture.GetHashCode(left?.Trim()), StringComparerIgnoreSpaces.CurrentCulture.GetHashCode(left));
            Assert.AreEqual(StringComparer.CurrentCulture.GetHashCode(right?.Trim()), StringComparerIgnoreSpaces.CurrentCulture.GetHashCode(right));

            Assert.AreEqual(StringComparer.CurrentCultureIgnoreCase.Compare(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.CurrentCultureIgnoreCase.Compare(left, right));
            Assert.AreEqual(StringComparer.CurrentCultureIgnoreCase.Equals(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.CurrentCultureIgnoreCase.Equals(left, right));
            Assert.AreEqual(StringComparer.CurrentCultureIgnoreCase.GetHashCode(left?.Trim()), StringComparerIgnoreSpaces.CurrentCultureIgnoreCase.GetHashCode(left));
            Assert.AreEqual(StringComparer.CurrentCultureIgnoreCase.GetHashCode(right?.Trim()), StringComparerIgnoreSpaces.CurrentCultureIgnoreCase.GetHashCode(right));

#if NETCOREAPP2_0_OR_ABOVE || NETSTANDARD2_0_OR_ABOVE
            Assert.AreEqual(StringComparer.InvariantCulture.Compare(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.InvariantCulture.Compare(left, right));
            Assert.AreEqual(StringComparer.InvariantCulture.Equals(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.InvariantCulture.Equals(left, right));
            Assert.AreEqual(StringComparer.InvariantCulture.GetHashCode(left?.Trim()), StringComparerIgnoreSpaces.InvariantCulture.GetHashCode(left));
            Assert.AreEqual(StringComparer.InvariantCulture.GetHashCode(right?.Trim()), StringComparerIgnoreSpaces.InvariantCulture.GetHashCode(right));

            Assert.AreEqual(StringComparer.InvariantCultureIgnoreCase.Compare(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.InvariantCultureIgnoreCase.Compare(left, right));
            Assert.AreEqual(StringComparer.InvariantCultureIgnoreCase.Equals(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.InvariantCultureIgnoreCase.Equals(left, right));
            Assert.AreEqual(StringComparer.InvariantCultureIgnoreCase.GetHashCode(left?.Trim()), StringComparerIgnoreSpaces.InvariantCultureIgnoreCase.GetHashCode(left));
            Assert.AreEqual(StringComparer.InvariantCultureIgnoreCase.GetHashCode(right?.Trim()), StringComparerIgnoreSpaces.InvariantCultureIgnoreCase.GetHashCode(right));
#endif

            CultureInfo.CurrentCulture = new CultureInfo(currentCultureName);
        }
    }
}