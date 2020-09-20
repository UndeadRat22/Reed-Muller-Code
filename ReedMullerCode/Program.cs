using System;
using System.Linq;
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
            double probability = 0.0;
            Scenario1(r, m, probability);
        }

        private static void Scenario1(int r, int m, double probability)
        {
            var encoder = new ReedMullerEncoder(r, m, Console.Out);
            Console.WriteLine("Enter a message,");
            Console.WriteLine(encoder.CanEncode("").Message);
            string message;
            ValidationResult validationResult;
            do
            {
                message = Console.ReadLine();
                validationResult = encoder.CanEncode(message);
                if (!validationResult.CanEncode)
                {
                    Console.WriteLine(validationResult.Message);
                }
            } while (!validationResult.CanEncode);

            var encoded = encoder.Encode(message, true);
            Console.WriteLine("Raw encoded message: [before sending]");
            Console.WriteLine(encoded.ToString());
            var channel = new Channel {DistortionProbability = probability};
            var distorted = channel.Pass(encoded);
            Console.WriteLine("Distorted encoded message: [after sending]");
            var v = distorted.Vectors.Single();
            Console.WriteLine(v.ToString());
            Console.WriteLine("You can 'rewrite' this vector, press [Enter] once done.");
            string distortedWithUserMod;
            do
            {
                distortedWithUserMod = Console.ReadLine();
            }
            while (distortedWithUserMod.Length != v.Size);

            var decoder = new ReedMullerDecoder(r, m);
            var decodedMessage = decoder.Decode(new Vector(distortedWithUserMod));
            Console.WriteLine("Message was decoded as:");
            Console.WriteLine(decodedMessage);
        }
    }
}
