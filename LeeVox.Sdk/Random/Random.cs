using System;
using PseudoRandom;

namespace LeeVox.Sdk
{
    public class Random<T> where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {
        private MersenneTwister _mt = new MersenneTwister();

        public T Next()
        {
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Double:
                    return (T)Convert.ChangeType(_mt.genrand_real1(), typeof(T));
                case TypeCode.Int64:
                    return (T)Convert.ChangeType(_mt.genrand_uint32(), typeof(T));
                default:
                    return default(T);
            }
        }
    }
}