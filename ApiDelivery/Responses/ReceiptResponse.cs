using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiDelivery.Responses
{
    public class ReceiptResponse : BaseResponse
    {
        new public List<string> message { get; set; }
        public List<ReceiptResp> receipts { get; set; }
    }

    public class ReceiptResp
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public float TotallCost { get; set; }
        public float InsuranceCost { get; set; }
        public float ComissionGM { get; set; }
        public string Comment { get; set; }
        public Eg[] egs { get; set; }
    }

    public class Eg
    {
        public string Id { get; set; }
        public object PartnerNumber { get; set; }
        public string Number { get; set; }
    }

}
