using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeeVox.Sdk.Test
{
    [TestClass]
    public class StringExtensionTests
    {
        readonly char[] ALL_WHITESPACES = Enumerable.Range(0, ushort.MaxValue)
            .Where(c => {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory((char)c);
                return unicodeCategory == UnicodeCategory.SpaceSeparator
                    || unicodeCategory == UnicodeCategory.LineSeparator
                    || unicodeCategory == UnicodeCategory.ParagraphSeparator;
            }).Select(c => Convert.ToChar(c)).ToArray();

        [TestMethod]
        public void SafeTrimTests()
        {
            string text, actual, expected;

            text = null;
            expected = string.Empty;
            actual = text.SafeTrim();
            Assert.AreEqual(expected, actual, "Should returns empty string if text is null.");

            text = null;
            expected = string.Empty;
            actual = text.SafeTrim('a', 'b', 'c');
            Assert.AreEqual(expected, actual, "Should returns empty string if text is null.");

            text = "\t Đây là Unicode.\r\n ";
            expected = "Đây là Unicode.";
            actual = text.SafeTrim();
            Assert.AreEqual(expected, actual, "Should able to trim basic whitespaces.");

            text = "text" + String.Join("", ALL_WHITESPACES);
            expected = "text";
            actual = text.SafeTrim();
            Assert.AreEqual(expected, actual, "Should able to trim all whitespace chars.");
            // ref: https://docs.microsoft.com/en-us/dotnet/api/system.char.iswhitespace

            text = "# Markdown header\r\n  ## xxyyyzzz";
            expected = "Markdown header";
            actual = text.SafeTrim('#', ' ', '\r', '\n', 'x', 'y', 'z');
            Assert.AreEqual(expected, actual, "Should able to trim specified chars.");
        }
    }
}