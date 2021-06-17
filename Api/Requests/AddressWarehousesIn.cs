using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Requests
{
    public class AddressWarehousesIn
    {
        public string CityName { get; set; }
        public string CityRef { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
        public string Language { get; set; }
    }
}
