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
        public Vector[] Vectors { get; private set; }
        public ReedMullerGeneratorMatrix(int r, int m)
        {
            M = m;
            R = r;
            Generate();
        }

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

                //with every set(combination of vectors) perform a aggregation action: multiply the vectors together;
                var productVectors = vectorCombinations
                    .Select(combination => combination
                        .Aggregate(Vector.One(VectorSize), (acc, v) => acc.Multiply(v)));
                Vectors = baseVectors.Concat(productVectors).ToArray();
            }
            else
            {
                Vectors = baseVectors;
            }
        }

        /// <summary>
        /// Generates the base vectors to generate the matrix with;
        /// </summary>
        /// <returns>Base vectors</returns>
        private IEnumerable<Vector> GenerateBaseVectors()
        {
            if (R == 0)
            {
                yield return Vector.One(VectorSize);
                yield break;
            }
            for (var currentSize = VectorSize >> 1; currentSize >= 1; currentSize >>= 1)
            {
                var onePart = Enumerable.Repeat(true, currentSize);
                var zeroPart = Enumerable.Repeat(false, currentSize);
                var elem = onePart.Concat(zeroPart).ToArray();
                var vectorBits = Enumerable.Repeat(elem, VectorSize / (currentSize << 1))
                    .SelectMany(x => x);

                yield return new Vector(vectorBits);
            }
        }
    }
}