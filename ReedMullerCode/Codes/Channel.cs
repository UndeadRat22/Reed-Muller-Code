using System;
using System.Linq;
using Communication.Infrastructure;
using Communication.Infrastructure.Collections;

namespace Communication.Codes
{
    public class Channel
    {
        public double DistortionProbability
        {
            get => _distortionProbability;
            set => _distortionProbability = value.Clamp(0d, 1d);
        }

        private readonly Random _random = new Random((int)DateTime.Now.Ticks);
        private double _distortionProbability;
        public Message Pass(Message data)
        {
            var distortedVectors = data.Vectors.Select(Distort).ToArray();
            return new Message
            {
                Vectors = distortedVectors,
                InitialByteCount = data.InitialByteCount
            };
        }

        private Vector Distort(Vector v)
        {
            var distortedBits = v.BitArray.Select(bit => _random.NextDouble() < _distortionProbability ? !bit : bit);
            return new Vector(distortedBits);
        }
    }
}