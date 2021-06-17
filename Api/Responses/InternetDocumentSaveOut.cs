using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Responses
{
    public class InternetDocumentSaveOut
    {
        public string Ref { get; set; }
        public int CostOnSite { get; set; }
        public string EstimatedDeliveryDate { get; set; }
        public string IntDocNumber { get; set; }
        public string TypeDocument { get; set; }
    }
}
