using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ApiUkrPost.Base
{
    public class Postpay
    {
        public string recipientName { get; set; }
        public string number { get; set; }
        public double sum { get; set; }
        public string lastStatus { get; set; }
        public string lastStatusNameUa { get; set; }
        public string lastStatusNameEn { get; set; }
        public string lastStatusNameRu { get; set; }
        public string lastStatusTime { get; set; }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
        public override string ToString()
        {
            return lastStatus;
        }
    }
}
