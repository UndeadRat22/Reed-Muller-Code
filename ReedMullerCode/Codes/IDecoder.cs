using System.Collections;

namespace ReedMullerCode.Codes
{
    public interface IDecoder
    {
        public byte[] Decode(BitArray bits);
    }
}