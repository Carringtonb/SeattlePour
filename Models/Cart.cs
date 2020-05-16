using System;
using System.Collections.Generic;

namespace EcomProject.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public List<CartItems> CartItems { get; set; }
    }
}
