using System;
using System.Security.Cryptography;
using System.Text;
using LeeVox.Sdk;
using LeeVox.Sdk.Lib;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeeVox.Sdk.Test
{
    public class RandomTests
    {
        private readonly ITestOutputHelper output;

        public RandomTests(ITestOutputHelper _output)
        {
            output = _output;
        }

        [Fact]
        public void TestRandomDouble()
        {
            var r = new XoShiRo256StarStar(0x012de1babb3c4104L, 0xa5a818b8fc5aa503L, 0xb124ea2b701f4993L, 0x18e0374933d8c782L);
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

            foreach (var num in EXPECTED_SEQUENCE)
            {
                Assert.Equal<ulong>(num, r.NextULong());
            }
        }
    }
}