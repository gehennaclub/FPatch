using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPatch.Settings
{
    public class Mapper
    {
        private Address.Pointer pointer { get; set; }
        public Dictionary<Address.Pointer.Method, Func<byte[], byte[]>> mapping { get; set; }

        public Mapper(Address.Pointer pointer)
        {
            this.pointer = pointer;
            mapping = new Dictionary<Address.Pointer.Method, Func<byte[], byte[]>>()
            {
                { Address.Pointer.Method.insert, pointer.insert },
                { Address.Pointer.Method.replace, pointer.replace }
            };
        }
    }
}
