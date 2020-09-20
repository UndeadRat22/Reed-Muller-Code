namespace Communication.Codes
{
    public interface IEncoder
    {
        public Message Encode(byte[] bytes, bool log);
        public Message Encode(string bitString, bool log);
        public ValidationResult CanEncode(string bitString);
    }

    public class ValidationResult
    {
        public bool CanEncode { get; set; }
        public string Message { get; set; }
    }
}