using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ApiDelivery.Responses
{
    public class AreaListResponse : BaseResponse
    {
        public List<Area> data { get; set; }
    }

    public class Area
    {
        [SQLTypeAttribute("nvarchar(36)")]
        public string id { get; set; }
        [SQLTypeAttribute("nvarchar(100)")]
        public string name { get; set; }
        [SQLTypeAttribute("nvarchar(36)")]
        public string RegionId { get; set; }
        [SQLTypeAttribute("bit")]
        public bool IsWarehouse { get; set; }
        [SQLTypeAttribute("bit")]
        public bool ExtracityPickup { get; set; }
        [SQLTypeAttribute("bit")]
        public bool ExtracityShipping { get; set; }
        [SQLTypeAttribute("bit")]
        public bool RAP { get; set; }
        [SQLTypeAttribute("bit")]
        public bool RAS { get; set; }
        [SQLTypeAttribute("nvarchar(100)")]
        public string regionName { get; set; }
        [SQLTypeAttribute("int")]
        [JsonProperty("regionId")]
        public int regionCode { get; set; }
        [SQLTypeAttribute("int")]
        public int country { get; set; }
        [SQLTypeAttribute("nvarchar(100)")]
        public string districtName { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
