using System;
using System.Linq;
using Communication.Infrastructure.Collections;

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
                ? padding.Concat(array)
                : array.Concat(padding);

            return new BitArray(resultBits.ToArray());
        }

        private static BitArray PerformBitwiseOperation(
            BitArray left,
            BitArray right,
            Func<(bool a, bool b), bool> operation, 
            bool padLeft = true)
        {
            var size = Math.Max(left.Count, right.Count);
            var paddedLeft = left.Pad(size, padLeft);
            var paddedRight = right.Pad(size, padLeft);


            var bits = paddedLeft.Zip(paddedRight)
                .Select(operation)
                .ToArray();

            return new BitArray(bits);
        }
    }
}