using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Generators = Org.BouncyCastle.Crypto.Generators;

namespace LeeVox.Sdk
{
	public sealed class CryptoHash
	{
		public const int BCryptCost = 12;
		public const int BCryptSaltLength = 16;

#region BCrypt

		public string BCrypt(string password, int cost = BCryptCost)
			=> Generators.OpenBsdBCrypt.Generate(password.ToCharArray(), GenerateBCryptSalt(), cost);
		public string BCrypt(byte[] password, int cost = BCryptCost)
			=> Generators.OpenBsdBCrypt.Generate(Encoding.UTF8.GetChars(password), GenerateBCryptSalt(), cost);
		public string BCrypt(char[] password, int cost = BCryptCost)
			=> Generators.OpenBsdBCrypt.Generate(password, GenerateBCryptSalt(), cost);

		public string BCrypt(string password, string salt, int cost = BCryptCost)
			=> Generators.OpenBsdBCrypt.Generate(password.ToCharArray(), Encoding.UTF8.GetBytes(salt), cost);
		public string BCrypt(string password, byte[] salt, int cost = BCryptCost)
			=> Generators.OpenBsdBCrypt.Generate(password.ToCharArray(), salt, cost);
		public string BCrypt(byte[] password, byte[] salt, int cost = BCryptCost)
			=> Generators.OpenBsdBCrypt.Generate(Encoding.UTF8.GetChars(password), salt, cost);
		public string BCrypt(char[] password, byte[] salt, int cost = BCryptCost)
			=> Generators.OpenBsdBCrypt.Generate(password, salt, cost);

		public bool ValidateBCrypt(string bcryptString, string password)
			=> Generators.OpenBsdBCrypt.CheckPassword(bcryptString, password.ToCharArray());
		public bool ValidateBCrypt(string bcryptString, char[] password)
			=> Generators.OpenBsdBCrypt.CheckPassword(bcryptString, password);

#endregion

		private byte[] GenerateBCryptSalt()
		{
			var random = new CryptoRandom();
			return random.NextBytes(BCryptSaltLength);
		}
	}
}