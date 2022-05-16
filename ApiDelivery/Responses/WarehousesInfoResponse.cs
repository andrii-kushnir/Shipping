using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiDelivery.Responses
{
    public class WarehousesInfoResponse : BaseResponse
    {
        public WarehousesInfo data { get; set; }
    }

    public class WarehousesInfo
    {
        [SQLTypeAttribute("nvarchar(36)")]
        public string id { get; set; }
        [SQLTypeAttribute("nvarchar(50)")]
        public string name { get; set; }
        [SQLTypeAttribute("nvarchar(250)")]
        public string address { get; set; }
        [SQLTypeAttribute("nvarchar(100)")]
        public string operatingTime { get; set; }
        [SQLTypeAttribute("nvarchar(100)")]
        public string Phone { get; set; }
        [SQLTypeAttribute("nvarchar(50)")]
        public string EmailStorage { get; set; }
        [SQLTypeAttribute("numeric(16,8)")]
        public float latitude { get; set; }
        [SQLTypeAttribute("numeric(16,8)")]
        public float longitude { get; set; }
        [SQLTypeAttribute("numeric(16,8)")]
        public float latitudeCorrect { get; set; }
        [SQLTypeAttribute("numeric(16,8)")]
        public float longitudeCorrect { get; set; }
        [SQLTypeAttribute("bit")]
        public bool Office { get; set; }
        [SQLTypeAttribute("nvarchar(36)")]
        public string CityId { get; set; }
        [SQLTypeAttribute("nvarchar(50)")]
        public string CityName { get; set; }
        [SQLTypeAttribute("bit")]
        public bool IsWarehouse { get; set; }
        [SQLTypeAttribute("nvarchar(50)")]
        public string RcPhoneSecurity { get; set; }
        [SQLTypeAttribute("nvarchar(50)")]
        public string RcPhoneManagers { get; set; }
        [SQLTypeAttribute("nvarchar(50)")]
        public string RcPhone { get; set; }
        [SQLTypeAttribute("nvarchar(100)")]
        public string RcName { get; set; }
        [SQLTypeAttribute("bit")]
        public bool IsCashOnDelivery { get; set; }
        [SQLTypeAttribute("int")]
        public int WarehouseType { get; set; }
        [SQLTypeAttribute("bit")]
        public bool CenterPickUpDelivery { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
