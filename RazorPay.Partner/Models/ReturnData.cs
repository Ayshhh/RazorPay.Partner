using RazorPay.Partner.Models.Errors;

namespace RazorPay.Partner.Models
{
    public class ReturnData<T>
    {
        public T Data { get; set; }
        public BaseError Error { get; set; }
        public bool Success { get; set; }
    }
}