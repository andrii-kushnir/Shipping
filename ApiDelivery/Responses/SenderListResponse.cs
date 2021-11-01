using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiDelivery.Responses
{
    class SenderListResponse : BaseResponse
    {
        public List<Sender> data { get; set; }
    }

    public class Sender
    {
        public string id { get; set; }
        public string name { get; set; }
        public string cityId { get; set; }
        public string cityName { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
