using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ApiUkrPost.Base
{
    public class ClientDto
    {
        public string uuid { get; set; }
        public string name { get; set; } // Обов"язкове для юр. особи
        public string firstName { get; set; } // Для фіз. особи
        public string lastName { get; set; } // Для фіз. особи
        public long addressId { get; set; }
        public bool ShouldSerializeaddressId() { return addressId != 0; }
        public List<Address> addresses { get; set; }
        public bool ShouldSerializeaddresses() { return false; }
        public string addressName { 
            get 
            {
                if (addresses == null || addresses.Count == 0) return null;
                return addresses.FirstOrDefault(a => a.main)?.address?.ToString();
            }
            set { value = null; }
        }
        public string edrpou { get; set; } // Обов"язкове для юр. особи
        public string tin { get; set; } // Обов"язкове для ФОП
        public string phoneNumber { get; set; }
        public string latinName { get; set; }
        public string middleName { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ClientIndivType? type { get; set; }
        public string uniqueRegistrationNumber { get; set; }
        public string email { get; set; }
        public string externalId { get; set; }
        public string contactPersonName { get; set; }
        public bool GDPRAccept { get; set; } //True if client accept Terms of Use
        public bool ShouldSerializeGDPRAccept() { return false; }
        public bool GDPRRead { get; set; } //True if client read Terms of Use
        public bool ShouldSerializeGDPRRead() { return false; }
        public string counterpartyUuid { get; set; }
        public bool ShouldSerializecounterpartyUuid() { return false; }
        public bool personalDataApproved { get; set; } //True if client accept Terms of Use
        public bool ShouldSerializepersonalDataApproved() { return false; }
        public string postId { get; set; }
        public bool ShouldSerializepostId() { return false; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PostPayPaymentType postPayPaymentType { get; set; }
        public bool ShouldSerializepostPayPaymentType() { return false; }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
        public override string ToString()
        {
            return name;
        }
    }

    public enum ClientIndivType
    {
        INDIVIDUAL = 0,          //фізична особа
        COMPANY = 1,             //юридична особа
        PRIVATE_ENTREPRENEUR = 2,//фізична особа підприємець
        //EMPLOYEE = 3, 
    }

    public enum PostPayPaymentType
    {
        POSTPAY_PAYMENT_CASH_ONLY = 0,
        POSTPAY_PAYMENT_CASHLESS_ONLY = 1,
        POSTPAY_PAYMENT_CASH_AND_CASHLESS = 2 
    }

    public class Address
    {
        public string uuid { get; set; }
        public int addressId { get; set; }
        public AddressDto address { get; set; }
        public string type { get; set; }
        public bool main { get; set; }
    }
}
