using LeeVox.Sdk.Lib;
using FluentAssertions;
using Xunit;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace LeeVox.Sdk.Test.Lib
{
    public class XoShiRo256StarStarTests
    {
        public XoShiRo256StarStarTests()
        {
        }

        [Fact]
        public void TestSuiteFromApache()
        {
            // this is seed from tests of Apache' Commons-RNG
            // https://gitbox.apache.org/repos/asf?p=commons-rng.git;a=blob;f=commons-rng-core/src/test/java/org/apache/commons/rng/core/source64/XoShiRo256StarStarTest.java;h=5c7abdf4afb860e16b10a0d92a873c7ae57805f7;hb=HEAD
            var random = new XoShiRo256StarStar(0x012de1babb3c4104L, 0xa5a818b8fc5aa503L, 0xb124ea2b701f4993L, 0x18e0374933d8c782L);
            ulong[] EXPECTED_SEQUENCE = {
                0x462c422df780c48eL, 0xa82f1f6031c183e6L, 0x8a113820e8d2ca8dL, 0x1ac7023a26534958L,
                0xac8e41d0101e109cL, 0x46e34bc13edd63c4L, 0x3a26776adcd665c3L, 0x9ac6c9bea8fc518cL,
                0x1cef0aa07cc738c4L, 0x5136a5f070244b1dL, 0x12e2e12edee691ffL, 0x28942b20799b71b4L,
                0xbe2d5c4267af2469L, 0x9dbec53728b2b9b7L, 0x893cf86611b14a96L, 0x712c226c79f066d6L,
                0x1a8a11ef81d2ac60L, 0x28171739ef8f2f46L, 0x073baa93525f8b1dL, 0xa73c7f3cb93df678L,
                0xae5633ab977a3531L, 0x25314041ba2d047eL, 0x31e6819dea142672L, 0x9479fa694f4c2965L,
                0xde5b771a968472b7L, 0xf0501965d9eeb4a3L, 0xef25a2a8ec90b911L, 0x1f58f71a75392659L,
                0x32d9547188781f3cL, 0x2d13b036ccf65bc0L, 0x289f9cc038dd952fL, 0x6ae2d5231e50824aL,
                0x75651acfb42ab170L, 0x7369aeb4f10056cfL, 0x0297ed632a97cf75L, 0x19f534c778015b72L,
                0x5d1d111c5ff182a8L, 0x861cdfe8e8014b96L, 0x07c6071e08112c83L, 0x15601582dcf4e4feL,
            };

            for (var i = 0; i < EXPECTED_SEQUENCE.Length; i++)
            {
                random.NextULong().Should().Be(EXPECTED_SEQUENCE[i], $"At sequence {i}, random should generate ulong value {EXPECTED_SEQUENCE[i]}");
            }
        }

        [Fact]
        public void Test()
        {
            XoShiRo256StarStar random = null;
            var seed = new List<ulong>();

            uint? uintValue; ulong? ulongValue; float? floatValue; double? doubleValue; byte? byteValue;

            var lines = File.ReadAllLines("Fixtures/xoshiro256starstar.out")
                .Select(line => line.Trim())
                .ToArray();

            for (var i = 0; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]) || lines[i].StartsWith("#") || lines[i].StartsWith("//"))
                {
                    continue;
                }
                else if (lines[i].StartsWith("Seed"))
                {
                    seed = new List<ulong>();

                    while ((ulongValue = lines[++i].Replace("0x", "").ParseToULong(NumberStyles.HexNumber, CultureInfo.CurrentCulture)) != null)
                    {
                        seed.Add(ulongValue.Value);
                    }
                }
                else if (lines[i].StartsWith("Integers"))
                {
                    random = new XoShiRo256StarStar(seed.ToArray());

                    while ((uintValue = lines[++i].Replace("0x", "").ParseToUInt(NumberStyles.HexNumber, CultureInfo.CurrentCulture)) != null)
                    {
                        random.NextUInt().Should().Be(uintValue.Value, $"At line {i+1}, random should generate uint value {uintValue}");
                    }
                }
                else if (lines[i].StartsWith("Longs"))
                {
                    random = new XoShiRo256StarStar(seed.ToArray());

                    while ((ulongValue = lines[++i].Replace("0x", "").ParseToULong(NumberStyles.HexNumber, CultureInfo.CurrentCulture)) != null)
                    {
                        random.NextULong().Should().Be(ulongValue.Value, $"At line {i+1}, random should generate ulong value {ulongValue}");
                    }
                }
                else if (lines[i].StartsWith("Floats"))
                {
                    random = new XoShiRo256StarStar(seed.ToArray());

                    while ((floatValue = lines[++i].ParseToFloat()) != null)
                    {
                        random.NextFloat().Should().BeApproximately(floatValue.Value, float.Epsilon, $"At line {i+1}, random should generate float value {floatValue}");
                    }
                }
                else if (lines[i].StartsWith("Doubles"))
                {
                    random = new XoShiRo256StarStar(seed.ToArray());

                    while ((doubleValue = lines[++i].ParseToDouble()) != null)
                    {
                        random.NextDouble().Should().BeApproximately(doubleValue.Value, double.Epsilon, $"At line {i+1}, random should generate double value {doubleValue}");
                    }
                }
                else if (lines[i].StartsWith("Bytes"))
                {
                    random = new XoShiRo256StarStar(seed.ToArray());

                    var expectedBytes = new List<byte>();
                    while ((byteValue = lines[++i].Replace("0x", "").ParseToByte(NumberStyles.HexNumber, CultureInfo.CurrentCulture)) != null)
                    {
                        expectedBytes.Add(byteValue.Value);
                    }

                    var randomBytes = new byte[expectedBytes.Count];
                    random.FillBytes(randomBytes);
                    randomBytes.Should().BeEquivalentTo(expectedBytes);
                }
            }
        }
    }
}