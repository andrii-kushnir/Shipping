using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace ApiUkrPost.Base
{
    public class ShipmentDto
    {
        public string uuid { get; set; }
        public bool ShouldSerializeuuid() { return uuid != null; }
        public string barcode { get; set; }
        public bool ShouldSerializebarcode() { return barcode != null; }
        public ClientDto sender { get; set; }
        public ClientDto recipient { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public DeliveryType deliveryType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ShipmentType type { get; set; }
        public List<ParcelDto> parcels { get; set; }
        public double? postPay { get; set; }
        public bool ShouldSerializepostPay() { return (postPay != null && postPay != 0); }
        public bool postPayPaidByRecipient { get; set; }
        public bool ShouldSerializepostPayPaidByRecipient() { return (postPay != null && postPay != 0); }
        public double deliveryPrice { get; set; }
        public bool ShouldSerializedeliveryPrice() { return deliveryPrice != 0; }
        //public bool recommended { get; set; }
        public bool sms { get; set; }
        public bool paidByRecipient { get; set; }
        public string description { get; set; }
        public string calculationDescription { get; set; }
        public bool ShouldSerializecalculationDescription() { return calculationDescription != null; }
        public string lastModified { get; set; }
        public bool ShouldSerializelastModified() { return false; }
        public LifecycleDto lifecycle { get; set; }
        public bool ShouldSerializelifecycle() { return lifecycle != null; }
        public DirectionDto direction { get; set; }
        public bool ShouldSerializedirection() { return false; }
        public bool checkOnDelivery { get; set; }

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
        [EnumMember(Value = "ІНІЦІАЛІЗОВАНО")]
        [XmlEnum(Name = "ІНІЦІАЛІЗОВАНО")]
        INITIALIZED = 0,
        [EnumMember(Value = "СТВОРЕНО")]
        [XmlEnum(Name = "СТВОРЕНО")]
        CREATED = 1,
        [EnumMember(Value = "ЗАРЕЄСТРОВАНО")]
        [XmlEnum(Name = "ЗАРЕЄСТРОВАНО")]
        REGISTERED = 2,
        [EnumMember(Value = "ПЕРЕАДРЕСАЦІЯ")]
        [XmlEnum(Name = "ПЕРЕАДРЕСАЦІЯ")]
        FORWARDING = 3,
        [EnumMember(Value = "ПОВЕРНЕННЯ")]
        [XmlEnum(Name = "ПОВЕРНЕННЯ")]
        RETURNING = 4,
        [EnumMember(Value = "ПОВЕРНУТО")]
        [XmlEnum(Name = "ПОВЕРНУТО")]
        RETURNED = 5,
        [EnumMember(Value = "ДОСТАВЛЕНО")]
        [XmlEnum(Name = "ДОСТАВЛЕНО")]
        DELIVERED = 6,
        [EnumMember(Value = "У ВІДДІЛЕННІ")]
        [XmlEnum(Name = "У ВІДДІЛЕННІ")]
        IN_DEPARTMENT = 7,
        [EnumMember(Value = "ДОСТАВЛЯЄТЬСЯ")]
        [XmlEnum(Name = "ДОСТАВЛЯЄТЬСЯ")]
        DELIVERING = 8,
        [EnumMember(Value = "НА ЗБЕРІГАННІ")]
        [XmlEnum(Name = "НА ЗБЕРІГАННІ")]
        STORAGE = 9,
        [EnumMember(Value = "СКАСОВАНО")]
        [XmlEnum(Name = "СКАСОВАНО")]
        CANCELED = 10,
        [EnumMember(Value = "ВИДАЛЕНО")]
        [XmlEnum(Name = "ВИДАЛЕНО")]
        DELETED = 11
    }

    public class LifecycleDto
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Status1 status { get; set; }
        public string statusDate { get; set; }  // переписати на номальну дату для вибору тільки "активних" відправлень 
        public override string ToString()
        {
            return status.GetEnumMember() + " встановлено " + statusDate;
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
