using System.Linq;
using Codes.Infrastructure;
using Codes.Primitives;

namespace Codes.Communication
{
    public static class MessageTools
    {
        /// <summary>
        /// Builds a message from bytes, performs padding, chucking (batching) etc.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="vectorSize"></param>
        /// <returns></returns>
        public static Message BuildMessage(byte[] bytes, in int vectorSize)
        {
            int sizeInBits = bytes.Length * Constants.BitsInByte;
            var allBits = bytes.SelectMany(b => b.ToBoolList()).ToList();
            var nonFittingBits = sizeInBits % vectorSize;
            //if the bits are not splittable into a whole number of vectors
            //need to "pad" the bit list with extra bits so they fit exactly.
            if (nonFittingBits > 0) 
            {
                allBits = allBits.Pad(vectorSize - nonFittingBits, false).ToList();
            }

            var vectors = allBits
                .Batch(vectorSize)
                .Select(bits => new Vector(bits))
                .ToList();

            return new Message
            {
                Vectors = vectors
            };
        }
    }
}