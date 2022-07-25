using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            FPatch.Core fpatch = new FPatch.Core("neo", "1.0.0");

            fpatch.create_and_add("test.txt", 0x00000008, new UInt32[]
            {
                (UInt32)'N',
                (UInt32)'O',
                (UInt32)'T',
                (UInt32)' ',
                (UInt32)'A',
                (UInt32)' ',
                (UInt32)'T',
                (UInt32)'E',
                (UInt32)'S',
                (UInt32)'T'
            });

            fpatch.apply();
            fpatch.save();

            Console.ReadKey();
        }
    }
}
