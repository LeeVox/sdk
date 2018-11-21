using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using LeeVox.Sdk;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeeVox.Sdk.Test
{
    [TestClass]
    public class StringExtensionTests
    {
        static readonly string STRING_1 = "encyclopædia";
        static  readonly string STRING_1_UPPER = STRING_1.ToUpper();
        static  readonly string STRING_1_SPACES = $"\t {STRING_1}\r\n ";
        static  readonly string STRING_1_SPACES_UPPER = STRING_1_SPACES.ToUpper();
        static  readonly string STRING_2 = "encyclopaedia";
        static  readonly string STRING_2_UPPER = STRING_2.ToUpper();
        static  readonly string STRING_2_SPACES = $"\r\n {STRING_2}\t ";
        static  readonly string STRING_2_SPACES_UPPER = STRING_2_SPACES.ToUpper();

        static readonly char[] ALL_WHITESPACES = Enumerable.Range(0, ushort.MaxValue)
            .Where(c => {
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
            char[] TRIM_CHARS = new [] {'#', ' ', '\r', '\n', 'x', 'y', 'z'};

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
        public void EqualsTests_se_SE()
        {
            var currentCultureName = CultureInfo.CurrentCulture.Name;
            CultureInfo.CurrentCulture = new CultureInfo("se-SE");

            Assert.IsFalse(STRING_1.OrdinalEquals(STRING_2));
            Assert.IsFalse(STRING_1.OrdinalEquals(STRING_1_UPPER));
            Assert.IsTrue(STRING_1_UPPER.OrdinalEquals(STRING_1, true));
            Assert.IsFalse(STRING_1.OrdinalEquals(STRING_2_UPPER, true));

            Assert.IsTrue(STRING_1.EqualsIgnoreSpaces(STRING_1_SPACES));
            Assert.IsFalse(STRING_1.EqualsIgnoreSpaces(STRING_2));
            Assert.IsFalse(STRING_1_SPACES.EqualsIgnoreSpaces(STRING_2));
            Assert.IsFalse(STRING_1.EqualsIgnoreSpaces(STRING_2_SPACES));
            Assert.IsFalse(STRING_1_SPACES.EqualsIgnoreSpaces(STRING_2_SPACES));

            Assert.IsTrue(STRING_1.EqualsIgnoreSpaces(STRING_1_SPACES_UPPER, true));
            Assert.IsFalse(STRING_1_SPACES.EqualsIgnoreSpaces(STRING_2_UPPER, true));
            Assert.IsFalse(STRING_1_SPACES_UPPER.EqualsIgnoreSpaces(STRING_2, true));
            Assert.IsFalse(STRING_1_UPPER.EqualsIgnoreSpaces(STRING_2_SPACES, true));
            Assert.IsFalse(STRING_1_SPACES.EqualsIgnoreSpaces(STRING_2_SPACES_UPPER, true));

            Assert.IsTrue(STRING_1.OrdinalEqualsIgnoreSpaces(STRING_1_SPACES));
            Assert.IsFalse(STRING_1.OrdinalEqualsIgnoreSpaces(STRING_2));
            Assert.IsFalse(STRING_1_SPACES.OrdinalEqualsIgnoreSpaces(STRING_2));
            Assert.IsFalse(STRING_1.OrdinalEqualsIgnoreSpaces(STRING_2_SPACES));
            Assert.IsFalse(STRING_1_SPACES.OrdinalEqualsIgnoreSpaces(STRING_2_SPACES));

            Assert.IsTrue(STRING_1.OrdinalEqualsIgnoreSpaces(STRING_1_SPACES_UPPER, true));
            Assert.IsFalse(STRING_1_SPACES.OrdinalEqualsIgnoreSpaces(STRING_2_UPPER, true));
            Assert.IsFalse(STRING_1_SPACES_UPPER.OrdinalEqualsIgnoreSpaces(STRING_2, true));
            Assert.IsFalse(STRING_1_UPPER.OrdinalEqualsIgnoreSpaces(STRING_2_SPACES, true));
            Assert.IsFalse(STRING_1_SPACES.OrdinalEqualsIgnoreSpaces(STRING_2_SPACES_UPPER, true));

            CultureInfo.CurrentCulture = new CultureInfo(currentCultureName);
        }

        [TestMethod]
        public void EqualsTests_en_US()
        {
            var currentCultureName = CultureInfo.CurrentCulture.Name;
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            Assert.IsFalse(STRING_1.OrdinalEquals(STRING_2));
            Assert.IsFalse(STRING_1.OrdinalEquals(STRING_1_UPPER));
            Assert.IsTrue(STRING_1_UPPER.OrdinalEquals(STRING_1, true));
            Assert.IsFalse(STRING_1.OrdinalEquals(STRING_2_UPPER, true));

            Assert.IsTrue(STRING_1.EqualsIgnoreSpaces(STRING_1_SPACES));
            Assert.IsTrue(STRING_1.EqualsIgnoreSpaces(STRING_2));
            Assert.IsTrue(STRING_1_SPACES.EqualsIgnoreSpaces(STRING_2));
            Assert.IsTrue(STRING_1.EqualsIgnoreSpaces(STRING_2_SPACES));
            Assert.IsTrue(STRING_1_SPACES.EqualsIgnoreSpaces(STRING_2_SPACES));

            Assert.IsTrue(STRING_1.EqualsIgnoreSpaces(STRING_1_SPACES_UPPER, true));
            Assert.IsTrue(STRING_1_SPACES.EqualsIgnoreSpaces(STRING_2_UPPER, true));
            Assert.IsTrue(STRING_1_SPACES_UPPER.EqualsIgnoreSpaces(STRING_2, true));
            Assert.IsTrue(STRING_1_UPPER.EqualsIgnoreSpaces(STRING_2_SPACES, true));
            Assert.IsTrue(STRING_1_SPACES.EqualsIgnoreSpaces(STRING_2_SPACES_UPPER, true));

            Assert.IsTrue(STRING_1.OrdinalEqualsIgnoreSpaces(STRING_1_SPACES));
            Assert.IsFalse(STRING_1.OrdinalEqualsIgnoreSpaces(STRING_2));
            Assert.IsFalse(STRING_1_SPACES.OrdinalEqualsIgnoreSpaces(STRING_2));
            Assert.IsFalse(STRING_1.OrdinalEqualsIgnoreSpaces(STRING_2_SPACES));
            Assert.IsFalse(STRING_1_SPACES.OrdinalEqualsIgnoreSpaces(STRING_2_SPACES));

            Assert.IsTrue(STRING_1.OrdinalEqualsIgnoreSpaces(STRING_1_SPACES_UPPER, true));
            Assert.IsFalse(STRING_1_SPACES.OrdinalEqualsIgnoreSpaces(STRING_2_UPPER, true));
            Assert.IsFalse(STRING_1_SPACES_UPPER.OrdinalEqualsIgnoreSpaces(STRING_2, true));
            Assert.IsFalse(STRING_1_UPPER.OrdinalEqualsIgnoreSpaces(STRING_2_SPACES, true));
            Assert.IsFalse(STRING_1_SPACES.OrdinalEqualsIgnoreSpaces(STRING_2_SPACES_UPPER, true));

            CultureInfo.CurrentCulture = new CultureInfo(currentCultureName);
        }
    }
}


