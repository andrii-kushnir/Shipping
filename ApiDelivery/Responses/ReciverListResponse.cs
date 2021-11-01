using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiDelivery.Responses
{
    public class ReciverListResponse : BaseResponse
    {
        public List<Reciver> data;
    }

    public class Reciver
    {
        public string egrpo { get; set; }
        public string phone { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
