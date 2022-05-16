using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiDelivery.Responses
{
    public class WarehouseListResponse : BaseResponse
    {
        public List<Warehouse> data { get; set; }
    }

    public class Warehouse
    {
        [SQLTypeAttribute("nvarchar(36)")]
        public string id { get; set; }
        [SQLTypeAttribute("nvarchar(100)")]
        public string name { get; set; }
        [SQLTypeAttribute("numeric(16,5)")]
        public float Latitude { get; set; }
        [SQLTypeAttribute("numeric(16,5)")]
        public float Longitude { get; set; }
        [SQLTypeAttribute("nvarchar(36)")]
        public string CityId { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
