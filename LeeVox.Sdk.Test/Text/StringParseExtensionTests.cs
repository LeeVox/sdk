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
        public void GenericParseTests()
        {
            var currentCultureName = CultureInfo.CurrentCulture.Name;
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            Assert.AreEqual(3_000_000_000U, "\t 3000000000\r \n".ParseTo<uint>(CultureInfo.CurrentCulture));
            Assert.AreEqual((sbyte)-75, "-75".ParseTo<sbyte>());
            Assert.AreEqual(null, "-12.3".ParseTo<ulong>());
            Assert.AreEqual('z', "-12.3".ParseTo<char>('z'));
            Assert.AreEqual(-12.3F, "-12.3".ParseTo<float>(CultureInfo.CurrentCulture.NumberFormat));
            Assert.AreEqual(null, "0xe10adc3949ba59abbe56e057f20f883e".ParseTo<decimal>(CultureInfo.CurrentCulture.NumberFormat));
            Assert.AreEqual(1M, "0xe10adc3949ba59abbe56e057f20f883e".ParseTo<decimal>(CultureInfo.CurrentCulture.NumberFormat, 1M));

            CultureInfo.CurrentCulture = new CultureInfo(currentCultureName);
        }

        [TestMethod]
        public void ParseToPrimitiveTypeTests()
        {
            var currentCultureName = CultureInfo.CurrentCulture.Name;
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

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
            Assert.AreEqual((byte)175, "AF".ParseToByte(NumberStyles.AllowHexSpecifier, null));
            Assert.AreEqual(null, "AF".ParseToByte(NumberStyles.AllowDecimalPoint, null));
            Assert.AreEqual((byte)1, "AF".ParseToByte(NumberStyles.AllowDecimalPoint, null, (byte)1));
            Assert.AreEqual((byte)21, "21.0".ParseToByte(NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat));

            Assert.AreEqual(10, "10".ParseToInt());
            Assert.AreEqual(-12, "\t -12\r \n".ParseToInt());
            Assert.AreEqual(null, "9999999999999999999999999999999999999999".ParseToInt());
            Assert.AreEqual(1, "abcdef".ParseToInt(1));
            Assert.AreEqual(-15, "-15".ParseToInt(1));
            Assert.AreEqual(-1234, "1,234-".ParseToInt(NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign, null));
            Assert.AreEqual(null, "AF".ParseToInt(NumberStyles.AllowDecimalPoint, null));
            Assert.AreEqual(1, "AF".ParseToInt(NumberStyles.AllowDecimalPoint, null, 1));
            Assert.AreEqual(1234, "1,234.000".ParseToInt(NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat));

            Assert.AreEqual(10L, "10".ParseToLong());
            Assert.AreEqual(-12L, "\t -12\r \n".ParseToLong());
            Assert.AreEqual(null, "9999999999999999999999999999999999999999".ParseToLong());
            Assert.AreEqual(1L, "abcdef".ParseToLong(1L));
            Assert.AreEqual(-15L, "-15".ParseToLong(1L));
            Assert.AreEqual(-1234L, "1,234-".ParseToLong(NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign, null));
            Assert.AreEqual(null, "AF".ParseToLong(NumberStyles.AllowDecimalPoint, null));
            Assert.AreEqual(1L, "AF".ParseToLong(NumberStyles.AllowDecimalPoint, null, 1L));
            Assert.AreEqual(1234L, "1,234.000".ParseToLong(NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat));

            Assert.AreEqual(10F, "10".ParseToFloat());
            Assert.AreEqual(-12.345F, "\t -12.345\r \n".ParseToFloat());
            Assert.AreEqual(null, "9999999999999999999999999999999999999999".ParseToFloat());
            Assert.AreEqual(1F, "abcdef".ParseToFloat(1F));
            Assert.AreEqual(-15.666F, "-15.666".ParseToFloat(1F));
            Assert.AreEqual(-1234F, "1,234-".ParseToFloat(NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign, null));
            Assert.AreEqual(null, "AF".ParseToFloat(NumberStyles.AllowDecimalPoint, null));
            Assert.AreEqual(1F, "AF".ParseToFloat(NumberStyles.AllowDecimalPoint, null, 1F));
            Assert.AreEqual(1234.567F, "1,234.567".ParseToFloat(NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat));

            Assert.AreEqual(10D, "10".ParseToDouble());
            Assert.AreEqual(-12.345D, "\t -12.345\r \n".ParseToDouble());
            Assert.AreEqual(null, "abcdef".ParseToDouble());
            Assert.AreEqual(1D, "abcdef".ParseToDouble(1D));
            Assert.AreEqual(-15.666D, "-15.666".ParseToDouble(1D));
            Assert.AreEqual(-1234D, "1,234-".ParseToDouble(NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign, null));
            Assert.AreEqual(null, "AF".ParseToDouble(NumberStyles.AllowDecimalPoint, null));
            Assert.AreEqual(1D, "AF".ParseToDouble(NumberStyles.AllowDecimalPoint, null, 1D));
            Assert.AreEqual(1234.567D, "1,234.567".ParseToDouble(NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat));

            Assert.AreEqual(10M, "10".ParseToDecimal());
            Assert.AreEqual(-12.345M, "\t -12.345\r \n".ParseToDecimal());
            Assert.AreEqual(null, "9999999999999999999999999999999999999999".ParseToDecimal());
            Assert.AreEqual(1M, "abcdef".ParseToDecimal(1M));
            Assert.AreEqual(-15.666M, "-15.666".ParseToDecimal(1M));
            Assert.AreEqual(-1234M, "1,234-".ParseToDecimal(NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign, null));
            Assert.AreEqual(null, "AF".ParseToDecimal(NumberStyles.AllowDecimalPoint, null));
            Assert.AreEqual(1M, "AF".ParseToDecimal(NumberStyles.AllowDecimalPoint, null, 1M));
            Assert.AreEqual(1234.567M, "1,234.567".ParseToDecimal(NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat));

            Assert.AreEqual(new DateTime(1970, 1, 1), "1970/1/1".ParseToDateTime());
            Assert.AreEqual(new DateTime(2018, 11, 26, 1, 23, 45, 666, DateTimeKind.Utc).ToLocalTime(), "\t 2018-11-26T01:23:45.666Z\r \n".ParseToDateTime());
            Assert.AreEqual(null, "Thursday".ParseToDateTime());
            Assert.AreEqual(new DateTime(1970, 1, 1), "1970/1/1".ParseToDateTime(new DateTime(9999, 12, 31)));
            Assert.AreEqual(new DateTime(1970, 1, 1), "-1/1/1".ParseToDateTime(new DateTime(1970, 1, 1)));
            Assert.AreEqual(new DateTime(2018, 11, 26, 1, 23, 45, 666, DateTimeKind.Utc).ToLocalTime(), "2018-11-26 01:23:45.666".ParseToDateTime(DateTimeStyles.AssumeUniversal, null));
            Assert.AreEqual(new DateTime(2018, 11, 26, 1, 23, 45, 666), "2018-11-26 01:23:45.666".ParseToDateTime(DateTimeStyles.AssumeLocal, null));
            Assert.AreEqual(null, "YYYY/MM/DD".ParseToDateTime(DateTimeStyles.AssumeLocal, null));
            Assert.AreEqual(new DateTime(1970, 1, 1), "YYYY/MM/DD".ParseToDateTime(DateTimeStyles.AssumeLocal, null, new DateTime(1970, 1, 1)));

            CultureInfo.CurrentCulture = new CultureInfo(currentCultureName);
        }
    }
}


