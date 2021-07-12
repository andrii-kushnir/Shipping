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
        public bool ShouldSerializeuuid() { return false; }
        public bool GDPRAccept { get; set; } //True if client accept Terms of Use
        public bool ShouldSerializeGDPRAccept() { return false; }
        public bool GDPRRead { get; set; } //True if client read Terms of Use
        public bool ShouldSerializeGDPRRead() { return false; }
        public long addressId { get; set; }
        public string contactPersonName { get; set; }
        public bool ShouldSerializecontactPersonName() { return false; }
        public string counterpartyUuid { get; set; }
        public bool ShouldSerializecounterpartyUuid() { return false; }
        public string email { get; set; }
        public bool ShouldSerializeuuemail() { return false; }
        public string externalId { get; set; }
        public bool ShouldSerializeexternalId() { return false; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string latinName { get; set; }
        public bool ShouldSerializelatinName() { return false; }
        public string middleName { get; set; }
        public bool ShouldSerializemiddleName() { return false; }
        public string name { get; set; }
        public bool ShouldSerializename() { return false; }
        public bool personalDataApproved { get; set; } //True if client accept Terms of Use
        public bool ShouldSerializepersonalDataApproved() { return false; }
        public string phoneNumber { get; set; }
        public string postId { get; set; }
        public bool ShouldSerializepostId() { return false; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PostPayPaymentType postPayPaymentType { get; set; }
        public bool ShouldSerializepostPayPaymentType() { return false; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ClientIndivType type { get; set; }
        public string uniqueRegistrationNumber { get; set; }
        public bool ShouldSerializeuniqueRegistrationNumber() { return false; }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public enum ClientIndivType
    {
        INDIVIDUAL = 0,          //фізична особа
        COMPANY = 1,             //юридична особа
        PRIVATE_ENTREPRENEUR = 2 //фізична особа підприємець
//        ,EMPLOYEE
    }

    public enum PostPayPaymentType
    {
        POSTPAY_PAYMENT_CASH_ONLY = 0,
        POSTPAY_PAYMENT_CASHLESS_ONLY = 1,
        POSTPAY_PAYMENT_CASH_AND_CASHLESS = 2 
    }
}
