using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace FPatch.Configuration
{
    public class Writter
    {
        public void save(Model.Rootobject model)
        {
            string output = "patch";

            if (Directory.Exists(output) == false)
            {
                Directory.CreateDirectory(output);
            }

            File.WriteAllText($"{output}\\fpatch.fpp", JsonConvert.SerializeObject(model, Formatting.Indented));

        }
    }
}
