using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPatch.Configuration
{
    public class Model
    {
        public class Rootobject
        {
            public Patch patch { get; set; }
            public Settings settings { get; set; }
        }

        public class Patch
        {
            public string version { get; set; }
            public string author { get; set; }
            public List<Types.Patch> content { get; set; }
        }

        public class Settings
        {
            public string version { get; set; }
        }
    }
}
