using System;
namespace EcomProject.Models
{
    public class CartItems
    {
        public int ID { get; set; }
        public int CartID { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        
        public Product Product { get; set; }
    }
}
