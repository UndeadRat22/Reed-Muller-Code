using Communication.Codes;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class VectorTests
    {
        [Test]
        public void DotProductReturnsCorrectValue()
        {
            //Arrange
            Vector v1 = "10011110";
            Vector v2 = "11101001";
            //Act
            var result = v1.DotProduct(v2);
            //Assert
            Assert.IsTrue(result);
        }
    }
}