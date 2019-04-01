using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Opel : Car
    {
        
        public string Country { get; set; }

        public Opel(string model, byte doors, string fuelType, double fuelConsumption, int price, TypeOfCar carType, string country)
            : base(model, Manufacturer.Opel, doors, fuelType, fuelConsumption, price, carType)
        {
            Model = model;
            Doors = doors;
            FuelType = fuelType;
            FuelConsumption = fuelConsumption;
            Price = price;
            CarType = carType;
            Country = country;
        }

        public override string CarInfo()
        {
            return base.CarInfo() + $"Manufactured in : {Country} \n";
        }
    }
}