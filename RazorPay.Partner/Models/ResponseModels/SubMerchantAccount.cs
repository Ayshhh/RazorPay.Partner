using RazorPay.Partner.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPay.Partner.Models.ResponseModels
{
    public class SubMerchantAccount : SubMerchantAccountRequest
    {
        public string id { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public int created_at { get; set; }
    }
}
