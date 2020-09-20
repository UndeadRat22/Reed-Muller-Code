using System.Collections.Generic;
using System.Linq;
using Communication.Infrastructure;
using Communication.Infrastructure.Collections;

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
            var decoded = bits.Vectors.Select(Decode).ToArray();
            var bitArray = decoded.SelectMany(s => s).Select(c => c == '1').ToArray();
            var bytes = bitArray.Chunk(8)
                .Select(chunk => chunk.ToByte())
                .ToArray();

            return bytes;
        }

        public string Decode(Vector vector)
        {
            //the inverse bitList of the vector;
            var bitList = new List<bool>();
            //Get rows from the matrix in reverse order, without the identity row.
            //The rows are also grouped by 'complexity' (key size)
            var rows = _generatorMatrix.GetRowsGroupedByComplexity();
            foreach (var rGroup in rows)
            {
                //this result will have to be added to the given vector, when proceeding to a 'lower' complexity
                var groupResult = Vector.Zero(_generatorMatrix.WordSize);
                foreach (var row in rGroup)
                {
                    //get characteristic vectors for row.
                    var vectors = _generatorMatrix.GetCharacteristicVectorsFor(row.Key);
                    //get majority of 'votes' for row.
                    var votes = vectors.Select(v => v.DotProduct(vector)).ToArray();
                    var majority = GetMajority(votes);
                    //add vector to groupResult based on majority vote;
                    groupResult = groupResult.Add(row.Value.Multiply(majority));
                    //save the vote
                    bitList.Add(majority);
                }
                //s + u;
                vector = vector.Add(groupResult);
            }
            var majorityCount = GetMajority(vector.BitArray.ToArray());
            bitList.Add(majorityCount);
            bitList.Reverse();
            return new Vector(bitList).ToString();
        }


        private static bool GetMajority(bool[] votes)
        {
            var oneCount = votes.Count(x => x);
            return oneCount >= votes.Length - oneCount;
        }
    }
}