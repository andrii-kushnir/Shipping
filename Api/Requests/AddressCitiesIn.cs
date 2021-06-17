using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Requests
{
    public class AddressCitiesIn
    {
        public string Ref { get; set; }
        public int Page { get; set; }
        public string FindByString { get; set; }
    }
}
