using System;
using System.Diagnostics;
using System.Linq;
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
            Assert.AreEqual(2 << m, matrix.Vectors.Single().BitArray.Length);
        }
    }
}