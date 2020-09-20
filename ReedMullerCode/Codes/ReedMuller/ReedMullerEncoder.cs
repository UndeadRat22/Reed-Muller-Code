using System.Collections.Generic;
using System.Linq;
using Communication.Infrastructure;
using Communication.Infrastructure.Collections;

namespace Communication.Codes.ReedMuller
{
    public class ReedMullerEncoder : IEncoder
    {
        private readonly ReedMullerGeneratorMatrix _generatorMatrix;
        public ReedMullerEncoder(int r, int m)
        {
            _generatorMatrix = new ReedMullerGeneratorMatrix(r, m);
        }

        /// <summary>
        /// Encodes given bytes as a message using the Reed-Muller Code
        /// </summary>
        /// <param name="bytes">The bytes to encode</param>
        /// <returns>Bytes encoded as a message</returns>
        public Message Encode(byte[] bytes)
        {
            var rawMessageVectors = EnumerateBytesAsVectors(bytes);
            var encodedVectors = rawMessageVectors
                .Select(Encode)
                .ToArray();

            return new Message
            {
                Vectors = encodedVectors
            };
        }

        public Vector Encode(Vector vector) => _generatorMatrix.Multiply(vector);

        private IEnumerable<Vector> EnumerateBytesAsVectors(IEnumerable<byte> bytes)
        {
            var bitArray = new BitArray(bytes);
            var bits = bitArray.ToArray();
            return bits
                .Chunk(_generatorMatrix.WordSize)
                .Select(chunk => new Vector(chunk));
        }
    }
}