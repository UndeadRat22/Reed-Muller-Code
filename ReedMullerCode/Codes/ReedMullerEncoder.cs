using System;
using System.Collections;
using System.Linq;
using System.Numerics;
using ReedMullerCode.Infrastructure;

namespace ReedMullerCode.Codes
{
    public class ReedMullerEncoder : IEncoder
    {
        public int R { get; set; }
        public int M { get; set; }
        public ReedMullerEncoder(int r, int m)
        {
            R = r;
            M = m;
        }

        private int VectorSize => (int)BigInteger.Pow(2, R);
        
        /// <summary>
        /// Encodes given bytes as a message using the Reed-Muller Code
        /// </summary>
        /// <param name="bytes">The bytes to encode</param>
        /// <returns>Bytes encoded as a message</returns>
        public Message Encode(byte[] bytes)
        {
            //var bits = new BitArray(bytes);
            //var bitArray = bits.AsEnumerable().ToArray();
            ////unencoded chunks
            //var chunks = bitArray.Chunk(VectorSize)
            //    .Select(chunk => new BitArray(chunk));


            return null;
        }
    }
}