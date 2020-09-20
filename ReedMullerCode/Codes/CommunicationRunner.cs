using System;
using System.IO;
using System.Text;

namespace Communication.Codes
{
    public class CommunicationRunner
    {
        private readonly IDecoder _decoder;
        private readonly IEncoder _encoder;
        private readonly Channel _channel;
        private readonly TextWriter _writer;

        public CommunicationRunner(
            IDecoder decoder, IEncoder encoder, Channel channel, TextWriter outWriter = null)
        {
            _decoder = decoder;
            _encoder = encoder;
            _channel = channel;
            _writer = outWriter ?? Console.Out;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Run(byte[] data)
        {
            //var startingMessage = _encoder.Encode(data, true);
            //_writer.WriteLine(startingMessage.ToString());

            //var result = _decoder.Decode(startingMessage);
            //var resultString = Encoding.ASCII.GetString(result);
            //_writer.WriteLine(resultString);
        }
    }
}