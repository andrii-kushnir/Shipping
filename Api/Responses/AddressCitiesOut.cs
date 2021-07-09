using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNovaPost.Responses
{
    public class AddressCitiesOut
    {
        public string Description { get; set; }
        public string DescriptionRu { get; set; }
        public string Ref { get; set; }
        public int Delivery1 { get; set; }
        public int Delivery2 { get; set; }
        public int Delivery3 { get; set; }
        public int Delivery4 { get; set; }
        public int Delivery5 { get; set; }
        public int Delivery6 { get; set; }
        public int Delivery7 { get; set; }
        public string Area { get; set; }
        public string SettlementType { get; set; }
        public string IsBranch { get; set; }
        public object PreventEntryNewStreetsUser { get; set; }
        public object Conglomerates { get; set; }
        public int CityID { get; set; }
        public string SettlementTypeDescriptionRu { get; set; }
        public string SettlementTypeDescription { get; set; }
    }
}
