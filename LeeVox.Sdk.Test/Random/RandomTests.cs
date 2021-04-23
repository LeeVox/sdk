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
        private IRandom random;
        private readonly ITestOutputHelper output;

        public RandomTests(ITestOutputHelper _output)
        {
            output = _output;
            random = new Random();
        }

        [Fact]
        public void PrintRandomIntegers()
        {
            output.WriteLine("NextInt()");
            for (var i = 0; i < 30; i++)
            {
                output.WriteLine(random.NextInt().ToString());
            }

            output.WriteLine("NextInt(10)");
            for (var i = 0; i < 30; i++)
            {
                output.WriteLine(random.NextInt(10).ToString());
            }

            output.WriteLine("NextInt(-9999, 9999)");
            for (var i = 0; i < 30; i++)
            {
                output.WriteLine(random.NextInt(-9999, 9999).ToString());
            }
        }
    }
}