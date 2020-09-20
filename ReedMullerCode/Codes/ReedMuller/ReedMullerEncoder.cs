using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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
                Vectors = encodedVectors,
                InitialByteCount = bytes.Length
            };
        }

        public Message Encode(string bitString, bool log)
        {
            return new Message
            {
                Vectors = new[] {Encode(bitString)}
            };
        }

        public ValidationResult CanEncode(string bitString)
        {
            if (bitString.Length != _generatorMatrix.EncodableVectorSize || bitString.Length == 0)
            {
                return new ValidationResult
                {
                    CanEncode = false,
                    Message = $"Message length must have a length {_generatorMatrix.EncodableVectorSize}."
                };
            }
            return new ValidationResult
            {
                CanEncode = true
            };
        }

        public Vector Encode(Vector vector) => _generatorMatrix.Multiply(vector);

        private IEnumerable<Vector> EnumerateBytesAsVectors(IReadOnlyCollection<byte> bytes)
        {
            //i.e if bytes.length = 1, bits = 1111 1111 and evc = 7, then we need
            //to encode bits as (1111 111), (1000 000)
            var totalLengthWithPadding =
                (int)Math.Ceiling((bytes.Count * 8) / (double) _generatorMatrix.EncodableVectorSize) * _generatorMatrix.EncodableVectorSize;

            //pad remaining bits as 0s
            var bits = new BitArray(bytes).Values
                .Pad(false, totalLengthWithPadding);

            return bits.ToArray()
                .Chunk(_generatorMatrix.EncodableVectorSize)
                .Select(chunk => new Vector(chunk));
        }
    }
}