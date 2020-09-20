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
            var vector = bits.Vectors.First();
            

            return null;
        }

        public string Decode(Vector vector)
        {
            var bitList = new List<bool>();//TODO reverse list after
            var rowsWithoutIdentity = _generatorMatrix.GetRowsGroupedByComplexity().ToArray();
            Vector result = null;
            foreach (var group in rowsWithoutIdentity)
            {
                var groupBitList = new List<bool>();
                foreach (var row in group)
                {
                    var characteristicVectors = _generatorMatrix.GetCharacteristicVectorsFor(row.Key);
                    var dotProducts = characteristicVectors.Select(c => vector.DotProduct(c)).ToArray();
                    //majority vote
                    var majority = GetMajority(dotProducts);
                    groupBitList.Add(majority);
                    var vToAdd = row.Value.Multiply(majority);
                    result = result == null ? vToAdd : result.Add(vToAdd);
                }
                vector = vector.Add(result);
                bitList.AddRange(groupBitList);
            }
            //var rows = _generatorMatrix.Rows.Skip(1).Reverse().ToArray();
            //Vector result = null;
            //foreach (var row in rows)
            //{
            //    var vectors = _generatorMatrix.GetCharacteristicVectorsFor(row.Key);
            //    var votes = vectors.Select(v => v.DotProduct(vector)).ToArray();
            //    var majority = GetMajority(votes);
            //    bitList.Add(majority);
            //    var vToAdd = row.Value.Multiply(majority);
            //    result = result == null ? vToAdd : result.Add(vToAdd);
            //}
            ////bitList.Reverse();
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