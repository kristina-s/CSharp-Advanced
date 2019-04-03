using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Shop
{
    public class Part
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public PartType PartType { get; set; }

        public Part()
        {
        }
    }
}
