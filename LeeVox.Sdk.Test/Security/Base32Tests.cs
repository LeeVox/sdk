using System;
using System.Security.Cryptography;
using System.Text;
using FluentAssertions;
using Xunit;

namespace LeeVox.Sdk.Test
{
    public class Base32Tests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("f", "MY======")]
        [InlineData("fo", "MZXQ====")]
        [InlineData("foo", "MZXW6===")]
        [InlineData("foob", "MZXW6YQ=")]
        [InlineData("fooba", "MZXW6YTB")]
        [InlineData("foobar", "MZXW6YTBOI======")]
        public void EncodeStringUsingBase32(string raw, string expectedEncoded)
        {
            var bytes = Encoding.UTF8.GetBytes(raw);
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
        public void DecodeBase32ToString(string encoded, string expectedRaw)
        {
            var actualDecodedBytes = Base32.FromBase32String(encoded);
            var actualDecodedString = Encoding.UTF8.GetString(actualDecodedBytes);
            actualDecodedString.Should().BeEquivalentTo(expectedRaw);
        }

        [Theory]
        [InlineData("MZX====")]
        [InlineData("MZX")]
        [InlineData("!@#$")]
        public void DecodeInvalidBase32String(string encoded)
        {

            this.Invoking(x => Base32.FromBase32String(encoded))
                .Should().Throw<ArgumentException>();

            this.Invoking(x => Base32.FromBase32ExtendedHexString(encoded))
                .Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("f", "CO======")]
        [InlineData("fo", "CPNG====")]
        [InlineData("foo", "CPNMU===")]
        [InlineData("foob", "CPNMUOG=")]
        [InlineData("fooba", "CPNMUOJ1")]
        [InlineData("foobar", "CPNMUOJ1E8======")]
        public void EncodeStringToBase32ExtendedHex(string raw, string expectedEncoded)
        {
            var bytes = Encoding.UTF8.GetBytes(raw);
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
        public void DecodeBase32ExtendedHexToString(string encoded, string expectedRaw)
        {
            var actualDecodedBytes = Base32.FromBase32ExtendedHexString(encoded);
            var actualDecodedString = Encoding.UTF8.GetString(actualDecodedBytes);
            actualDecodedString.Should().BeEquivalentTo(expectedRaw);
        }

        [Theory]
        [InlineData(0, 128)]
        [InlineData(128, 256)]
#if STRESS_TEST
        [InlineData(256, 512)]
        [InlineData(512, 1024)]
        [InlineData(1024, 1536)]
        [InlineData(1536, 2048)]
#endif
        public void EncodeDecodeRandomBytesUsingBase32(int minLength, int maxLength)
        {
            var uselowerCaseTests = new bool[] { true, false };

            for (var length = minLength; length <= maxLength; length++)
            {
                var bytes = GenerateRandomBytes(length);
                var bytesAsBase64 = Convert.ToBase64String(bytes);

                foreach (var useLowercase in uselowerCaseTests)
                {
                    var encoded = Base32.ToBase32String(bytes, useLowercase);
                    var decoded = Base32.FromBase32String(encoded);
                    var decodedTrim = Base32.FromBase32String(encoded.TrimEnd('=', ' '));

                    decoded.Length.Should().Be(bytes.Length, $"Encode then Decode should return same original byte count (useLowercase: {useLowercase}, original bytes as base64: '{bytesAsBase64}')");
                    decoded.Should().BeEquivalentTo(bytes, $"Encode then Decode should return original bytes (useLowercase: {useLowercase}, original bytes as base64: '{bytesAsBase64}')");
                    decodedTrim.Length.Should().Be(bytes.Length, $"Encode then Trim then then Decode should return same original byte count (useLowercase: {useLowercase}, original bytes as base64: '{bytesAsBase64}')");
                    decodedTrim.Should().BeEquivalentTo(bytes, $"Encode then Trim then Decode should return original bytes (useLowercase: {useLowercase}, original bytes as base64: '{bytesAsBase64}')");
                }
            }
        }

        [Theory]
        [InlineData(0, 128)]
        [InlineData(128, 256)]
#if STRESS_TEST
        [InlineData(256, 512)]
        [InlineData(512, 1024)]
        [InlineData(1024, 1536)]
        [InlineData(1536, 2048)]
#endif
        public void EncodeDecodeRandomBytesUsingBase32ExtendedHex(int minLength, int maxLength)
        {
            var uselowerCaseTests = new bool[] { true, false };

            for (var length = minLength; length <= maxLength; length++)
            {
                var bytes = GenerateRandomBytes(length);
                var bytesAsBase64 = Convert.ToBase64String(bytes);

                foreach (var useLowercase in uselowerCaseTests)
                {
                    var encoded = Base32.ToBase32ExtendedHexString(bytes, useLowercase);
                    var decoded = Base32.FromBase32ExtendedHexString(encoded);
                    var decodedTrim = Base32.FromBase32ExtendedHexString(encoded.TrimEnd('=', ' '));

                    decoded.Length.Should().Be(bytes.Length, $"Encode then Decode should return same original byte count (useLowercase: {useLowercase}, original bytes as base64: '{bytesAsBase64}')");
                    decoded.Should().BeEquivalentTo(bytes, $"Encode then Decode should return original bytes (useLowercase: {useLowercase}, original bytes as base64: '{bytesAsBase64}')");
                    decodedTrim.Length.Should().Be(bytes.Length, $"Encode then Trim then then Decode should return same original byte count (useLowercase: {useLowercase}, original bytes as base64: '{bytesAsBase64}')");
                    decodedTrim.Should().BeEquivalentTo(bytes, $"Encode then Trim then Decode should return original bytes (useLowercase: {useLowercase}, original bytes as base64: '{bytesAsBase64}')");
                }
            }
        }

        [Theory]
        [InlineData(0, 128)]
        [InlineData(128, 256)]
#if STRESS_TEST
        [InlineData(256, 512)]
        [InlineData(512, 1024)]
        [InlineData(1024, 1536)]
        [InlineData(1536, 2048)]
#endif
        public void EncodeDecodeBytesOfZeroUsingBase32(int minLength, int maxLength)
        {
            for (var length = minLength; length <= maxLength; length++)
            {
                var bytes = new byte[length];
                Array.Fill(bytes, (byte)0);

                var encoded = Base32.ToBase32String(bytes);
                var decoded = Base32.FromBase32String(encoded);
                var decodedTrim = Base32.FromBase32String(encoded.TrimEnd('=', ' '));

                decoded.Length.Should().Be(length, $"Encode then Decode should return {length} bytes of zero");
                decoded.Should().BeEquivalentTo(bytes, $"Encode then Decode should return {length} bytes of zero");
                decodedTrim.Length.Should().Be(length, $"Encode then Trim then Decode should return {length} bytes of zero");
                decodedTrim.Should().BeEquivalentTo(bytes, $"Encode then Trim then Decode should return {length} bytes of zero");

                var encodedLowerCase = Base32.ToBase32String(bytes);
                var decodedLowerCase = Base32.FromBase32String(encodedLowerCase);
                var decodedLowerCaseTrim = Base32.FromBase32String(encodedLowerCase.TrimEnd('=', ' '));

                decodedLowerCase.Length.Should().Be(length, $"Encode then Decode (lowercase) should return {length} bytes of zero");
                decodedLowerCase.Should().BeEquivalentTo(bytes, $"Encode then Decode (lowercase) should return {length} bytes of zero");
                decodedLowerCaseTrim.Length.Should().Be(length, $"Encode then Trim then Decode (lowercase) should return {length} bytes of zero");
                decodedLowerCaseTrim.Should().BeEquivalentTo(bytes, $"Encode then Trim then Decode (lowercase) should return {length} bytes of zero");
            }
        }

        [Theory]
        [InlineData(0, 128)]
        [InlineData(128, 256)]
#if STRESS_TEST
        [InlineData(256, 512)]
        [InlineData(512, 1024)]
        [InlineData(1024, 1536)]
        [InlineData(1536, 2048)]
#endif
        public void EncodeDecodeBytesOfZeroUsingBase32ExtendedHex(int minLength, int maxLength)
        {
            for (var length = minLength; length <= maxLength; length++)
            {
                var bytes = new byte[length];
                Array.Fill(bytes, (byte)0);

                var encoded = Base32.ToBase32ExtendedHexString(bytes);
                var decoded = Base32.FromBase32ExtendedHexString(encoded);
                var decodedTrim = Base32.FromBase32ExtendedHexString(encoded.TrimEnd('=', ' '));

                decoded.Length.Should().Be(length, $"Encode then Decode should return {length} bytes of zero");
                decoded.Should().BeEquivalentTo(bytes, $"Encode then Decode should return {length} bytes of zero");
                decodedTrim.Length.Should().Be(length, $"Encode then Trim then Decode should return {length} bytes of zero");
                decodedTrim.Should().BeEquivalentTo(bytes, $"Encode then Trim then Decode should return {length} bytes of zero");

                var encodedLowerCase = Base32.ToBase32ExtendedHexString(bytes);
                var decodedLowerCase = Base32.FromBase32ExtendedHexString(encodedLowerCase);
                var decodedLowerCaseTrim = Base32.FromBase32ExtendedHexString(encodedLowerCase.TrimEnd('=', ' '));

                decodedLowerCase.Length.Should().Be(length, $"Encode then Decode (lowercase) should return {length} bytes of zero");
                decodedLowerCase.Should().BeEquivalentTo(bytes, $"Encode then Decode (lowercase) should return {length} bytes of zero");
                decodedLowerCaseTrim.Length.Should().Be(length, $"Encode then Trim then Decode (lowercase) should return {length} bytes of zero");
                decodedLowerCaseTrim.Should().BeEquivalentTo(bytes, $"Encode then Trim then Decode (lowercase) should return {length} bytes of zero");
            }
        }

        [Theory(Skip = "For debug local only.")]
        [InlineData("")]
        public void EncodeDecodeBytesToBase32(string bytesAsBase64)
        {
            var bytes = Convert.FromBase64String(bytesAsBase64);

            var encoded = Base32.ToBase32String(bytes);
            var decoded = Base32.FromBase32String(encoded);
            var decodedTrim = Base32.FromBase32String(encoded.TrimEnd('=', ' '));

            decoded.Should().BeEquivalentTo(bytes, $"(decoded {Convert.ToHexString(decoded)}, bytes {Convert.ToHexString(bytes)})");
            decodedTrim.Should().BeEquivalentTo(bytes, $"(decodedTrim {Convert.ToHexString(decodedTrim)}, bytes {Convert.ToHexString(bytes)})");

            var encodedLowercase = Base32.ToBase32String(bytes);
            var decodedLowercase = Base32.FromBase32String(encodedLowercase);
            var decodedLowercaseTrim = Base32.FromBase32String(encodedLowercase.TrimEnd('=', ' '));

            decodedLowercase.Should().BeEquivalentTo(bytes,$"(decodedLowercase {Convert.ToHexString(decodedLowercase)}, bytes {Convert.ToHexString(bytes)})");
            decodedLowercaseTrim.Should().BeEquivalentTo(bytes, $"(decodedLowercaseTrim {Convert.ToHexString(decodedLowercaseTrim)}, bytes {Convert.ToHexString(bytes)})");
        }

        private byte[] GenerateRandomBytes(int length)
        {
            var result = new byte[length];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetBytes(result);
            }
            return result;
        }
    }
}