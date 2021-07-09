using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiNovaPost.Requests
{
    public class InternetDocumentDocumentListIn
    {
        public DateTime? DateTimeFrom { get; set; }
        public DateTime? DateTimeTo { get; set; }
        public string Page { get; set; }
        public string GetFullList { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
