using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPay.Partner.Models.Requests
{
    public class DocumentRequest
    {
        public string file { get; set; }
        public string document_type { get; set; }
    }
}
