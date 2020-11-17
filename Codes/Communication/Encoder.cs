using System.Linq;

namespace Codes.Communication
{
    public class Encoder
    {
        private readonly GeneratorMatrix _generatorMatrix;

        public Encoder(GeneratorMatrix generatorMatrix)
        {
            _generatorMatrix = generatorMatrix;
        }

        public Message Encode(Message message)
        {
            return new Message
            {
                Vectors = message.Vectors
                    .Select(vector => _generatorMatrix.Multiply(vector))
                    .ToList()
            };
        }
    }
}