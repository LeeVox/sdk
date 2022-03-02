using System;
using FluentAssertions;
using Xunit;
using System.Collections.Generic;

namespace LeeVox.Sdk.Test
{
    public class RandomTests
    {
        private static Random random;
        private static SecureRandom secureRandom;

        public RandomTests()
        {
            random = new Random();
            secureRandom = new SecureRandom();
        }

        public static object[][] TestData = new object[][]
        {
            new object[] { 00, () => random.NextShort(), 1000, 0.9f },
            new object[] { 01, () => random.NextShort(short.MaxValue), 1000, 0.9f },
            new object[] { 02, () => random.NextShort(short.MinValue, short.MaxValue), 1000, 0.9f },
            new object[] { 03, () => secureRandom.NextShort(), 1000, 0.95f },
            new object[] { 04, () => secureRandom.NextShort(short.MaxValue), 1000, 0.95f },
            new object[] { 05, () => secureRandom.NextShort(short.MinValue, short.MaxValue), 1000, 0.95f },

            new object[] { 06, () => random.NextUShort(), 1000, 0.9f },
            new object[] { 07, () => random.NextUShort(ushort.MaxValue), 1000, 0.9f },
            new object[] { 08, () => random.NextUShort(ushort.MinValue, ushort.MaxValue), 1000, 0.9f },
            new object[] { 09, () => secureRandom.NextUShort(), 1000, 0.95f },
            new object[] { 10, () => secureRandom.NextUShort(ushort.MaxValue), 1000, 0.95f },
            new object[] { 11, () => secureRandom.NextUShort(ushort.MinValue, ushort.MaxValue), 1000, 0.95f },

            new object[] { 12, () => random.NextInt(), 1000000, 0.9f },
            new object[] { 13, () => random.NextInt(int.MaxValue), 1000000, 0.9f },
            new object[] { 14, () => random.NextInt(int.MinValue, int.MaxValue), 1000000, 0.9f },
            new object[] { 15, () => secureRandom.NextInt(), 1000000, 0.95f },
            new object[] { 16, () => secureRandom.NextInt(int.MaxValue), 1000000, 0.95f },
            new object[] { 17, () => secureRandom.NextInt(int.MinValue, int.MaxValue), 1000000, 0.95f },

            new object[] { 18, () => random.NextUInt(), 1000000, 0.9f },
            new object[] { 19, () => random.NextUInt(uint.MaxValue), 1000000, 0.9f },
            new object[] { 20, () => random.NextUInt(uint.MinValue, uint.MaxValue), 1000000, 0.9f },
            new object[] { 21, () => secureRandom.NextUInt(), 1000000, 0.95f },
            new object[] { 22, () => secureRandom.NextUInt(uint.MaxValue), 1000000, 0.95f },
            new object[] { 23, () => secureRandom.NextUInt(uint.MinValue, uint.MaxValue), 1000000, 0.95f },

            new object[] { 12, () => random.NextLong(), 1000000, 0.9f },
            new object[] { 13, () => random.NextLong(long.MaxValue), 1000000, 0.9f },
            new object[] { 14, () => random.NextLong(long.MinValue, long.MaxValue), 1000000, 0.9f },
            new object[] { 15, () => secureRandom.NextLong(), 1000000, 0.95f },
            new object[] { 16, () => secureRandom.NextLong(long.MaxValue), 1000000, 0.95f },
            new object[] { 17, () => secureRandom.NextLong(long.MinValue, long.MaxValue), 1000000, 0.95f },

            new object[] { 18, () => random.NextULong(), 1000000, 0.9f },
            new object[] { 19, () => random.NextULong(ulong.MaxValue), 1000000, 0.9f },
            new object[] { 20, () => random.NextULong(ulong.MinValue, ulong.MaxValue), 1000000, 0.9f },
            new object[] { 21, () => secureRandom.NextULong(), 1000000, 0.95f },
            new object[] { 22, () => secureRandom.NextULong(ulong.MaxValue), 1000000, 0.95f },
            new object[] { 23, () => secureRandom.NextULong(ulong.MinValue, ulong.MaxValue), 1000000, 0.95f },

            new object[] { 24, () => random.NextFloat(), 1000000, 0.9f },
            new object[] { 25, () => random.NextFloat(float.MinValue, float.MaxValue), 1000000, 0.9f },
            new object[] { 26, () => secureRandom.NextFloat(), 1000000, 0.95f },
            new object[] { 27, () => secureRandom.NextFloat(float.MinValue, float.MaxValue), 1000000, 0.95f },

            new object[] { 28, () => random.NextDouble(), 1000000, 0.9f },
            new object[] { 29, () => random.NextDouble(double.MinValue, double.MaxValue), 1000000, 0.9f },
            new object[] { 30, () => secureRandom.NextDouble(), 1000000, 0.95f },
            new object[] { 31, () => secureRandom.NextDouble(double.MinValue, double.MaxValue), 1000000, 0.95f },

            new object[] { 32, () => random.NextDecimal(), 1000000, 0.9f },
            new object[] { 33, () => random.NextDecimal(decimal.MinValue, decimal.MaxValue), 1000000, 0.9f },
            new object[] { 34, () => secureRandom.NextDecimal(), 1000000, 0.95f },
            new object[] { 35, () => secureRandom.NextDecimal(decimal.MinValue, decimal.MaxValue), 1000000, 0.95f },

            new object[] { 36, () => random.NextDateTime(), 1000000, 0.9f },
            new object[] { 37, () => random.NextDateTime(DateTime.MinValue, DateTime.MaxValue), 1000000, 0.9f },
            new object[] { 38, () => secureRandom.NextDateTime(), 1000000, 0.95f },
            new object[] { 39, () => secureRandom.NextDateTime(DateTime.MinValue, DateTime.MaxValue), 1000000, 0.95f },

            new object[] { 40, () => random.NextString(100), 1000000, 0.9f },
            new object[] { 41, () => secureRandom.NextString(100), 1000000, 0.95f },
        };

        [Theory]
        [MemberData(nameof(TestData))]
        internal void Test<T>(int testDataIndex, Func<T> fnRandom, int count, float threshold)
        {
            var set = new HashSet<T>();
            for (var i = 0; i < count; i++)
                set.Add(fnRandom());
            set.Count.Should().BeGreaterOrEqualTo((int)(count*threshold), "(test data index: {0})", testDataIndex);
        }

        public static object[][] TestData_Small = new object[][]
        {
            new object[] { 00, () => random.NextBool(), 100, 0.8f },
            new object[] { 01, () => secureRandom.NextBool(), 100, 0.8f },

            new object[] { 02, () => random.NextByte(), 1000, 0.9f },
            new object[] { 03, () => random.NextByte(byte.MaxValue), 1000, 0.9f },
            new object[] { 04, () => random.NextByte(byte.MinValue, byte.MaxValue), 1000, 0.9f },
            new object[] { 05, () => secureRandom.NextByte(), 1000, 0.9f },
            new object[] { 06, () => secureRandom.NextByte(byte.MaxValue), 1000, 0.9f },
            new object[] { 07, () => secureRandom.NextByte(byte.MinValue, byte.MaxValue), 1000, 0.9f },

            new object[] { 08, () => random.NextSByte(), 1000, 0.9f },
            new object[] { 09, () => random.NextSByte(sbyte.MaxValue), 1000, 0.9f },
            new object[] { 10, () => random.NextSByte(sbyte.MinValue, sbyte.MaxValue), 1000, 0.9f },
            new object[] { 11, () => secureRandom.NextSByte(), 1000, 0.9f },
            new object[] { 12, () => secureRandom.NextSByte(sbyte.MaxValue), 1000, 0.9f },
            new object[] { 13, () => secureRandom.NextSByte(sbyte.MinValue, sbyte.MaxValue), 1000, 0.9f },

            new object[] { 14, () => random.NextChar(), 1000, 0.9f },
            new object[] { 15, () => random.NextChar(char.MinValue, char.MaxValue), 1000, 0.9f },
            new object[] { 16, () => secureRandom.NextChar(), 1000, 0.9f },
            new object[] { 17, () => secureRandom.NextChar(char.MinValue, char.MaxValue), 1000, 0.9f },
        };

        [Theory]
        [MemberData(nameof(TestData_Small))]
        internal void TestSmallValue<T>(int testDataIndex, Func<T> fnRandom, int count, float threshold)
        {
            var set = new HashSet<(T, T, T, T, T, T, T, T)>();
            for (var i = 0; i < count; i++)
            {
                var tuple = (fnRandom(), fnRandom(), fnRandom(), fnRandom(), fnRandom(), fnRandom(), fnRandom(), fnRandom());
                set.Add(tuple);
            }
            set.Count.Should().BeGreaterOrEqualTo((int)(count*threshold), "(test data index: {0})", testDataIndex);
        }
    }
}