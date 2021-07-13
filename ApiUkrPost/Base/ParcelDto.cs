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
        public bool ShouldSerializeuuid() { return false; }
        public string barcode { get; set; }
        public bool ShouldSerializebarcode() { return false; }
        public int declaredPrice { get; set; }
        public string description { get; set; } // maxLength: 1024
        public int weight { get; set; }
        public int length { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string name { get; set; }
        public bool ShouldSerializename() { return false; }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
