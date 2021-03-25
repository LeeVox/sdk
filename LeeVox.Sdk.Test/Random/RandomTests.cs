using System;
using System.Security.Cryptography;
using System.Text;
using LeeVox.Sdk;
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
            var random = new Random<double>();
            for (var i = 0; i < 20; i++)
            {
                double actualResult = 0;
                this.Invoking(x => actualResult = random.Next())
                    .Should().NotThrow();
                output.WriteLine(actualResult.ToString());
            }

            var random2 = new Random<long>();
            for (var i = 0; i < 20; i++)
            {
                long actualResult = 0;
                this.Invoking(x => actualResult = random2.Next())
                    .Should().NotThrow();
                output.WriteLine(actualResult.ToString());
            }
        }
    }
}