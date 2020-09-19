using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Communication.Infrastructure
{
    public static class BitArrayExtensions
    {
        public static BitArray Xor(this BitArray left, BitArray right, bool padLeft = true)
        {
            return PerformBitwiseOperation(left, right, pair => pair.a ^ pair.b, padLeft);
        }

        public static BitArray And(this BitArray left, BitArray right, bool padLeft = true)
        {
            return PerformBitwiseOperation(left, right, pair => pair.a && pair.b, padLeft);
        }

        public static BitArray Pad(this BitArray array, int size, bool padBit = false, bool padLeft = true)
        {
            if (array.Count >= size)
            {
                return array;
            }

            var padding = Enumerable.Repeat(padBit, size - array.Count);

            var resultBits = padLeft
                ? padding.Concat(array.AsEnumerable())
                : array.AsEnumerable().Concat(padding);

            return new BitArray(resultBits.ToArray());
        }


        public static IEnumerable<bool> AsEnumerable(this BitArray array) 
            => array.Cast<bool>();


        private static BitArray PerformBitwiseOperation(
            BitArray left,
            BitArray right,
            Func<(bool a, bool b), bool> operation, 
            bool padLeft = true)
        {
            var size = Math.Max(left.Count, right.Count);
            var paddedLeft = left.Pad(size, padLeft);
            var paddedRight = right.Pad(size, padLeft);


            var bits = paddedLeft.AsEnumerable().Zip(paddedRight.AsEnumerable())
                .Select(operation)
                .ToArray();

            return new BitArray(bits);
        }
    }
}