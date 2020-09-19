using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using Communication.Codes.ReedMuller;
using NUnit.Framework;

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
            Assert.AreEqual(1, matrix.Vectors.Length);
            Assert.AreEqual((int)BigInteger.Pow(2, m), matrix.Vectors.Single().BitArray.Length);
        }
        [Test]
        public void OneRMatrixGeneratesAlternatingVectors1()
        {
            //Arrange
            //Act
            var matrix = new ReedMullerGeneratorMatrix(1, 1);
            //Assert
            Assert.AreEqual("10", matrix.Vectors[1].ToString());
            Assert.AreEqual(2, matrix.Vectors.Length);
        }
        [Test]
        public void OneRMatrixGeneratesAlternatingVectors2()
        {
            //Arrange
            //Act
            var matrix = new ReedMullerGeneratorMatrix(1, 2);
            //Assert
            Assert.AreEqual("1100", matrix.Vectors[1].ToString());
            Assert.AreEqual("1010", matrix.Vectors[2].ToString());
            Assert.AreEqual(3, matrix.Vectors.Length);
        }

        [Test]
        //[Ignore("test for debugging")]
        public void Test()
        {
            var matrix = new ReedMullerGeneratorMatrix(2, 3);

            var result = matrix.Vectors.Select(v => v.ToString()).ToList();
        }
    }
}