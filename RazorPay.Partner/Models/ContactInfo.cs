namespace RazorPay.Partner.Models
{
    public class ContactInfo
    {
        public Chargeback chargeback { get; set; }
        public Refund refund { get; set; }
        public Support support { get; set; }
    }
}
