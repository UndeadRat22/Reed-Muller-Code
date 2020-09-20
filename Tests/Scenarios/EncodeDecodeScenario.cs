using Communication.Codes.ReedMuller;
using NUnit.Framework;

namespace Tests.Scenarios
{
    [TestFixture]
    public class EncodeDecodeScenario
    {
        [TestCase(1, 3, "0110")]
        [TestCase(2, 3, "0111010")]
        [TestCase(2, 4, "01101001010")]
        [TestCase(2, 4, "01101001010")]
        [TestCase(2, 5, "1111111111111111")]
        [TestCase(2, 5, "1111111111111111")]
        public void Test(int r, int m, string raw)
        {
            //Arrange
            var encoder = new ReedMullerEncoder(r, m, null);
            var decoder = new ReedMullerDecoder(r, m);
            //Act
            var codedVector = encoder.Encode(raw);
            var decodedString = decoder.Decode(codedVector);

            Assert.AreEqual(raw, decodedString);
        }
    }
}