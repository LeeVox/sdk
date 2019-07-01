using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using LeeVox.Sdk;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeeVox.Sdk.Test
{
    [TestClass]
    public class BCryptTests
    {
        [TestMethod]
		[DataRow("")]
		[DataRow("123456")]
		[DataRow("Đây là UniCode!")]
        public void SimpleTests(string password)
        {
			var cryptoHash = new CryptoHash();
			var result = cryptoHash.OpenBsdBCrypt(password);
			Assert.AreEqual(result, "1");
        }
    }
}


