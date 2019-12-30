using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Generators = Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Digests;

namespace LeeVox.Sdk
{
	public sealed class CryptoHash
	{
#region PBKDF2
		public const int Pbkdf2_Sha1_Iterations = 300_000;
		public const int Pbkdf2_Sha256_Iterations = 200_000;
		public const int Pbkdf2_Sha512_Iterations = 100_000;
		private const int Pbkdf2_Sha1_Length = 160; // in bit
		private const int Pbkdf2_Sha256_Length = 256; // in bit
		private const int Pbkdf2_Sha512_Length = 512; // in bit
		private const int Pbkdf2SaltLength = 16; // in byte

#region PBKDF2 - SHA1

		public (byte[] hash, byte[] salt) Pbkdf2_Sha1(string password, int iterations = Pbkdf2_Sha1_Iterations)
			=> Pbkdf2_Sha1(Encoding.UTF8.GetBytes(password), iterations);
		public (byte[] hash, byte[] salt) Pbkdf2_Sha1(byte[] password, int iterations = Pbkdf2_Sha1_Iterations)
		{
			var salt = GenerateSalt(Pbkdf2SaltLength);
			var hash = Pbkdf2_Sha1(password, salt, iterations);
			return (hash, salt);
		}

		public byte[] Pbkdf2_Sha1(string password, string salt, int iterations = Pbkdf2_Sha1_Iterations)
			=> Pbkdf2_Sha1(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(salt), iterations);
		public byte[] Pbkdf2_Sha1(string password, byte[] salt, int iterations = Pbkdf2_Sha1_Iterations)
			=> Pbkdf2_Sha1(Encoding.UTF8.GetBytes(password), salt, iterations);
		public byte[] Pbkdf2_Sha1(byte[] password, byte[] salt, int iterations = Pbkdf2_Sha1_Iterations)
		{
			var hasher = new Generators.Pkcs5S2ParametersGenerator(new Sha1Digest());
			hasher.Init(password, salt, iterations);
			var hash = (hasher.GenerateDerivedMacParameters(Pbkdf2_Sha1_Length) as KeyParameter).GetKey();
			return hash;
		}

#endregion

#region PBKDF2 - SHA256

		public (byte[] hash, byte[] salt) Pbkdf2_Sha256(string password, int iterations = Pbkdf2_Sha256_Iterations)
			=> Pbkdf2_Sha256(Encoding.UTF8.GetBytes(password), iterations);
		public (byte[] hash, byte[] salt) Pbkdf2_Sha256(byte[] password, int iterations = Pbkdf2_Sha256_Iterations)
		{
			var salt = GenerateSalt(Pbkdf2SaltLength);
			var hash = Pbkdf2_Sha256(password, salt, iterations);
			return (hash, salt);
		}

		public byte[] Pbkdf2_Sha256(string password, string salt, int iterations = Pbkdf2_Sha256_Iterations)
			=> Pbkdf2_Sha256(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(salt), iterations);
		public byte[] Pbkdf2_Sha256(string password, byte[] salt, int iterations = Pbkdf2_Sha256_Iterations)
			=> Pbkdf2_Sha256(Encoding.UTF8.GetBytes(password), salt, iterations);
		public byte[] Pbkdf2_Sha256(byte[] password, byte[] salt, int iterations = Pbkdf2_Sha256_Iterations)
		{
			var hasher = new Generators.Pkcs5S2ParametersGenerator(new Sha256Digest());
			hasher.Init(password, salt, iterations);
			var hash = (hasher.GenerateDerivedMacParameters(Pbkdf2_Sha256_Length) as KeyParameter).GetKey();
			return hash;
		}

#endregion

#region PBKDF2 - SHA512

		public (byte[] hash, byte[] salt) Pbkdf2_Sha512(string password, int iterations = Pbkdf2_Sha512_Iterations)
			=> Pbkdf2_Sha512(Encoding.UTF8.GetBytes(password), iterations);
		public (byte[] hash, byte[] salt) Pbkdf2_Sha512(byte[] password, int iterations = Pbkdf2_Sha512_Iterations)
		{
			var salt = GenerateSalt(Pbkdf2SaltLength);
			var hash = Pbkdf2_Sha512(password, salt, iterations);
			return (hash, salt);
		}

		public byte[] Pbkdf2_Sha512(string password, string salt, int iterations = Pbkdf2_Sha512_Iterations)
			=> Pbkdf2_Sha512(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(salt), iterations);
		public byte[] Pbkdf2_Sha512(string password, byte[] salt, int iterations = Pbkdf2_Sha512_Iterations)
			=> Pbkdf2_Sha512(Encoding.UTF8.GetBytes(password), salt, iterations);
		public byte[] Pbkdf2_Sha512(byte[] password, byte[] salt, int iterations = Pbkdf2_Sha512_Iterations)
		{
			var hasher = new Generators.Pkcs5S2ParametersGenerator(new Sha512Digest());
			hasher.Init(password, salt, iterations);
			var hash = (hasher.GenerateDerivedMacParameters(Pbkdf2_Sha512_Length) as KeyParameter).GetKey();
			return hash;
		}

#endregion

#endregion

#region BCrypt

		public const int BCryptCost = 12;
		public const int BCryptSaltLength = 16; // in byte

		public string BCrypt(string password, int cost = BCryptCost)
			=> Generators.OpenBsdBCrypt.Generate(password.ToCharArray(), GenerateSalt(BCryptSaltLength), cost);
		public string BCrypt(byte[] password, int cost = BCryptCost)
			=> Generators.OpenBsdBCrypt.Generate(Encoding.UTF8.GetChars(password), GenerateSalt(BCryptSaltLength), cost);
		public string BCrypt(char[] password, int cost = BCryptCost)
			=> Generators.OpenBsdBCrypt.Generate(password, GenerateSalt(BCryptSaltLength), cost);

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

#region SCrypt

		public const int SCryptCost = 1 << 15;
		public const int SCryptBlockSize = 8;
		public const int SCryptParallelization = 1;
		public const int SCryptOutputLength = 32;
		public const int SCryptSaltLength = 16; // in byte

		public (byte[] hash, byte[] salt) SCrypt(string password, int cost = SCryptCost, int blockSize = SCryptBlockSize, int parallelization = SCryptParallelization, int outputLength = SCryptOutputLength)
			=> SCrypt(Encoding.UTF8.GetBytes(password), cost, blockSize, parallelization, outputLength);
		public (byte[] hash, byte[] salt) SCrypt(byte[] password, int cost = SCryptCost, int blockSize = SCryptBlockSize, int parallelization = SCryptParallelization, int outputLength = SCryptOutputLength)
		{
			var salt = GenerateSalt(SCryptSaltLength);
			var hash = Generators.SCrypt.Generate(password, salt, cost, blockSize, parallelization, outputLength);
			return (hash, salt);
		}

		public byte[] SCrypt(string password, string salt, int cost = SCryptCost, int blockSize = SCryptBlockSize, int parallelization = SCryptParallelization, int outputLength = SCryptOutputLength)
			=> Generators.SCrypt.Generate(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(salt), cost, blockSize, parallelization, outputLength);
		public byte[] SCrypt(string password, byte[] salt, int cost = SCryptCost, int blockSize = SCryptBlockSize, int parallelization = SCryptParallelization, int outputLength = SCryptOutputLength)
			=> Generators.SCrypt.Generate(Encoding.UTF8.GetBytes(password), salt, cost, blockSize, parallelization, outputLength);
		public byte[] SCrypt(byte[] password, byte[] salt, int cost = SCryptCost, int blockSize = SCryptBlockSize, int parallelization = SCryptParallelization, int outputLength = SCryptOutputLength)
			=> Generators.SCrypt.Generate(password, salt, cost, blockSize, parallelization, outputLength);

#endregion

		private byte[] GenerateSalt(int length)
		{
			var random = new CryptoRandom();
			return random.NextBytes(length);
		}
	}
}