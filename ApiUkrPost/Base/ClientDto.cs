using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiUkrPost.Base
{
    public class ClientDto
    {
        public long id { get; set; }
        public bool ShouldSerializeid() { return false; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public long addressId { get; set; }
        public string phoneNumber { get; set; }
        public string type { get; set; }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
