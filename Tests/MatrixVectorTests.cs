using Communication.Codes;
using Communication.Codes.ReedMuller;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class MatrixVectorTests
    {
        [Test]
        public void GetCharacteristicVectorKeysReturnsAllCharacteristicKeys()
        {
            //Arrange
            var vector = new ReedMullerGeneratorMatrix.MatrixVector(new []{1}, new Vector("10"));
            //Act
            var keys = vector.GetCharacteristicVectorIndices(2);
            //Assert
            Assert.AreEqual(2, keys[0]);
        }
    }
}