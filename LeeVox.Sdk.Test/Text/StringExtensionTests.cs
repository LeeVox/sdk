using System;
using System.Globalization;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeeVox.Sdk.Test
{
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

        [Fact]
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
            actual.Should().BeEquivalentTo(expected, "Should returns empty string if text is null.");

            expected = string.Empty;
            actual = NULL_STRING.SafeTrim('a', 'b', 'c');
            actual.Should().BeEquivalentTo(expected, "Should returns empty string if text is null.");

            expected = UNICODE_STRING.Trim();
            actual = UNICODE_STRING.SafeTrim();
            actual.Should().BeEquivalentTo(expected, "Should able to trim basic whitespaces.");

            expected = ALL_WHITESPACES_STRING.Trim();
            actual = ALL_WHITESPACES_STRING.SafeTrim();
            actual.Should().BeEquivalentTo(expected, "Should able to trim all whitespace chars.");
            // ref: https://docs.microsoft.com/en-us/dotnet/api/system.char.iswhitespace

            expected = SAMPLE_STRING.Trim(TRIM_CHARS);
            actual = SAMPLE_STRING.SafeTrim(TRIM_CHARS);
            actual.Should().BeEquivalentTo(expected, "Should able to trim specified chars.");
        }

        [Theory]
        [InlineData(US, STRING_1, STRING_1_UPPER)]
        [InlineData(US, STRING_1, STRING_1_SPACES)]
        [InlineData(US, STRING_1, STRING_1_SPACES_UPPER)]
        [InlineData(US, STRING_1_SPACES, STRING_1_SPACES_UPPER)]
        [InlineData(US, STRING_2, STRING_1)]
        [InlineData(US, STRING_2_SPACES, STRING_1_UPPER)]
        [InlineData(US, STRING_2_LOWER, STRING_1_SPACES_UPPER)]
        [InlineData(US, STRING_2_SPACES_LOWER, STRING_1_SPACES_UPPER)]

        [InlineData(SE, STRING_1, STRING_1_UPPER)]
        [InlineData(SE, STRING_1, STRING_1_SPACES)]
        [InlineData(SE, STRING_1, STRING_1_SPACES_UPPER)]
        [InlineData(SE, STRING_1_SPACES, STRING_1_SPACES_UPPER)]
        [InlineData(SE, STRING_2, STRING_1)]
        [InlineData(SE, STRING_2_SPACES, STRING_1_UPPER)]
        [InlineData(SE, STRING_2_LOWER, STRING_1_SPACES_UPPER)]
        [InlineData(SE, STRING_2_SPACES_LOWER, STRING_1_SPACES_UPPER)]
        public void EqualsTests_NotNullString(string cultureName, string a, string b)
        {
            var currentCultureName = CultureInfo.CurrentCulture.Name;
            CultureInfo.CurrentCulture = new CultureInfo(cultureName);

            Assert.Equals(string.Equals(a, b, StringComparison.CurrentCulture), a.IsEqual(b));
            Assert.Equals(string.Equals(a, b, StringComparison.CurrentCulture), a.IsEqual(b, false));
            Assert.Equals(string.Equals(a.ToUpper(), b.ToLower(), StringComparison.CurrentCultureIgnoreCase), a.IsEqual(b, true));

            Assert.Equals(string.Equals(a, b, StringComparison.Ordinal), a.IsOrdinalEqual(b));
            Assert.Equals(string.Equals(a, b, StringComparison.Ordinal), a.IsOrdinalEqual(b, false));
            Assert.Equals(string.Equals(a.ToUpper(), b.ToLower(), StringComparison.OrdinalIgnoreCase), a.IsOrdinalEqual(b, true));

            Assert.Equals(string.Equals(a.Trim(), b.Trim(), StringComparison.CurrentCulture), a.IsEqualIgnoreSpaces(b));
            Assert.Equals(string.Equals(a.Trim(), b.Trim(), StringComparison.CurrentCulture), a.IsEqualIgnoreSpaces(b, false));
            Assert.Equals(string.Equals(a.ToUpper().Trim(), b.Trim(), StringComparison.CurrentCultureIgnoreCase), a.IsEqualIgnoreSpaces(b, true));
            Assert.Equals(string.Equals(a.Trim(), b.ToLower().Trim(), StringComparison.CurrentCultureIgnoreCase), a.IsEqualIgnoreSpaces(b, true));

            Assert.Equals(string.Equals(a.Trim(), b.Trim(), StringComparison.CurrentCulture), a.IsEqualIgnoreSpaces(b, StringComparison.CurrentCulture));
            Assert.Equals(string.Equals(a.ToUpper().Trim(), b.ToLower().Trim(), StringComparison.CurrentCultureIgnoreCase), a.IsEqualIgnoreSpaces(b, StringComparison.CurrentCultureIgnoreCase));
            Assert.Equals(string.Equals(a.Trim(), b.Trim(), StringComparison.InvariantCulture), a.IsEqualIgnoreSpaces(b, StringComparison.InvariantCulture));
            Assert.Equals(string.Equals(a.ToUpper().Trim(), b.ToLower().Trim(), StringComparison.InvariantCultureIgnoreCase), a.IsEqualIgnoreSpaces(b, StringComparison.InvariantCultureIgnoreCase));

            Assert.Equals(string.Equals(a.Trim(), b.Trim(), StringComparison.Ordinal), a.IsOrdinalEqualIgnoreSpaces(b));
            Assert.Equals(string.Equals(a.Trim(), b.Trim(), StringComparison.Ordinal), a.IsOrdinalEqualIgnoreSpaces(b, false));
            Assert.Equals(string.Equals(a.ToUpper().Trim(), b.Trim(), StringComparison.OrdinalIgnoreCase), a.IsOrdinalEqualIgnoreSpaces(b, true));
            Assert.Equals(string.Equals(a.Trim(), b.ToLower().Trim(), StringComparison.OrdinalIgnoreCase), a.IsOrdinalEqualIgnoreSpaces(b, true));

            CultureInfo.CurrentCulture = new CultureInfo(currentCultureName);
        }

        [Theory]
        [InlineData(US, NULL_STRING_1, NULL_STRING_2)]
        [InlineData(US, NULL_STRING_2, STRING_2)]
        [InlineData(US, STRING_1, NULL_STRING_1)]

        [InlineData(SE, NULL_STRING_1, NULL_STRING_2)]
        [InlineData(SE, NULL_STRING_2, STRING_2)]
        [InlineData(SE, STRING_1, NULL_STRING_1)]
        public void EqualsTests_WithNull(string cultureName, string a, string b)
        {
            var currentCultureName = CultureInfo.CurrentCulture.Name;
            CultureInfo.CurrentCulture = new CultureInfo(cultureName);

            Assert.Equals(string.Equals(a, b, StringComparison.CurrentCulture), a.IsEqual(b));
            Assert.Equals(string.Equals(a, b, StringComparison.CurrentCulture), a.IsEqual(b, false));
            Assert.Equals(string.Equals(a, b, StringComparison.CurrentCultureIgnoreCase), a.IsEqual(b, true));

            Assert.Equals(string.Equals(a, b, StringComparison.Ordinal), a.IsOrdinalEqual(b));
            Assert.Equals(string.Equals(a, b, StringComparison.Ordinal), a.IsOrdinalEqual(b, false));
            Assert.Equals(string.Equals(a, b, StringComparison.OrdinalIgnoreCase), a.IsOrdinalEqual(b, true));

            Assert.Equals(string.Equals(a, b, StringComparison.CurrentCulture), a.IsEqualIgnoreSpaces(b));
            Assert.Equals(string.Equals(a, b, StringComparison.CurrentCulture), a.IsEqualIgnoreSpaces(b, false));
            Assert.Equals(string.Equals(a, b, StringComparison.CurrentCulture), a.IsEqualIgnoreSpaces(b, StringComparison.CurrentCulture));
            Assert.Equals(string.Equals(a, b, StringComparison.CurrentCultureIgnoreCase), a.IsEqualIgnoreSpaces(b, StringComparison.CurrentCultureIgnoreCase));
            Assert.Equals(string.Equals(a, b, StringComparison.InvariantCulture), a.IsEqualIgnoreSpaces(b, StringComparison.InvariantCulture));
            Assert.Equals(string.Equals(a, b, StringComparison.InvariantCultureIgnoreCase), a.IsEqualIgnoreSpaces(b, StringComparison.InvariantCultureIgnoreCase));

            Assert.Equals(string.Equals(a, b, StringComparison.Ordinal), a.IsOrdinalEqualIgnoreSpaces(b));
            Assert.Equals(string.Equals(a, b, StringComparison.OrdinalIgnoreCase), a.IsOrdinalEqualIgnoreSpaces(b, false));

            CultureInfo.CurrentCulture = new CultureInfo(currentCultureName);
        }

        [Fact]
        public void ContainsTests()
        {
            var currentCultureName = CultureInfo.CurrentCulture.Name;
            CultureInfo.CurrentCulture = new CultureInfo(US);

            Assert.True(STRING_1_SPACES.Contains(STRING_1));
            Assert.False(STRING_1_SPACES.Contains(STRING_1_UPPER, false));
            Assert.Equals(STRING_1_SPACES.IndexOf(STRING_1_UPPER, StringComparison.CurrentCultureIgnoreCase) >= 0, STRING_1_SPACES.Contains(STRING_1_UPPER, StringComparison.CurrentCultureIgnoreCase));
            Assert.Equals(STRING_2_SPACES.IndexOf(STRING_2_LOWER, StringComparison.InvariantCulture) >= 0, STRING_2_SPACES.Contains(STRING_2_LOWER, StringComparison.InvariantCulture));
            Assert.True(STRING_2_SPACES.Contains(STRING_2_LOWER, true));

            Assert.True(STRING_1_SPACES.OrdinalContains(STRING_1));
            Assert.False(STRING_1_SPACES.OrdinalContains(STRING_1_UPPER, false));
            Assert.True(STRING_2_SPACES.OrdinalContains(STRING_2_LOWER, true));

            CultureInfo.CurrentCulture = new CultureInfo(SE);

            Assert.True(STRING_1_SPACES.Contains(STRING_1));
            Assert.False(STRING_1_SPACES.Contains(STRING_1_UPPER, false));
            Assert.Equals(STRING_2_SPACES.IndexOf(STRING_2_LOWER, StringComparison.CurrentCultureIgnoreCase) >= 0, STRING_2_SPACES.Contains(STRING_2_LOWER, StringComparison.CurrentCultureIgnoreCase));
            Assert.Equals(STRING_1_SPACES.IndexOf(STRING_1_UPPER, StringComparison.InvariantCultureIgnoreCase) >= 0, STRING_1_SPACES.Contains(STRING_1_UPPER, StringComparison.InvariantCultureIgnoreCase));
            Assert.True(STRING_2_SPACES.Contains(STRING_2_LOWER, true));

            Assert.True(STRING_1_SPACES.OrdinalContains(STRING_1));
            Assert.False(STRING_1_SPACES.OrdinalContains(STRING_1_UPPER, false));
            Assert.True(STRING_2_SPACES.OrdinalContains(STRING_2_LOWER, true));

            CultureInfo.CurrentCulture = new CultureInfo(currentCultureName);
        }

        [Fact]
        public void ContainsTests_WithNull()
        {
            this.Invoking(_ => NULL_STRING_1.Contains(STRING_1)).Should().Throw<NullReferenceException>();
            this.Invoking(_ => NULL_STRING_1.Contains(STRING_2, false)).Should().Throw<NullReferenceException>();
            this.Invoking(_ => NULL_STRING_2.Contains(STRING_1, StringComparison.CurrentCulture)).Should().Throw<NullReferenceException>();
            this.Invoking(_ => NULL_STRING_1.Contains(NULL_STRING_2)).Should().Throw<NullReferenceException>();
            this.Invoking(_ => NULL_STRING_2.Contains(NULL_STRING_1, false)).Should().Throw<NullReferenceException>();
            this.Invoking(_ => NULL_STRING_2.Contains(NULL_STRING_1, StringComparison.CurrentCultureIgnoreCase)).Should().Throw<NullReferenceException>();
            this.Invoking(_ => STRING_2.Contains(NULL_STRING_1)).Should().Throw<ArgumentNullException>();
            this.Invoking(_ => STRING_1.Contains(NULL_STRING_2, true)).Should().Throw<ArgumentNullException>();
            this.Invoking(_ => STRING_2.Contains(NULL_STRING_2, StringComparison.CurrentCulture)).Should().Throw<ArgumentNullException>();

            this.Invoking(_ => NULL_STRING_1.OrdinalContains(STRING_1)).Should().Throw<NullReferenceException>();
            this.Invoking(_ => NULL_STRING_1.OrdinalContains(STRING_2, false)).Should().Throw<NullReferenceException>();
            this.Invoking(_ => NULL_STRING_1.OrdinalContains(NULL_STRING_2)).Should().Throw<NullReferenceException>();
            this.Invoking(_ => NULL_STRING_2.OrdinalContains(NULL_STRING_1, false)).Should().Throw<NullReferenceException>();
            this.Invoking(_ => STRING_2.OrdinalContains(NULL_STRING_1)).Should().Throw<ArgumentNullException>();
            this.Invoking(_ => STRING_1.OrdinalContains(NULL_STRING_2, true)).Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(US, STRING_1, STRING_1_UPPER)]
        [InlineData(US, STRING_1, STRING_1_SPACES)]
        [InlineData(US, STRING_1, STRING_1_SPACES_UPPER)]
        [InlineData(US, STRING_1_SPACES, STRING_1_SPACES_UPPER)]
        [InlineData(US, STRING_2, STRING_1)]
        [InlineData(US, STRING_2_SPACES, STRING_1_UPPER)]
        [InlineData(US, STRING_2_LOWER, STRING_1_SPACES_UPPER)]
        [InlineData(US, STRING_2_SPACES_LOWER, STRING_1_SPACES_UPPER)]

        [InlineData(SE, STRING_1, STRING_1_UPPER)]
        [InlineData(SE, STRING_1, STRING_1_SPACES)]
        [InlineData(SE, STRING_1, STRING_1_SPACES_UPPER)]
        [InlineData(SE, STRING_1_SPACES, STRING_1_SPACES_UPPER)]
        [InlineData(SE, STRING_2, STRING_1)]
        [InlineData(SE, STRING_2_SPACES, STRING_1_UPPER)]
        [InlineData(SE, STRING_2_LOWER, STRING_1_SPACES_UPPER)]
        [InlineData(SE, STRING_2_SPACES_LOWER, STRING_1_SPACES_UPPER)]
        public void StringComparerTests(string cultureName, string left, string right)
        {
            var currentCultureName = CultureInfo.CurrentCulture.Name;
            CultureInfo.CurrentCulture = new CultureInfo(cultureName);

            Assert.Equals(StringComparer.Ordinal.Compare(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.Ordinal.Compare(left, right));
            Assert.Equals(StringComparer.Ordinal.Equals(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.Ordinal.Equals(left, right));
            Assert.Equals(StringComparer.Ordinal.GetHashCode(left?.Trim()), StringComparerIgnoreSpaces.Ordinal.GetHashCode(left));
            Assert.Equals(StringComparer.Ordinal.GetHashCode(right?.Trim()), StringComparerIgnoreSpaces.Ordinal.GetHashCode(right));

            Assert.Equals(StringComparer.OrdinalIgnoreCase.Compare(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.OrdinalIgnoreCase.Compare(left, right));
            Assert.Equals(StringComparer.OrdinalIgnoreCase.Equals(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.OrdinalIgnoreCase.Equals(left, right));
            Assert.Equals(StringComparer.OrdinalIgnoreCase.GetHashCode(left?.Trim()), StringComparerIgnoreSpaces.OrdinalIgnoreCase.GetHashCode(left));
            Assert.Equals(StringComparer.OrdinalIgnoreCase.GetHashCode(right?.Trim()), StringComparerIgnoreSpaces.OrdinalIgnoreCase.GetHashCode(right));

            Assert.Equals(StringComparer.CurrentCulture.Compare(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.CurrentCulture.Compare(left, right));
            Assert.Equals(StringComparer.CurrentCulture.Equals(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.CurrentCulture.Equals(left, right));
            Assert.Equals(StringComparer.CurrentCulture.GetHashCode(left?.Trim()), StringComparerIgnoreSpaces.CurrentCulture.GetHashCode(left));
            Assert.Equals(StringComparer.CurrentCulture.GetHashCode(right?.Trim()), StringComparerIgnoreSpaces.CurrentCulture.GetHashCode(right));

            Assert.Equals(StringComparer.CurrentCultureIgnoreCase.Compare(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.CurrentCultureIgnoreCase.Compare(left, right));
            Assert.Equals(StringComparer.CurrentCultureIgnoreCase.Equals(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.CurrentCultureIgnoreCase.Equals(left, right));
            Assert.Equals(StringComparer.CurrentCultureIgnoreCase.GetHashCode(left?.Trim()), StringComparerIgnoreSpaces.CurrentCultureIgnoreCase.GetHashCode(left));
            Assert.Equals(StringComparer.CurrentCultureIgnoreCase.GetHashCode(right?.Trim()), StringComparerIgnoreSpaces.CurrentCultureIgnoreCase.GetHashCode(right));

            Assert.Equals(StringComparer.InvariantCulture.Compare(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.InvariantCulture.Compare(left, right));
            Assert.Equals(StringComparer.InvariantCulture.Equals(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.InvariantCulture.Equals(left, right));
            Assert.Equals(StringComparer.InvariantCulture.GetHashCode(left?.Trim()), StringComparerIgnoreSpaces.InvariantCulture.GetHashCode(left));
            Assert.Equals(StringComparer.InvariantCulture.GetHashCode(right?.Trim()), StringComparerIgnoreSpaces.InvariantCulture.GetHashCode(right));

            Assert.Equals(StringComparer.InvariantCultureIgnoreCase.Compare(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.InvariantCultureIgnoreCase.Compare(left, right));
            Assert.Equals(StringComparer.InvariantCultureIgnoreCase.Equals(left?.Trim(), right?.Trim()), StringComparerIgnoreSpaces.InvariantCultureIgnoreCase.Equals(left, right));
            Assert.Equals(StringComparer.InvariantCultureIgnoreCase.GetHashCode(left?.Trim()), StringComparerIgnoreSpaces.InvariantCultureIgnoreCase.GetHashCode(left));
            Assert.Equals(StringComparer.InvariantCultureIgnoreCase.GetHashCode(right?.Trim()), StringComparerIgnoreSpaces.InvariantCultureIgnoreCase.GetHashCode(right));

            CultureInfo.CurrentCulture = new CultureInfo(currentCultureName);
        }
    }
}