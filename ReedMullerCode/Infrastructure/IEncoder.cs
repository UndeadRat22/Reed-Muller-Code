using System.Collections;

namespace ReedMullerCode.Infrastructure
{
    public interface IEncoder
    {
        public BitArray Encode(byte[] bytes);
    }
}