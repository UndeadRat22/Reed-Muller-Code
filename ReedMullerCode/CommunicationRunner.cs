using ReedMullerCode.Infrastructure;

namespace ReedMullerCode
{
    public class CommunicationRunner
    {
        private readonly IDecoder _decoder;
        private readonly IEncoder _encoder;
        private readonly IChannel _channel;

        public CommunicationRunner(
            IDecoder decoder, IEncoder encoder, IChannel channel)
        {
            _decoder = decoder;
            _encoder = encoder;
            _channel = channel;
        }
    }
}