using System;
using System.Linq;
using LeeVox.Sdk.Lib;

namespace LeeVox.Sdk
{
    /// <summary>Generate random numbers or string using XoShiRo256StarStar algorithm. </summary>
    /// <remarks>
    /// WARNING: This class is not thread-safe.
    /// </remarks>
    public class Random : IRandom, IDisposable
    {
        private XoShiRo256StarStar _random;

        #region constructors

        public Random()
        {
            _random = new XoShiRo256StarStar((ulong)DateTime.UtcNow.Ticks);
        }
        public Random(params int[] seed)
        {
            _random = new XoShiRo256StarStar(seed.Select(x => (ulong)x).ToArray());
        }
        public Random(params uint[] seed)
        {
            _random = new XoShiRo256StarStar(seed.Select(x => (ulong)x).ToArray());
        }
        public Random(params long[] seed)
        {
            _random = new XoShiRo256StarStar(seed.Select(x => (ulong)x).ToArray());
        }
        public Random(params ulong[] seed)
        {
            _random = new XoShiRo256StarStar(seed);
        }

        #endregion

        #region core functions

        /// <inheritdoc/>
        public byte[] NextBytes(int length)
        {
            var result = new byte[length];
            _random.FillBytes(result, 0, length);
            return result;
        }

        /// <inheritdoc/>
        public float NextFloat()
            => _random.NextFloat();

        /// <inheritdoc/>
        public double NextDouble()
            => _random.NextDouble();

        #endregion

        #region other functions

        /// <inheritdoc/>
        public int NexInt()
            => (int)_random.NextUInt();

        /// <inheritdoc/>
        public ulong NextUInt()
            => _random.NextUInt();

        /// <inheritdoc/>
        public long NexLong()
            => (long)_random.NextULong();

        /// <inheritdoc/>
        public ulong NextULong()
            => _random.NextULong();

        #endregion

        #region disposable

        private bool _disposed = false;
        public void Dispose() => Dispose(true);
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _random?.Dispose();
            }

            _disposed = true;
        }

        #endregion
    }
}