using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiUkrPost.Adresses
{
    public class Courierarea
    {
        [JsonProperty("IS_COURIERAREA")]
        public string ISCOURIERAREA { get; set; }

        [JsonProperty("postindex")]
        public string Postindex { get; set; }
    }

    public class Courierareas
    {
        [JsonProperty("Entry")]
        public List<Courierarea> Entry { get; set; }
    }

    public class CourierareasRoot
    {
        [JsonProperty("Entries")]
        public Courierareas Entries { get; set; }
    }
}
