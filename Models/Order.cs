using System;
namespace EcomProject.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public decimal TotalPrice { get; set; }
        public string Time { get; set; }


    }
}
