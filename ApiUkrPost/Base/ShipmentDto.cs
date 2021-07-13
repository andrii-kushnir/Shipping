using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ApiUkrPost.Base
{
    public class ShipmentDto
    {
        public string uuid { get; set; }
        public bool ShouldSerializeuuid() { return false; }
        public Sender sender { get; set; }
        public Recipient recipient { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public DeliveryType deliveryType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ShipmentType shipmentType { get; set; }
        public List<ParcelDto> parcels { get; set; }
        public int postPay { get; set; }
        public bool recommended { get; set; }
        public bool sms { get; set; }
        public bool paidByRecipient { get; set; }
        public string description { get; set; }

        // Не дописано!

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Sender
    {
        public string uuid { get; set; }
    }

    public class Recipient
    {
        public string uuid { get; set; }
    }

    public enum ShipmentType
    {
        EXPRESS = 0,
        STANDARD = 1,
        INTERNATIONAL = 2,
        DOCUMENT_BACK = 3,
        INTERNATIONAL_CONSIGNMENT = 4,
        INTERNATIONAL_EXPORT_PLUS
    }

    public enum DeliveryType
    {
        [Description("Відділення на відділення")]
        W2W = 0,
        [Description("Відділення на дім")]
        W2D = 1,
        [Description("З дому на відділення")]
        D2W = 2,
        [Description("З дому на дім")]
        D2D = 3
    }
}
