using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ApiDelivery.Responses
{
    public class RegionListResponse : BaseResponse
    {
        public List<Region> data { get; set; }
    }

    public class Region
    {
        [SQLTypeAttribute("int")]
        public int id { get; set; }
        [SQLTypeAttribute("nvarchar(100)")]
        public string name { get; set; }
        [SQLTypeAttribute("nvarchar(36)")]
        public string externalId { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}


