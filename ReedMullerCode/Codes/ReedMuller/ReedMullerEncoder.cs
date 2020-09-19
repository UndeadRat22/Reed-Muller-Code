using System.Numerics;

namespace ReedMullerCode.Codes.ReedMuller
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
            //var bits = new BitArray(bytes);
            //var bitArray = bits.AsEnumerable().ToArray();
            ////unencoded chunks
            //var chunks = bitArray.Chunk(VectorSize)
            //    .Select(chunk => new BitArray(chunk));


            return null;
        }
    }
}