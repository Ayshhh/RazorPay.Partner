using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPay.Partner.Models.ResponseModels
{
    public class Document
    {
        public Business_Proof_Of_Identification[] business_proof_of_identification { get; set; }
        public class Business_Proof_Of_Identification
        {
            public string type { get; set; }
            public string url { get; set; }
        }

    }
}
