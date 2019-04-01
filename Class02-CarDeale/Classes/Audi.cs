using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Audi : Car
    {
        public string Colour { get; set; }

        public Audi(string model, byte doors, string fuelType, double fuelConsumption, int price, TypeOfCar carType, string colour)
            : base(model, Manufacturer.Audi, doors, fuelType, fuelConsumption, price, carType)
        {
            Model = model;
            Doors = doors;
            FuelType = fuelType;
            FuelConsumption = fuelConsumption;
            Price = price;
            CarType = carType;
            Colour = colour;
        }

        public override string CarInfo()
        {
            return base.CarInfo() + $"Car Colour: {Colour} \n";
        }

    }
}
