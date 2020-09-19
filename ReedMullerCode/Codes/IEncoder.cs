namespace Communication.Codes
{
    public interface IEncoder
    {
        public Message Encode(byte[] bytes);
    }
}