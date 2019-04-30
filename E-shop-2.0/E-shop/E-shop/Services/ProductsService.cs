using E_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_shop.Services
{
    public class ProductsService
    {
        public static List<Product> GetAllProducts()
        {
            return new List<Product>()
            {
                new Product("001", "Superstar", 6450, Vendor.Adidas),
                new Product("002", "Gazelle", 5200, Vendor.Adidas),
                new Product("003", "TopTen", 4350, Vendor.Adidas),
                new Product("004", "Hops_VF", 2180, Vendor.Adidas),
                new Product("005", "VL_Court", 2088, Vendor.Adidas),
                new Product("006", "AirMax", 8690, Vendor.Nike),
                new Product("007", "AirForce", 6790, Vendor.Nike),
                new Product("008", "FlyKnit_Max", 9890, Vendor.Nike),
                new Product("009", "Air_Zoom", 5660, Vendor.Nike),
                new Product("010", "Odyssey_React", 4320, Vendor.Nike),
                new Product("011","M670", 8720, Vendor.NewBalance),
                new Product("012", "ML50", 5550, Vendor.NewBalance),
                new Product("013", "W996", 7260, Vendor.NewBalance),
                new Product("014", "WTNTR550", 3700, Vendor.NewBalance),
                new Product("015", "Crossfit_Nano", 7580, Vendor.Reebok),
                new Product("016", "ZPump_Fusion", 5400, Vendor.Reebok),
                new Product("017", "Infinity_Runner", 4156, Vendor.Reebok),
                new Product("018", "Royal_Glide", 3700, Vendor.Reebok),
                new Product("019", "PrintSmooth", 3240, Vendor.Reebok),
                new Product("020", "SubliteX", 2952, Vendor.Reebok),
                new Product("021", "ChuckTaylor_AllStar", 3590, Vendor.Converse),
                new Product("022", "OneStar", 4890, Vendor.Converse),
                new Product("023", "Pro_Blaze", 4190, Vendor.Converse),
                new Product("024", "El_Distrito", 3290, Vendor.Converse),
                new Product("025", "Gates", 2944, Vendor.Converse),
                new Product("026", "Breakpoint", 2183, Vendor.Converse),
                new Product("027", "Legacy", 2790, Vendor.Champion),
                new Product("028", "Envy 2.0", 3010, Vendor.Champion),
                new Product("029", "Warior", 2772, Vendor.Champion),
                new Product("030", "Raven", 1990, Vendor.Champion),
                new Product("031", "Swift", 2690, Vendor.Champion),
                new Product("032", "FlowSatin", 2480, Vendor.Champion)
            };
        }
    }
}
