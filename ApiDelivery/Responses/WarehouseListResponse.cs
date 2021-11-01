using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiDelivery.Responses
{
    public class WarehouseListResponse : BaseResponse
    {
        public List<Warehouse> data;
    }

    public class Warehouse
    {
        public string id { get; set; }
        public string name { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string CityId { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
