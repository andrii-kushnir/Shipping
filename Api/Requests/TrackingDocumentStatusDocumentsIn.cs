using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Requests
{
    public class TrackingDocumentStatusDocumentsIn
    {
        public List<Documents> Documents { get; set; }
    }

    public class Documents
    {
        public string DocumentNumber { get; set; }
        public string Phone { get; set; }
    }
}
