using Communication.Codes;
using Communication.Codes.ReedMuller;
using Communication.Infrastructure.Collections;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CommunicationRunnerTests
    {
        [Test]
        public void Foo()
        {
            //Arrange
            var runner = new CommunicationRunner(new ReedMullerDecoder(2, 3), new ReedMullerEncoder(2, 3), new Channel());
            //Act

            var bytes = new[] {(byte) 0x55 };
            var bitArray = new BitArray(bytes);

            runner.Run(new []{ (byte)0b01010101, (byte)0b11110011 });
            //Assert
        }
    }
}