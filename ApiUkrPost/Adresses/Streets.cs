using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiUkrPost.Adresses
{
    public class Street
    {
        [JsonProperty("REGION_ID")]
        public string REGIONID { get; set; }

        [JsonProperty("OLDSTREET_EN")]
        public string OLDSTREETEN { get; set; }

        [JsonProperty("DISTRICT_ID")]
        public string DISTRICTID { get; set; }

        [JsonProperty("CITY_RU")]
        public string CITYRU { get; set; }

        [JsonProperty("STREET_UA")]
        public string STREETUA { get; set; }

        [JsonProperty("SHORTSTREETTYPE_UA")]
        public string SHORTSTREETTYPEUA { get; set; }

        [JsonProperty("DISTRICT_EN")]
        public string DISTRICTEN { get; set; }

        [JsonProperty("REGION_EN")]
        public string REGIONEN { get; set; }

        [JsonProperty("STREET_ID")]
        public string STREETID { get; set; }

        [JsonProperty("STREETTYPE_UA")]
        public string STREETTYPEUA { get; set; }

        [JsonProperty("SHORTSTREETTYPE_RU")]
        public string SHORTSTREETTYPERU { get; set; }

        [JsonProperty("STREETTYPE_RU")]
        public string STREETTYPERU { get; set; }

        [JsonProperty("OLDSTREET_UA")]
        public string OLDSTREETUA { get; set; }

        [JsonProperty("NEW_DISTRICT_UA")]
        public string NEWDISTRICTUA { get; set; }

        [JsonProperty("CITY_EN")]
        public string CITYEN { get; set; }

        [JsonProperty("STREET_EN")]
        public string STREETEN { get; set; }

        [JsonProperty("OLDSTREET_RU")]
        public string OLDSTREETRU { get; set; }

        [JsonProperty("REGION_RU")]
        public string REGIONRU { get; set; }

        [JsonProperty("REGION_UA")]
        public string REGIONUA { get; set; }

        [JsonProperty("SHORTSTREETTYPE_EN")]
        public string SHORTSTREETTYPEEN { get; set; }

        [JsonProperty("STREETTYPE_EN")]
        public string STREETTYPEEN { get; set; }

        [JsonProperty("CITY_ID")]
        public string CITYID { get; set; }

        [JsonProperty("DISTRICT_UA")]
        public string DISTRICTUA { get; set; }

        [JsonProperty("STREET_RU")]
        public string STREETRU { get; set; }

        [JsonProperty("CITY_UA")]
        public string CITYUA { get; set; }

        [JsonProperty("DISTRICT_RU")]
        public string DISTRICTRU { get; set; }
    }

    public class Streets
    {
        [JsonProperty("Entry")]
        public List<Street> Entry { get; set; }
    }

    public class StreetsRoot
    {
        [JsonProperty("Entries")]
        public Streets Entries { get; set; }
    }


}
