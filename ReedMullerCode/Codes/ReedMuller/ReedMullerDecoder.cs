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

        public byte[] Decode(Message message)
        {
            var decoded = message.Vectors.SelectMany(Decode).Select(c => c == '1').ToArray(); //get the message as a list of {1,0}
            //drop the appended zeroes;
            //meaning that if the length is 14, then 6 bits were appended to the original byte string
            //if the length is a multiple of 8 and > 8, then there's no way to tell how many zeroes were appended to the massage
            //i.e. if 0xff0xf00 was sent, it's impossible to tell whether that last byte was part of the data set
            decoded = decoded.Take(message.InitialByteCount * 8).ToArray();
            //split the bits into groups of 8, (byte size)
            var byteBitChunks = decoded.Chunk(8);
            var bytes = byteBitChunks.Select(bits => bits.ToByte()).ToArray();
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