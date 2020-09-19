using System.Collections.Generic;
using System.Linq;
using Communication.Infrastructure;
using Communication.Infrastructure.Collections;

namespace Communication.Codes
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
            BitArray = new BitArray(bits.ToList());
        }

        public Vector(string bitString) : this(bitString.Select(c => c == '1')) { }

        /// <summary>
        /// Gets the i'th bit of the vector
        /// </summary>
        /// <param name="i">index of bit to return</param>
        /// <returns>i'th bit</returns>
        public bool this[int i] => BitArray[i];

        public int Size => BitArray.Count;


        public Vector Add(Vector other)
            => new Vector(BitArray.Xor(other.BitArray, true));

        /// <summary>
        /// performs 'and' logical operation on bits in corresponding positions:
        /// 1010 & 1100 = 1000
        /// </summary>
        /// <param name="other">vector to and with</param>
        public Vector Multiply(Vector other)
            => new Vector(BitArray.And(other.BitArray, true));

        /// <summary>
        /// Multiplies bits by a given scalar.
        /// In other words, returns either 0 or the same vector
        /// </summary>
        /// <param name="scalar">the scalar to multiply with</param>
        public Vector Multiply(bool scalar)
            => scalar ? this : Vector.Zero(BitArray.Count);
        
        /// <summary>
        /// Produces the inverse of the vector.
        /// </summary>
        public Vector Complement()
        {
            var bits = BitArray
                .Select(bit => !bit);

            return new Vector(bits);
        }
        /// <summary>
        /// Produces the dot product for vector with given vector.
        /// </summary>
        public bool DotProduct(Vector other)
        {
            return Multiply(other).BitArray.Any(b => b);
            //var productVector = Add(other);
            //return productVector.BitArray.AsEnumerable()
            //    .Aggregate(false, (agg, bit) => agg ^ bit);
        }


        public static Vector Zero(int size) => new Vector(Enumerable.Repeat(false, size));
        public static Vector One(int size) => new Vector(Enumerable.Repeat(true, size));


        /// <summary>
        /// Syntactic sugar for assigning a string as a vector like so
        /// Vector v = "10101010";
        /// </summary>
        /// <param name="bitString">the bit string</param>
        public static implicit operator Vector(string bitString) => new Vector(bitString);

        public override string ToString() => 
            string.Join("", BitArray.Select(b => b ? "1" : "0"));
    }
}