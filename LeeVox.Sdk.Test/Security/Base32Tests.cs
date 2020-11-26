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
		public void EncodeAndDecodeBase32(string raw, string expectedEncoded)
		{
			var bytes = Encoding.ASCII.GetBytes(raw);
			var actualEncoded = Base32.ToBase32String(bytes);
			Assert.AreEqual(expectedEncoded, actualEncoded);
			var actualDecoded = Base32.FromBase32String(expectedEncoded);
			var actualDecodedString = Encoding.ASCII.GetString(actualDecoded);
			Assert.AreEqual(raw, actualDecodedString);
		}

		[TestMethod]
		[DataRow("", "")]
		[DataRow("f", "CO======")]
		[DataRow("fo", "CPNG====")]
		[DataRow("foo", "CPNMU===")]
		[DataRow("foob", "CPNMUOG=")]
		[DataRow("fooba", "CPNMUOJ1")]
		[DataRow("foobar", "CPNMUOJ1E8======")]
		public void EncodeAndDecodeBase32ExtendedHex(string raw, string expectedEncoded)
		{
			var bytes = Encoding.ASCII.GetBytes(raw);
			var actualEncoded = Base32.ToBase32ExtendedHexString(bytes);
			Assert.AreEqual(expectedEncoded, actualEncoded);
			var actualDecoded = Base32.FromBase32ExtendedHexString(expectedEncoded);
			var actualDecodedString = Encoding.ASCII.GetString(actualDecoded);
			Assert.AreEqual(raw, actualDecodedString);
		}
	}
}