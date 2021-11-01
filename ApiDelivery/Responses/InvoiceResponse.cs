using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiDelivery.Responses
{
    public class InvoiceResponse : BaseResponse
    {
        public List<Invoice> data;
    }

    public class Invoice
    {
        public string id { get; set; }
        public string name { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
