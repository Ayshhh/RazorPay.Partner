using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPay.Partner.Models.Requests
{
    public class SubMerchantAccountRequest
    {
        public string email { get; set; }
        public string phone { get; set; }
        public string legal_business_name { get; set; }
        public string business_type { get; set; }
        public string customer_facing_business_name { get; set; }
        public Profile profile { get; set; }
        public LegalInfo legal_info { get; set; }
        public Brand brand { get; set; }
        public Notes notes { get; set; }
        public TosAcceptance tos_acceptance { get; set; }
        public ContactInfo contact_info { get; set; }
        public Apps apps { get; set; }
    }
}
