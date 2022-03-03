/**
* This is ported from Apache Commons RNG class
* Source: https://commons.apache.org/proper/commons-rng/
*/

using System;
using System.Numerics;

namespace LeeVox.Sdk.Lib
{
    internal class XoShiRo256StarStar : IDisposable
    {
        private const int SEED_SIZE = 4;

        // State is maintained using variables rather than an array for performance
        private ulong state0;
        private ulong state1;
        private ulong state2;
        private ulong state3;

        private bool cachedShortSource;
        private bool cachedIntSource;
        private uint shortSource;
        private ulong intSource;

        internal XoShiRo256StarStar(params ulong[] seed)
        {
            if (seed.Length < SEED_SIZE)
            {
                var state = new ulong[SEED_SIZE];
                FillState(state, seed);
                SetState(state);
            }
            else
            {
                SetState(seed);
            }
        }
        internal XoShiRo256StarStar(ulong seed0, ulong seed1, ulong seed2, ulong seed3)
        {
            state0 = seed0;
            state1 = seed1;
            state2 = seed2;
            state3 = seed3;
        }

        internal ushort NextUShort()
        {
            if (cachedShortSource)
            {
                cachedShortSource = false;
                return NumberFactory.ExtractLow(shortSource);
            }
            else
            {
                shortSource = NextUInt();
                cachedShortSource = true;
                return NumberFactory.ExtractHigh(shortSource);
            }
        }

        internal uint NextUInt()
        {
            if (cachedIntSource)
            {
                cachedIntSource = false;
                return NumberFactory.ExtractLow(intSource);
            }
            else
            {
                intSource = NextULong();
                cachedIntSource = true;
                return NumberFactory.ExtractHigh(intSource);
            }
        }

        internal uint[] NextUIntArray(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be greater than or equal to 0.");
            uint[] result = new uint[length];
            for (var i = 0; i < length; i++)
                result[i] = NextUInt();
            return result;
        }

        internal ulong NextULong()
        {
            ulong result = BitOperations.RotateLeft(state1 * 5, 7) * 9;

            ulong t = state1 << 17;

            state2 ^= state0;
            state3 ^= state1;
            state1 ^= state2;
            state0 ^= state3;

            state2 ^= t;

            state3 = BitOperations.RotateLeft(state3, 45);
            return result;
        }

        internal ulong[] NextULongArray(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be greater than or equal to 0.");
            ulong[] result = new ulong[length];
            for (var i = 0; i < length; i++)
                result[i] = NextULong();
            return result;
        }

        internal float NextFloat()
        {
            return NumberFactory.MakeFloat(NextUInt());
        }

        internal float[] NextFloatArray(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be greater than or equal to 0.");
            float[] result = new float[length];
            for (var i = 0; i < length; i++)
                result[i] = NumberFactory.MakeFloat(NextUInt());
            return result;
        }

        internal double NextDouble()
        {
            return NumberFactory.MakeDouble(NextULong());
        }

        internal double[] NextDoubleArray(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be greater than or equal to 0.");
            double[] result = new double[length];
            for (var i = 0; i < length; i++)
                result[i] = NumberFactory.MakeDouble(NextULong());
            return result;
        }

        internal void FillBytes(byte[] bytes)
            => FillBytes(bytes, 0, bytes.Length);

        internal void FillBytes(byte[] bytes, int start, int length)
        {
            checkIndex(0, bytes.Length - 1, start);
            checkIndex(0, bytes.Length - start, length);

            int index = start;
            int indexLoopLimit = index + (length & 0x7ffffff8);

            while (index < indexLoopLimit)
            {
                ulong random = NextULong();
                bytes[index++] = (byte)random;
                bytes[index++] = (byte)(random >> 8);
                bytes[index++] = (byte)(random >> 16);
                bytes[index++] = (byte)(random >> 24);
                bytes[index++] = (byte)(random >> 32);
                bytes[index++] = (byte)(random >> 40);
                bytes[index++] = (byte)(random >> 48);
                bytes[index++] = (byte)(random >> 56);
            }

            int indexLimit = start + length;
            if (index < indexLimit)
            {
                ulong random = NextULong();
                while (true)
                {
                    bytes[index++] = (byte)random;
                    if (index < indexLimit)
                    {
                        random = random >> 8;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void FillState(ulong[] state, ulong[] seed)
        {
            Array.Copy(seed, 0, state, 0, Math.Min(state.Length, seed.Length));
            for (var i = seed.Length; i < state.Length; i++)
            {
                state[i] = ScrambleWell(state[i - seed.Length], i);
            }
        }

        private void SetState(ulong[] state)
        {
            state0 = state[0];
            state1 = state[1];
            state2 = state[2];
            state3 = state[3];
        }

        private void checkIndex(int min, int max, int index)
        {
            if (index < min || index > max)
                throw new IndexOutOfRangeException($"{index} is out of range [{min}, {max}]");
        }

        private ulong ScrambleWell(ulong n, int add)
        {
            return Scramble(n, 1812433253UL, 30, add);
        }

        private ulong Scramble(ulong n, ulong mult, int shift, int add)
        {
            // cast from ulong to long to match with original Java source.
            return (ulong)((long)mult * ((long)n ^ ((long)n >> shift)) + add);
        }

        #region disposable

        private bool _disposed = false;
        public void Dispose() => Dispose(true);
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            _disposed = true;
        }

        #endregion
    }
}