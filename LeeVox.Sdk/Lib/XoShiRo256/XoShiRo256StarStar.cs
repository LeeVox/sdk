using System;
using System.Numerics;

namespace LeeVox.Sdk.Lib
{
    internal class XoShiRo256StarStar : IDisposable
    {
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

        // State is maintained using variables rather than an array for performance
        private ulong state0;
        private ulong state1;
        private ulong state2;
        private ulong state3;

        private bool cachedIntSource;
        private ulong intSource;

        public XoShiRo256StarStar(params ulong[] seed)
        {
            state0 = seed.Length > 0 ? seed[0] : 0;
            state1 = seed.Length > 1 ? seed[1] : 0;
            state2 = seed.Length > 2 ? seed[2] : 0;
            state3 = seed.Length > 3 ? seed[3] : 0;
        }

        internal uint NextUInt()
        {
            if (cachedIntSource)
            {
                cachedIntSource = false;
                return extractLo(intSource);
            }
            else
            {
                intSource = NextULong();
                cachedIntSource = true;
                return extractHi(intSource);
            }
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

        internal float NextFloat()
        {
            return makeFloat(NextUInt());
        }

        internal double NextDouble()
        {
            return makeDouble(NextULong());
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

        private uint extractLo(ulong number)
        {
            return (uint)number;
        }
        private uint extractHi(ulong number)
        {
            return (uint)(number >> sizeof(uint));
        }

        private double makeDouble(ulong number)
        {
            return (double)(number >> 11) * 1e-53d;
        }

        private float makeFloat(uint number)
        {
            return (float)(number >> 8) * 1e-24f;
        }

        private void checkIndex(int min, int max, int index)
        {
            if (index < min || index > max)
                throw new IndexOutOfRangeException($"{index} is out of range [{min}, {max}]");
        }
    }
}