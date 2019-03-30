using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class BMW : Car
    {
        public string Model { get; set; }
        public byte Doors { get; set; }
        public string FuelType { get; set; }
        public double FuelConsumption { get; set; }
        public int Price { get; set; }
        public TypeOfCar CarType { get; set; }
        public bool SunRoof { get; set; }

        public BMW(string model, byte doors, string fuelType, double fuelConsumption, int price, TypeOfCar carType, bool sunRoof)
            :base(model, Manufacturer.BMW, doors, fuelType, fuelConsumption, price, carType)
        {
            Model = model;
            Doors = doors;
            FuelType = fuelType;
            FuelConsumption = fuelConsumption;
            Price = price;
            CarType = carType;
            SunRoof = sunRoof;
        }

        public override string CarInfo()
        {
            return base.CarInfo() + $"Has sunroof: {SunRoof} \n";
        }
        
    }
}
