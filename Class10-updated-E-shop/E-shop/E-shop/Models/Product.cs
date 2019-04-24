using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_shop.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Vendor Vendor { get; set; }

        public Product(string id, string name, double price, Vendor vendor)
        {
            Id = id;
            Name = name;
            Price = price;
            Vendor = vendor;
        }

    }
}
