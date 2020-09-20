using System.Text;

namespace Communication.Codes
{
    public class Message
    {
        public Vector[] Vectors { get; set; }

        //Utility info
        public int InitialByteCount { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var vector in Vectors)
            {
                builder.Append($"{vector} ");
            }
            return builder.ToString();
        }
    }
}