using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiUkrPost.Adresses
{
    public class City
    {
        [JsonProperty("REGION_ID")]
        public string REGIONID { get; set; }

        [JsonProperty("POPULATION")]
        public string POPULATION { get; set; }

        [JsonProperty("DISTRICT_ID")]
        public string DISTRICTID { get; set; }

        [JsonProperty("LONGITUDE")]
        public string LONGITUDE { get; set; }

        [JsonProperty("CITY_RU")]
        public string CITYRU { get; set; }

        [JsonProperty("DISTRICT_EN")]
        public object DISTRICTEN { get; set; }

        [JsonProperty("REGION_EN")]
        public string REGIONEN { get; set; }

        [JsonProperty("OLDCITY_RU")]
        public object OLDCITYRU { get; set; }

        [JsonProperty("SHORTCITYTYPE_EN")]
        public object SHORTCITYTYPEEN { get; set; }

        [JsonProperty("CITYTYPE_UA")]
        public string CITYTYPEUA { get; set; }

        [JsonProperty("OLDCITY_UA")]
        public object OLDCITYUA { get; set; }

        [JsonProperty("NEW_DISTRICT_UA")]
        public string NEWDISTRICTUA { get; set; }

        [JsonProperty("CITY_EN")]
        public string CITYEN { get; set; }

        [JsonProperty("CITYTYPE_RU")]
        public string CITYTYPERU { get; set; }

        [JsonProperty("CITY_KOATUU")]
        public string CITYKOATUU { get; set; }

        [JsonProperty("REGION_RU")]
        public string REGIONRU { get; set; }

        [JsonProperty("NAME_UA")]
        public string NAMEUA { get; set; }

        [JsonProperty("REGION_UA")]
        public string REGIONUA { get; set; }

        [JsonProperty("OLDCITY_EN")]
        public object OLDCITYEN { get; set; }

        [JsonProperty("SHORTCITYTYPE_RU")]
        public object SHORTCITYTYPERU { get; set; }

        [JsonProperty("CITY_ID")]
        public string CITYID { get; set; }

        [JsonProperty("DISTRICT_UA")]
        public string DISTRICTUA { get; set; }

        [JsonProperty("CITYTYPE_EN")]
        public string CITYTYPEEN { get; set; }

        [JsonProperty("SHORTCITYTYPE_UA")]
        public string SHORTCITYTYPEUA { get; set; }

        [JsonProperty("LATTITUDE")]
        public string LATTITUDE { get; set; }

        [JsonProperty("CITY_UA")]
        public string CITYUA { get; set; }

        [JsonProperty("OWNOF")]
        public string OWNOF { get; set; }

        [JsonProperty("DISTRICT_RU")]
        public object DISTRICTRU { get; set; }
    }

    public class Cities
    {
        [JsonProperty("Entry")]
        public List<City> Entry { get; set; }
    }

    public class CitiesRoot
    {
        [JsonProperty("Entries")]
        public Cities Entries { get; set; }
    }
}
