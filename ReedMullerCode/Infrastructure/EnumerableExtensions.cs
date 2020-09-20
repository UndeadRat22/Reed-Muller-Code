using System.Collections.Generic;
using System.Linq;

namespace Communication.Infrastructure
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> GetCombinations<T>(this IEnumerable<T> items, int minCombinationSize, int maxCombinationSize)
        {
            var itemArray = items.ToArray();
            for (var i = minCombinationSize; i <= maxCombinationSize; i++)
            {
                var iSizeCombinations = itemArray.GetCombinations(i);
                foreach (var combination in iSizeCombinations)
                {
                    yield return combination;
                }
            }
        }

        public static IEnumerable<IEnumerable<T>> GetCombinations<T>(this IEnumerable<T> items, int combinationSize)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (combinationSize == 1)
                    yield return new[] {item};
                else
                {
                    foreach (var result in GetCombinations(items.Skip(i + 1), combinationSize - 1))
                        yield return new[] {item}.Concat(result);
                }

                ++i;
            }
        }

        public static IEnumerable<T> Pad<T>(this IEnumerable<T> items, T padding, int size)
        {
            var count = 0;
            foreach (var item in items)
            {
                count++;
                yield return item;
            }

            while (count < size)
            {
                count++;
                yield return padding;
            }
        }
    }
}