using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Codes.Infrastructure;

namespace Codes.Primitives
{
    public class Vector : IEnumerable<bool>
    {
        public IList<bool> Bits { get; set; }
        public int Size => Bits.Count;

        /// <summary>
        /// Returns the indexth bit of the vector;
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool this[int index] => Bits[index];

        /// <summary>
        /// Creates a new vector from a byte.
        /// </summary>
        public Vector(byte b) : this(b.ToBoolList()) { }
        /// <summary>
        /// Creates a new vector from a bit string like 10010
        /// </summary>
        /// <param name="bitString"></param>
        public Vector(string bitString) : this(bitString.Select(c => c == '1')) { }
        /// <summary>
        /// Creates a new vector from any boolean enumeration
        /// </summary>
        /// <param name="bits"></param>
        public Vector(IEnumerable<bool> bits) : this(bits.ToList()) { }
        /// <summary>
        /// Creates a new vector from a concrete list of booleans
        /// </summary>
        /// <param name="bits"></param>
        public Vector(IList<bool> bits)
        {
            Bits = bits;
        }

        /// <summary>
        /// performs the 'and' logical operation on bits in corresponding positions:
        /// 1010 & 1100 = 1000
        /// </summary>
        /// <param name="other"></param>
        public Vector Multiply(Vector other)
        {
            var bits = this.Zip(other.Bits, (a, b) => a & b);
            return new Vector(bits);
        }

        /// <summary>
        /// performs the 'xor' logical operation on bits in corresponding positions:
        /// 1010 & 1100 = 0110
        /// </summary>
        /// <param name="other"></param>
        public Vector Add(Vector other)
        {
            var bits = this.Zip(other.Bits, (a, b) => a ^ b);
            return new Vector(bits);
        }

        /// <summary>
        /// Multiplies a vector by a scalar
        /// </summary>
        /// <param name="scalar"></param>
        public Vector Multiply(bool scalar) =>
            scalar ? this : Vector.Zero(this.Size);

        /// <summary>
        /// Returns the inverse of the current vector:
        /// 1001 -> 0110
        /// </summary>
        public Vector Complement() => new Vector(this.Select(bit => !bit));

        /// <summary>
        /// Produces the dot product of this vector and the param vector
        /// </summary>
        public bool DotProduct(Vector other) => this.Multiply(other)
            .Aggregate(false, (agg, bit) => agg ^ bit);

        #region static
        public static Vector Zero(int size) => new Vector(Enumerable.Repeat(false, size));
        public static Vector One(int size) => new Vector(Enumerable.Repeat(true, size));
        #endregion

        #region IEnumerable
        public IEnumerator<bool> GetEnumerator() => Bits.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Bits.GetEnumerator();
        #endregion

        public override string ToString() => string.Join("", this.Select(bit => bit ? "1" : "0"));
    }
}