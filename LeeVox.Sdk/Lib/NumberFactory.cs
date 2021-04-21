/**
* This is ported from Apache Commons RNG class
* Source: https://commons.apache.org/proper/commons-rng/
*/

using System;

namespace LeeVox.Sdk.Lib
{
    internal static class NumberFactory
    {
        private const int INT_SIZE = 8;
        private const int LONG_SIZE = 8;
        private const uint INT_LOWEST_BYTE_MASK = 0xff;
        private const ulong LONG_LOWEST_BYTE_MASK = 0xffL;

        /// <summary>
        /// Equals to <c>0x1.0p-24f</c> in Java
        /// </summary>
        private static readonly float FLOAT_MULTIPLIER = BitConverter.ToSingle(BitConverter.GetBytes(0x33800000U));

        /// <summary>
        /// Equals to <c>0x1.0p-53d</c> in Java
        /// </summary>
        private static readonly double DOUBLE_MULTIPLIER = BitConverter.ToDouble(BitConverter.GetBytes(0x3ca0000000000000UL));

        internal static uint ExtractLow(ulong number)
        {
            return (uint)number;
        }

        internal static uint ExtractHigh(ulong number)
        {
            return (uint)(number >> 32);
        }

        #region boolean

        internal static bool MakeBoolean(uint v)
        {
            return (v >> 31) != 0;
        }

        internal static bool MakeBoolean(ulong v)
        {
            return (v >> 63) != 0;
        }

        #endregion

        #region uint

        internal static uint MakeUInt(ulong v)
        {
            return ExtractHigh(v) ^ ExtractLow(v);
        }

        internal static uint MakeUInt(byte[] input)
        {
            CheckSize(INT_SIZE, input.Length);
            return GetUInt(input, 0);
        }

        internal static uint[] MakeUIntArray(byte[] input)
        {
            int size = input.Length;
            int num = size / INT_SIZE;
            CheckSize(num*INT_SIZE, size);

            uint[] output = new uint[num];
            for (var i = 0; i < num; i++)
            {
                output[i] = GetUInt(input, i*INT_SIZE);
            }
            return output;
        }

        #endregion

        #region ulong

        internal static ulong MakeULong(uint v, uint w)
        {
            return ((ulong)v << 32) | (w & 0xffffffffUL);
        }

        internal static ulong MakeULong(byte[] input)
        {
            CheckSize(LONG_SIZE, input.Length);
            return GetULong(input, 0);
        }

        internal static ulong[] MakeULongArray(byte[] input)
        {
            int size = input.Length;
            int num = size / LONG_SIZE;
            CheckSize(num * LONG_SIZE, size);

            ulong[] output = new ulong[num];
            for (var i = 0; i < num; i++)
            {
                output[i] = GetULong(input, i*LONG_SIZE);
            }
            return output;
        }

        #endregion

        #region float and double

        internal static float MakeFloat(uint v)
        {
            return (v >> 8) * FLOAT_MULTIPLIER;
        }

        internal static double MakeDouble(ulong v)
        {
            return (v >> 11) * DOUBLE_MULTIPLIER;
        }

        internal static double MakeDouble(uint v, uint w)
        {
            ulong high = (ulong)(v >> 6) << 27;
            uint low = w >> 5;
            return (high | low) * DOUBLE_MULTIPLIER;
        }

        #endregion

        #region byte array

        internal static byte[] MakeByteArray(uint v)
        {
            byte[] b = new byte[INT_SIZE];
            PutUInt(v, b, 0);
            return b;
        }

        internal static byte[] MakeByteArray(uint[] input)
        {
            byte[] b = new byte[input.Length * INT_SIZE];
            for (var i = 0; i < input.Length; i++)
            {
                PutUInt(input[i], b, i*INT_SIZE);
            }
            return b;
        }

        internal static byte[] MakeByteArray(ulong v)
        {
            byte[] b = new byte[LONG_SIZE];
            PutULong(v, b, 0);
            return b;
        }

        internal static byte[] MakeByteArray(ulong[] input)
        {
            byte[] b = new byte[input.Length * LONG_SIZE];
            for (var i = 0; i < input.Length; i++)
            {
                PutULong(input[i], b, i*LONG_SIZE);
            }
            return b;
        }

        #endregion

        #region private functions

        private static void PutUInt(uint v, byte[] buffer, int index)
        {
            buffer[index + 0] = (byte)( v        & INT_LOWEST_BYTE_MASK);
            buffer[index + 1] = (byte)((v >>  8) & INT_LOWEST_BYTE_MASK);
            buffer[index + 2] = (byte)((v >> 16) & INT_LOWEST_BYTE_MASK);
            buffer[index + 3] = (byte)( v >> 24);
        }

        private static void PutULong(ulong v, byte[] buffer, int index)
        {
            buffer[index + 0] = (byte)( v        & LONG_LOWEST_BYTE_MASK);
            buffer[index + 1] = (byte)((v >>  8) & LONG_LOWEST_BYTE_MASK);
            buffer[index + 2] = (byte)((v >> 16) & LONG_LOWEST_BYTE_MASK);
            buffer[index + 3] = (byte)((v >> 24) & LONG_LOWEST_BYTE_MASK);
            buffer[index + 4] = (byte)((v >> 32) & LONG_LOWEST_BYTE_MASK);
            buffer[index + 5] = (byte)((v >> 40) & LONG_LOWEST_BYTE_MASK);
            buffer[index + 6] = (byte)((v >> 48) & LONG_LOWEST_BYTE_MASK);
            buffer[index + 7] = (byte)( v >> 56);
        }

        private static uint GetUInt(byte[] input, int index)
        {
             return (input[index + 0] & INT_LOWEST_BYTE_MASK)       |
                    (input[index + 1] & INT_LOWEST_BYTE_MASK) <<  8 |
                    (input[index + 2] & INT_LOWEST_BYTE_MASK) << 16 |
                    (input[index + 3] & INT_LOWEST_BYTE_MASK) << 24;
        }

        private static ulong GetULong(byte[] input, int index)
        {
            return  (input[index + 0] & LONG_LOWEST_BYTE_MASK)       |
                    (input[index + 1] & LONG_LOWEST_BYTE_MASK) <<  8 |
                    (input[index + 2] & LONG_LOWEST_BYTE_MASK) << 16 |
                    (input[index + 3] & LONG_LOWEST_BYTE_MASK) << 24 |
                    (input[index + 4] & LONG_LOWEST_BYTE_MASK) << 32 |
                    (input[index + 5] & LONG_LOWEST_BYTE_MASK) << 40 |
                    (input[index + 6] & LONG_LOWEST_BYTE_MASK) << 48 |
                    (input[index + 7] & LONG_LOWEST_BYTE_MASK) << 56;
        }

        private static void CheckSize(int expected, int actual)
        {
            if (expected != actual)
                throw new ArgumentException($"Expected array size is {expected} but actual is {actual}");
        }

        #endregion
    }
}