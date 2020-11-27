using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using FluentAssertions;
using Xunit;

namespace LeeVox.Sdk.Test
{
    public class Base32Tests
    {
        public static readonly IEnumerable<object[]> RandomBytes;

        static Base32Tests()
        {
            RandomBytes = Enumerable.Range(1, 30).Select(x =>
            {
                var bytes = new byte[64];
                using (var random = new RNGCryptoServiceProvider())
                {
                    random.GetBytes(bytes);
                }
                return new string[] { Convert.ToBase64String(bytes) };
            });
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("f", "MY======")]
        [InlineData("fo", "MZXQ====")]
        [InlineData("foo", "MZXW6===")]
        [InlineData("foob", "MZXW6YQ=")]
        [InlineData("fooba", "MZXW6YTB")]
        [InlineData("foobar", "MZXW6YTBOI======")]
        public void EncodeBase32(string raw, string expectedEncoded)
        {
            var bytes = Encoding.ASCII.GetBytes(raw);
            var actualEncoded = Base32.ToBase32String(bytes);
            actualEncoded.Should().BeEquivalentTo(expectedEncoded);
            var actualEncodedLowerCase = Base32.ToBase32String(bytes, useLowerCase: true);
            actualEncodedLowerCase.Should().BeEquivalentTo(expectedEncoded.ToLower());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("MY======", "f")]
        [InlineData("MZXQ====", "fo")]
        [InlineData("MZXW6===", "foo")]
        [InlineData("MZXW6YQ=", "foob")]
        [InlineData("MZXW6YTB", "fooba")]
        [InlineData("MZXW6YTBOI======", "foobar")]
        [InlineData("MY", "f")]
        [InlineData("MZXQ", "fo")]
        [InlineData("MZXW6", "foo")]
        [InlineData("MZXW6YQ", "foob")]
        [InlineData("MZXW6ytb", "fooba")]
        [InlineData("MZXW6YTBOI", "foobar")]
        [InlineData("mY======", "f")]
        [InlineData("MzxQ====", "fo")]
        [InlineData("MzxW6===", "foo")]
        [InlineData("MZxw6YQ=", "foob")]
        [InlineData("mzXW6ytB", "fooba")]
        [InlineData("mzxw6ytboi======", "foobar")]
        [InlineData("My", "f")]
        [InlineData("mzxq", "fo")]
        [InlineData("MZxw6", "foo")]
        [InlineData("mzXW6YQ", "foob")]
        [InlineData("mzxW6ytB", "fooba")]
        [InlineData("mzxw6ytboi", "foobar")]
        public void DecodeBase32(string encoded, string expectedRaw)
        {
            var actualDecodedBytes = Base32.FromBase32String(encoded);
            var actualDecodedString = Encoding.ASCII.GetString(actualDecodedBytes);
            actualDecodedString.Should().BeEquivalentTo(expectedRaw);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("f", "CO======")]
        [InlineData("fo", "CPNG====")]
        [InlineData("foo", "CPNMU===")]
        [InlineData("foob", "CPNMUOG=")]
        [InlineData("fooba", "CPNMUOJ1")]
        [InlineData("foobar", "CPNMUOJ1E8======")]
        public void EncodeBase32ExtendedHex(string raw, string expectedEncoded)
        {
            var bytes = Encoding.ASCII.GetBytes(raw);
            var actualEncoded = Base32.ToBase32ExtendedHexString(bytes);
            actualEncoded.Should().BeEquivalentTo(expectedEncoded);
            var actualEncodedLowerCase = Base32.ToBase32ExtendedHexString(bytes, useLowerCase: true);
            actualEncodedLowerCase.Should().BeEquivalentTo(expectedEncoded.ToLower());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("CO======", "f")]
        [InlineData("CPNG====", "fo")]
        [InlineData("CPNMU===", "foo")]
        [InlineData("CPNMUOG=", "foob")]
        [InlineData("CPNMUOJ1", "fooba")]
        [InlineData("CPNMUOJ1E8======", "foobar")]
        [InlineData("CO", "f")]
        [InlineData("CPNG", "fo")]
        [InlineData("CPNMU", "foo")]
        [InlineData("CPNMUOG", "foob")]
        [InlineData("CPnmuOJ1", "fooba")]
        [InlineData("CPNMUOJ1E8", "foobar")]
        [InlineData("Co======", "f")]
        [InlineData("cPnG====", "fo")]
        [InlineData("cpnmu===", "foo")]
        [InlineData("CpNmuoG=", "foob")]
        [InlineData("cpnmuoj1", "fooba")]
        [InlineData("cpnMUOj1e8======", "foobar")]
        [InlineData("cO", "f")]
        [InlineData("cpNG", "fo")]
        [InlineData("CPnmu", "foo")]
        [InlineData("CpnMuoG", "foob")]
        [InlineData("cPnMUoJ1", "fooba")]
        [InlineData("cpnmuoj1e8", "foobar")]
        public void DecodeBase32ExtendedHex(string encoded, string expectedRaw)
        {
            var actualDecodedBytes = Base32.FromBase32ExtendedHexString(encoded);
            var actualDecodedString = Encoding.ASCII.GetString(actualDecodedBytes);
            actualDecodedString.Should().BeEquivalentTo(expectedRaw);
        }

        [Theory]
        [MemberData(nameof(RandomBytes))]
        public void EncodeDecodeRandomBytesUsingBase32(string randomBytesAsBase64)
        {
            var randomBytes = Convert.FromBase64String(randomBytesAsBase64);

            var encoded = Base32.ToBase32String(randomBytes);
            var decoded = Base32.FromBase32String(encoded);

            decoded.Length.Should().Be(randomBytes.Length);
            decoded.Should().BeEquivalentTo(randomBytes, $"Encode then Decode should return original bytes: '{randomBytesAsBase64}'");

            var encodedLowercase = Base32.ToBase32String(randomBytes, useLowerCase: true);
            var decodedLowercase = Base32.FromBase32String(encodedLowercase);

            decodedLowercase.Length.Should().Be(randomBytes.Length);
            decodedLowercase.Should().BeEquivalentTo(randomBytes, $"Encode then Decode (Lowercase) should return original bytes: '{randomBytesAsBase64}'");
        }

        [Theory]
        [MemberData(nameof(RandomBytes))]
        public void EncodeDecodeRandomBytesUsingBase32ExtendedHex(string randomBytesAsBase64)
        {
            var randomBytes = Convert.FromBase64String(randomBytesAsBase64);

            var encoded = Base32.ToBase32ExtendedHexString(randomBytes);
            var decoded = Base32.FromBase32ExtendedHexString(encoded);

            decoded.Length.Should().Be(randomBytes.Length);
            decoded.Should().BeEquivalentTo(randomBytes, $"Encode then Decode should return original bytes: '{randomBytesAsBase64}'");

            var encodedLowercase = Base32.ToBase32ExtendedHexString(randomBytes, useLowerCase: true);
            var decodedLowercase = Base32.FromBase32ExtendedHexString(encodedLowercase);

            decodedLowercase.Length.Should().Be(randomBytes.Length);
            decodedLowercase.Should().BeEquivalentTo(randomBytes, $"Encode then Decode (Lowercase) should return original bytes: '{randomBytesAsBase64}'");
        }
    }
}