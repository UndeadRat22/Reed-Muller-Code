using Communication.Codes;
using Communication.Codes.ReedMuller;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ReedMullerDecoderTests
    {
        [TestCase(2, 3, "00110110", "0111010")]
        [TestCase(1, 3, "00111100", "0110")]
        public void DecodeReturnsCorrectResult(int r, int m, string encoded, string decoded)
        {
            //Arrange
            Vector v = encoded;
            var decoder = new ReedMullerDecoder(2, 3);
            //Act
            var result = decoder.Decode(encoded);
            //Assert
            Assert.AreEqual(decoded, result);
        }
    }
}