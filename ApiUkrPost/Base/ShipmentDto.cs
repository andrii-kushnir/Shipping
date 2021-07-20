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
        public bool ShouldSerializeuuid() { return uuid != null; }
        public ClientDto sender { get; set; }
        public ClientDto recipient { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public DeliveryType deliveryType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ShipmentType type { get; set; }
        public List<ParcelDto> parcels { get; set; }
        public int? postPay { get; set; }
        public bool ShouldSerializepostPay() { return (postPay != null && postPay != 0); }
        //public bool recommended { get; set; }
        public bool sms { get; set; }
        public bool paidByRecipient { get; set; }
        public string description { get; set; }
        public long recipientAddressId { get; set; }
        public bool ShouldSerializerecipientAddressId() { return (recipientAddressId != 0); }
        public string lastModified { get; set; }
        public bool ShouldSerializelastModified() { return false; }
        public LifecycleDto lifecycle { get; set; }
        public bool ShouldSerializelifecycle() { return false; }
        public DirectionDto direction { get; set; }
        public bool ShouldSerializedirection() { return false; }
        // Не дописані всі поля!

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore});
        }
        public override string ToString()
        {
            return uuid;
        }
    }

    public enum ShipmentType
    {
        EXPRESS = 0,
        STANDARD = 1,
        INTERNATIONAL = 2,
        DOCUMENT_BACK = 3,
        INTERNATIONAL_CONSIGNMENT = 4,
        INTERNATIONAL_EXPORT_PLUS = 5
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

    public enum Status1
    {
        INITIALIZED = 0,
        CREATED = 1,
        REGISTERED = 2,
        FORWARDING = 3,
        RETURNING = 4,
        RETURNED = 5,
        DELIVERED = 6,
        IN_DEPARTMENT = 7,
        DELIVERING = 8,
        STORAGE = 9,
        CANCELED = 10,
        DELETED = 11
    }

    public class LifecycleDto
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Status1 status { get; set; }
        public string statusDate { get; set; }
        public override string ToString()
        {
            return status.ToString() + " встановлено " + statusDate;
        }
    }
    public class DirectionDto
    {
        public string districtSortingCenter { get; set; }
        public string postOfficeName { get; set; }
        public string postOfficeNumber { get; set; }
        public string regionSortingCenter { get; set; }
        public override string ToString()
        {
            return postOfficeNumber + ", " + postOfficeName;
        }
    }
}
