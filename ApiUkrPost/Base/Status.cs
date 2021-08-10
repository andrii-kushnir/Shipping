using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ApiUkrPost.Base
{
    public class Status
    {
        public string barcode { get; set; }
        public int step { get; set; }
        public string date { get; set; }
        public string index { get; set; }
        public string name { get; set; }
        [JsonProperty("event")]
        public int event_ { get; set; }
        public string eventName { get; set; }
        public string country { get; set; }
        public string eventReason { get; set; }
        public int eventReason_id { get; set; }
        public int mailType { get; set; }
        public int indexOrder { get; set; }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
        public override string ToString()
        {
            return name;
        }
    }
}
