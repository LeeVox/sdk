using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using LeeVox.Sdk;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeeVox.Sdk.Test
{
    [TestClass]
    public class StringParseExtensionTests
    {
        [TestMethod]
        public void ParseToPrimitiveTypeTests()
        {
            Assert.AreEqual(true, "true".ParseToBoolean());
            Assert.AreEqual(false, "faLSE".ParseToBoolean());
            Assert.AreEqual(true, "\t  TRUE\r \n".ParseToBoolean());
            Assert.AreEqual(null, "1".ParseToBoolean());
            Assert.AreEqual(true, "0".ParseToBoolean(true));
            Assert.AreEqual(false, "FALSE".ParseToBoolean(true));

            Assert.AreEqual((byte)10, "10".ParseToByte());
            Assert.AreEqual((byte)12, "\t 12\r \n".ParseToByte());
            Assert.AreEqual(null, "9999999999999999999999999999999999999999".ParseToByte());
            Assert.AreEqual((byte)1, "abcdef".ParseToByte((byte)1));
            Assert.AreEqual((byte)15, "15".ParseToByte((byte)1));

            Assert.AreEqual(10, "10".ParseToInt());
            Assert.AreEqual(-12, "\t -12\r \n".ParseToInt());
            Assert.AreEqual(null, "9999999999999999999999999999999999999999".ParseToInt());
            Assert.AreEqual(1, "abcdef".ParseToInt(1));
            Assert.AreEqual(-15, "-15".ParseToInt(1));

            Assert.AreEqual(10F, "10".ParseToFloat());
            Assert.AreEqual(-12.345F, "\t -12.345\r \n".ParseToFloat());
            Assert.AreEqual(null, "9999999999999999999999999999999999999999".ParseToFloat());
            Assert.AreEqual(1F, "abcdef".ParseToFloat(1F));
            Assert.AreEqual(-15.666F, "-15.666".ParseToFloat(1F));

            Assert.AreEqual(10D, "10".ParseToDouble());
            Assert.AreEqual(-12.345D, "\t -12.345\r \n".ParseToDouble());
            Assert.AreNotEqual(null, "999999999999999999999999999999999999999955555555555555555555555555555555555555555555555".ParseToDouble());
            Assert.AreEqual(1D, "abcdef".ParseToDouble(1D));
            Assert.AreEqual(-15.666D, "-15.666".ParseToDouble(1D));

            Assert.AreEqual(10M, "10".ParseToDecimal());
            Assert.AreEqual(-12.345M, "\t -12.345\r \n".ParseToDecimal());
            Assert.AreEqual(null, "9999999999999999999999999999999999999999".ParseToDecimal());
            Assert.AreEqual(1M, "abcdef".ParseToDecimal(1M));
            Assert.AreEqual(-15.666M, "-15.666".ParseToDecimal(1M));

            var currentCultureName = CultureInfo.CurrentCulture.Name;
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            Assert.AreEqual(new DateTime(1970, 1, 1), "1970/1/1".ParseToDateTime());
            //Assert.AreEqual(new DateTime(2018, 11, 26, 1, 23, 45, 666, DateTimeKind.Local).ToUniversalTime(), "\t 2018-11-26T01:23:45.666Z\r \n".ParseToDateTime());
            Assert.AreEqual(null, "Thursday".ParseToDateTime());
            Assert.AreEqual(new DateTime(1970, 1, 1), "1970/1/1".ParseToDateTime(new DateTime(9999, 12, 31)));
            Assert.AreEqual(new DateTime(1970, 1, 1), "-1/1/1".ParseToDateTime(new DateTime(1970, 1, 1)));

            CultureInfo.CurrentCulture = new CultureInfo(currentCultureName);
        }
    }
}


