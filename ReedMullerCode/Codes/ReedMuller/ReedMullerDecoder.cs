using System.Collections.Generic;
using System.Linq;
using Communication.Infrastructure;

namespace Communication.Codes.ReedMuller
{
    public class ReedMullerDecoder : IDecoder
    {
        private readonly ReedMullerGeneratorMatrix _generatorMatrix;
        public ReedMullerDecoder(int r, int m)
        {
            _generatorMatrix = new ReedMullerGeneratorMatrix(r, m);
        }

        public byte[] Decode(Message bits)
        {
            var vector = bits.Vectors.First();
            var bitList = new List<bool>();//TODO reverse list after
            var rowsWithoutIdentity = _generatorMatrix.GetRowsGroupedByComplexity();
            foreach (var group in rowsWithoutIdentity)
            {
                foreach (var row in group)
                {
                    var characteristicVectors = _generatorMatrix.GetCharacteristicVectorsFor(row.Key);
                    var dotProducts = characteristicVectors.Select(c => vector.DotProduct(c)).ToArray();
                    var oneCount = dotProducts.Count(p => p);
                    var zeroCount = dotProducts.Length - oneCount;
                    bitList.Add(oneCount >= zeroCount); //if oneCount == zeroCount just assume it's a 1
                }
            }
            bitList.Reverse();

            return null;
        }
    }
}