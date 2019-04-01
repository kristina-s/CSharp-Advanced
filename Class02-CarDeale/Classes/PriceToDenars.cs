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

        public static string PrintPrice(this Car car, string currency)
        {
            string price = String.Empty;
            if(currency == "eur")
            {
                price = $"Price in {currency.ToUpper()} is: {car.Price}";

            }
            else if(currency == "mkd")
            {
                price = $"Price in {currency.ToUpper()} is: {car.ConvertPriceToDenars()}";
            }
            else
            {
                Console.WriteLine("No such option");
            }
            return price;
        }
    }
}
