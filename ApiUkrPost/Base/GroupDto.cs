using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiUkrPost.Base
{
    public class GroupDto
    {
        public string uuid { get; set; }
        public bool ShouldSerializeuuid() { return uuid != null; }
        public string name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ShipmentType type { get; set; }
        public string clientUuid { get; set; }
        public bool ShouldSerializeclientUuid() { return clientUuid != null; }
        public DateTime created { get; set; }
        public bool ShouldSerializecreated() { return false; }
        public bool closed { get; set; }
        public bool ShouldSerializeclosed() { return false; }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
        public override string ToString()
        {
            return name;
        }
    }

    public class GroupAddResponse
    {
        public string targetUuid { get; set; }
        public int httpStatus { get; set; }
        public string message { get; set; }
    }

}
