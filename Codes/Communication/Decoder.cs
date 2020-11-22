using System.Collections.Generic;
using System.Linq;
using Codes.Primitives;

namespace Codes.Communication
{
    public class Decoder
    {
        private readonly GeneratorMatrix _generatorMatrix;

        public Decoder(GeneratorMatrix generatorMatrix)
        {
            _generatorMatrix = generatorMatrix;
        }

        public Message Decode(Message message)
        {
            return new Message
            {
                Vectors = message.Vectors.Select(Decode).ToList()
            };
        }


        private Vector Decode(Vector vector)
        {
            //the inverse bitList of the vector;
            var bitList = new List<bool>();
            //Get rows from the matrix in reverse order, without the identity row.
            //The rows are also grouped by 'complexity' (key size)
            var rows = _generatorMatrix.GetRowsGroupedByComplexity();
            foreach (var rGroup in rows)
            {
                //this result will have to be added to the given vector, when proceeding to a 'lower' complexity
                var groupResult = Vector.Zero(_generatorMatrix.EncodableVectorSize);
                foreach (var row in rGroup)
                {
                    //get characteristic vectors for row.
                    var vectors = _generatorMatrix.GetCharacteristicVectorsFor(row);
                    if (!vectors.Any())
                    {
                        vectors = new List<Vector> { Vector.One(_generatorMatrix.VectorSize) };
                    }
                    //get majority of 'votes' for row.
                    var votes = vectors.Select(v => v.DotProduct(vector)).ToList();
                    var majority = GetMajority(votes);
                    //add vector to groupResult based on majority vote;
                    groupResult = groupResult.Add(row.Value.Multiply(majority));
                    //save the vote
                    bitList.Add(majority);
                }
                //s + u;
                vector = vector.Add(groupResult);
            }
            var majorityCount = GetMajority(vector.Bits);
            bitList.Add(majorityCount);
            bitList.Reverse();
            return new Vector(bitList);
        }

        private static bool GetMajority(IList<bool> votes)
        {
            var oneCount = votes.Count(x => x);
            return oneCount >= votes.Count - oneCount;
        }
    }
}