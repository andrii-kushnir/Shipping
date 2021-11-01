using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiDelivery.Responses
{
    public class UserReceiptResponse : BaseResponse
    {
        public List<Receipt> data { get; set; }
    }

    public class Receipt
    {
        public string id { get; set; }
        public string number { get; set; }
        public int total { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime ReceiveDate { get; set; }
        public string SenderWarehouseName { get; set; }
        public string RecepientWarehouseName { get; set; }
        public int State { get; set; }
        public string Status { get; set; }
        public string StatusesDecoding { get; set; }
        public float TotalCost { get; set; }
        public string PartnerNumber { get; set; }
        public int type { get; set; }
        public float Weight { get; set; }
        public float Volume { get; set; }
        public bool PaymentStatus { get; set; }
        public int Currency { get; set; }
        public bool CanChangeRecepient { get; set; }
        public bool LockShipping { get; set; }
        public int IsPrivate { get; set; }
        public bool IsAllowDeny { get; set; }
        public string Sender { get; set; }
        public string Recepient { get; set; }
        public string Payer { get; set; }
        public float StatedValue { get; set; }
        public string Sites { get; set; }
        public float PriceWarehouseWarehouse { get; set; }
        public Auxserviceslist[] AuxServicesList { get; set; }
        public float InsuranceCost { get; set; }
        public int InsuranceCurrency { get; set; }
        public Possiblereceiver[] PossibleReceivers { get; set; }
        public int PushStateCode { get; set; }
        public float codCost { get; set; }
        public int codCurrency { get; set; }
        public object SenderPhone { get; set; }
        public object ReceiverPhone { get; set; }
        public object AddressPickup { get; set; }
        public object AddressDelivery { get; set; }
        public object DateArrivalExpress { get; set; }
        public object CitySendName { get; set; }
        public object CityReceiveName { get; set; }
        public object DeliveryType { get; set; }
        public object codName { get; set; }
        public object codPhone { get; set; }
        public object codWarehouse { get; set; }
        public bool isGiveMoney { get; set; }
        public object codGiveMoneyDate { get; set; }
        public object SafetyDealMoneyStatus { get; set; }
    }

    public class Auxserviceslist
    {
        public string Id { get; set; }
        public object ReceiptId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public float Summ { get; set; }
        public object AddressId { get; set; }
        public bool IsDelivery { get; set; }
    }

    public class Possiblereceiver
    {
        public string Id { get; set; }
        public object ReceiptId { get; set; }
        public string Name { get; set; }
    }
}
