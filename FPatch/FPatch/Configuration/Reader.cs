using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace FPatch.Configuration
{
    public class Reader
    {
        public Model.Rootobject load(string raw)
        {
            return (JsonConvert.DeserializeObject<Model.Rootobject>(raw));
        }
    }
}
