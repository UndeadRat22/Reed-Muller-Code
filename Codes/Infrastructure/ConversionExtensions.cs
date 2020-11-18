using System.Collections.Generic;

namespace Codes.Infrastructure
{
    public static class ConversionExtensions
    {
        /// <summary>
        /// Converts bits to a byte
        /// </summary>
        /// <param name="source"></param>
        public static byte ToByte(this IList<bool> source)
        {
            byte result = 0;
            int index = 8 - source.Count;

            foreach (var b in source)
            {
                if (b)
                    result |= (byte) (1 << (7 - index));
                index++;
            }
            return result;
        }

        /// <summary>
        /// Converts byte to bits
        /// </summary>
        /// <param name="b"></param>
        /// <returns>list of bits</returns>
        public static IList<bool> ToBoolList(this byte b)
        {
            List<bool> result = new List<bool>(8);
            for (int i = 0; i < 8; i++)
                result.Add((b & (1 << i)) != 0);

            result.Reverse();
            return result;
        }
    }
}