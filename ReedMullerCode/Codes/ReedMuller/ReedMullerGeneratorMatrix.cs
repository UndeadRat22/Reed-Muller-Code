using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Communication.Infrastructure;

namespace Communication.Codes.ReedMuller
{
    public class ReedMullerGeneratorMatrix
    {
        public int R { get; set; }
        public int M { get; set; }
        public int VectorSize => (int)BigInteger.Pow(2, M);
        public int WordSize => Rows.First().Value.Size;
        public Dictionary<int[], Vector> Rows { get; private set; }
        public ReedMullerGeneratorMatrix(int r, int m)
        {
            M = m;
            R = r;
            Generate();
        }


        /// <summary>
        /// Generates the GRM matrix vectors
        /// </summary>
        private void Generate()
        {
            var baseVectors = GenerateBaseVectors().ToArray();

            //base vectors are x1 (1111 1111), x2 (1111 0000), x3 (1100, 1100), x4 (1010 1010) for m = 3
            //the next step is to generate the full generator matrix using (r) products with the base vectors
            //i.e. if r = 2, then it should be base vectors + (x1*x2, x1*x3, x1*x4), (x2*x3, x2*x4), (x3 * x4), and r = 3 would
            //include x1*x2*x3, etc.
            if (R > 1)
            {
                //getting the combinations of all vectors in R means (R being the max selection size). Note - combinations, not permutations, as V1 * V2 == V2 * V1
                //skipping the 'One' Vector as it simply provides the same vector after multiplication (V * V1 = V)
                var vectorCombinations = baseVectors.Skip(1).GetCombinations(2, R);

                //with every set(combination of vectors) perform an aggregation action: multiply the vectors together
                //also keep track of the indices used for the creation of vectors;
                var productVectors = vectorCombinations
                    .Select(combination => combination
                        .Aggregate(new KeyValuePair<int[], Vector>(new int[]{}, Vector.One(VectorSize)), 
                            (acc, v) => 
                                new KeyValuePair<int[], Vector>(acc.Key.Concat(v.Key).ToArray(), acc.Value.Multiply(v.Value))));

                Rows = new Dictionary<int[], Vector>(baseVectors.Concat(productVectors), new ArrayValueComparer<int>());
            }
            else
            {
                Rows = new Dictionary<int[], Vector>(baseVectors, new ArrayValueComparer<int>());
            }
        }

        /// <summary>
        /// Generates the base vectors to generate the matrix with;
        /// </summary>
        /// <returns>indexed base vectors</returns>
        private IEnumerable<KeyValuePair<int[], Vector>> GenerateBaseVectors()
        {
            yield return new KeyValuePair<int[], Vector>(new []{ 0 }, Vector.One(VectorSize));
            if (R == 0)
            {
                yield break;
            }

            var index = 0;
            for (var currentSize = VectorSize >> 1; currentSize >= 1; currentSize >>= 1)
            {
                var onePart = Enumerable.Repeat(true, currentSize);
                var zeroPart = Enumerable.Repeat(false, currentSize);
                var elem = onePart.Concat(zeroPart).ToArray();
                var vectorBits = Enumerable.Repeat(elem, VectorSize / (currentSize << 1))
                    .SelectMany(x => x);

                yield return new KeyValuePair<int[], Vector>(new[] {++index}, new Vector(vectorBits));
            }
        }

        /// <summary>
        /// Multiplies the matrix by a vector the size of matrix height
        /// </summary>
        /// <param name="vector">vector to multiply the matrix with</param>
        /// <returns>a vector the size of any given matrix vector</returns>
        public Vector Multiply(Vector vector)
        {
            return Rows.Select((row, index) => row.Value.Multiply(vector[index]))
                .Aggregate(Vector.Zero(VectorSize), (agg, v) => agg.Add(v));
        }
    }
}