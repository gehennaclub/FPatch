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
            UInt32 count = 0;

            if (Directory.Exists(output) == false)
            {
                Directory.CreateDirectory(output);
            }

            foreach (Types.Patch patch in model.patch.content)
            {
                File.WriteAllText($"{output}\\patched.{count.ToString("00")}", JsonConvert.SerializeObject(patch));
                count++;
            }

            File.WriteAllText($"{output}\\fpatch.fpp", JsonConvert.SerializeObject(model));

        }
    }
}
