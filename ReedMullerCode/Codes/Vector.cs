using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ReedMullerCode.Infrastructure;

namespace ReedMullerCode.Codes
{
    public class Vector
    {
        public BitArray BitArray { get; set; }

        public Vector(BitArray bitArray)
        {
            BitArray = bitArray;
        }

        public Vector(IEnumerable<bool> bits)
        {
            BitArray = new BitArray(bits.ToArray());
        }

        public Vector Add(Vector other)
            => new Vector(BitArray.Xor(other.BitArray, true));

        public Vector Multiply(Vector other)
            => new Vector(BitArray.And(other.BitArray, true));

        public Vector Complement()
        {
            var bits = BitArray.AsEnumerable()
                .Select(bit => !bit);

            return new Vector(bits);
        }

        public bool DotProduct(Vector other)
        {
            var productVector = Add(other);
            return productVector.BitArray.AsEnumerable()
                .Aggregate(false, (agg, bit) => agg ^ bit);
        }


        public static Vector Zero(int size) => new Vector(Enumerable.Repeat(false, size));
        public static Vector One(int size) => new Vector(Enumerable.Repeat(true, size));


        public override string ToString() => 
            string.Join("", BitArray.AsEnumerable().Select(b => b ? "1" : "0"));
    }
}