using System.Collections.Generic;
using System.Linq;

namespace Communication.Infrastructure
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> GetCombinations<T>(this IEnumerable<T> items, int minCombinationSize, int maxCombinationSize)
            => Enumerable
                .Range(maxCombinationSize, maxCombinationSize - minCombinationSize + 1)
                .SelectMany(i => items.GetCombinations(i));

        public static IEnumerable<IEnumerable<T>> GetCombinations<T>(this IEnumerable<T> items, int combinationSize)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (combinationSize == 1)
                {
                    yield return new[] {item};
                }
                else
                {
                    foreach (var result in GetCombinations(items.Skip(i + 1), combinationSize - 1))
                    {
                        yield return new[] { item }.Concat(result);
                    }
                }
                ++i;
            }
        }
    }
}