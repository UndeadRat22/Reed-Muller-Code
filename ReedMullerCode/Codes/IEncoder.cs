using System.Collections;

namespace ReedMullerCode.Codes
{
    public interface IEncoder
    {
        public BitArray Encode(byte[] bytes);
    }
}