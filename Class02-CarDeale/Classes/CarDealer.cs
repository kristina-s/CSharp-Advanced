using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class CarDealer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Car> CarsList { get; set; }

        
        public void PriceRange (int min, int max)
        {
            foreach (var car in CarsList)
            {
                if((car.Price >= min) && (car.Price <= max))
                {
                    Console.WriteLine(car.CarInfo() + car.PrintPrice("eur"));
                    Console.WriteLine("------------------------------------");

                }
            }

        }

        public void PriceRangeMKD(int min, int max)
        {
            foreach (var car in CarsList)
            {
                if ((car.ConvertPriceToDenars() >= min) && (car.ConvertPriceToDenars() <= max))
                {
                    Console.WriteLine(car.CarInfo() + car.PrintPrice("mkd"));
                    Console.WriteLine("------------------------------------");

                }
            }

        }
    }
}
