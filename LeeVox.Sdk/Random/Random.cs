// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Security.Cryptography;
// using Rei.Random;

// namespace LeeVox.Sdk
// {
//     /// <summary>
//     /// <para>
//     /// Generate random numbers or string using MersenneTwister algorithm.
//     /// </para>
//     /// <para>
//     /// This MersenneTwister class is done by stlalv on October 8, 2010.
//     /// e-mail:stlalv @ nifty.com (remove space)
//     /// </para>
//     /// <para>
//     /// See more: <see href="http://www.math.sci.hiroshima-u.ac.jp/m-mat/MT/VERSIONS/C-LANG/c-lang.html"/>
//     /// </para>
//     /// </summary>
//     /// <remarks>
//     /// WARNING: This class is not thread-safe.
//     /// </remarks>
//     public class Random : IRandom, IDisposable
//     {
//         internal static readonly char[] ASCII_CHARS = Enumerable.Range(32, 126).Select(x => (char)x).ToArray();
//         private const int SIZEOF_ULONG = sizeof(ulong);
//         private const int DEFAULT_SEED_SIZE = 8 * SIZEOF_ULONG;

//         #region constructor & dispose methods

//         private bool _disposed = false;
//         private SFMT _sfmt;

//         public Random()
//         {
//             _sfmt = new SFMT();
//         }
//         public Random(int seed)
//         {
//             _sfmt = new SFMT(seed);
//         }

//         public void Dispose() => Dispose(true);
//         protected virtual void Dispose(bool disposing)
//         {
//             if (_disposed)
//                 return;

//             if (disposing)
//             {
//                 _sfmt?.Dispose();
//             }

//             _disposed = true;
//         }

//         #endregion

//         /// <inheritdoc/>
//         public byte[] NextBytes(int length)
//         {
//             var result = new byte[length];
//             ulong random = 0;
//             for (var i = 0; i < length; i++)
//             {
//                 if (i % SIZEOF_ULONG == 0)
//                 {
//                     random = _sfmt.NextBytes
//                 }

//                 result[i] = (byte)(0b1111_1111 & (random >> 8*(SIZEOF_ULONG - i - 1)));
//             }
//             return result;
//         }

//         /// <inheritdoc/>
//         public double NextDouble(double minValue, double maxValue)
//         {
//             if (maxValue < minValue)
//                 throw new ArgumentOutOfRangeException(nameof(maxValue), $"{nameof(maxValue)} must greater than or equal to {minValue}.");
//             return minValue + (maxValue - minValue) * mt.genrand_real2();
//         }
//     }
// }