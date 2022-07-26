using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qpatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            FPatch.Core fpatch = new FPatch.Core(null, null);

            fpatch.load("fpatch.fpp");
            fpatch.apply();

            Console.ReadLine();
        }
    }
}
