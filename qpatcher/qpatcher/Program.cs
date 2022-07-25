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
            string file = "fpatch.fpp";
            FPatch.Core fpatch = new FPatch.Core(null, null);

            fpatch.load(File.ReadAllText(file));
            fpatch.apply();

            Console.ReadLine();
        }
    }
}
