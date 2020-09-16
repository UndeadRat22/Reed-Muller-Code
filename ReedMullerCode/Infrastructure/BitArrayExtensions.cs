using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ReedMullerCode.Infrastructure
{
    public static class BitArrayExtensions
    {
        public static BitArray Xor(this BitArray left, BitArray right, bool padLeft = true)
        {
            var size = Math.Max(left.Count, right.Count);
            var paddedLeft = left.Pad(size);
            var paddedRight = right.Pad(size);


            var bits = paddedLeft.AsEnumerable().Zip(paddedRight.AsEnumerable())
                .Select(pair => pair.First ^ pair.Second)
                .ToArray();

            return new BitArray(bits);
        }

        public static BitArray Pad(this BitArray array, int size, bool padLeft = true)
        {
            if (array.Count >= size)
            {
                return array;
            }

            var padding = Enumerable.Repeat(false, size - array.Count);

            var resultBits = padLeft
                ? padding.Concat(array.AsEnumerable())
                : array.AsEnumerable().Concat(padding);

            return new BitArray(resultBits.ToArray());
        }


        public static IEnumerable<bool> AsEnumerable(this BitArray array) 
            => array.Cast<bool>();
    }
}