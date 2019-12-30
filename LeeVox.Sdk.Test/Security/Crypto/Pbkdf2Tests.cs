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
    public class Pbkdf2Tests
    {
        [TestMethod]
		[DataRow("", "random-salt", 10_000, "266d511246f5f8cf4846f181440c679f392c6027")]
		[DataRow("123456", "random-salt", 100_000, "894b861e7abf057f96dd787f32f7105dd251f919")]
		[DataRow("Đây là UniCode!", "random-salt", 1_000_000, "15ee507d4e93646c80a4f43a080357ca0d9810f9")]
		/** Expected PBKDF2 are generated using Node (Pbkdf2Tests.js)
		*/
        public void SimplePbkdf2_Sha1Tests(string password, string salt, int iterations, string expected)
        {
			var cryptoHash = new CryptoHash();
			var actual = cryptoHash.Pbkdf2_Sha1(password, salt, iterations);
            Assert.AreEqual(expected, actual.ToHexaString(), true);
        }

		[TestMethod]
		[DataRow("", "random-salt", 10_000, "00662d2ede65d6b6d149126f3bba9818bab680971bfbfc56a87484a1c38a4fa0")]
		[DataRow("123456", "random-salt", 100_000, "f0520bfffe739e4278848d1e8d5e9fd15d04a240f0491181a53caf8405da58e5")]
		[DataRow("Đây là UniCode!", "random-salt", 1_000_000, "a509c1cab5eb78256a47564e97136365ca598ef1b653aa2aed168fa4603ab96b")]
		/** Expected PBKDF2 are generated using Node (Pbkdf2Tests.js)
		*/
        public void SimplePbkdf2_Sha256Tests(string password, string salt, int iterations, string expected)
        {
			var cryptoHash = new CryptoHash();
			var actual = cryptoHash.Pbkdf2_Sha256(password, salt, iterations);
            Assert.AreEqual(expected, actual.ToHexaString(), true);
        }

		[TestMethod]
		[DataRow("", "random-salt", 10_000, "fa8226a60702da719393a4444e4487c1117a472cd44ebf2124be71e3b6128ca8c43c93e6a3466645d84bfb416e2db483db5545b86a6d302c9d49b7ee1f26377e")]
		[DataRow("123456", "random-salt", 100_000, "065f96dd061120da47e22b078d7a74497a275f352f4a1af10c356393d0c38c4d4d8369d5358687032e7c2a3134583f350aa97979d97cf6d68c7d1252560252e8")]
		[DataRow("Đây là UniCode!", "random-salt", 1_000_000, "eae5f3427baa6e06afa8473b8fc87e618c067a579a31c1e873846d0f208a89f39977c225ce9764645b1892c145ac5860ed9fa34fece21015ed330253f8bdb9c3")]
		/** Expected PBKDF2 are generated using Node (Pbkdf2Tests.js)
		*/
        public void SimplePbkdf2_Sha512Tests(string password, string salt, int iterations, string expected)
        {
			var cryptoHash = new CryptoHash();
			var actual = cryptoHash.Pbkdf2_Sha512(password, salt, iterations);
            Assert.AreEqual(expected, actual.ToHexaString(), true);
        }

		[TestMethod]
		[DataRow("")]
		[DataRow("123456")]
		[DataRow("Đây là UniCode!")]
        public void CheckDefaultParams_Pbkdf2Sha1(string password)
        {
			var cryptoHash = new CryptoHash();
			var watch = new Stopwatch();
			byte[] pbkdf2, salt;

			watch.Start();
			(pbkdf2, salt) = cryptoHash.Pbkdf2_Sha1(Encoding.UTF8.GetBytes(password));
			watch.Stop();
			Assert.IsTrue(watch.Elapsed >= TimeSpan.FromMilliseconds(500), $"PBKDF2-SHA1 should delay atleast 500ms. Default iterations: {CryptoHash.Pbkdf2_Sha1_Iterations}, elapsed time: {watch.ElapsedMilliseconds}ms");
			if (watch.Elapsed > TimeSpan.FromMilliseconds(1000))
			{
				Assert.Inconclusive($"PBKDF2-SHA1 should delay less than 1000ms. Default iterations: {CryptoHash.Pbkdf2_Sha1_Iterations}, elapsed time: {watch.ElapsedMilliseconds}ms");
			}
        }

		[TestMethod]
		[DataRow("")]
		[DataRow("123456")]
		[DataRow("Đây là UniCode!")]
        public void CheckDefaultParams_Pbkdf2Sha256(string password)
        {
			var cryptoHash = new CryptoHash();
			var watch = new Stopwatch();
			byte[] pbkdf2, salt;

			watch.Start();
			(pbkdf2, salt) = cryptoHash.Pbkdf2_Sha256(Encoding.UTF8.GetBytes(password));
			watch.Stop();
			Assert.IsTrue(watch.Elapsed >= TimeSpan.FromMilliseconds(500), $"PBKDF2-SHA256 should delay atleast 500ms. Default iterations: {CryptoHash.Pbkdf2_Sha256_Iterations}, elapsed time: {watch.ElapsedMilliseconds}ms");
			if (watch.Elapsed > TimeSpan.FromMilliseconds(1000))
			{
				Assert.Inconclusive($"PBKDF2-SHA256 should delay less than 1000ms. Default iterations: {CryptoHash.Pbkdf2_Sha256_Iterations}, elapsed time: {watch.ElapsedMilliseconds}ms");
			}
        }

		[TestMethod]
		[DataRow("")]
		[DataRow("123456")]
		[DataRow("Đây là UniCode!")]
        public void CheckDefaultParams_Pbkdf2Sha512(string password)
        {
			var cryptoHash = new CryptoHash();
			var watch = new Stopwatch();
			byte[] pbkdf2, salt;

			watch.Start();
			(pbkdf2, salt) = cryptoHash.Pbkdf2_Sha512(Encoding.UTF8.GetBytes(password));
			watch.Stop();
			Assert.IsTrue(watch.Elapsed >= TimeSpan.FromMilliseconds(500), $"PBKDF2-SHA512 should delay atleast 500ms. Default iterations: {CryptoHash.Pbkdf2_Sha512_Iterations}, elapsed time: {watch.ElapsedMilliseconds}ms");
			if (watch.Elapsed > TimeSpan.FromMilliseconds(1000))
			{
				Assert.Inconclusive($"PBKDF2-SHA512 should delay less than 1000ms. Default iterations: {CryptoHash.Pbkdf2_Sha512_Iterations}, elapsed time: {watch.ElapsedMilliseconds}ms");
			}
        }
    }
}


