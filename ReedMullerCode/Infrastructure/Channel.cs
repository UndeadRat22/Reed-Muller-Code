using System;
using System.Collections;
using System.Linq;

namespace ReedMullerCode.Infrastructure
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
        public BitArray Pass(BitArray data)
        {
            var resultBits = data
                .Cast<bool>()
                .Select(bit => _random.NextDouble() < _distortionProbability ? bit : !bit)
                .ToArray();

            var result = new BitArray(resultBits);
            return result;
        }
    }
}