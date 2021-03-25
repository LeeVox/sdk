using System;
using System.Security.Cryptography;
using System.Text;
using LeeVox.Sdk;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace LeeVox.Sdk.Test
{
    public class SecureRandomTests
    {
        private readonly ITestOutputHelper output;

        public SecureRandomTests(ITestOutputHelper _output)
        {
            output = _output;
        }

        [Fact]
        public void TestRandomDouble()
        {
            for (var i = 0; i < 20; i++)
            {
                double actualResult = 0;
                this.Invoking(x => actualResult = SecureRandom.NextDouble())
                    .Should().NotThrow();
                output.WriteLine(actualResult.ToString());
            }
        }
    }
}