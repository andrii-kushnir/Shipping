using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiDelivery.Responses
{
    public class CargoCategoryListResponse : BaseResponse
    {
        public List<CargoCategory> data { get; set; }
    }

    public class CargoCategory
    {
        [SQLTypeAttribute("nvarchar(36)")]
        public string id { get; set; }
        [SQLTypeAttribute("nvarchar(100)")]
        public string name { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}
