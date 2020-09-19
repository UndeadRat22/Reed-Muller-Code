using System;
using System.Collections.Generic;

namespace ReedMullerCode.Infrastructure
{
    public static class ArrayExtensions
    {
        public static T[] Slice<T>(this T[] source, int index, int length)
        {
            var slice = new T[length];
            Array.Copy(source, index, slice, 0, length);
            return slice;
        }

        public static IEnumerable<T[]> Chunk<T>(this T[] source, int size)
        {
            var chunkCount = (int)Math.Ceiling((double) source.Length / size);
            for (var i = 0; i < chunkCount; i++)
            {
                yield return source.Slice(i * size, size);
            }
        }
    }
}