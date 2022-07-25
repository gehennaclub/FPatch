using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPatch.Tools
{
    public class Payload
    {
        public static UInt32[] build(string data)
        {
            UInt32[] payload = new UInt32[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                payload[i] = (UInt32)data[i];
            }

            return (payload);
        }
    }
}
