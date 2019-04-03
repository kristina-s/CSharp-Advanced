using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Part p1 = new Part() { Name = "HDD", Price = 30.0, PartType = PartType.HDD};
            Part p2 = new Part() { Name = "HDD SSD", Price = 120.0, PartType = PartType.HDD };
            Part p3 = new Part() { Name = "HDD Data Cable", Price = 15.25 };
            Part p4 = new Part() { Name = "HDD Power cable", Price = 5.25};
            Part p5 = new Part() { Name = "HDD External Box", Price = 9.0 };
            Part p6 = new Part() { Name = "HDD Usb cable", Price = 3.25};
            Part p7 = new Part() { Name = "HDD Connector", Price = 2.25 };
            Part p8 = new Part() { Name = "Camera external", Price = 15.0 };
            Part p9 = new Part() { Name = "HDMI cable", Price = 20.5 };
            Part p10 = new Part() { Name = "VGA cable", Price = 4.25 };
            Part p11 = new Part() { Name = "USB cable", Price = 3.25 };
            Part p12 = new Part() { Name = "Wifi Mouse", Price = 25.25, PartType = PartType.Peripherals };
            Part p13 = new Part() { Name = "Wifi Keyboard", Price = 5.25, PartType = PartType.Peripherals };
            Part p14 = new Part() { Name = "Desk mont part", Price = 15.25 };
            Part p15 = new Part() { Name = "Monitor", Price = 115.25, PartType = PartType.Screen };
            Part p16 = new Part() { Name = "Cooler", Price = 7.25 };
            Part p17 = new Part() { Name = "RAM", Price = 45.25, PartType = PartType.RAM };
            Part p18 = new Part() { Name = "Graphic card", Price = 86.25, PartType = PartType.VGA };
            Part p19 = new Part() { Name = "CPU", Price = 205.25, PartType = PartType.CPU };
            Part p20 = new Part() { Name = "Motherboard", Price = 175.0, PartType = PartType.CPU };
            Part p21 = new Part() { Name = "PC box", Price = 35.0 };
            Part p22 = new Part() { Name = "Wifi sound", Price = 19.0, PartType = PartType.Peripherals };
            Part p23 = new Part() { Name = "RAM02", Price = 155.25, PartType = PartType.RAM };
            Part p24 = new Part() { Name = "RAM03", Price = 65.25, PartType = PartType.RAM };
            Part p25 = new Part() { Name = "HDD02", Price = 55.0, PartType = PartType.HDD };
            Part p26 = new Part() { Name = "HDD03", Price = 199.0, PartType = PartType.HDD };
            Part p27 = new Part() { Name = "HDD04", Price = 78.0, PartType = PartType.HDD };
            Part p28 = new Part() { Name = "Graphic card02", Price = 72.25, PartType = PartType.VGA };
            Part p29 = new Part() { Name = "Graphic card03", Price = 90.25, PartType = PartType.VGA };
            Part p30 = new Part() { Name = "Graphic card04", Price = 169.25, PartType = PartType.VGA };
            Part p31 = new Part() { Name = "Monitor03", Price = 170.25, PartType = PartType.Screen };
            Part p32 = new Part() { Name = "Monitor05", Price = 99.25, PartType = PartType.Screen };
            Part p33 = new Part() { Name = "Monitor06", Price = 130.25, PartType = PartType.Screen };
            Part p34 = new Part() { Name = "CPU05", Price = 83.25, PartType = PartType.CPU };
            Part p35 = new Part() { Name = "CPU09", Price = 225.25, PartType = PartType.CPU };

            //add parts to a list
            List<Part> partsList = new List<Part>() { p1, p2, p12, p13, p15,  p17, p18, p19, p20, p22, p23, p24, p25, p26, p27, p28, p29, p30, p31, p32, p33, p34, p35};
            

            Module m1 = new Module("HDD module");  //HDD module:
            m1.AddPartToModule(p1, 1); //HDD
            m1.AddPartToModule(p2, 1); //HDD SSD
            m1.AddPartToModule(p3, 2); //two data cables
            m1.AddPartToModule(p4, 1); //hdd power cable
            m1.AddPartToModule(p6, 1); //HDD usb cable
            m1.AddPartToModule(p7, 1); //HDD connector

            
            m1.SetDiscount(10); // 10%
            //Console.WriteLine("Module 1: {0}", m1.Name);
            //Console.WriteLine(m1.GetPrice());
            //Console.WriteLine(m1.GetPrice().PriceWithCurrency("EUR"));
            //Console.WriteLine("Discount price: {0}", m1.GetPriceWithDiscount().PriceWithCurrency("EUR"));
            //Console.WriteLine("--------------------");


            Module m2 = new Module("Perhipherals"); //Peripherals
            //Console.WriteLine("Module 2: {0}", m2.Name);
            //m2.AddPartToModule(p12, 1); //wifi mouse
            //m2.AddPartToModule(p13, 1); //wifi Keyboard
            //m2.AddPartToModule(p16, 1); //cooler
            //m2.AddPartToModule(p22, 1); //wifi sound
            //m2.AddPartToModule(p9, 1); //HDMI cable for the second monitor of the configuration
            //m2.SetDiscount(5); // 5%
            //Console.WriteLine(m2.GetPrice());
            //Console.WriteLine(m2.GetPrice().PriceWithCurrency("EUR"));
            //Console.WriteLine("Discount price: {0}", m2.GetPriceWithDiscount().PriceWithCurrency("EUR"));
            //Console.WriteLine("--------------------");


            Configuration pc1 = new Configuration(Colors.Black); //pc configuration
            pc1.Name = "Configuration 1";
            //add modules to configuration 
            pc1.AddModuleToProduct(m1, 1);
            pc1.AddModuleToProduct(m2, 1);

            //add parts to configuration
            pc1.AddPartToProduct(p15, 2); //Monitors x2
            pc1.AddPartToProduct(p17, 1); //RAM
            pc1.AddPartToProduct(p18, 1); //Graphic card
            pc1.AddPartToProduct(p20, 1); //Motherboard
            pc1.AddPartToProduct(p19, 1); //CPU
            pc1.AddPartToProduct(p21, 1); //PC box

            //Console.WriteLine(pc1.Name);
            //Console.WriteLine("Box color: {0}", pc1.BoxColor);
            //Console.WriteLine(pc1.GetPrice());
            //Console.WriteLine(pc1.GetPrice().PriceWithCurrency("EUR"));
            //pc1.SetDiscount(5); // 5%
            //Console.WriteLine("Discount price: {0}", pc1.GetPriceWithDiscount().PriceWithCurrency("EUR"));
            //Console.WriteLine("--------------------");

            //bonus exercise
            //min price configuration
            Console.Write("Configuration for minimum price: ");
            Console.WriteLine(Requirement.GetMinPriceConfig(partsList));
            Console.WriteLine("---------------------------");
            Console.Write("Configuration for maximum price: ");
            Console.WriteLine(Requirement.GetMaxPriceConfig(partsList));
            Console.WriteLine("---------------------------");

            Console.WriteLine("Enter price:");
            try
            {
                double userPrice = double.Parse(Console.ReadLine());
                Console.Write("Closest amount of money for a configuration with a given price: ");
                Console.WriteLine(Requirement.GetClosestPrice(userPrice, partsList));
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

            Console.ReadLine();
        }
    }
}
