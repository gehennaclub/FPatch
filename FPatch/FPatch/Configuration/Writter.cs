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
            File.WriteAllText("patch.fpp", JsonConvert.SerializeObject(model));
        }
    }
}
