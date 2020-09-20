using System;
using System.Text;
using Communication.Codes;
using Communication.Codes.ReedMuller;

namespace Communication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int r = 2;
            int m = 3;
            var runner = new CommunicationRunner(
                new ReedMullerDecoder(r, m), 
                new ReedMullerEncoder(r, m, Console.Out), 
                new Channel(),
                Console.Out);

            var message = "hello world!";
            var bytes = Encoding.ASCII.GetBytes(message);

            runner.Run(bytes);
        }
    }
}
