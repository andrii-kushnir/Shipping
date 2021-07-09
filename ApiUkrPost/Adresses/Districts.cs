﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiUkrPost.Adresses
{
    public class District
    {
        [JsonProperty("REGION_ID")]
        public string REGIONID { get; set; }

        [JsonProperty("DISTRICT_EN")]
        public object DISTRICTEN { get; set; }

        [JsonProperty("REGION_UA")]
        public string REGIONUA { get; set; }

        [JsonProperty("REGION_EN")]
        public string REGIONEN { get; set; }

        [JsonProperty("DISTRICT_KOATUU")]
        public string DISTRICTKOATUU { get; set; }

        [JsonProperty("DISTRICT_UA")]
        public string DISTRICTUA { get; set; }

        [JsonProperty("DISTRICT_ID")]
        public string DISTRICTID { get; set; }

        [JsonProperty("REGION_KOATUU")]
        public string REGIONKOATUU { get; set; }

        [JsonProperty("REGION_RU")]
        public string REGIONRU { get; set; }

        [JsonProperty("DISTRICT_RU")]
        public object DISTRICTRU { get; set; }

        [JsonProperty("NEW_DISTRICT_UA")]
        public string NEWDISTRICTUA { get; set; }
    }

    public class Districts
    {
        [JsonProperty("Entry")]
        public List<District> Entry { get; set; }
    }

    public class DistrictsRoot
    {
        [JsonProperty("Entries")]
        public Districts Entries { get; set; }
    }
}