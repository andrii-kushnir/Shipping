using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiUkrPost.Base
{
    public class ParcelDto
    {
        public string uuid { get; set; }
        public bool ShouldSerializeuuid() { return uuid != null; }
        public string barcode { get; set; }
        public bool ShouldSerializebarcode() { return barcode != null; }
        public int parcelNumber { get; set; }
        public bool ShouldSerializeparcelNumber() { return parcelNumber != 0; }
        public double? declaredPrice { get; set; }
        public bool ShouldSerializedeclaredPrice() { return declaredPrice != null; }
        public string description { get; set; } // maxLength: 1024
        public bool ShouldSerializedescription() { return false; }
        public int weight { get; set; }
        public int length { get; set; }
        public int? width { get; set; }
        public bool ShouldSerializewidth() { return width != null; }
        public int? height { get; set; }
        public bool ShouldSerializeheight() { return height != null; }
        public string name { get; set; }
        public bool ShouldSerializename() { return false; }
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
