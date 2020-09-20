using Communication.Codes;
using Communication.Codes.ReedMuller;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ReedMullerDecoderTests
    {
        [TestCase(1, 3, "00111100", "0110")]
        [TestCase(2, 3, "00110110", "0111010")]
        [TestCase(2, 4, "1010111111111010", "01101001010")]
        [TestCase(2, 4, "1010111011111010", "01101001010")]
        [TestCase(2, 5, "01111110111010001110100010000001", "1111111111111111")]
        [TestCase(2, 5, "01101110101010001110101010000001", "1111111111111111")]
        public void DecodeReturnsCorrectResult(int r, int m, string encoded, string decoded)
        {
            //Arrange
            Vector v = encoded;
            var decoder = new ReedMullerDecoder(r, m);
            //Act
            var result = decoder.Decode(encoded);
            //Assert
            Assert.AreEqual(decoded, result);
        }
    }
}