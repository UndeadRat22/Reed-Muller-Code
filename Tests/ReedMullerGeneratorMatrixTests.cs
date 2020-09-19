using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using ReedMullerCode.Codes.ReedMuller;

namespace Tests
{
    public class ReedMullerGeneratorMatrixTests
    {
        [Test]
        public void Test1()
        {
            //Arrange
            //Act
            var matrix = new ReedMullerGeneratorMatrix(3, 4);
            //Assert
            var vs = matrix.Vectors.Select(x => x.ToString())
                .ToList();
        }
    }
}