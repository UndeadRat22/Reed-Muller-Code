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
        public MatrixVector[] Rows { get; private set; }

        //Characteristic vector lookup map
        private readonly Dictionary<int[], Vector> _characteristicVectors = new Dictionary<int[], Vector>(new ArrayValueComparer<int>());
        public ReedMullerGeneratorMatrix(int r, int m)
        {
            M = m;
            R = r;
            Generate();
        }

        public MatrixVector this[params int[] index]
            => Rows.First(row => row.HasKey(index));

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
                        .Aggregate(new MatrixVector(new int[]{}, Vector.One(VectorSize)), 
                            (acc, v) => 
                                new MatrixVector(acc.Key.Concat(v.Key).ToArray(), acc.Value.Multiply(v.Value))));

                Rows = baseVectors.Concat(productVectors).ToArray();
            }
            else
            {
                Rows = baseVectors;
            }
        }

        /// <summary>
        /// Generates the base vectors to generate the matrix with;
        /// </summary>
        /// <returns>indexed base vectors</returns>
        private IEnumerable<MatrixVector> GenerateBaseVectors()
        {
            var vectors = new MatrixVector(new []{ 0 }, Vector.One(VectorSize));
            yield return vectors;
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

                var vector = new MatrixVector(new[] { ++index }, new Vector(vectorBits));
                yield return vector;
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

        public IEnumerable<Vector> GetCharacteristicVectorsFor(int[] key)
        {
            var matrixVector = this[key];
            var indices = matrixVector.GetCharacteristicVectorIndices(M);
            //need inversed vectors too.
            var characteristicVectorKeyCombinations = indices
                .SelectMany(index => new[] {index, -index})
                .GetCombinations(indices.Length)
                .Select(c => c.ToArray())
                .Where(c => c.All(e => !c.Contains(-e))); //filter out keys like x1!(x1);

            foreach (var comb in characteristicVectorKeyCombinations)
            {
                var contains = _characteristicVectors.TryGetValue(comb, out var vector);
                if (contains) yield return vector;
                else
                {
                    var result = Vector.One(VectorSize);
                    foreach (var index in comb)
                    {
                        var isInverse = index < 0;
                        vector = this[isInverse ? -index : index].Value;
                        vector = isInverse ? vector.Complement() : vector;
                        result = result.Multiply(vector);
                    }
                    _characteristicVectors.Add(comb, result);
                    yield return result;
                }
            }
        }

        public class MatrixVector
        {
            public int[] Key { get; set; }
            public Vector Value { get; set; }
            public MatrixVector(int[] key, Vector value)
            {
                Key = key;
                Value = value;
            }

            public bool HasKey(params int[] key)
            {
                return key.Length == Key.Length && Key.All(key.Contains);
            }

            public int[] GetCharacteristicVectorIndices(int m)
            {
                return Enumerable.Range(1, m)
                    .Except(Key)
                    .ToArray();
            }
        }
    }
}