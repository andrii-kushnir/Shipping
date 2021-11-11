using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiDelivery.Responses
{
    public class PayerResponse : BaseResponse
    {
        public List<Payer> data { get; set; }
    }

    public class Payer
    {
        public string id { get; set; }
        public string name { get; set; }
    }

}
