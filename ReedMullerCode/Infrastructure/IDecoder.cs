using System.Collections;

namespace ReedMullerCode.Infrastructure
{
    public interface IDecoder
    {
        public byte[] Decode(BitArray bits);
    }
}