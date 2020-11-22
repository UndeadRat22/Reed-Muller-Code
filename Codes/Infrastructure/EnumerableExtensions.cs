using System;
using System.Collections.Generic;
using System.Linq;

namespace Codes.Infrastructure
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Performs an action with every element.
        /// Semantic sugar for foreach
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
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

        /// <summary>
        /// Returns all items from a given enumerable, then returns padding until size is reached
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="paddingSize"></param>
        /// <param name="padding"></param>
        /// <returns></returns>
        public static IEnumerable<T> Pad<T>(this IEnumerable<T> items, int paddingSize, T padding)
        {
            foreach (var item in items)
            {
                yield return item;
            }
            for (int count = 0; count < paddingSize; count++)
            {
                yield return padding;
            }
        }


        /// <summary>
        /// splits the enumeration into multiple enumerations of size batchSize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">the enumeration to split</param>
        /// <param name="batchSize">size to split into</param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Batch<T>(
            this IEnumerable<T> source, int batchSize)
        {
            using (var enumerator = source.GetEnumerator())
                while (enumerator.MoveNext())
                    yield return YieldBatchElements(enumerator, batchSize - 1);
        }

        private static IEnumerable<T> YieldBatchElements<T>(
            IEnumerator<T> source, int batchSize)
        {
            yield return source.Current;
            for (int i = 0; i < batchSize && source.MoveNext(); i++)
                yield return source.Current;
        }
    }
}