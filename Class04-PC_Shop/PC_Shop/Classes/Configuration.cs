using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Shop
{
    public class Configuration : Product
    {
        public List<Part> PartsList { get; set; } = new List<Part>();
        public List<Module> ModulesList { get; set; } = new List<Module>();
        public Colors BoxColor { get; set; }


        public Configuration(Colors color)
        {
            BoxColor = color;
        }

        public void AddPartToProduct(Part p, int q)
        {
            for (int i = 0; i < q; i++)
            {
                PartsList.Add(p);
                Price += p.Price;
            }
        }

        public void AddModuleToProduct(Module m, int q)
        {
            for (int i = 0; i < q; i++)
            {
                ModulesList.Add(m);
                Price += m.Price;
            }
        }

    }
}
