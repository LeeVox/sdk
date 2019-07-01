using System;
using System.Security.Cryptography;

namespace LeeVox.Sdk
{
	public sealed class CryptoRandom
	{
        public byte[] NextBytes(int length)
		{
			if (length <= 0)
				throw new ArgumentException("Length is not valid.", nameof(length));

			var result = new byte[length];
			using (var generator = RandomNumberGenerator.Create())
			{
				generator.GetBytes(result);
			}
			return result;
		}
	}
}