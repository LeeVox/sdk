using System;
using System.Collections.Generic;
using System.Linq;

namespace LeeVox.Sdk
{
    public static class Base32
    {
        private static readonly char PaddingChar = '=';
        private static readonly char[] Base32LowerCaseChars = Enumerable.Concat(GetCharsRange('a', 'z'), GetCharsRange('2', '7')).ToArray();
        private static readonly char[] Base32Chars = Enumerable.Concat(GetCharsRange('A', 'Z'), GetCharsRange('2', '7')).ToArray();
        private static readonly char[] Base32ExtendedHexLowerCaseChars = Enumerable.Concat(GetCharsRange('0', '9'), GetCharsRange('a', 'v')).ToArray();
        private static readonly char[] Base32ExtendedHexChars = Enumerable.Concat(GetCharsRange('0', '9'), GetCharsRange('A', 'V')).ToArray();
        private static readonly Dictionary<char, byte> Base32CharsLookup = Base32Chars.Concat(GetCharsRange('a', 'z'))
            .ToDictionary(c => c, c => (byte)Array.IndexOf(Base32Chars, Char.ToUpper(c)));
        private static readonly Dictionary<char, byte> Base32ExtendedHexCharsLookup = Base32ExtendedHexChars.Concat(GetCharsRange('a', 'v'))
            .ToDictionary(c => c, c => (byte)Array.IndexOf(Base32ExtendedHexChars, Char.ToUpper(c)));

        private static readonly byte[] MASKS = new byte[] { 0b0000_0000, 0b0000_0001, 0b0000_0011, 0b0000_0111, 0b0000_1111, 0b0001_1111, 0b0011_1111, 0b0111_1111, 0b1111_1111 };

        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent string representation
        // that is encoded with base-32 digits (RFC 4648)
        /// </summary>
        public static string ToBase32String(IEnumerable<byte> bytes, bool useLowerCase = false)
            => new string(EncodeBase32WithMappingChars(bytes, useLowerCase ? Base32LowerCaseChars : Base32Chars));

        /// <summary>
        /// Converts the specified string, which encodes binary data as base-32 digits (RFC 4648),
        /// to an equivalent 8-bit unsigned integer array.
        /// </summary>
        public static byte[] FromBase32String(string base32String)
            => DecodeBase32WithMappingChars(base32String, Base32CharsLookup);

        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent string representation
        /// that is encoded with base-32-extended-hex digits (RFC 4648)
        /// </summary>
        public static string ToBase32ExtendedHexString(byte[] bytes, bool useLowerCase = false)
            => new string(EncodeBase32WithMappingChars(bytes, useLowerCase ? Base32ExtendedHexLowerCaseChars : Base32ExtendedHexChars));

        /// <summary>
        /// Converts the specified string, which encodes binary data as base-32-extended-hex digits (RFC 4648),
        /// to an equivalent 8-bit unsigned integer array.
        /// </summary>
        public static byte[] FromBase32ExtendedHexString(string base32ExtendedHexString)
            => DecodeBase32WithMappingChars(base32ExtendedHexString, Base32ExtendedHexCharsLookup);

        private static char[] EncodeBase32WithMappingChars(IEnumerable<byte> bytes, char[] mappingChars)
        {
            var length = bytes.Count();
            var paddedBytes = length % 5 == 0 ? bytes : bytes.Concat(Enumerable.Repeat((byte)0, 5 - (length % 5)));
            var paddedLength = paddedBytes.Count();
            var result = new char[(paddedLength / 5) * 8];
            var resultIndex = 0;
            for (var index = 0; index < paddedLength; index += 5)
            {
                result[resultIndex++] = mappingChars[GetBits(paddedBytes.ElementAt(index), 0, 4)];
                result[resultIndex++] = mappingChars[(GetBits(paddedBytes.ElementAt(index), 5, 7) << 2) | GetBits(paddedBytes.ElementAt(index + 1), 0, 1)];
                result[resultIndex++] = mappingChars[GetBits(paddedBytes.ElementAt(index + 1), 2, 6)];
                result[resultIndex++] = mappingChars[(GetBits(paddedBytes.ElementAt(index + 1), 7, 7) << 4) | GetBits(paddedBytes.ElementAt(index + 2), 0, 3)];
                result[resultIndex++] = mappingChars[(GetBits(paddedBytes.ElementAt(index + 2), 4, 7) << 1) | GetBits(paddedBytes.ElementAt(index + 3), 0, 0)];
                result[resultIndex++] = mappingChars[GetBits(paddedBytes.ElementAt(index + 3), 1, 5)];
                result[resultIndex++] = mappingChars[(GetBits(paddedBytes.ElementAt(index + 3), 6, 7) << 3) | GetBits(paddedBytes.ElementAt(index + 4), 0, 2)];
                result[resultIndex++] = mappingChars[GetBits(paddedBytes.ElementAt(index + 4), 3, 7)];
            }
            switch (length % 5)
            {
                case 1:
                    Array.Fill(result, PaddingChar, result.Length - 6, 6);
                    break;
                case 2:
                    Array.Fill(result, PaddingChar, result.Length - 4, 4);
                    break;
                case 3:
                    Array.Fill(result, PaddingChar, result.Length - 3, 3);
                    break;
                case 4:
                    Array.Fill(result, PaddingChar, result.Length - 1, 1);
                    break;
            }
            return result;
        }

        private static byte[] DecodeBase32WithMappingChars(string base32String, Dictionary<char, byte> mappingChars)
        {
            var length = base32String.Length;
            var paddedChars = length % 8 == 0 ? base32String : base32String.Concat(Enumerable.Repeat(PaddingChar, 8 - length % 8));
            var paddedLength = paddedChars.Count();
            var result = new byte[paddedLength / 8 * 5];
            var resultIndex = 0;

            for (var index = 0; index < paddedLength; index += 8)
            {
                var charValues = new byte[8];
                for (var i = 0; i < 8; i++)
                {
                    char c = paddedChars.ElementAt(index + i);
                    if (c == PaddingChar)
                        break;
                    if (!mappingChars.ContainsKey(c))
                        throw new ArgumentException(nameof(base32String), $"Invalid char {c} at index {index + i}");
                    charValues[i] = mappingChars[c];
                }

                result[resultIndex++] = (byte)((charValues[0] << 3) | GetBits(charValues[1], 3, 5));
                result[resultIndex++] = (byte)((GetBits(charValues[1], 6, 7)  << 6) | (charValues[2] << 1) | GetBits(charValues[3], 3, 3));
                result[resultIndex++] = (byte)((GetBits(charValues[3], 4, 7) << 4) | GetBits(charValues[4], 3, 6));
                result[resultIndex++] = (byte)((GetBits(charValues[4], 7, 7) << 7) | (charValues[5] << 2) | GetBits(charValues[6], 3, 4));
                result[resultIndex++] = (byte)((GetBits(charValues[6], 5, 7) << 5) | charValues[7]);
            }

            do
            {
                --resultIndex;
            }
            while (resultIndex > 0 && result[resultIndex] == 0);

            Array.Resize(ref result, resultIndex + 1);

            return result;
        }

        private static int GetBits(byte b, int fromBit, int toBit)
        {
            if (fromBit < 0 || fromBit > toBit)
                throw new ArgumentOutOfRangeException(nameof(fromBit));
            if (toBit < fromBit || toBit >= 8)
                throw new ArgumentOutOfRangeException(nameof(toBit));

            return (b >> (8 - toBit - 1)) & MASKS[toBit - fromBit + 1];
        }

        private static IEnumerable<char> GetCharsRange(char from, char to)
        {
            return Enumerable.Range(from, to - from + 1).Select(x => (char)x);
        }
    }
}