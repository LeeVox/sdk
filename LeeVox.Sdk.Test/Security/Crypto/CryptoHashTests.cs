using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using LeeVox.Sdk;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Org.BouncyCastle.Crypto.Generators;

namespace LeeVox.Sdk.Test
{
    [TestClass]
    public class CryptoHashTests
    {
        [TestMethod]
		[DataRow("", 9)]
		[DataRow("123456", 12)]
		[DataRow("Đây là UniCode!", 14)]
        public void SimpleBCryptTests(string password, int cost)
        {
            var cryptoRandom = new CryptoRandom();
            var salt = cryptoRandom.NextBytes(CryptoHash.BCryptSaltLength);

			var cryptoHash = new CryptoHash();
			var bcrypt1 = cryptoHash.BCrypt(password, cost);
            var bcrypt2 = cryptoHash.BCrypt(password, cost);
            var bcrypt3 = cryptoHash.BCrypt(password, salt, cost);
            var bcrypt4 = cryptoHash.BCrypt(password, salt, cost);

            Assert.AreNotEqual(bcrypt1, bcrypt2, false, "Should generate different bcrypt each time.");
            Assert.AreNotEqual(bcrypt1, bcrypt3, false, "Should generate different bcrypt each time.");
            Assert.AreNotEqual(bcrypt2, bcrypt3, false, "Should generate different bcrypt each time.");
            Assert.AreEqual(bcrypt3, bcrypt4, false, "Should generate same bcrypt result if use same salt.");

			Assert.IsTrue(cryptoHash.ValidateBCrypt(bcrypt1, password));
            Assert.IsTrue(cryptoHash.ValidateBCrypt(bcrypt2, password));
            Assert.IsTrue(cryptoHash.ValidateBCrypt(bcrypt3, password));
            Assert.IsTrue(cryptoHash.ValidateBCrypt(bcrypt4, password));
        }

		[TestMethod]
		[DataRow("", 9, "$2y$09$eeXJbsKtrahwgTD5rzEx1.rE0QBzxeqDkA/1YovnWb9P6ZCnkf0pC")]
		[DataRow("123456", 12, "$2y$12$hM8RwzjalsRanXP0EGmHLeF3iUbSaHYavtPijX7XrZGhlWiGJwZ0u")]
		[DataRow("Đây là UniCode!", 14, "$2y$14$TbTy0WMUk4Y7fjneOymHLOFRN7NhONtwGf1b6dyH7BaHlX0XKZQea")]
        public void SelectedBCryptTests(string password, int cost, string bcrypt)
        {
			var cryptoHash = new CryptoHash();
			Assert.IsTrue(cryptoHash.ValidateBCrypt(bcrypt, password));

			var salt = OpenBsdBCrypt.DecodeSaltString(bcrypt.Substring(7, 22));
			var actualBcrypt = cryptoHash.BCrypt(password, salt, cost);
			Assert.AreEqual(bcrypt, actualBcrypt, false);
        }
    }
}


