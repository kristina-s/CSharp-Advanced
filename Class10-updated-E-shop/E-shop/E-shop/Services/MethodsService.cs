using E_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_shop.Services
{
    public static class MethodsService
    {
        public static void ShowMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------");
            Console.WriteLine("\t Select number to choose what would you like to do? \n");
            Console.WriteLine("\t 1 - Search and browse products");
            Console.WriteLine("\t 2 - See your shopping cart");
            Console.WriteLine("\t 3 - Finalize orders and get receipt");
            Console.WriteLine("\t 9 - Exit");
            Console.WriteLine("------------------------");
            Console.ResetColor();

        }

        public static void ShowProductsMenu()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("------------------------");
            Console.WriteLine("\t This is our products manager. Choose action: \n");
            Console.WriteLine("\t 1 - List all vendor names");
            Console.WriteLine("\t 2 - List all products");
            Console.WriteLine("\t 3 - Search products");
            Console.WriteLine("\t 9 - Back to main menu");
            Console.WriteLine("------------------------");
            Console.ResetColor();
        }

        public static void OrderMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("------------------------");
            Console.WriteLine("\t Would you like to make an order? \n");
            Console.WriteLine("\t 1 - Make order");
            Console.WriteLine("\t 9 - Go back");
            Console.WriteLine("------------------------");
            Console.ResetColor();
        }

        public static void SortMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("------------------------");
            Console.WriteLine("\t Sort products by: \n");
            Console.WriteLine("\t 1 - Price (ascending)");
            Console.WriteLine("\t 2 - Price (descending)");
            Console.WriteLine("\t 3 - Names (ascending)");
            Console.WriteLine("\t 4 - Names (descending)");
            Console.WriteLine("\t 9 - Go back");
            Console.WriteLine("------------------------");
            Console.ResetColor();
        }

        public static void GetVendors()
        {
            var vendors = Enum.GetValues(typeof(Vendor)).Cast<Vendor>().ToList();
            for (int i = 0; i < vendors.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {vendors[i]}");
            }
        }
        public static string GetVendor(int num)
        {
            var vendors = Enum.GetValues(typeof(Vendor)).Cast<Vendor>().ToList();
            string vend = String.Empty;
            for (int i = 0; i < vendors.Count; i++)
            {
                if (i + 1 == num)
                {
                    vend = vendors[i].ToString();
                }

            }
            return vend;
        }
    }
}

