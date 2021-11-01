using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiDelivery.Responses
{
    public class TariffListResponse : BaseResponse
    {
        public List<Tariff> data;
    }

    public class Tariff
    {
        public float? MinWidth { get; set; }
        public float? MaxWidth { get; set; }
        public float? MinSize { get; set; }
        public float? MaxSize { get; set; }
        public float? Length { get; set; }
        public float? Width { get; set; }
        public float? Height { get; set; }
        public bool? RequiredWeight { get; set; }
        public bool? RequiredSize { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public override string ToString()
        {
            return name;
        }
    }
}