﻿using System;
namespace EcomProject.Models
{
    public class OrderDetails
    {
        public int ProductID { get; set; }

        public int OrderID { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }

        public Order Order { get; set; }
    }
}
