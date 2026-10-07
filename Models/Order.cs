namespace Lazaro_Midterm_Store.Models
{
    public class Order
    {
        public string CustomerName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string PaymentMethod { get; set; } = string.Empty;
    }
}