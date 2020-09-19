using System.Linq;
using Communication.Infrastructure;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class EnumerableExtensionTests
    {
        [Test]
        public void GetCombinationsOfSize1ReturnsAllElements()
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
        public void GetCombinationsOfSize2ReturnsAllElements()
        {
            //Arrange
            var testSet = new[] {1, 2, 3};
            var expectedSet = new[] {new[] {1, 2}, new[] {1, 3}, new[] {2, 3}};
            //Act
            var combinations = testSet.GetCombinations(2)
                .Select(c => c.ToArray())
                .ToArray();
            //Assert
            foreach (var combination in expectedSet)
            {
                var contains = combinations.Any(c => c[0] == combination[0] && c[1] == combination[1]);
                Assert.IsTrue(contains);
            }
        }

        [Test]
        public void GetCombinationsOfSize2_2ReturnsAllElements()
        {
            //Arrange
            var testSet = new[] { 1, 2, 3 };
            var expectedSet = new[] { new[] { 1, 2 }, new[] { 1, 3 }, new[] { 2, 3 } };
            //Act
            var combinations = testSet.GetCombinations(2, 2)
                .Select(c => c.ToArray())
                .ToArray();
            //Assert
            foreach (var combination in expectedSet)
            {
                var contains = combinations.Any(c => c[0] == combination[0] && c[1] == combination[1]);
                Assert.IsTrue(contains);
            }
        }
    }
}