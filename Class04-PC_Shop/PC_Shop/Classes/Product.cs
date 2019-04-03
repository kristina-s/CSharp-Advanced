using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Shop
{
    public abstract class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }


        public virtual double GetPrice()
        {
            return Price;
        }

        public void SetDiscount(int d)
        {
            Discount = d;
        }

        public double GetPriceWithDiscount()
        {
            double disc = (Discount * Price) / 100;
            return Price - disc;
        }
    }
}
