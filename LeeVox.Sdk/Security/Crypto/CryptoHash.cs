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

		public (byte[] hash, byte[] salt) BCrypt(string password, int cost = BCryptCost)
			=> BCrypt(Encoding.UTF8.GetBytes(password), cost);
		public (byte[] hash, byte[] salt) BCrypt(byte[] password, int cost = BCryptCost)
		{
			var salt = GenerateBCryptSalt();
			var hash = Generators.BCrypt.Generate(password, salt, cost);
			return (hash, salt);
		}

		public byte[] BCrypt(string password, string salt, int cost = BCryptCost)
			=> Generators.BCrypt.Generate(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(salt), cost);
		public byte[] BCrypt(string password, byte[] salt, int cost = BCryptCost)
			=> Generators.BCrypt.Generate(Encoding.UTF8.GetBytes(password), salt, cost);
		public byte[] BCrypt(byte[] password, byte[] salt, int cost = BCryptCost)
			=> Generators.BCrypt.Generate(password, salt, cost);

#endregion

#region OpenBSD BCrypt

		public string OpenBsdBCrypt(string password, int cost = BCryptCost)
			=> Generators.OpenBsdBCrypt.Generate(password.ToCharArray(), GenerateBCryptSalt(), cost);
		public string OpenBsdBCrypt(byte[] password, int cost = BCryptCost)
			=> Generators.OpenBsdBCrypt.Generate(Encoding.UTF8.GetChars(password), GenerateBCryptSalt(), cost);
		public string OpenBsdBCrypt(char[] password, int cost = BCryptCost)
			=> Generators.OpenBsdBCrypt.Generate(password, GenerateBCryptSalt(), cost);

		public string OpenBsdBCrypt(string password, string salt, int cost = BCryptCost)
			=> Generators.OpenBsdBCrypt.Generate(password.ToCharArray(), Encoding.UTF8.GetBytes(salt), cost);
		public string OpenBsdBCrypt(string password, byte[] salt, int cost = BCryptCost)
			=> Generators.OpenBsdBCrypt.Generate(password.ToCharArray(), salt, cost);
		public string OpenBsdBCrypt(byte[] password, byte[] salt, int cost = BCryptCost)
			=> Generators.OpenBsdBCrypt.Generate(Encoding.UTF8.GetChars(password), salt, cost);
		public string OpenBsdBCrypt(char[] password, byte[] salt, int cost = BCryptCost)
			=> Generators.OpenBsdBCrypt.Generate(password, salt, cost);

		public bool ValidateOpenBsdBCrypt(string bcryptString, string password)
			=> Generators.OpenBsdBCrypt.CheckPassword(bcryptString, password.ToCharArray());
		public bool ValidateOpenBsdBCrypt(string bcryptString, char[] password)
			=> Generators.OpenBsdBCrypt.CheckPassword(bcryptString, password);

#endregion

		private byte[] GenerateBCryptSalt()
		{
			var random = new CryptoRandom();
			return random.NextBytes(BCryptSaltLength);
		}
	}
}