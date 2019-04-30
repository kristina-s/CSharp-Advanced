using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_shop.Models
{
    public class Shipping
    {
        public string Name { get; set; }
        public Shipping(string name)
        {
            Name = Name;
        }

        public void ShipOrder(string shippingCompany)
        {
            if (shippingCompany == Name)
            {
                Console.WriteLine("Your order has been shipped successfully!");
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
