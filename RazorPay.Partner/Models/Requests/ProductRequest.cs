using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPay.Partner.Models.Requests
{
    public class ProductRequest
    {
       public string product_name { get; set; }
       public bool tnc_accepted { get; set; }
    }
}
