using System;

namespace Org.BouncyCastle.Crypto
{
    internal class MaxBytesExceededException
		: CryptoException
	{
		public MaxBytesExceededException()
		{
		}

		public MaxBytesExceededException(
			string message)
			: base(message)
		{
		}

		public MaxBytesExceededException(
			string		message,
			Exception	e)
			: base(message, e)
		{
		}
	}
}
