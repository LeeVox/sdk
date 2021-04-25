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
            output.WriteLine("NextShort()");
            for (var i = 0; i < 30; i++)
            {
                output.WriteLine(random.NextShort(100).ToString());
            }

            output.WriteLine("NextInt()");
            for (var i = 0; i < 30; i++)
            {
                output.WriteLine(random.NextInt(200).ToString());
            }

            output.WriteLine("NextLong()");
            for (var i = 0; i < 30; i++)
            {
                output.WriteLine(random.NextLong(300).ToString());
            }

            output.WriteLine("NextString()");
            for (var i = 0; i < 30; i++)
            {
                output.WriteLine(random.NextString(60).ToString());
            }
        }
    }
}