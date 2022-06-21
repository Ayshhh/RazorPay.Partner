using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPay.Partner.Models.ResponseModels
{
    public class Stakeholder
    {
        public string entity { get; set; }
        public Relationship relationship { get; set; }
        public Phone phone { get; set; }
        public Notes notes { get; set; }
        public Kyc kyc { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int percentage_ownership { get; set; }
        public Addresses addresses { get; set; }
    }
}
