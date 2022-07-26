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

            fpatch.create_and_add(
                "test.txt",
                0x00000008,
                FPatch.Tools.Payload.build("A PATCHED TEST "),
                FPatch.Address.Pointer.Method.insert
            );

            //fpatch.create_and_add(
            //    "test.txt",
            //    0x00000008,
            //    FPatch.Tools.Payload.build("A PATCHED TEST"),
            //    FPatch.Address.Pointer.Method.replace
            //);

            fpatch.apply();
            fpatch.save();
            //fpatch.restore();

            Console.ReadKey();
        }
    }
}
