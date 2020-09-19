using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;

namespace ReedMullerCode.Codes.ReedMuller
{
    public class ReedMullerGeneratorMatrix
    {
        public int M { get; set; }
        public int R { get; set; }
        public int N => 2 << M;
        public Vector[] Vectors { get; private set; }
        public ReedMullerGeneratorMatrix(int m, int r)
        {
            M = m;
            R = r;
            Generate();
        }

        private void Generate()
        {
            var vectorSize = N;
            //generate matrix akin to
            //0000 1111
            //0011 0011
            //0101 0101
            var vectors = new List<Vector>
            {
                Vector.One(vectorSize),
                Vector.Zero(vectorSize)
            };
            for (var currentSize = vectorSize >> 1; currentSize >= 1; currentSize >>= 1)
            {
                //0000
                var onePart= Enumerable.Repeat(true, currentSize);
                //1111
                var zeroPart= Enumerable.Repeat(false, currentSize);
                //0000 1111
                var elem = onePart.Concat(zeroPart).ToArray();

                var vectorBits = Enumerable.Repeat(elem, vectorSize / (currentSize << 1))
                    .SelectMany(x => x);

                vectors.Add(new Vector(vectorBits));
            }

            Vectors = vectors.ToArray();
        }

    }
}