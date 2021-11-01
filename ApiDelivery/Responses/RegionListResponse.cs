using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiDelivery.Responses
{
    public class RegionListResponse : BaseResponse
    {
        public List<Region> data;
    }

    public class Region
    {
        public int id { get; set; }
        public string name { get; set; }
        public string externalId { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}


