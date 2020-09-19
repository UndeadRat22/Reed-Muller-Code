using System.Collections.Generic;
using System.Linq;

namespace Communication.Codes.ReedMuller
{
    public class ReedMullerGeneratorMatrix
    {
        public int R { get; set; }
        public int M { get; set; }
        public int VectorSize => 2 << M;
        public Vector[] Vectors { get; private set; }
        public ReedMullerGeneratorMatrix(int r, int m)
        {
            M = m;
            R = r;
            Generate();
        }

        private void Generate()
        {
            if (R == 0)
            {
                Vectors = new[] {Vector.One(VectorSize)};
                return;
            }
            var baseVectors = new List<Vector>
            {
                Vector.One(VectorSize)
            };
            for (var currentSize = VectorSize >> 1; currentSize >= 1; currentSize >>= 1)
            {
                var onePart = Enumerable.Repeat(true, currentSize);
                var zeroPart = Enumerable.Repeat(false, currentSize);
                var elem = onePart.Concat(zeroPart).ToArray();
                var vectorBits = Enumerable.Repeat(elem, VectorSize / (currentSize << 1))
                    .SelectMany(x => x);

                baseVectors.Add(new Vector(vectorBits));
            }
            //base vectors are (1111 1111), (1111 0000), (1100, 1100), (1010 1010) for m = 3 after the loop
            //the next step is to generate the full generator matrix using (r) products with the base vectors
            //i.e. if r = 2, then 

            Vectors = baseVectors.ToArray();

        }
    }
}