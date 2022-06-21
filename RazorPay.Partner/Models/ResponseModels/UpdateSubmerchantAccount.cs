using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPay.Partner.Models.ResponseModels
{
    public class UpdateSubmerchantAccount
    {
        public string id { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string email { get; set; }
        public Profile profile { get; set; }
        public object[] notes { get; set; }
        public int created_at { get; set; }
        public string phone { get; set; }
        public string reference_id { get; set; }
        public string business_type { get; set; }
        public string legal_business_name { get; set; }
        public string customer_facing_business_name { get; set; }

        public class Profile
        {
            public string category { get; set; }
            public string subcategory { get; set; }
            public Addresses addresses { get; set; }
        }

        public class Addresses
        {
            public Registered registered { get; set; }
        }

        public class Registered
        {
            public string street1 { get; set; }
            public string street2 { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string postal_code { get; set; }
            public string country { get; set; }
        }
    }
}
