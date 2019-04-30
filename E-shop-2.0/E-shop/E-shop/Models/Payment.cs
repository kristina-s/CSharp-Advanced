using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_shop.Models
{
    public class Payment
    {
        public string Name { get; set; }
        public Payment(string name)
        {
            Name = Name;
        }

        public void Pay(string payWay)
        {
            if(payWay == Name)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Payment has finished successfully!");
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
