using Communication.Codes;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class VectorTests
    {
        [TestCase("00110110", "11000000", false)]
        [TestCase("00110110", "10100000", true)]
        [TestCase("00110110", "10001000", false)]
        [TestCase("11000000", "10111100", true)]
        [TestCase("00001100", "10111100", false)]
        [TestCase("00110000", "10111100", false)]
        [TestCase("00000011", "10111100", false)]
        public void DotProductReturnsCorrectValue(string v1s, string v2s, bool expected)
        {
            //Arrange
            Vector v1 = v1s;
            Vector v2 = v2s;
            //Act
            var result = v1.DotProduct(v2);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}