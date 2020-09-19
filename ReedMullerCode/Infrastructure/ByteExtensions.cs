using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Communication.Infrastructure
{
    public static class ByteExtensions
    {
        public static List<bool> ToBits(this byte b)
        {
            return new BitArray(new []{ b }).Cast<bool>().Reverse().ToList();
        }
    }
}