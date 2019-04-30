using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace E_shop.Models
{
    public delegate void MyEventDelegate(string payment);
    public delegate void MyEventDelegate02(string shipping);
    public class User
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public Order ListOrder { get; set; } = new Order();

        public User(string name)
        {
            Name = name;
        }

        public event MyEventDelegate EventHandler01;

        public void ProcessPayment(string payment)
        {
            Console.WriteLine("Processing payment...");
            Thread.Sleep(3000);
            EventHandler01.Invoke(payment);
        }

        public event MyEventDelegate02 EventHandler02;

        public void ShippingOrder(string shipping)
        {
            Console.WriteLine("Shipping your order...");
            Thread.Sleep(3000);
            Console.WriteLine($"Shipping address: {Address}");
            Console.WriteLine($"Shipping city: {City}");
            EventHandler02.Invoke(shipping);
        }
    }
}
