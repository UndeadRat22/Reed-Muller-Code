using System.Collections.Generic;
using System.Linq;

namespace Codes.Infrastructure
{
    public class SetValueComparer<T> : IEqualityComparer<ISet<T>>
    {
        public bool Equals(ISet<T> x, ISet<T> y)
        {
            return x.Count == y.Count && x.All(y.Contains);
        }

        public int GetHashCode(ISet<T> obj)
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