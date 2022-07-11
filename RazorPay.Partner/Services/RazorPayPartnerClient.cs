using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
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
        public string id;
        public string stakeholder_id;
        public string product_id;
        public async void CreateSubMerchantAccount()
        {

            string username = Console.ReadLine();
            var result = await CallApi<SubMerchantAccount>("accounts", await SampleData($"{username}@epoqzero.com"));
            id = result.Data.id;
            //Try doc

            ////Account
            //await FetchSubmerchantAccount();
            //await UpdateSubmerchantAccount();

            ////Stakeholder
            //await CreateStakeholder();
            //await FetchStakeholder();
            //await UpdateStakeholder();

            ////Product
            //await RequestProductConf();
            //await UpdateProductData();
            //await FetchProductData();

            //Document
            await UploadAccountDocuments();
        }

        //Account Api's
        public async Task FetchSubmerchantAccount()
        {
            var result = await Http.GetAsync($"accounts/{id}");

        }
        public async Task UpdateSubmerchantAccount()
        {
            //var data = @"{""customer_facing_business_name"": ""ABCD Ltd""}";
            var data = new { customer_facing_business_name = "ABCD Ltd" };
            var json = JsonConvert.SerializeObject(data);
            var Data = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await Http.PatchAsync($"accounts/{id}", Data);
        }

        //Stakeholder
        public async Task CreateStakeholder()
        {
            var result = await CallApi<Stakeholder>($"accounts/{id}/stakeholders", await SampleStakeholderData());
            //var result = await Http.PostAsJsonAsync($"accounts/{id}/stakeholders", await SampleStakeholderData());
            stakeholder_id = result.Data.id;
            //var str = await result.Content.ReadAsStringAsync();
        }
        public async Task FetchStakeholder()
        {
            var result = await Http.GetAsync($"accounts/{id}/stakeholders/{stakeholder_id}");

        }
        public async Task UpdateStakeholder()
        {
            var data = new
            {
                percentage_ownership = 20,
                name = "Gauri Kumar",
                relationship = new
                {
                    director = false,
                    executive = true
                },
                phone = new
                {
                    primary = "9898989898",
                    secondary = "9898989898"
                },
                addresses = new
                {
                    residential = new
                    {
                        street = "507, Koramangala 1st block",
                        city = "Bangalore",
                        state = "Karnataka",
                        postal_code = "560035",
                        country = "IN"
                    }
                },
                kyc = new
                {
                    pan = "AVOPB1111J"
                },
                notes = new
                {
                    random_key_by_partner = "random_value2"
                }
            };
            var json = JsonConvert.SerializeObject(data);
            var Data = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await Http.PatchAsync($"accounts/{id}/stakeholders/{stakeholder_id}", Data);

        }

        //Documents
        public async Task UploadAccountDocuments()
        {
            var result = await CallApi<Document>($"accounts/{id}/documents", await DocumentData());
        }
        public async Task<DocumentRequest> DocumentData()
        {
            //var dash = File.Open("C:/Users/Aysha/Documents/demo.txt", FileMode.Open);

            var data = new DocumentRequest()
            {
                file = @"C:/Users/Aysha/Downloads/LogoutIcon.png",
                document_type = "aadhar_front"
            };
            return data;
        }

        //Product
        public async Task RequestProductConf()
        {
            var result = await CallApi<Product>($"accounts/{id}/products", new
            {
                product_name = "payment_gateway",
                tnc_accepted = true
            });
            product_id = result.Data.id;
        }
        public async Task UpdateProductData()
        {
            var data = new
            {
                notifications = new
                {
                    email = new[] { "gaurav.kumar@example.com", "acd@gmail.com" }
                },
                checkout = new
                {
                    theme_color = "#528FFF"
                },
                refund = new
                {
                    default_refund_speed = "optimum"
                },
                settlements = new
                {
                    account_number = "1234567890",
                    ifsc_code = "HDFC0000317",
                    beneficiary_name = "Gaurav Kumar"
                },
                tnc_accepted = true
            };
            var json = JsonConvert.SerializeObject(data);
            var Data = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await Http.PatchAsync($"accounts/{id}/products/{product_id}", Data);

        }
        public async Task FetchProductData()
        {
            var result = await Http.GetAsync($"accounts/{id}/products/{product_id}");
        }

        public async Task<StakeholderRequest> SampleStakeholderData()
        {

            var data = new StakeholderRequest()
            {
                percentage_ownership = 10,
                name = "Gaurav Kumar",
                email = "blah@gmail.com",
                relationship = new StakeholderRequest.Relationship
                {
                    director = true,
                    executive = false
                },
                phone = new StakeholderRequest.Phone
                {
                    primary = "7474747474",
                    secondary = "7474747474"
                },
                addresses = new StakeholderRequest.Addresses
                {
                    residential = new StakeholderRequest.Residential
                    {
                        street = "506, Koramangala 1st block",
                        city = "Bengaluru",
                        state = "Karnataka",
                        postal_code = "560034",
                        country = "IN"
                    }
                },
                kyc = new StakeholderRequest.Kyc
                {
                    pan = "AVOPB1111K"
                },
                notes = new StakeholderRequest.Notes
                {
                    random_key_by_partner = "random_value"
                }
            };
            return data;
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
