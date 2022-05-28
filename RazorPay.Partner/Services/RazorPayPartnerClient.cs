using RazorPay.Partner.Models;
using RazorPay.Partner.Models.Errors;
using RazorPay.Partner.Models.Requests;
using RazorPay.Partner.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RazorPay.Partner.Services
{
    public class RazorPayPartnerClient
    {
        HttpClient Http;
        public RazorPayPartnerClient(string key = "rzp_test_partner_JWQBw8FIMPrePM", string secret = "0N0OO8TcT9jyMa9m2aKIpwgg")
        {
            Http = new HttpClient()
            {
                BaseAddress = new Uri("https://api.razorpay.com/v2/")
            };
            Http.DefaultRequestHeaders.Accept.Clear();
            Http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            string authString = string.Format("{0}:{1}", key, secret);
            Http.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes(authString)));
        }
        public async Task<ReturnData<T>> CallApi<T>(string relativeurl, object data)
        {
            
            ReturnData<T> returnData = new ReturnData<T>();
            try
            {
                HttpResponseMessage response = await Http.PostAsJsonAsync(relativeurl, data);
                var str = await response.Content.ReadAsStringAsync();
                returnData.Success = response.IsSuccessStatusCode;
                if (response.IsSuccessStatusCode)
                {
                    returnData.Data = await response.Content.ReadFromJsonAsync<T>();
                }
                else
                {
                    returnData = await response.Content.ReadFromJsonAsync<ReturnData<T>>();
                }
            }
            catch (Exception exc)
            {
                returnData.Error = new BaseError()
                {
                    description = exc.Message
                };
            }
            return returnData;
        }


        public async void CreateSubMerchantAccount()
        {

            string username = Console.ReadLine();
            var result = await CallApi<SubMerchantAccount>("accounts", await SampleData($"{username}@epoqzero.com"));
            //var str = await result.Content.ReadAsStringAsync();
        }
        public async Task<SubMerchantAccountRequest> SampleData(string email)
        {

            var data = new SubMerchantAccountRequest()
            {
                email = email,
                phone = "9999999999",
                legal_business_name = "Acme Corp",
                business_type = "partnership",
                customer_facing_business_name = "Example",
                profile = new Profile
                {
                    category = "healthcare",
                    subcategory = "clinic",
                    addresses = new Addresses
                    {
                        operation = new Address
                        {
                            street1 = "507, Koramangala 6th block",
                            street2 = "Kormanagala",
                            city = "Bengaluru",
                            state = "Karnataka",
                            postal_code = 560047,
                            country = "IN"
                        },
                        registered = new Address
                        {
                            street1 = "507, Koramangala 1st block",
                            street2 = "MG Road",
                            city = "Bengaluru",
                            state = "Karnataka",
                            postal_code = 560034,
                            country = "IN"
                        }
                    },
                    business_model = "Healthcare E-commerce platform"
                },
                legal_info = new LegalInfo
                {
                    pan = "AAACL1234C",
                    gst = "18AABCU9603R1ZM"
                },
                brand = new Brand
                {
                    color = "FFFFFF"
                },
                notes = new Notes
                {
                    internal_ref_id = "123123"
                },
                tos_acceptance = new TosAcceptance
                {
                    date = null,
                    ip = null,
                    user_agent = null
                },
                contact_info = new ContactInfo
                {
                    chargeback = new Chargeback
                    {
                        email = "cb@example.org"
                    },
                    refund = new Refund
                    {
                        email = "cb@example.org"
                    },
                    support = new Support
                    {
                        email = "support@example.org",
                        phone = "9999999998",
                        policy_url = "https://www.google.com"
                    }
                },
                apps = new Apps
                {
                    websites = new List<string>{
      "https://www.example.org"
    },
                    android = new List<App>{
        new App
      {
        url= "playstore.example.org",
        name= "Example"
      }
    },
                    ios = new List<App> {
        new App
      {
                url = "appstore.example.org",
        name = "Example"
      }
    }
                }
            };
            return data;
        }





    }
}
