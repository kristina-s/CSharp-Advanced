using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public static class PriceToDenars
    {
        public static double ConvertPriceToDenars(this Car car)
        {
            return car.Price * 61.5;
        }
    }
}
