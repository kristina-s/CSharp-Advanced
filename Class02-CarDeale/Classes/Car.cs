using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public abstract class Car
    {
        public string Model { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public byte Doors { get; set; }
        public string FuelType { get; set; }
        public double FuelConsumption { get; set; }
        public int Price { get; set; }
        public TypeOfCar CarType { get; set; }

        public Car()
        {
        }

        protected Car(string model, Manufacturer manufacturer, byte doors, string fuelType, double fuelConsumption, int price, TypeOfCar carType)
        {
            Model = model;
            Manufacturer = manufacturer;
            Doors = doors;
            FuelType = fuelType;
            FuelConsumption = fuelConsumption;
            Price = price;
            CarType = carType;
        }

        public virtual string CarInfo()
        {
            return $"Model: {Model} \n" +
                $"Manufacturer: {Manufacturer} \n" +
                $"Number of doors: {Doors} \n" +
                $"Fuel type: {FuelType} \n" +
                $"Fuel consumption: {FuelConsumption} \n" +
                $"Price in EUR {Price} \n" +
                $"Price in MKD {Price*61.5} \n" +
                $"Type {CarType} \n";

            
        }


    }
}
