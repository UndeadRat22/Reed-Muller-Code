using System;
using System.Linq;
using Codes.Infrastructure;
using Codes.Primitives;

namespace Codes.Communication
{
    public class Channel
    {
        public double DistortionProbability
        {
            get => _distortionProbability;
            set => _distortionProbability = value.Clamp(0d, 1d);
        }
        private double _distortionProbability;
        private readonly Random _random;

        public Channel(double distortionProbability, int seed = 666)
        {
            DistortionProbability = distortionProbability;
            _random = new Random(seed);
        }

        /// <summary>
        /// Passes the message though a channel, distorts the data based on the probability
        /// Does not modify the original message (the vectors it contains)!
        /// </summary>
        /// <param name="data"></param>
        public Message Pass(Message data)
        {
            var distortedVectors = data.Vectors.Select(Distort).ToList();
            return new Message
            {
                Vectors = distortedVectors
            };
        }

        /// <summary>
        /// Distorts a given vector based on the random instance.
        /// </summary>
        /// <param name="vector"></param>
        private Vector Distort(Vector vector)
        {
            var distortedBits = vector
                .Select(bit => _random.NextDouble() < _distortionProbability ? !bit : bit);
            return new Vector(distortedBits);
        }
    }
}