using System;
namespace EcomProject.Models
{
    public class CheckoutUser
    {
        public string Email { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime Time { get; set; }
        public string CreditCard { get; set; }
    }
}
