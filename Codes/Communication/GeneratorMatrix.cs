using System.Collections.Generic;
using System.Linq;
using Codes.Infrastructure;
using Codes.Primitives;

namespace Codes.Communication
{
    public class GeneratorMatrix
    {
        public int R { get; }
        public int M { get; }
        /// <summary>
        /// Row length
        /// </summary>
        public int VectorSize => 1 << M; // Math.Pow(2, M)
        public int InputVectorSize => _rows.Count;

        private readonly Dictionary<HashSet<int>, MatrixRow> _rows = 
            new Dictionary<HashSet<int>, MatrixRow>(new SetValueComparer<int>());

        private readonly Dictionary<HashSet<int>, IList<Vector>> _characteristicVectors = 
            new Dictionary<HashSet<int>, IList<Vector>>(new SetValueComparer<int>());

        public MatrixRow this[HashSet<int> index] => _rows[index];

        public GeneratorMatrix(int r, int m)
        {
            R = r;
            M = m;
            Generate();
        }

        /// <summary>
        /// Generates the matrix stored in the _rows field
        /// </summary>
        private void Generate()
        {
            var baseVectors = GenerateBaseVectors().ToList();

            baseVectors.Each(row => _rows.Add(row.Index, row));

            //base vectors are x1 (1111 1111), x2 (1111 0000), x3 (1100, 1100), x4 (1010 1010) for m = 3
            //the next step is to generate the full generator matrix using (r) products with the base vectors
            //i.e. if r = 2, then it should be base vectors + (x1*x2, x1*x3, x1*x4), (x2*x3, x2*x4), (x3 * x4), and r = 3 would
            //include x1*x2*x3, etc.
            if (R > 1)
            {
                //getting the combinations of all vectors in R means (R being the max selection size).
                //note - combinations, not permutations, as V1 * V2 == V2 * V1
                //skipping the 'One' Vector as it simply provides the same vector after multiplication (V * V1 = V)
                var vectorCombinations = baseVectors.Skip(1).GetCombinations(2, R);

                //populate the matrix
                vectorCombinations
                    .Select(GetCombinedRow)
                    .Each(row => _rows.Add(row.Index, row));
            }
        }


        /// <summary>
        /// Multiplies the matrix by a vector the size of matrix height
        /// </summary>
        /// <param name="vector">vector to multiply the matrix with</param>
        /// <returns>a vector the size of any given matrix vector</returns>
        public Vector Multiply(Vector vector)
        {
            return _rows
                .Select((indexedRow, index) => indexedRow.Value.Vector.Multiply(vector[index]))
                .Aggregate(Vector.Zero(VectorSize), (agg, v) => agg.Add(v));
        }

        /// <summary>
        /// Combines the rows using vector multiplication
        /// </summary>
        /// <param name="rows"></param>
        /// <returns>A row, with the combined values and indices as used indices</returns>
        private MatrixRow GetCombinedRow(IEnumerable<MatrixRow> rows)
        {
            var result = MatrixRow.Empty(VectorSize);
            rows.Each(row => result.Multiply(row));
            return result;
        }

        private IEnumerable<MatrixRow> GenerateBaseVectors()
        {
            var one = new MatrixRow(Vector.One(VectorSize), 0);
            yield return one;
            if (R == 0)
            {
                yield break;
            }
            //Generates vectors like 11110000, 11001100, 10101010 when VectorSize == 8
            var index = 0;
            for (var currentSize = VectorSize >> 1; currentSize >= 1; currentSize >>= 1)
            {
                var onePart = Enumerable.Repeat(true, currentSize);
                var zeroPart = Enumerable.Repeat(false, currentSize);
                var element = onePart.Concat(zeroPart).ToList();
                var vectorBits = Enumerable.Repeat(element, VectorSize / (currentSize << 1))
                    .SelectMany(bit => bit);

                var row = new MatrixRow(new Vector(vectorBits), ++index);
                yield return row;
            }
        }
    }

    public class MatrixRow
    {
        public HashSet<int> Index { get; private set; }
        public Vector Vector { get; private set; }
        public MatrixRow(Vector vector, params int[] key)
        {
            Index = key?.ToHashSet() ?? new HashSet<int>();
            Vector = vector;
        }

        public HashSet<int> GetCharacteristicIndices(int m)
        {
            return Enumerable.Range(1, m)
                .Except(Index)
                .ToHashSet();
        }

        public void Multiply(MatrixRow other)
        {
            Vector = Vector.Multiply(other.Vector);
            Index.UnionWith(other.Index);
        }


        public static MatrixRow Empty(int size) => new MatrixRow(Vector.One(size));
    }
}