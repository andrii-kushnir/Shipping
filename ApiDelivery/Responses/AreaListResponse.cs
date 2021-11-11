using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiDelivery.Responses
{
    public class AreaListResponse : BaseResponse
    {
        public List<Area> data { get; set; }
    }

    public class Area
    {
        public string id { get; set; }
        public string name { get; set; }
        public string RegionId { get; set; }
        public bool IsWarehouse { get; set; }
        public bool ExtracityPickup { get; set; }
        public bool ExtracityShipping { get; set; }
        public bool RAP { get; set; }
        public bool RAS { get; set; }
        public string regionName { get; set; }
        public int regionId { get; set; }
        public int country { get; set; }
        public string districtName { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
