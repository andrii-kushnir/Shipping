using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiUkrPost.Adresses
{
    public class Region
    {
        [JsonProperty("REGION_ID")]
        public string REGIONID { get; set; }

        [JsonProperty("REGION_UA")]
        public string REGIONUA { get; set; }

        [JsonProperty("REGION_EN")]
        public string REGIONEN { get; set; }

        [JsonProperty("REGION_KOATUU")]
        public string REGIONKOATUU { get; set; }

        [JsonProperty("REGION_RU")]
        public string REGIONRU { get; set; }

        public override string ToString()
        { 
            return REGIONUA;
        }
    }

    public class Regions
    {
        [JsonProperty("Entry")]
        public List<Region> Entry { get; set; }
    }

    public class RegionsRoot
    {
        [JsonProperty("Entries")]
        public Regions Entries { get; set; }
    }

}
