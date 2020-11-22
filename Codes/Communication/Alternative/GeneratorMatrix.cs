using System.Collections.Generic;
using System.Linq;
using Codes.Primitives;

namespace Codes.Communication.Alternative
{
    public class GeneratorMatrix
    {
        public int R { get; }
        public int M { get; }
        public int VectorSize => 1 << M;
        private IList<IndexedVector> _rows;

        public GeneratorMatrix(int r, int m)
        {
            R = r;
            M = m;
            _rows = GetStartingVectors().ToList();
        }

        private IEnumerable<IndexedVector> GetStartingVectors()
        {
            var index = 1; //indexed used to index vectors;
            //Starting from 2**M, go down in powers of two
            //So i = 2**M, 2**(M-1), 2**(M-2) ... 2**(0)
            for (var i = 1 << M; i >= 1; i = i >> 1, index++)
            {
                //One part
                var ones = Enumerable.Repeat(true, i).ToList();
                //Zero part
                var zeroes = Enumerable.Repeat(false, i).ToList();
                var vectorBits = new List<bool>(VectorSize);
                while (vectorBits.Count != VectorSize)
                {
                    vectorBits.AddRange(ones);
                    if (vectorBits.Count != VectorSize)
                    {
                        vectorBits.AddRange(zeroes);
                    }
                }
                yield return new IndexedVector
                {
                    Index = new HashSet<int>{ index },
                    Value = new Vector(vectorBits)
                };
            }
        }
    }

    public class IndexedVector
    {
        public HashSet<int> Index { get; set; }
        public Vector Value { get; set; }

        #region object
        public override int GetHashCode()
        {
            int result = 17;
            foreach (var t in Index)
            {
                unchecked
                {
                    result = result * 23 + t.GetHashCode();
                }
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is IndexedVector other)) return false;
            return other.Index.Count == Index.Count && other.Index.All(Index.Contains);
        }

        public override string ToString()
        {
            return string.Join(",", Index.Select(i => i.ToString())) + ": " + Value;
        }

        #endregion
    }
}