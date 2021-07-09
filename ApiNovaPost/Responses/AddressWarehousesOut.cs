using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNovaPost.Responses
{
    public class AddressWarehousesOut
    {
        public string SiteKey { get; set; }
        public string Description { get; set; }
        public string DescriptionRu { get; set; }
        public string Phone { get; set; }
        public string TypeOfWarehouse { get; set; }
        public string Ref { get; set; }
        public string Number { get; set; }
        public string CityRef { get; set; }
        public string CityDescription { get; set; }
        public string CityDescriptionRu { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string PostFinance { get; set; }
        public string BicycleParking { get; set; }
        public string POSTerminal { get; set; }
        public string InternationalShipping { get; set; }
        public int TotalMaxWeightAllowed { get; set; }
        public int PlaceMaxWeightAllowed { get; set; }
        public SendingLimitationsOnDimensions SendingLimitationsOnDimensions { get; set; }
        public ReceivingLimitationsOnDimensions ReceivingLimitationsOnDimensions { get; set; }
        public Reception Reception { get; set; }
        public Delivery Delivery { get; set; }
        public Schedule Schedule { get; set; }
    }

    public class SendingLimitationsOnDimensions
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
    }

    public class ReceivingLimitationsOnDimensions
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
    }

    public class Reception
    {
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
    }

    public class Delivery
    {
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
    }

    public class Schedule
    {
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
    }

}
