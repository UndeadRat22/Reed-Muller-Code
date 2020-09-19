using System.Collections.Generic;
using System.Linq;

namespace Communication.Infrastructure
{
    public class ArrayValueComparer<T> : IEqualityComparer<T[]>
    {
        public bool Equals(T[] x, T[] y)
        {
            return x.Length == y.Length && x.All(y.Contains);
        }

        public int GetHashCode(T[] obj)
        {
            int result = 17;
            foreach (var t in obj)
            {
                unchecked
                {
                    result = result * 23 + t.GetHashCode();
                }
            }
            return result;
        }
    }
}