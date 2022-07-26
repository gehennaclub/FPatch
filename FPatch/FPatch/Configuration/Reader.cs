using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace FPatch.Configuration
{
    public class Reader
    {
        public Model.Rootobject load(string file)
        {
            return (JsonConvert.DeserializeObject<Model.Rootobject>(File.ReadAllText(file)));
        }
    }
}
