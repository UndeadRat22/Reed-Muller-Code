using System.Collections;

namespace ReedMullerCode.Codes
{
    public interface IEncoder
    {
        public Message Encode(byte[] bytes);
    }
}