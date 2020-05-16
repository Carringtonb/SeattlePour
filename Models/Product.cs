using System;
namespace EcomProject.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Finish { get; set; }
        public string Material { get; set; }

    }
}
