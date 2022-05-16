using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiDelivery.Responses
{
    public class TariffListResponse : BaseResponse
    {
        public List<Tariff> data { get; set; }
    }

    public class Tariff
    {
        [SQLTypeAttribute("numeric(16, 5)")]
        public float? MinWidth { get; set; }
        [SQLTypeAttribute("numeric(16, 5)")]
        public float? MaxWidth { get; set; }
        [SQLTypeAttribute("numeric(16, 5)")]
        public float? MinSize { get; set; }
        [SQLTypeAttribute("numeric(16, 5)")]
        public float? MaxSize { get; set; }
        [SQLTypeAttribute("numeric(16, 5)")]
        public float? Length { get; set; }
        [SQLTypeAttribute("numeric(16, 5)")]
        public float? Width { get; set; }
        [SQLTypeAttribute("numeric(16, 5)")]
        public float? Height { get; set; }
        [SQLTypeAttribute("bit")]
        public bool? RequiredWeight { get; set; }
        [SQLTypeAttribute("bit")]
        public bool? RequiredSize { get; set; }
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