using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPatch.Address
{
    public class Pointer
    {
        public UInt32 start { get; set; }
        public UInt32[] payload { get; set; }
        private Dictionary<Method, Action> mapping { get; set; }
        public enum Method
        {
            insert = 0,
            replace = 1
        }

        public Pointer(UInt32 start, UInt32[] payload)
        {
            this.start = start;
            this.payload = payload;
        }

        public byte[] replace(byte[] sources)
        {
            UInt32 index = 0x00000000;
            bool injected = false;
            List<byte> result = new List<byte>();

            foreach (byte source in sources)
            {
                if (index == start)
                {
                    foreach (byte b in payload)
                    {
                        result.Add(b);
                    }
                    injected = true;
                    return (result.ToArray());
                }
                if (injected == false)
                {
                    result.Add(source);
                    index++;
                }
            }

            return (result.ToArray());
        }
    }
}
