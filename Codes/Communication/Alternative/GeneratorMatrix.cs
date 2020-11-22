using System.Collections.Generic;
using System.Linq;
using Codes.Infrastructure;
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
            Generate();
        }

        /// <summary>
        /// Generates the matrix rows using R and M parameters.
        /// Stores the result in _rows;
        /// </summary>
        private void Generate()
        {
            var baseVectors = GetBaseVectors().ToList();
            // if R <= 1, then there is no need to generate the products from vector combinations
            if (R <= 1)
            {
                _rows = baseVectors;
                return;
            }
            //get all possible combinations from the base vectors in collections of size 2 - R.
            //skip the first 'base' vector, as it's equivalent to 1, and when multiplying by it later, the resulting vector is simply itself.
            var combinations = baseVectors.Skip(1).GetCombinations(2, R);

            var indexedCombinedVectors = combinations
                .Select(combination => IndexedVector.Combine(combination, VectorSize));

            _rows = baseVectors.Concat(indexedCombinedVectors).ToList();
        }

        /// <summary>
        /// Builds vectors which are used to generate the rest of the vectors,
        /// for example: 11111111, 11110000, 11001100, 10101010 for M = 3;
        /// </summary>
        /// <returns> indexed vectors </returns>
        private IEnumerable<IndexedVector> GetBaseVectors()
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
                    Index = new HashSet<int> { index },
                    Value = new Vector(vectorBits)
                };
            }
        }
    }

    public class IndexedVector
    {
        public HashSet<int> Index { get; set; }
        public Vector Value { get; set; }
        
        /// <summary>
        /// Combines vectors into their product vector.
        /// for example: [ v1, v2 ] => v3: {Value:v1 * v2, Index:[v1.Index, v2.Index]
        /// </summary>
        /// <param name="vectors">vectors to combine</param>
        /// <param name="vectorSize">the size of the passed vectors</param>
        /// <returns>combined vector</returns>
        public static IndexedVector Combine(IEnumerable<IndexedVector> vectors, int vectorSize)
        {
            var result = new IndexedVector
            {
                Index = Enumerable.Empty<int>().ToHashSet(),
                Value = Vector.One(vectorSize)
            };
            foreach (var vector in vectors)
            {
                result.Value = result.Value.Multiply(vector.Value);
                result.Index.UnionWith(vector.Index);
            }
            return result;
        }

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