using System;
using System.Collections;
using System.Collections.Generic;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Security
{
    public sealed class ParameterUtilities
    {
        private ParameterUtilities()
        {
        }

        private static readonly IDictionary<string, string> algorithms = new Dictionary<string, string>();
        private static readonly IDictionary<string, int> basicIVSizes = new Dictionary<string, int>();

        static ParameterUtilities()
        {
            AddAlgorithm("AES",
                "AESWRAP");
            AddAlgorithm("AES128",
                "2.16.840.1.101.3.4.2");
            AddAlgorithm("AES192",
                "2.16.840.1.101.3.4.22");
            AddAlgorithm("AES256",
                "2.16.840.1.101.3.4.42");
            AddAlgorithm("BLOWFISH",
                "1.3.6.1.4.1.3029.1.2");
            AddAlgorithm("CAMELLIA",
                "CAMELLIAWRAP");
            AddAlgorithm("CAMELLIA128");
            AddAlgorithm("CAMELLIA192");
            AddAlgorithm("CAMELLIA256");
            AddAlgorithm("CAST5",
                "1.2.840.113533.7.66.10");
            AddAlgorithm("CAST6");
            AddAlgorithm("DES");
            AddAlgorithm("DESEDE",
                "DESEDEWRAP",
                "TDEA");
            AddAlgorithm("DESEDE3");
            AddAlgorithm("GOST28147",
                "GOST",
                "GOST-28147");
            AddAlgorithm("HC128");
            AddAlgorithm("HC256");
            AddAlgorithm("IDEA",
                "1.3.6.1.4.1.188.7.1.1.2");
            AddAlgorithm("NOEKEON");
            AddAlgorithm("RC2");
            AddAlgorithm("RC4",
                "ARC4",
                "1.2.840.113549.3.4");
            AddAlgorithm("RC5",
                "RC5-32");
            AddAlgorithm("RC5-64");
            AddAlgorithm("RC6");
            AddAlgorithm("RIJNDAEL");
            AddAlgorithm("SALSA20");
            AddAlgorithm("SEED");
            AddAlgorithm("SERPENT");
            AddAlgorithm("SKIPJACK");
            AddAlgorithm("SM4");
            AddAlgorithm("TEA");
            AddAlgorithm("THREEFISH-256");
            AddAlgorithm("THREEFISH-512");
            AddAlgorithm("THREEFISH-1024");
            AddAlgorithm("TNEPRES");
            AddAlgorithm("TWOFISH");
            AddAlgorithm("VMPC");
            AddAlgorithm("VMPC-KSA3");
            AddAlgorithm("XTEA");

            AddBasicIVSizeEntries(8, "BLOWFISH", "DES", "DESEDE", "DESEDE3");
            AddBasicIVSizeEntries(16, "AES", "AES128", "AES192", "AES256",
                "CAMELLIA", "CAMELLIA128", "CAMELLIA192", "CAMELLIA256",
                "NOEKEON", "SEED", "SM4");

            // TODO These algorithms support an IV
            // but JCE doesn't seem to provide an AlgorithmParametersGenerator for them
            // "RIJNDAEL", "SKIPJACK", "TWOFISH"
        }

        private static void AddAlgorithm(
            string			canonicalName,
            params object[]	aliases)
        {
            algorithms[canonicalName] = canonicalName;

            foreach (object alias in aliases)
            {
                algorithms[alias.ToString()] = canonicalName;
            }
        }

        private static void AddBasicIVSizeEntries(int size, params string[] algorithms)
        {
            foreach (string algorithm in algorithms)
            {
                basicIVSizes.Add(algorithm, size);
            }
        }

        public static string GetCanonicalAlgorithmName(
            string algorithm)
        {
            return (string) algorithms[algorithm.ToUpperInvariant()];
        }

        public static KeyParameter CreateKeyParameter(
            string	algorithm,
            byte[]	keyBytes)
        {
            return CreateKeyParameter(algorithm, keyBytes, 0, keyBytes.Length);
        }

        public static KeyParameter CreateKeyParameter(
            string	algorithm,
            byte[]	keyBytes,
            int		offset,
            int		length)
        {
            if (algorithm == null)
                throw new ArgumentNullException("algorithm");

            string canonical = GetCanonicalAlgorithmName(algorithm);

            if (canonical == null)
                throw new SecurityUtilityException("Algorithm " + algorithm + " not recognised.");

            if (canonical == "DES")
                return new DesParameters(keyBytes, offset, length);

            if (canonical == "DESEDE" || canonical =="DESEDE3")
                return new DesEdeParameters(keyBytes, offset, length);

            if (canonical == "RC2")
                return new RC2Parameters(keyBytes, offset, length);

            return new KeyParameter(keyBytes, offset, length);
        }

        private static int FindBasicIVSize(
            string canonicalName)
        {
            if (!basicIVSizes.ContainsKey(canonicalName))
                return -1;

            return (int)basicIVSizes[canonicalName];
        }
    }
}
