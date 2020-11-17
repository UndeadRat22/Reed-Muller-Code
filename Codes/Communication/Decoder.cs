namespace Codes.Communication
{
    public class Decoder
    {
        private readonly GeneratorMatrix _generatorMatrix;

        public Decoder(GeneratorMatrix generatorMatrix)
        {
            _generatorMatrix = generatorMatrix;
        }

        public Message Decode(Message message)
        {
            return message;
        }
    }
}