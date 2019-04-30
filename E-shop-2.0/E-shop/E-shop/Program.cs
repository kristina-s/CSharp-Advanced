
using E_shop.Services;
using E_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace Class10_E_shop
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Product> productsToJson = ProductsService.GetAllProducts();
                string prodJson = JsonConvert.SerializeObject(productsToJson);
                string path02 = @"..\..\Json\prodJson.json";
                File.WriteAllText(path02, prodJson);

                List<Product> products;
                string readJson = File.ReadAllText(path02);
                products = JsonConvert.DeserializeObject<List<Product>>(readJson);
                
                //List<Product> products = ProductsService.GetAllProducts();
                var vendors = Enum.GetValues(typeof(Vendor)).Cast<Vendor>().ToList();

                List<User> historyUsers = new List<User>();

                bool exitProgramme = true;
                while (exitProgramme)
                {
                    //login 
                    Console.Clear();
                    Console.WriteLine("\t Welcome to our trainers e-shop. Please enter your name first...");
                    string userName = Console.ReadLine();
                    User user = new User(userName);
                    int index = 1;
                    Console.WriteLine($"\n \t Hello {userName}");

                    MethodsService.ShowMainMenu();

                    bool mainExit = true;
                    while (mainExit)
                    {
                        bool userMainInput = Int32.TryParse(Console.ReadLine(), out int mainInput);
                        switch (mainInput)
                        {
                            //browse and search and sort products
                            case 1:
                                MethodsService.ShowProductsMenu();
                                bool productsExit = true;
                                while (productsExit)
                                {
                                    bool userProductInput = Int32.TryParse(Console.ReadLine(), out int productsInput);
                                    switch (productsInput)
                                    {
                                        //vendor products and offer making order!!!!
                                        case 1:
                                            MethodsService.GetVendors();
                                            Console.WriteLine("\n\tThese are all the vendors we offer. \n\n\tChoose number to see models.\n\tOr \n\tPress 9 to go back  \n");
                                            bool vendorExit = true;
                                            while (vendorExit)
                                            {
                                                bool userVendorInput = Int32.TryParse(Console.ReadLine(), out int vendorInput);
                                                string vendName = MethodsService.GetVendor(vendorInput);
                                                Console.WriteLine(vendName);
                                                if (vendorInput > 0 && vendorInput <= vendors.Count && vendorInput != 9)
                                                {
                                                    var filteredVendorList = products
                                                    .Where(x => x.Vendor.ToString() == vendName)
                                                    .ToList();
                                                    filteredVendorList.ForEach(x => Console.WriteLine($" {x.Id} | {x.Name} | {x.Price} "));

                                                    //MethodsService.OrderMenu();
                                                    index = MakeOrder(products, user, index);

                                                    MethodsService.ShowProductsMenu();
                                                    Thread.Sleep(1000);
                                                    break;
                                                }
                                                if (vendorInput >= 0 && vendorInput > vendors.Count && vendorInput != 9)
                                                {
                                                    MethodsService.ShowProductsMenu();
                                                    break;
                                                }
                                                if (vendorInput <= 0 && vendorInput < vendors.Count && vendorInput != 9)
                                                {
                                                    MethodsService.ShowProductsMenu();
                                                    break;
                                                }
                                                if (vendorInput == 9)
                                                {
                                                    MethodsService.ShowProductsMenu();
                                                    vendorExit = false;
                                                }
                                                else
                                                {
                                                    vendorExit = true;
                                                }                                                                         
                                            }

                                            break;
                                        case 2:
                                            //all products and offer making order!!!!
                                            Console.WriteLine("\n\t-----------------------------------");
                                            products.ForEach(x => Console.WriteLine($" {x.Id} | {x.Name} | {x.Price} MKD"));
                                            Console.WriteLine("\n\t-----------------------------------");                                           
                                                index = MakeOrder(products, user, index);
                                                productsExit = false;
                                            MethodsService.ShowProductsMenu();
                                            break;
                                        case 3:
                                            //search products and offer making order!!!!
                                            Console.WriteLine("\t Search product by name:");
                                            string userSearchInput = Console.ReadLine();
                                            Console.WriteLine();
                                            var searchList = products
                                                .Where(x => x.Name.ToLower().Contains(userSearchInput))
                                                .ToList();
                                            if (searchList.Count != 0)
                                            {
                                                searchList.ForEach(x => Console.WriteLine($"\t {x.Id} | {x.Name} | {x.Price} MKD"));
                                                Console.WriteLine("\t-----------------------------");
                                                index = MakeOrder(products, user, index);

                                            }
                                            else
                                            {
                                                Console.WriteLine("\tEnter correct search input!");
                                            }
                                            MethodsService.ShowProductsMenu();
                                            break;
                                        case 9:
                                            break;
                                        default:
                                            Console.Clear();
                                            MethodsService.ShowProductsMenu();

                                            productsExit = false;
                                            break;
                                    }
                                    if (productsInput == 9)
                                    {
                                        productsExit = false;
                                    }
                                    else
                                    {
                                        productsExit = true;
                                    }
                                }
                                break;
                            case 2:
                                //search with specific parameters
                                Console.WriteLine("Enter search input:");
                                string userSearchInput02 = Console.ReadLine().Trim();
                                if (userSearchInput02.Length == 0)
                                {
                                    Console.WriteLine("Enter correct searh input!");
                                    Thread.Sleep(1000);
                                    break;
                                }
                                Console.WriteLine("\tSet search parameters:");
                                Console.WriteLine("\t1 - Search by vendor name");
                                Console.WriteLine("\t2 - Search by product name");
                                bool userSearch01 = Int32.TryParse(Console.ReadLine(), out int searchInput01);

                                if (searchInput01 == 1)
                                {
                                    Console.WriteLine("\t1 - Sort by name");
                                    Console.WriteLine("\t2 - Sort by price");
                                    bool userSearch0101 = Int32.TryParse(Console.ReadLine(), out int searchInput0101);
                                    if (searchInput0101 == 1)
                                    {
                                        Console.WriteLine("\t1 - Order - ascending");
                                        Console.WriteLine("\t2 - Order - descending");
                                        bool userSearch010101 = Int32.TryParse(Console.ReadLine(), out int searchInput010101);
                                        if (searchInput010101 == 1)
                                        {
                                            var searchList = products
                                                .Where(x => x.Vendor.ToString().Contains(userSearchInput02))
                                                .OrderBy(x => x.Vendor.ToString())
                                                .ToList();
                                            searchList.ForEach(x => Console.WriteLine($"\t {x.Id} |  {x.Vendor.ToString()}  | {x.Name} | {x.Price} MKD"));
                                        }
                                        else if (searchInput010101 == 2)
                                        {
                                            var searchList = products
                                                .Where(x => x.Vendor.ToString().Contains(userSearchInput02))
                                                .OrderByDescending(x => x.Vendor.ToString())
                                                .ToList();
                                            searchList.ForEach(x => Console.WriteLine($"\t {x.Id} |  {x.Vendor.ToString()}  | {x.Name} | {x.Price} MKD"));
                                        }
                                    }
                                    else if (searchInput0101 == 2)
                                    {
                                        Console.WriteLine("\t1 - Order - ascending");
                                        Console.WriteLine("\t2 - Order - descending");
                                        bool userSearch010101 = Int32.TryParse(Console.ReadLine(), out int searchInput010101);
                                        if (searchInput010101 == 1)
                                        {
                                            var searchList = products
                                                .Where(x => x.Vendor.ToString().Contains(userSearchInput02))
                                                .OrderBy(x => x.Price)
                                                .ToList();
                                            searchList.ForEach(x => Console.WriteLine($"\t {x.Id} |  {x.Vendor.ToString()}  | {x.Name} | {x.Price} MKD"));
                                        }
                                        else if (searchInput010101 == 2)
                                        {
                                            var searchList = products
                                                .Where(x => x.Vendor.ToString().Contains(userSearchInput02))
                                                .OrderByDescending(x => x.Price)
                                                .ToList();
                                            searchList.ForEach(x => Console.WriteLine($"\t {x.Id} |  {x.Vendor.ToString()} | {x.Name} | {x.Price} MKD"));
                                        }
                                    }
                                }
                                else if (searchInput01 == 2)
                                {
                                    Console.WriteLine("\t1 - Sort by name");
                                    Console.WriteLine("\t2 - Sort by price");
                                    bool userSearch0102 = Int32.TryParse(Console.ReadLine(), out int searchInput0102);
                                    if (searchInput0102 == 1)
                                    {
                                        Console.WriteLine("\t1 - Order - ascending");
                                        Console.WriteLine("\t2 - Order - descending");
                                        bool userSearch010201 = Int32.TryParse(Console.ReadLine(), out int searchInput010201);
                                        if (searchInput010201 == 1)
                                        {
                                            var searchList = products
                                                .Where(x => x.Vendor.ToString().Contains(userSearchInput02))
                                                .OrderBy(x => x.Name)
                                                .ToList();
                                            searchList.ForEach(x => Console.WriteLine($"\t {x.Id} |  {x.Vendor.ToString()} | {x.Name} | {x.Price} MKD"));
                                        }
                                        else if (searchInput010201 == 2)
                                        {
                                            var searchList = products
                                                .Where(x => x.Vendor.ToString().Contains(userSearchInput02))
                                                .OrderByDescending(x => x.Name)
                                                .ToList();
                                            searchList.ForEach(x => Console.WriteLine($"\t {x.Id} |  {x.Vendor.ToString()}  | {x.Name} | {x.Price} MKD"));
                                        }
                                    }
                                    else if (searchInput0102 == 2)
                                    {
                                        Console.WriteLine("\t1 - Order - ascending");
                                        Console.WriteLine("\t2 - Order - descending");
                                        bool userSearch010202 = Int32.TryParse(Console.ReadLine(), out int searchInput010202);
                                        if (searchInput010202 == 1)
                                        {
                                            var searchList = products
                                                .Where(x => x.Vendor.ToString().Contains(userSearchInput02))
                                                .OrderBy(x => x.Price)
                                                .ToList();
                                            searchList.ForEach(x => Console.WriteLine($"\t {x.Id} |  {x.Vendor.ToString()}  | {x.Name} | {x.Price} MKD"));
                                        }
                                        else if (searchInput010202 == 2)
                                        {
                                            var searchList = products
                                                .Where(x => x.Vendor.ToString().Contains(userSearchInput02))
                                                .OrderByDescending(x => x.Price)
                                                .ToList();
                                            searchList.ForEach(x => Console.WriteLine($"\t {x.Id} |  {x.Vendor.ToString()}  |  {x.Name} | {x.Price} MKD"));
                                        }
                                    }
                                }
                                index = MakeOrder(products, user, index);

                                Thread.Sleep(2000);
                                break;

                            case 3:
                                //shopping cart stuff
                                Console.WriteLine("\t-----------------------------------");
                                Console.WriteLine("\tSHOPPING CART");
                                Console.WriteLine("\t-----------------------------------");
                                if (user.ListOrder.GetCount() != 0)
                                {

                                    user.ListOrder.PrintOrderList();
                                    Console.WriteLine("\t-----------------------------------");
                                    do
                                    {
                                        Console.WriteLine("\tWould you like to remove an item from the shopping cart?");
                                        Console.WriteLine("\tPress Y/N... ");
                                        string userRemoveChoice = Console.ReadLine().ToUpper();
                                        if (userRemoveChoice == "Y")
                                        {
                                            Console.WriteLine("\tChoose an index of the product you would like to remove");
                                            int userRemoveInput = int.Parse(Console.ReadLine());
                                            user.ListOrder.RemoveItemFromOrder(userRemoveInput);
                                            continue;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    while (true);
                                }
                                else
                                {
                                    Console.WriteLine("\tYour shopping cart is emprty!");
                                    mainExit = false;
                                }
                                break;

                            case 4:
                                //complete order and export receipt
                                string userReceipt = PrintReceipt(user);
                                if (user.ListOrder.GetCount() != 0)
                                {
                                    Console.WriteLine(PrintReceipt(user));
                                    string path = @"..\..\Receipt\receipt.txt";
                                    if (File.Exists(path))
                                    {
                                        File.Delete(path);
                                    }
                                    File.WriteAllText(path, userReceipt);
                                    Thread.Sleep(2000);

                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\tEmpty receipt....");
                                }
                                break;

                            case 5:
                                //payment options 
                                if (user.ListOrder.GetCount() != 0)
                                {
                                    MethodsService.PaymentMenu();
                                    bool payExit = true;
                                    while (payExit)
                                    {
                                        bool userPayInput = Int32.TryParse(Console.ReadLine(), out int payInput);
                                        switch (payInput)
                                        {
                                            case 1:
                                                Console.WriteLine("\tEnter your credit card:");
                                                string userCredCard = Console.ReadLine();
                                                if(userCredCard.Length == 16)
                                                {
                                                    Payment p01 = new Payment("Credit card");
                                                    user.EventHandler01 += p01.Pay;
                                                    Console.WriteLine($"Paying via credit card!");
                                                    user.ProcessPayment(p01.Name);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("You have entered invalid Credit Card. Try again!");
                                                }
                                                Thread.Sleep(3000);
                                                payExit = false;
                                                break;
                                            case 2:
                                                Console.Write("Enter PayPal username: \t\t");
                                                Console.ReadLine();
                                                Console.Write("Enter password: \t\t");
                                                string password = "";
                                                ConsoleKeyInfo info = Console.ReadKey(true);
                                                while (info.Key != ConsoleKey.Enter)
                                                {
                                                    if (info.Key != ConsoleKey.Backspace)
                                                    {
                                                        password += info.KeyChar;
                                                        info = Console.ReadKey(true);
                                                    }
                                                    info = Console.ReadKey(true);
                                                    for (int i = 0; i < password.Length; i++)
                                                        Console.Write("*");
                                                }
                                                  
                                                string userPass = Console.ReadLine();
                                                //change pass to stars or other characters!!!!!!!!!!!
                                                Payment p02 = new Payment("PayPal");
                                                user.EventHandler01 += p02.Pay;
                                                Console.WriteLine($"Paying via PayPal!");
                                                user.ProcessPayment(p02.Name);
                                                Thread.Sleep(3000);

                                                payExit = false;
                                                break;
                                            case 9:
                                                payExit = false;
                                                break;
                                            default:
                                                Console.WriteLine("No such choice. Try again!");
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\tEmpty shopping cart....");
                                    Thread.Sleep(3000);
                                }
                                break;
                            case 6:
                                //shipping order
                                if (user.ListOrder.GetCount() != 0)
                                {
                                    MethodsService.ShippingMenu();
                                    bool shipExit = true;
                                    while (shipExit)
                                    {
                                        bool userShipInput = Int32.TryParse(Console.ReadLine(), out int shipInput);

                                        //different shipping companies
                                        switch (shipInput)
                                        {
                                            case 1:
                                                Console.WriteLine("\t-----------------------------------");
                                                Console.WriteLine("\tYour order can be shipped only to the following cities: Skopje, Bitola, Ohrid and Stip.");
                                                Console.WriteLine("\t-----------------------------------");

                                                Console.WriteLine("\tPlease enter shipping address:");
                                                string userAdress = Console.ReadLine().Trim();
                                                user.Address = userAdress;

                                                while (true)
                                                {
                                                    Console.WriteLine("\tPlease enter city:");
                                                    string userCity = Console.ReadLine().Trim();
                                                    if ((userCity == "Skopje") || (userCity == "Bitola") || (userCity == "Ohrid") || (userCity == "Stip"))
                                                    {
                                                        user.City = userCity;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        continue;
                                                    }
                                                }
                                                Shipping s01 = new Shipping("MakedonskaPosta");
                                                user.EventHandler02 += s01.ShipOrder;
                                                Console.WriteLine("\t-----------------------------------");
                                                Console.WriteLine("Shipping via Makedonska Posta service");
                                                Console.WriteLine("\t-----------------------------------");
                                                Thread.Sleep(3000);

                                                user.ShippingOrder(s01.Name);
                                                shipExit = false;
                                                break;
                                            case 2:
                                                Console.WriteLine("\t-----------------------------------");
                                                Console.WriteLine("Your order can be shipped only to the following cities: Skopje, Bitola, Ohrid and Stip.");
                                                Console.WriteLine("\t-----------------------------------");

                                                Console.WriteLine("Please enter shipping address:");
                                                string userAdress02 = Console.ReadLine().Trim();
                                                user.Address = userAdress02;

                                                while (true)
                                                {
                                                    Console.WriteLine("Please enter city:");
                                                    string userCity = Console.ReadLine().Trim();
                                                    if ((userCity == "Skopje") || (userCity == "Bitola") || (userCity == "Ohrid") || (userCity == "Stip"))
                                                    {
                                                        user.City = userCity;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        continue;
                                                    }
                                                }
                                                Shipping s02 = new Shipping("DelCo");
                                                user.EventHandler02 += s02.ShipOrder;
                                                Console.WriteLine("\t-----------------------------------");
                                                Console.WriteLine("Shipping via DelCo service");
                                                Console.WriteLine("\t-----------------------------------");
                                                user.ShippingOrder(s02.Name);
                                                Thread.Sleep(3000);

                                                shipExit = false;
                                                break;
                                            case 9:
                                                shipExit = false;
                                                break;
                                            default:
                                                Console.WriteLine("No such choice. Try again!");
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\tEmpty shopping cart....");
                                    Thread.Sleep(2000);
                                }
                                break;
                            case 7:
                                MethodsService.SeeHisotryMenu();
                                bool histExit = true;
                                while (histExit)
                                {
                                    bool userHistInput = Int32.TryParse(Console.ReadLine(), out int histInput);
                                    switch (histInput)
                                    {
                                        case 1:
                                            Console.WriteLine("See orders < 3000");
                                            List<User> smallerThan = historyUsers
                                                .Where(x => x.ListOrder.OrderTotal() < 3000)
                                                .ToList();
                                            smallerThan.ForEach(x => Console.WriteLine($"Customer {x.Name} - total order price {x.ListOrder.OrderTotal()} "));
                                            Thread.Sleep(3000);
                                            histExit = false;
                                            break;
                                        case 2:
                                            Console.WriteLine("See orders > 3000");
                                            List<User> largerThan = historyUsers
                                                .Where(x => x.ListOrder.OrderTotal() > 3000)
                                                .ToList();
                                            largerThan.ForEach(x => Console.WriteLine($"Customer {x.Name} - total order price {x.ListOrder.OrderTotal()} "));
                                            Thread.Sleep(3000);
                                            histExit = false;
                                            break;
                                        case 9:
                                            histExit = false;
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                break;
                            case 9:
                                break;
                            default:
                                Console.WriteLine("\t No such choice!");
                                Console.Clear();
                                mainExit = false;
                                break;
                        }
                        if (mainInput == 9)
                        {
                            Console.WriteLine("\t Thank your for buying at our place.\n");
                            //exitProgramme = false;
                            break;
                        }
                        else
                        {
                            MethodsService.ShowMainMenu();
                            mainExit = true;
                        }
                    }
                    historyUsers.Add(user);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.StackTrace);
            }
            //    //Tried the 2D printing but works out strange
            //    //user.ListOrder.Print2d();
            Console.ReadLine();
        }

        private static int MakeOrder(List<Product> products, User user, int index)
        {
            MethodsService.OrderMenu();
            bool orderExit1 = true;
            while (orderExit1)
            {
                bool userMakeOrderInput = Int32.TryParse(Console.ReadLine(), out int makeOrderInput);
                switch (makeOrderInput)
                {
                    case 1:
                        int userQuantInput = 0;
                        do
                        {
                            Console.WriteLine(" \n Choose a product from the list by entering product code...");
                            string userIdInput = Console.ReadLine();

                            Product product = products
                                .SingleOrDefault(x => x.Id == userIdInput);
                            Console.WriteLine("-----------------------------------");

                            if (product != null)
                            {
                                Console.WriteLine("Choose how many products would you like...");

                                try
                                {
                                    userQuantInput = int.Parse(Console.ReadLine());
                                }

                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                user.ListOrder.AddOrderLine(product, userQuantInput, index);
                                index++;
                                Console.WriteLine("---------------------------------");
                                Console.WriteLine("Would you like to add another product?");
                                Console.WriteLine("Press 1 for Yes, 9 for No");
                                try
                                {
                                    int userSameVendorChoice = int.Parse(Console.ReadLine());
                                    if (userSameVendorChoice == 1)
                                    {
                                        continue;
                                    }
                                    else if (userSameVendorChoice == 9)
                                    {
                                        orderExit1 = false;
                                        // Console.WriteLine("Press 9 to go back...");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("No such option!");
                                        break;
                                    }
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No such id!");
                                orderExit1 = false;
                                break;
                            }
                        }
                        while (true);
                        break;
                    case 9:
                        //orderExit1 = false;
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        break;
                }
                if (makeOrderInput == 9)
                {
                    //MethodsService.OrderMenu();
                    orderExit1 = false;
                }
            }
            //end of making order;
            return index;
        }

        public static string PrintReceipt(User user)
        {
            DateTime timeNow = DateTime.Now;
            string receipt = @"
                \n\t============================" +
                $"\n\t=============================" +
                $"\n\tCustomer: {user.Name}" +
                $"\n\t============================" +
                $"{user.ListOrder.PrintForReceipt()}" +
                $"\n\t=============================" +
                $"\n\t=============================" +
                $"\n\t{timeNow}" +
                $"\n\t=============================" +
                $"\n\tThank you!" +
                $"\n\t=============================" +
                $"\n\t=============================";
            return receipt;
        }      
    }
}
