using System.Collections.Generic;
using System.IO;
using System.Linq;
using Communication.Infrastructure;
using Communication.Infrastructure.Collections;

namespace Communication.Codes.ReedMuller
{
    public class ReedMullerEncoder : IEncoder
    {
        private readonly ReedMullerGeneratorMatrix _generatorMatrix;
        private readonly TextWriter _writer;
        public ReedMullerEncoder(int r, int m, TextWriter writer)
        {
            _generatorMatrix = new ReedMullerGeneratorMatrix(r, m);
            _writer = writer;
        }

        /// <summary>
        /// Encodes given bytes as a message using the Reed-Muller Code
        /// </summary>
        /// <param name="bytes">The bytes to encode</param>
        /// <param name="log"></param>
        /// <returns>Bytes encoded as a message</returns>
        public Message Encode(byte[] bytes, bool log)
        {
            if (log)
            {
                _writer.WriteLine(_generatorMatrix.ToString());
            }
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