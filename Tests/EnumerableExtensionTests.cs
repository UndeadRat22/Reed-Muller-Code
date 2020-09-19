using System.Linq;
using Communication.Infrastructure;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class EnumerableExtensionTests
    {
        [Test]
        public void Size1ReturnsAllElements()
        {
            //Arrange
            var testSet = new[] {1, 2, 3};

            //Act
            var combinations = testSet.GetCombinations(1);
            
            //Assert
            var result = combinations.SelectMany(c => c).ToArray();
            Assert.AreEqual(testSet.Length, result.Length);
            foreach (var i in testSet)
            {
                Assert.Contains(i, result);
            }
        }

        [Test]
        public void Size2ReturnsAllElements()
        {
            //Arrange
            //Act
            //Assert
        }
    }
}