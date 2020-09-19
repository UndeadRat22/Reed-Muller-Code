using System.Linq;
using System.Numerics;
using Communication.Codes;
using Communication.Codes.ReedMuller;
using NUnit.Framework;
using Vector = Communication.Codes.Vector;

namespace Tests
{
    public class ReedMullerGeneratorMatrixTests
    {
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void ZeroRMatrixReturnsOnlyOneVector(int m)
        {
            //Arrange
            //Act
            var matrix = new ReedMullerGeneratorMatrix(0, m);
            //Assert
            Assert.AreEqual(1, matrix.Rows.Count);
            Assert.AreEqual((int)BigInteger.Pow(2, m), matrix.Rows.Single().Value.Size);
        }
        [Test]
        public void OneRMatrixGeneratesAlternatingVectors1()
        {
            //Arrange
            //Act
            var matrix = new ReedMullerGeneratorMatrix(1, 1);
            //Assert
            Assert.AreEqual("10", matrix.Rows[new[] { 1 }].ToString());
            Assert.AreEqual(2, matrix.Rows.Count);
        }
        [Test]
        public void OneRMatrixGeneratesAlternatingVectors2()
        {
            //Arrange
            //Act
            var matrix = new ReedMullerGeneratorMatrix(1, 2);
            //Assert
            Assert.AreEqual("1100", matrix.Rows[new []{ 1 }].ToString());
            Assert.AreEqual("1010", matrix.Rows[new []{ 2 }].ToString());
            Assert.AreEqual(3, matrix.Rows.Count);
        }

        [Test]
        public void MultiplyRM24Returns1010111111111010()
        {
            //Arrange
            var matrix = new ReedMullerGeneratorMatrix(2, 4);
            //Act
            Vector vector = "01101001010";
            var result = matrix.Multiply(vector);
            //Assert
            Assert.AreEqual("1010111111111010", result.ToString());
        }

        [Test]
        //[Ignore("test for debugging")]
        public void Test()
        {

            var matrix = new ReedMullerGeneratorMatrix(2, 4);

            var result = matrix.Rows.Select(v => v.ToString()).ToList();
        }

    }
}