using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using LeeVox.Sdk;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Org.BouncyCastle.Crypto.Generators;

namespace LeeVox.Sdk.Test
{
    [TestClass]
    public class SCryptTests
    {
        [TestMethod]
		[DataRow("", "random-salt", 262144, 8, 1, 32, "165797a6989d76b5d8c47ba20d2ae427094c615cd3af37a9c9e48bc90f49899b")]
		[DataRow("123456", "random-salt", 262144, 8, 1, 32, "45e91cf54bbbcaa8cdda82c692da6ffb266512a36812f76faa7beb4da8927313")]
		[DataRow("Đây là UniCode!", "random-salt", 262144, 8, 1, 32, "0c2aefea25843f26f1c7f410af2449907b4ef9bf06c1202d7e72570acc3f61a7")]
		/** Expected SCrypt are generated using Node (SCryptTests.js)
		*/
        public void SimpleSCryptTests(string password, string salt, int N, int r, int p, int outputLength, string expected)
        {
            var cryptoHash = new CryptoHash();
			var scrypt1 = cryptoHash.SCrypt(password, salt, N, r, p, outputLength).ToHexaString();
			Assert.AreEqual(expected, scrypt1, true);

			var (scrypt2, randomSalt) = cryptoHash.SCrypt(password, N, r, p, outputLength);
			Assert.AreNotEqual(salt, randomSalt.ToHexaString(), true, "Salt should be random.");
			Assert.AreNotEqual(scrypt1, scrypt2.ToHexaString(), true, "SCrypt result should be different if salt are different.");
        }

		[TestMethod]
		[DataRow("")]
		[DataRow("123456")]
		[DataRow("Đây là UniCode!")]
        public void CheckDefaultParams(string password)
        {
			var cryptoHash = new CryptoHash();
			var watch = new Stopwatch();
			byte[] scrypt, salt;

			watch.Start();
			(scrypt, salt) = cryptoHash.SCrypt(Encoding.UTF8.GetBytes(password));
			watch.Stop();
			Assert.IsTrue(watch.Elapsed >= TimeSpan.FromMilliseconds(500), $"SCrypt should delay atleast 500ms. Default params: (N: {CryptoHash.SCryptCost}, r: {CryptoHash.SCryptBlockSize}, p: {CryptoHash.SCryptParallelization}, len: {CryptoHash.SCryptOutputLength}), elapsed time: {watch.ElapsedMilliseconds}ms");
			if (watch.Elapsed > TimeSpan.FromMilliseconds(1000))
			{
				Assert.Inconclusive($"SCrypt should delay less than 1000ms. Default params: (N: {CryptoHash.SCryptCost}, r: {CryptoHash.SCryptBlockSize}, p: {CryptoHash.SCryptParallelization}, len: {CryptoHash.SCryptOutputLength}), elapsed time: {watch.ElapsedMilliseconds}ms");
			}
        }
    }
}


