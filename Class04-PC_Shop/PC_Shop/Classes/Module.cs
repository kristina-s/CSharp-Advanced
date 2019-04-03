using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Shop
{
    public class Module : Product
    {
        public List<Part> PartsList { get; set; } = new List<Part>();

        public Module(string name)
        {
            Name = name;
        }

        public void AddPartToModule(Part p, int q)
        {
            for (int i = 0; i < q; i++)
            {
                PartsList.Add(p);
                Price += p.Price;
            }         
        }

        //public double GetPrice()
        //{
            
        //    return Price;
        //}      
    }
}
