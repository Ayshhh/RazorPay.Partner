// See https://aka.ms/new-console-template for more information
using RazorPay.Partner.Services;

Console.WriteLine("Hello, World!");
RazorPayPartnerClient razorPayPartnerClient = new RazorPayPartnerClient();
razorPayPartnerClient.CreateSubMerchantAccount();
Console.ReadLine();