using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using LeeVox.Sdk;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeeVox.Sdk.Test
{
    public class StringParseExtensionTests
    {
        [Fact]
        public void GenericParseTests()
        {
            var currentCultureName = CultureInfo.CurrentCulture.Name;
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            Assert.Equals(3_000_000_000U, "\t 3000000000\r \n".ParseTo<uint>(CultureInfo.CurrentCulture));
            Assert.Equals((sbyte)-75, "-75".ParseTo<sbyte>());
            Assert.Equals(null, "-12.3".ParseTo<ulong>());
            Assert.Equals('z', "-12.3".ParseTo<char>('z'));
            Assert.Equals(-12.3F, "-12.3".ParseTo<float>(CultureInfo.CurrentCulture.NumberFormat));
            Assert.Equals(null, "0xe10adc3949ba59abbe56e057f20f883e".ParseTo<decimal>(CultureInfo.CurrentCulture.NumberFormat));
            Assert.Equals(1M, "0xe10adc3949ba59abbe56e057f20f883e".ParseTo<decimal>(CultureInfo.CurrentCulture.NumberFormat, 1M));

            CultureInfo.CurrentCulture = new CultureInfo(currentCultureName);
        }

        [Fact]
        public void ParseToPrimitiveTypeTests()
        {
            var currentCultureName = CultureInfo.CurrentCulture.Name;
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            Assert.Equals(true, "true".ParseToBoolean());
            Assert.Equals(false, "faLSE".ParseToBoolean());
            Assert.Equals(true, "\t  TRUE\r \n".ParseToBoolean());
            Assert.Equals(null, "1".ParseToBoolean());
            Assert.Equals(true, "0".ParseToBoolean(true));
            Assert.Equals(false, "FALSE".ParseToBoolean(true));

            Assert.Equals((byte)10, "10".ParseToByte());
            Assert.Equals((byte)12, "\t 12\r \n".ParseToByte());
            Assert.Equals(null, "9999999999999999999999999999999999999999".ParseToByte());
            Assert.Equals((byte)1, "abcdef".ParseToByte((byte)1));
            Assert.Equals((byte)15, "15".ParseToByte((byte)1));
            Assert.Equals((byte)175, "AF".ParseToByte(NumberStyles.AllowHexSpecifier, null));
            Assert.Equals(null, "AF".ParseToByte(NumberStyles.AllowDecimalPoint, null));
            Assert.Equals((byte)1, "AF".ParseToByte(NumberStyles.AllowDecimalPoint, null, (byte)1));
            Assert.Equals((byte)21, "21.0".ParseToByte(NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat, (byte)1));

            Assert.Equals(10, "10".ParseToInt());
            Assert.Equals(-12, "\t -12\r \n".ParseToInt());
            Assert.Equals(null, "9999999999999999999999999999999999999999".ParseToInt());
            Assert.Equals(1, "abcdef".ParseToInt(1));
            Assert.Equals(-15, "-15".ParseToInt(1));
            Assert.Equals(-1234, "1,234-".ParseToInt(NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign, null));
            Assert.Equals(null, "AF".ParseToInt(NumberStyles.AllowDecimalPoint, null));
            Assert.Equals(1, "AF".ParseToInt(NumberStyles.AllowDecimalPoint, null, 1));
            Assert.Equals(1234, "1,234.000".ParseToInt(NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat, 1));

            Assert.Equals(10L, "10".ParseToLong());
            Assert.Equals(-12L, "\t -12\r \n".ParseToLong());
            Assert.Equals(null, "9999999999999999999999999999999999999999".ParseToLong());
            Assert.Equals(1L, "abcdef".ParseToLong(1L));
            Assert.Equals(-15L, "-15".ParseToLong(1L));
            Assert.Equals(-1234L, "1,234-".ParseToLong(NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign, null));
            Assert.Equals(null, "AF".ParseToLong(NumberStyles.AllowDecimalPoint, null));
            Assert.Equals(1L, "AF".ParseToLong(NumberStyles.AllowDecimalPoint, null, 1L));
            Assert.Equals(1234L, "1,234.000".ParseToLong(NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat, 1L));

            Assert.True(float.Epsilon >= float.MinValue - "-3.402823E+38".ParseToFloat());
            Assert.Equals(-12.345F, "\t -12.345\r \n".ParseToFloat());
            Assert.Equals(float.NegativeInfinity, "-3.992823E+38".ParseToFloat());
            Assert.Equals(1F, "abcdef".ParseToFloat(1F));
            Assert.Equals(-15.666F, "-15.666".ParseToFloat(1F));
            Assert.Equals(-1234F, "1,234-".ParseToFloat(NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign, null));
            Assert.Equals(null, "AF".ParseToFloat(NumberStyles.AllowDecimalPoint, null));
            Assert.Equals(1F, "AF".ParseToFloat(NumberStyles.AllowDecimalPoint, null, 1F));
            Assert.Equals(1234.567F, "1,234.567".ParseToFloat(NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat, 1F));

            Assert.True(double.Epsilon >= double.MaxValue - "1.7976931348623157E+308".ParseToDouble());
            Assert.Equals(-12.345D, "\t -12.345\r \n".ParseToDouble());
            Assert.Equals(double.PositiveInfinity, "1.9976931348623157E+308".ParseToDouble());
            Assert.Equals(1D, "abcdef".ParseToDouble(1D));
            Assert.Equals(-15.666D, "-15.666".ParseToDouble(1D));
            Assert.Equals(-1234D, "1,234-".ParseToDouble(NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign, null));
            Assert.Equals(null, "AF".ParseToDouble(NumberStyles.AllowDecimalPoint, null));
            Assert.Equals(1D, "AF".ParseToDouble(NumberStyles.AllowDecimalPoint, null, 1D));
            Assert.Equals(1234.567D, "1,234.567".ParseToDouble(NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat, 1D));

            Assert.Equals(10M, "10".ParseToDecimal());
            Assert.Equals(-12.345M, "\t -12.345\r \n".ParseToDecimal());
            Assert.Equals(null, "9999999999999999999999999999999999999999".ParseToDecimal());
            Assert.Equals(1M, "abcdef".ParseToDecimal(1M));
            Assert.Equals(-15.666M, "-15.666".ParseToDecimal(1M));
            Assert.Equals(-1234M, "1,234-".ParseToDecimal(NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign, null));
            Assert.Equals(null, "AF".ParseToDecimal(NumberStyles.AllowDecimalPoint, null));
            Assert.Equals(1M, "AF".ParseToDecimal(NumberStyles.AllowDecimalPoint, null, 1M));
            Assert.Equals(1234.567M, "1,234.567".ParseToDecimal(NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat, 1M));

            Assert.Equals(new DateTime(1970, 1, 1), "1970/1/1".ParseToDateTime());
            Assert.Equals(new DateTime(2018, 11, 26, 1, 23, 45, 666, DateTimeKind.Utc).ToLocalTime(), "\t 2018-11-26T01:23:45.666Z\r \n".ParseToDateTime());
            Assert.Equals(null, "Thursday".ParseToDateTime());
            Assert.Equals(new DateTime(1970, 1, 1), "1970/1/1".ParseToDateTime(new DateTime(9999, 12, 31)));
            Assert.Equals(new DateTime(1970, 1, 1), "-1/1/1".ParseToDateTime(new DateTime(1970, 1, 1)));
            Assert.Equals(new DateTime(2018, 11, 26, 1, 23, 45, 666, DateTimeKind.Utc).ToLocalTime(), "2018-11-26 01:23:45.666".ParseToDateTime(DateTimeStyles.AssumeUniversal, null));
            Assert.Equals(new DateTime(2018, 11, 26, 1, 23, 45, 666), "2018-11-26 01:23:45.666".ParseToDateTime(DateTimeStyles.AssumeLocal, null));
            Assert.Equals(null, "YYYY/MM/DD".ParseToDateTime(DateTimeStyles.AssumeLocal, null));
            Assert.Equals(new DateTime(1970, 1, 1), "YYYY/MM/DD".ParseToDateTime(DateTimeStyles.AssumeLocal, null, new DateTime(1970, 1, 1)));
            Assert.Equals(new DateTime(2001, 11, 12), "2001/11/12".ParseToDateTime(DateTimeStyles.AssumeLocal, null, new DateTime(1970, 1, 1)));

            CultureInfo.CurrentCulture = new CultureInfo(currentCultureName);
        }
    }
}


