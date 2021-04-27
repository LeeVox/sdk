using System;
using System.Globalization;
using FluentAssertions;
using Xunit;

namespace LeeVox.Sdk.Test
{
    public class StringParseExtensionTests
    {
        [Fact]
        public void GenericParseTests()
        {
            var currentCultureName = CultureInfo.CurrentCulture.Name;
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            AssertEqual(3_000_000_000U, "\t 3000000000\r \n".ParseTo<uint>(CultureInfo.CurrentCulture));
            AssertEqual((sbyte)-75, "-75".ParseTo<sbyte>());
            AssertEqual((short)-1234, "-1234".ParseTo<short>());
            AssertEqual(ushort.MaxValue, "65535".ParseTo<ushort>());
            AssertNull("-12.3".ParseTo<ulong>());
            AssertEqual('z', "-12.3".ParseTo<char>('z'));
            AssertEqual(-12.3F, "-12.3".ParseTo<float>(CultureInfo.CurrentCulture.NumberFormat));
            AssertNull("0xe10adc3949ba59abbe56e057f20f883e".ParseTo<decimal>(CultureInfo.CurrentCulture.NumberFormat));
            AssertEqual(1M, "0xe10adc3949ba59abbe56e057f20f883e".ParseTo<decimal>(CultureInfo.CurrentCulture.NumberFormat, 1M));

            CultureInfo.CurrentCulture = new CultureInfo(currentCultureName);
        }

        [Fact]
        public void ParseToPrimitiveTypeTests()
        {
            var currentCultureName = CultureInfo.CurrentCulture.Name;
            CultureInfo.CurrentCulture = new CultureInfo("en-US");

            AssertTrue("true".ParseToBoolean());
            AssertFalse("faLSE".ParseToBoolean());
            AssertTrue("\t  TRUE\r \n".ParseToBoolean());
            AssertNull("1".ParseToBoolean());
            AssertTrue("0".ParseToBoolean(true));
            AssertFalse("FALSE".ParseToBoolean(true));

            AssertEqual((byte)10, "10".ParseToByte());
            AssertEqual((byte)12, "\t 12\r \n".ParseToByte());
            AssertNull("9999999999999999999999999999999999999999".ParseToByte());
            AssertEqual((byte)1, "abcdef".ParseToByte((byte)1));
            AssertEqual((byte)15, "15".ParseToByte((byte)1));
            AssertEqual((byte)175, "AF".ParseToByte(NumberStyles.AllowHexSpecifier, null));
            AssertNull("AF".ParseToByte(NumberStyles.AllowDecimalPoint, null));
            AssertEqual((byte)1, "AF".ParseToByte(NumberStyles.AllowDecimalPoint, null, (byte)1));
            AssertEqual((byte)21, "21.0".ParseToByte(NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat, (byte)1));

            AssertEqual((sbyte)10, "10".ParseToSByte());
            AssertEqual((sbyte)12, "\t 12\r \n".ParseToSByte());
            AssertNull("9999999999999999999999999999999999999999".ParseToSByte());
            AssertEqual((sbyte)1, "abcdef".ParseToSByte((sbyte)1));
            AssertEqual((sbyte)15, "15".ParseToSByte((sbyte)1));
            AssertEqual((sbyte)-81, "AF".ParseToSByte(NumberStyles.AllowHexSpecifier, null));
            AssertNull("AF".ParseToSByte(NumberStyles.AllowDecimalPoint, null));
            AssertEqual((sbyte)1, "AF".ParseToSByte(NumberStyles.AllowDecimalPoint, null, (sbyte)1));
            AssertEqual((sbyte)21, "21.0".ParseToSByte(NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat, (sbyte)1));

            AssertEqual((short)10, "10".ParseToShort());
            AssertEqual((short)-12, "\t -12\r \n".ParseToShort());
            AssertNull("9999999999999999999999999999999999999999".ParseToShort());
            AssertEqual((short)1, "abcdef".ParseToShort(1));
            AssertEqual((short)-15, "-15".ParseToShort(1));
            AssertEqual((short)-1234, "1,234-".ParseToShort(NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign, null));
            AssertNull("AF".ParseToShort(NumberStyles.AllowDecimalPoint, null));
            AssertEqual((short)1, "AF".ParseToShort(NumberStyles.AllowDecimalPoint, null, 1));
            AssertEqual((short)1234, "1,234.000".ParseToShort(NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat, 1));

            AssertEqual((ushort)10, "10".ParseToUShort());
            AssertNull("9999999999999999999999999999999999999999".ParseToUShort());
            AssertEqual((ushort)1, "abcdef".ParseToUShort(1));
            AssertNull("AF".ParseToUShort(NumberStyles.AllowDecimalPoint, null));
            AssertEqual((ushort)1, "AF".ParseToUShort(NumberStyles.AllowDecimalPoint, null, 1));
            AssertEqual((ushort)1234, "1,234.000".ParseToUShort(NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat, 1));

            AssertEqual(10, "10".ParseToInt());
            AssertEqual(-12, "\t -12\r \n".ParseToInt());
            AssertNull("9999999999999999999999999999999999999999".ParseToInt());
            AssertEqual(1, "abcdef".ParseToInt(1));
            AssertEqual(-15, "-15".ParseToInt(1));
            AssertEqual(-1234, "1,234-".ParseToInt(NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign, null));
            AssertNull("AF".ParseToInt(NumberStyles.AllowDecimalPoint, null));
            AssertEqual(1, "AF".ParseToInt(NumberStyles.AllowDecimalPoint, null, 1));
            AssertEqual(1234, "1,234.000".ParseToInt(NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat, 1));

            AssertEqual(10U, "10".ParseToUInt());
            AssertNull("9999999999999999999999999999999999999999".ParseToUInt());
            AssertEqual(1U, "abcdef".ParseToUInt(1));
            AssertNull("AF".ParseToUInt(NumberStyles.AllowDecimalPoint, null));
            AssertEqual(1U, "AF".ParseToUInt(NumberStyles.AllowDecimalPoint, null, 1));
            AssertEqual(1234U, "1,234.000".ParseToUInt(NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat, 1));

            AssertEqual(10L, "10".ParseToLong());
            AssertEqual(-12L, "\t -12\r \n".ParseToLong());
            AssertNull("9999999999999999999999999999999999999999".ParseToLong());
            AssertEqual(1L, "abcdef".ParseToLong(1L));
            AssertEqual(-15L, "-15".ParseToLong(1L));
            AssertEqual(-1234L, "1,234-".ParseToLong(NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign, null));
            AssertNull("AF".ParseToLong(NumberStyles.AllowDecimalPoint, null));
            AssertEqual(1L, "AF".ParseToLong(NumberStyles.AllowDecimalPoint, null, 1L));
            AssertEqual(1234L, "1,234.000".ParseToLong(NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat, 1L));

            AssertEqual(10UL, "10".ParseToULong());
            AssertNull("9999999999999999999999999999999999999999".ParseToULong());
            AssertEqual(1UL, "abcdef".ParseToULong(1L));
            AssertNull("AF".ParseToULong(NumberStyles.AllowDecimalPoint, null));
            AssertEqual(1UL, "AF".ParseToULong(NumberStyles.AllowDecimalPoint, null, 1L));
            AssertEqual(1234UL, "1,234.000".ParseToULong(NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat, 1L));

            AssertTrue(float.Epsilon >= float.MinValue - "-3.402823E+38".ParseToFloat());
            AssertEqual(null, "abc".ParseToFloat());
            AssertEqual(-12.345F, "\t -12.345\r \n".ParseToFloat());
            AssertEqual(float.NegativeInfinity, "-3.992823E+38".ParseToFloat());
            AssertEqual(1F, "abcdef".ParseToFloat(1F));
            AssertEqual(-15.666F, "-15.666".ParseToFloat(1F));
            AssertEqual(-1234F, "1,234-".ParseToFloat(NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign, null));
            AssertNull("AF".ParseToFloat(NumberStyles.AllowDecimalPoint, null));
            AssertEqual(1F, "AF".ParseToFloat(NumberStyles.AllowDecimalPoint, null, 1F));
            AssertEqual(1234.567F, "1,234.567".ParseToFloat(NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat, 1F));

            AssertTrue(double.Epsilon >= double.MaxValue - "1.7976931348623157E+308".ParseToDouble());
            AssertEqual(-12.345D, "\t -12.345\r \n".ParseToDouble());
            AssertEqual(null, "abc".ParseToDouble());
            AssertEqual(double.PositiveInfinity, "1.9976931348623157E+308".ParseToDouble());
            AssertEqual(1D, "abcdef".ParseToDouble(1D));
            AssertEqual(-15.666D, "-15.666".ParseToDouble(1D));
            AssertEqual(-1234D, "1,234-".ParseToDouble(NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign, null));
            AssertNull("AF".ParseToDouble(NumberStyles.AllowDecimalPoint, null));
            AssertEqual(1D, "AF".ParseToDouble(NumberStyles.AllowDecimalPoint, null, 1D));
            AssertEqual(1234.567D, "1,234.567".ParseToDouble(NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat, 1D));

            AssertEqual(10M, "10".ParseToDecimal());
            AssertEqual(-12.345M, "\t -12.345\r \n".ParseToDecimal());
            AssertNull("9999999999999999999999999999999999999999".ParseToDecimal());
            AssertEqual(1M, "abcdef".ParseToDecimal(1M));
            AssertEqual(-15.666M, "-15.666".ParseToDecimal(1M));
            AssertEqual(-1234M, "1,234-".ParseToDecimal(NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign, null));
            AssertNull("AF".ParseToDecimal(NumberStyles.AllowDecimalPoint, null));
            AssertEqual(1M, "AF".ParseToDecimal(NumberStyles.AllowDecimalPoint, null, 1M));
            AssertEqual(1234.567M, "1,234.567".ParseToDecimal(NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture.NumberFormat, 1M));

            AssertEqual(new DateTime(1970, 1, 1), "1970/1/1".ParseToDateTime());
            AssertEqual(new DateTime(2018, 11, 26, 1, 23, 45, 666, DateTimeKind.Utc).ToLocalTime(), "\t 2018-11-26T01:23:45.666Z\r \n".ParseToDateTime());
            AssertNull("Thursday".ParseToDateTime());
            AssertEqual(new DateTime(1970, 1, 1), "1970/1/1".ParseToDateTime(new DateTime(9999, 12, 31)));
            AssertEqual(new DateTime(1970, 1, 1), "-1/1/1".ParseToDateTime(new DateTime(1970, 1, 1)));
            AssertEqual(new DateTime(2018, 11, 26, 1, 23, 45, 666, DateTimeKind.Utc).ToLocalTime(), "2018-11-26 01:23:45.666".ParseToDateTime(DateTimeStyles.AssumeUniversal, null));
            AssertEqual(new DateTime(2018, 11, 26, 1, 23, 45, 666), "2018-11-26 01:23:45.666".ParseToDateTime(DateTimeStyles.AssumeLocal, null));
            AssertNull("YYYY/MM/DD".ParseToDateTime(DateTimeStyles.AssumeLocal, null));
            AssertEqual(new DateTime(1970, 1, 1), "YYYY/MM/DD".ParseToDateTime(DateTimeStyles.AssumeLocal, null, new DateTime(1970, 1, 1)));
            AssertEqual(new DateTime(2001, 11, 12), "2001/11/12".ParseToDateTime(DateTimeStyles.AssumeLocal, null, new DateTime(1970, 1, 1)));

            CultureInfo.CurrentCulture = new CultureInfo(currentCultureName);
        }

        private void AssertEqual<T>(T expected, T actual)
            => actual.Should().BeEquivalentTo(expected);

        private void AssertNull<T>(T value)
            => value.Should().BeNull();

        private void AssertTrue(bool? value)
            => value.Should().BeTrue();

        private void AssertFalse(bool? value)
            => value.Should().BeFalse();
    }
}