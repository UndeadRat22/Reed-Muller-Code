﻿namespace Communication.Codes
{
    public class CommunicationRunner
    {
        private readonly IDecoder _decoder;
        private readonly IEncoder _encoder;
        private readonly Channel _channel;

        public CommunicationRunner(
            IDecoder decoder, IEncoder encoder, Channel channel)
        {
            _decoder = decoder;
            _encoder = encoder;
            _channel = channel;
        }

        public void Run(byte[] data)
        {
            var startingMessage = _encoder.Encode(data);
            var result = _decoder.Decode(startingMessage);
        }
    }
}