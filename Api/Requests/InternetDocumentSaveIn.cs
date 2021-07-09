using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNovaPost.Requests
{
    public class InternetDocumentSaveIn
    {
        public string NewAddress { get; set; }
        public string PayerType { get; set; }
        public string PaymentMethod { get; set; }
        public string CargoType { get; set; }
        public string VolumeGeneral { get; set; }
        public string Weight { get; set; }
        public string ServiceType { get; set; }
        public string SeatsAmount { get; set; }
        public string Description { get; set; }
        public string Cost { get; set; }
        public string CitySender { get; set; }
        public string Sender { get; set; }
        public string SenderAddress { get; set; }
        public string ContactSender { get; set; }
        public string SendersPhone { get; set; }
        public string RecipientCityName { get; set; }
        public string RecipientArea { get; set; }
        public string RecipientAreaRegions { get; set; }
        public string RecipientAddressName { get; set; }
        public string RecipientHouse { get; set; }
        public string RecipientFlat { get; set; }
        public string RecipientName { get; set; }
        public string RecipientType { get; set; }
        public string RecipientsPhone { get; set; }
        public string DateTime { get; set; }
    }
}
