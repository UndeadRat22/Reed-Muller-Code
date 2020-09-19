using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Communication.Infrastructure.Collections
{
    public class BitArray : IEnumerable<bool>
    {
        public IList<bool> Values { get; set; }
        public bool this[int index] => Values[index];
        public int Count => Values.Count;
        public BitArray(IList<bool> values)
        {
            Values = values;
        }

        public BitArray(IEnumerable<byte> bytes) 
            : this(bytes.SelectMany(b => b.ToBits()).ToList()){}

        public IEnumerator<bool> GetEnumerator() 
            => Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}