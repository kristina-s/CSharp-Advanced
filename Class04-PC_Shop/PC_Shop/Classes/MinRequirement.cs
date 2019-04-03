using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Shop
{
    public static class MinRequirement
    {
        public static List<PartType> GetCategories()
        {
            return new List<PartType>()
            {
                PartType.CPU,
                PartType.HDD,
                PartType.Peripherals,
                PartType.RAM,
                PartType.Screen,
                PartType.VGA
            };
        }
    }
}
