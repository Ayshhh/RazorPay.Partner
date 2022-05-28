namespace RazorPay.Partner.Models
{
    public class Profile
    {
        public string category { get; set; }
        public string subcategory { get; set; }
        public Addresses addresses { get; set; }
        public string business_model { get; set; }
    }
}
