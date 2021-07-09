using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiUkrPost.Adresses
{
    public class CityFromIndex
    {
        [JsonProperty("REGION_ID")]
        public string REGIONID { get; set; }

        [JsonProperty("DISTRICT_NAME")]
        public string DISTRICTNAME { get; set; }

        [JsonProperty("NEW_DISTRICT_NAME")]
        public string NEWDISTRICTNAME { get; set; }

        [JsonProperty("CITY_ID")]
        public string CITYID { get; set; }

        [JsonProperty("REGION_NAME")]
        public string REGIONNAME { get; set; }

        [JsonProperty("POSTCODE")]
        public string POSTCODE { get; set; }

        [JsonProperty("DISTRICT_ID")]
        public string DISTRICTID { get; set; }

        [JsonProperty("CITY_NAME")]
        public string CITYNAME { get; set; }

        [JsonProperty("CITYTYPE_NAME")]
        public string CITYTYPENAME { get; set; }

        [JsonProperty("OLDSTREET_NAME")]
        public string OLDSTREETNAME { get; set; }

        [JsonProperty("OLDCITY_NAME")]
        public string OLDCITYNAME { get; set; }

        [JsonProperty("CITYTYPE_ID")]
        public string CITYTYPEID { get; set; }
    }

    public class CitiesFromIndex
    {
        [JsonProperty("Entry")]
        public List<CityFromIndex> Entry { get; set; }
    }

    public class CitiesFromIndexRoot
    {
        [JsonProperty("Entries")]
        public CitiesFromIndex Entries { get; set; }
    }
}
