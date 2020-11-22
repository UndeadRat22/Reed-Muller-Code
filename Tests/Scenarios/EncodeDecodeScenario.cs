using System.Linq;
using Communication.Codes.ReedMuller;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace Tests.Scenarios
{
    [TestFixture]
    public class EncodeDecodeScenario
    {
        [TestCase(1, 3, "0110")]
        [TestCase(2, 3, "0111010")]
        [TestCase(2, 3, "0111011")]
        [TestCase(2, 3, "1111011")]
        [TestCase(2, 3, "1010101")]
        [TestCase(2, 3, "1111111")]
        [TestCase(2, 3, "1111110")]
        [TestCase(2, 3, "0111110")]
        [TestCase(2, 4, "01101001010")]
        [TestCase(2, 4, "01101011010")]
        [TestCase(2, 5, "1111111111111111")]
        [TestCase(2, 5, "1111111111111111")]
        [TestCase(3, 4, "101010101010101")]
        [TestCase(3, 4, "101010101010001")]
        [TestCase(3, 3, "10101010")]
        [TestCase(2, 4, "10100000000")]
        public void Test(int r, int m, string raw)
        {
            //Arrange
            var encoder = new ReedMullerEncoder(r, m, null);
            var decoder = new ReedMullerDecoder(r, m);
            //Act
            var codedVector = encoder.Encode(raw);
            var decodedString = decoder.Decode(codedVector);
            //Assert
            Assert.AreEqual(raw, decodedString);
        }

        
        [TestCase(1, 3, new [] {(byte)0xFF, (byte)0x00 })]
        [TestCase(1, 3, new [] {(byte)0b0000001 })]
        [TestCase(1, 3, new [] {(byte)0b0000010 })]
        [TestCase(1, 3, new [] {(byte)0b0000100 })]
        [TestCase(1, 3, new [] {(byte)0b0001000 })]
        [TestCase(1, 3, new [] {(byte)0b0010000 })]
        [TestCase(1, 3, new [] {(byte)0b0100000 })]
        [TestCase(1, 3, new [] {(byte)0b1000000 })]
        public void BasicCombinationsAreNotShifted(int r, int m, byte[] raw)
        {
            //Arrange
            var encoder = new ReedMullerEncoder(r, m, null);
            var decoder = new ReedMullerDecoder(r, m);
            //Act
            var encoded = encoder.Encode(raw, false);
            var decoded = decoder.Decode(encoded);
            //Assert
            Assert.AreEqual(raw.Length, decoded.Length);
            foreach (var pair in raw.Zip(decoded))
            {
             Assert.AreEqual(pair.First, pair.Second);   
            }
        }

        [TestCase(1, 3, new[] { (byte)0b0001000 })]
        [TestCase(2, 3, new[] { (byte)0b0001000 })]
        [TestCase(2, 5, new[] { (byte)0b0001000 })]
        [TestCase(3, 5, new[] { (byte)0b0001000 })]
        public void SameArraySizeForAnyRMCombination(int r, int m, byte[] raw)
        {
            //Arrange
            var encoder = new ReedMullerEncoder(r, m, null);
            var decoder = new ReedMullerDecoder(r, m);
            //Act
            var encoded = encoder.Encode(raw, false);
            var decoded = decoder.Decode(encoded);
            //Assert
            Assert.AreEqual(raw.Length, decoded.Length);
            foreach (var (first, second) in raw.Zip(decoded))
            {
                Assert.AreEqual(first, second);
            }
        }
    }
}