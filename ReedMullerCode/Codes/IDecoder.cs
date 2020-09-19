namespace Communication.Codes
{
    public interface IDecoder
    {
        public byte[] Decode(Message bits);
    }
}