using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPay.Partner.Models.Requests
{
    public class StakeholderRequest
    {
        public int percentage_ownership { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public Relationship relationship { get; set; }
        public Phone phone { get; set; }
        public Addresses addresses { get; set; }
        public Kyc kyc { get; set; }
        public Notes notes { get; set; }
        public class Relationship
        {
            public bool director { get; set; }
            public bool executive { get; set; }
        }
        public class Phone
        {
            public string primary { get; set; }
            public string secondary { get; set; }
        }
        public class Addresses
        {
            public Residential residential { get; set; }
        }
        public class Residential
        {
            public string street { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string postal_code { get; set; }
            public string country { get; set; }
        }
        public class Kyc
        {
            public string pan { get; set; }
        }
        public class Notes
        {
            public string random_key_by_partner { get; set; }
        }
    }
}
