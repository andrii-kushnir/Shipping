using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiUkrPost.Base
{
    public class AddressDto
    {
        public long id { get; set; }
        public bool ShouldSerializeid() { return id != 0; }
        public string postcode { get; set; }
        public string country { get; set; } //maxLength: 2
        public string region { get; set; } //maxLength: 25
        public string district { get; set; } //maxLength: 45
        public string city { get; set; } //maxLength: 45
        public string street { get; set; } //maxLength: 255
        public string houseNumber { get; set; } //maxLength: 15
        public string apartmentNumber { get; set; } //maxLength: 15
        public string description { get; set; } //maxLength: 255
        public bool countryside { get; set; } //True if address located in countryside
        public bool ShouldSerializecountryside() { return false; }
        public bool posteRestante { get; set; } //Address for letters delivered with tag by request on sticker
        public bool ShouldSerializeposteRestante() { return false; }
        public string created { get; set; } //This address creation time
        public bool ShouldSerializecreated() { return false; }
        public string detailedInfo { get; set; }
        public string foreignStreetHouseApartment { get; set; }
        public bool ShouldSerializeforeignStreetHouseApartment() { return false; }
        public string lastModified { get; set; } //This address modification time
        public bool ShouldSerializelastModified() { return false; }
        public string mailbox { get; set; } //Mailbox number
        public bool ShouldSerializemailbox() { return false; }
        public string specialDestination { get; set; } //maxLength: 255
        public bool ShouldSerializespecialDestination() { return false; }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
        public override string ToString()
        {
            return detailedInfo;
        }
    }
}
