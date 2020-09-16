using System.Collections;
using System.Linq;
using ReedMullerCode.Infrastructure;

namespace ReedMullerCode.Codes
{
    public class Vector
    {
        public BitArray BitArray { get; set; }

        public Vector Add(Vector other)
            => new Vector { BitArray = BitArray.Xor(other.BitArray) };

        public Vector Complement()
        {
            return new Vector
            {
                BitArray = new BitArray(BitArray
                    .AsEnumerable()
                    .Select(bit => !bit)
                    .ToArray())
            };
        }

        public bool Multiply(Vector other)
        {
            var productVector = Add(other);
            return productVector.BitArray.AsEnumerable()
                .Aggregate(false, (agg, bit) => agg ^ bit);
        }
    }

}