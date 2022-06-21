using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPay.Partner.Models.ResponseModels
{
    public class Product
    {
        public Requested_Configuration requested_configuration { get; set; }
        public Active_Configuration active_configuration { get; set; }
        public Requirement[] requirements { get; set; }
        public Tnc tnc { get; set; }
        public string id { get; set; }
        public string account_id { get; set; }
        public string product_name { get; set; }
        public string activation_status { get; set; }
        public int requested_at { get; set; }

        public class Requested_Configuration
        {
            public object[] payment_methods { get; set; }
        }
        public class Active_Configuration
        {
            public Payment_Capture payment_capture { get; set; }
            public Settlements settlements { get; set; }
            public Checkout checkout { get; set; }
            public Refund refund { get; set; }
            public Notifications notifications { get; set; }
            public Payment_Methods payment_methods { get; set; }
        }
        public class Payment_Capture
        {
            public string mode { get; set; }
            public string refund_speed { get; set; }
            public int automatic_expiry_period { get; set; }
        }

        public class Settlements
        {
            public object account_number { get; set; }
            public object ifsc_code { get; set; }
            public object beneficiary_name { get; set; }
        }

        public class Checkout
        {
            public string theme_color { get; set; }
            public bool flash_checkout { get; set; }
            public string logo { get; set; }
        }

        public class Refund
        {
            public string default_refund_speed { get; set; }
        }

        public class Notifications
        {
            public bool whatsapp { get; set; }
            public bool sms { get; set; }
            public string[] email { get; set; }
        }

        public class Payment_Methods
        {
            public Netbanking netbanking { get; set; }
            public Wallet wallet { get; set; }
            public Upi upi { get; set; }
        }

        public class Netbanking
        {
            public bool enabled { get; set; }
            public Instrument[] instrument { get; set; }
        }

        public class Instrument
        {
            public string type { get; set; }
            public string[] bank { get; set; }
        }

        public class Wallet
        {
            public bool enabled { get; set; }
            public string[] instrument { get; set; }
        }

        public class Upi
        {
            public bool enabled { get; set; }
            public string[] instrument { get; set; }
        }

        public class Tnc
        {
            public string id { get; set; }
            public bool accepted { get; set; }
            public int accepted_at { get; set; }
        }

        public class Requirement
        {
            public string field_reference { get; set; }
            public string resolution_url { get; set; }
            public string status { get; set; }
            public string reason_code { get; set; }
        }
    }
}
