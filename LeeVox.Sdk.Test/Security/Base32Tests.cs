using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeeVox.Sdk.Test
{
	[TestClass]
	public class Base32Tests
	{
		[TestMethod]
		[DataRow("", "")]
		[DataRow("f", "MY======")]
		[DataRow("fo", "MZXQ====")]
		[DataRow("foo", "MZXW6===")]
		[DataRow("foob", "MZXW6YQ=")]
		[DataRow("fooba", "MZXW6YTB")]
		[DataRow("foobar", "MZXW6YTBOI======")]
		public void EncodeBase32(string raw, string expectedEncoded)
		{
			var bytes = Encoding.ASCII.GetBytes(raw);
			var actualEncoded = Base32.ToBase32String(bytes);
			Assert.AreEqual(expectedEncoded, actualEncoded);
			var actualEncodedLowerCase = Base32.ToBase32String(bytes, useLowerCase: true);
			Assert.AreEqual(expectedEncoded.ToLower(), actualEncodedLowerCase);
		}

		[TestMethod]
		[DataRow("", "")]
		[DataRow("MY======", "f")]
		[DataRow("MZXQ====", "fo")]
		[DataRow("MZXW6===", "foo")]
		[DataRow("MZXW6YQ=", "foob")]
		[DataRow("MZXW6YTB", "fooba")]
		[DataRow("MZXW6YTBOI======", "foobar")]
		[DataRow("", "")]
		[DataRow("MY", "f")]
		[DataRow("MZXQ", "fo")]
		[DataRow("MZXW6", "foo")]
		[DataRow("MZXW6YQ", "foob")]
		[DataRow("MZXW6YTB", "fooba")]
		[DataRow("MZXW6YTBOI", "foobar")]
		[DataRow("", "")]
		[DataRow("mY======", "f")]
		[DataRow("MzxQ====", "fo")]
		[DataRow("MZXW6===", "foo")]
		[DataRow("MZxw6YQ=", "foob")]
		[DataRow("mzXW6ytB", "fooba")]
		[DataRow("mzxw6ytboi======", "foobar")]
		[DataRow("", "")]
		[DataRow("My", "f")]
		[DataRow("mzxq", "fo")]
		[DataRow("MZXW6", "foo")]
		[DataRow("mzXW6YQ", "foob")]
		[DataRow("mzXW6ytB", "fooba")]
		[DataRow("mzxw6ytboi", "foobar")]
		public void DecodeBase32(string encoded, string expectedRaw)
		{
			var actualDecodedBytes = Base32.FromBase32String(encoded);
			var actualDecodedString = Encoding.ASCII.GetString(actualDecodedBytes);
			Assert.AreEqual(expectedRaw, actualDecodedString);
		}

		[TestMethod]
		[DataRow("", "")]
		[DataRow("f", "CO======")]
		[DataRow("fo", "CPNG====")]
		[DataRow("foo", "CPNMU===")]
		[DataRow("foob", "CPNMUOG=")]
		[DataRow("fooba", "CPNMUOJ1")]
		[DataRow("foobar", "CPNMUOJ1E8======")]
		public void EncodeBase32ExtendedHex(string raw, string expectedEncoded)
		{
			var bytes = Encoding.ASCII.GetBytes(raw);
			var actualEncoded = Base32.ToBase32ExtendedHexString(bytes);
			Assert.AreEqual(expectedEncoded, actualEncoded);
			var actualEncodedLowerCase = Base32.ToBase32ExtendedHexString(bytes, useLowerCase: true);
			Assert.AreEqual(expectedEncoded.ToLower(), actualEncodedLowerCase);
		}

		[TestMethod]
		[DataRow("", "")]
		[DataRow("CO======", "f")]
		[DataRow("CPNG====", "fo")]
		[DataRow("CPNMU===", "foo")]
		[DataRow("CPNMUOG=", "foob")]
		[DataRow("CPNMUOJ1", "fooba")]
		[DataRow("CPNMUOJ1E8======", "foobar")]
		[DataRow("", "")]
		[DataRow("CO", "f")]
		[DataRow("CPNG", "fo")]
		[DataRow("CPNMU", "foo")]
		[DataRow("CPNMUOG", "foob")]
		[DataRow("CPNMUOJ1", "fooba")]
		[DataRow("CPNMUOJ1E8", "foobar")]
		[DataRow("", "")]
		[DataRow("Co======", "f")]
		[DataRow("cPnG====", "fo")]
		[DataRow("cpnmu===", "foo")]
		[DataRow("CpNmuoG=", "foob")]
		[DataRow("cpnmuoj1", "fooba")]
		[DataRow("cpnMUOj1e8======", "foobar")]
		[DataRow("", "")]
		[DataRow("cO", "f")]
		[DataRow("cpNG", "fo")]
		[DataRow("CPnmu", "foo")]
		[DataRow("CpnMuoG", "foob")]
		[DataRow("cPnMUoJ1", "fooba")]
		[DataRow("cpnmuoj1e8", "foobar")]
		public void DecodeBase32ExtendedHex(string encoded, string expectedRaw)
		{
			var actualDecodedBytes = Base32.FromBase32ExtendedHexString(encoded);
			var actualDecodedString = Encoding.ASCII.GetString(actualDecodedBytes);
			Assert.AreEqual(expectedRaw, actualDecodedString);
		}
	}
}