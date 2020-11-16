using System;
using System.Collections.Generic;

namespace Codes.Infrastructure
{
    public static class EnumerableExtensions
    {
        public static void Each<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var elem in enumerable)
            {
                action(elem);
            }
        }
    }
}