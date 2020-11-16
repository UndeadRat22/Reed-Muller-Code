using System.Collections.Generic;
using System.Text;
using Codes.Infrastructure;
using Codes.Primitives;

namespace Codes.Communication
{
    public class Message
    {
        public IList<Vector> Vectors { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            Vectors.Each(vector => builder.Append($"{vector} "));
            return builder.ToString();
        }
    }
}