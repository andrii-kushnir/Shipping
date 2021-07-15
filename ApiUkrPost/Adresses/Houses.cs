using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiUkrPost.Adresses
{
    public class House
    {
        [JsonProperty("STREET_ID")]
        public string STREETID { get; set; }

        [JsonProperty("POSTCODE")]
        public string POSTCODE { get; set; }

        [JsonProperty("HOUSENUMBER_UA")]
        public string HOUSENUMBERUA { get; set; }
        public override string ToString()
        {
            return HOUSENUMBERUA;
        }
    }

    public class Houses
    {
        [JsonProperty("Entry")]
        public List<House> Entry { get; set; }
    }

    public class HousesRoot
    {
        [JsonProperty("Entries")]
        public Houses Entries { get; set; }
    }
}
