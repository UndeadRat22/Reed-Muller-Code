using System;
using System.Collections.Generic;
using System.Linq;

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


        /// <summary>
        /// Returns all possible combinations of a given size
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="combinationSize"></param>
        public static IEnumerable<IEnumerable<T>> GetCombinations<T>(this IEnumerable<T> items, int combinationSize)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (combinationSize == 1)
                    yield return new[] { item };
                else
                {
                    foreach (var result in GetCombinations(items.Skip(i + 1), combinationSize - 1))
                        yield return new[] { item }.Concat(result);
                }
                ++i;
            }
        }

        /// <summary>
        /// Returns all possible combinations of sizes in [min : max]
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="minCombinationSize"></param>
        /// <param name="maxCombinationSize"></param>
        public static IEnumerable<IEnumerable<T>> GetCombinations<T>(this IEnumerable<T> items, int minCombinationSize, int maxCombinationSize)
        {
            for (var i = minCombinationSize; i <= maxCombinationSize; i++)
            {
                var iSizeCombinations = items.GetCombinations(i);
                foreach (var combination in iSizeCombinations)
                {
                    yield return combination;
                }
            }
        }
    }
}