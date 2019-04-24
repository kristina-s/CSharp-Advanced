
using E_shop.Services;
using E_shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Class10_E_shop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = ProductsService.GetAllProducts();
            var vendors = Enum.GetValues(typeof(Vendor)).Cast<Vendor>().ToList();
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

                                                //end of making order;


                                                MethodsService.ShowProductsMenu();
                                                break;
                                            }
                                            if(vendorInput >=0 && vendorInput > vendors.Count && vendorInput != 9)
                                            {
                                                MethodsService.ShowProductsMenu();
                                                break;
                                            }
                                            if (vendorInput <=0 && vendorInput < vendors.Count && vendorInput != 9)
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

                                            //vendorExit = false;                                                                            
                                        }

                                        break;
                                    case 2:
                                        //all products and offer making order!!!!
                                        Console.WriteLine("\n\t-----------------------------------");
                                        products.ForEach(x => Console.WriteLine($" {x.Id} | {x.Name} | {x.Price} MKD"));
                                        Console.WriteLine("\n\t-----------------------------------");
                                        MethodsService.SortMenu();
                                        bool sortExit = true;
                                        while (sortExit)
                                        {
                                            bool userSortInput = Int32.TryParse(Console.ReadLine(), out int sortInput);
                                            switch (sortInput)
                                            {
                                                case 1:
                                                    Console.WriteLine("\tSort by price - Asc");
                                                    var priceAsc = products
                                                        .OrderBy(x => x.Price)
                                                        .ToList();
                                                    priceAsc.ForEach(x => Console.WriteLine($"\t {x.Id} | {x.Name} | {x.Price} MKD"));
                                                    break;
                                                case 2:
                                                    Console.WriteLine("\tSort by price - Desc");
                                                    var priceDesc = products
                                                        .OrderByDescending(x => x.Price)
                                                        .ToList();
                                                    priceDesc.ForEach(x => Console.WriteLine($"\t {x.Id} | {x.Name} | {x.Price} MKD"));
                                                    break;
                                                case 3:
                                                    Console.WriteLine("\tSort by name - Asc");
                                                    var nameAsc = products
                                                        .OrderBy(x => x.Name)
                                                        .ToList();
                                                    nameAsc.ForEach(x => Console.WriteLine($"\t {x.Id} | {x.Name} | {x.Price} MKD"));
                                                    break;
                                                case 4:
                                                    Console.WriteLine("\tSort by name - Desc");
                                                    var nameDesc = products
                                                        .OrderByDescending(x => x.Name)
                                                        .ToList();
                                                    nameDesc.ForEach(x => Console.WriteLine($"\t {x.Id} | {x.Name} | {x.Price} MKD"));
                                                    break;
                                                case 9:
                                                    sortExit = false;
                                                    break;
                                                default:

                                                    break;
                                            }
                                            if (sortInput == 9)
                                            {
                                                MethodsService.ShowProductsMenu();

                                                sortExit = false;
                                            }
                                            else
                                            {
                                                index = MakeOrder(products, user, index);
                                                MethodsService.SortMenu();
                                                sortExit = true;
                                            }
                                        }

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
                                        Console.WriteLine("Choose an index of the product you would like to remove");
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
                                Console.WriteLine("Your shopping cart is emprty!");
                                mainExit = false;
                            }

                            break;
                        case 3:
                            //complete order and export receipt
                            Console.WriteLine("Finalize order/get receipt");
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
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Empty receipt....");
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
                        //Console.Clear();
                        MethodsService.ShowMainMenu();
                        mainExit = true;
                    }                 
                }
            }

            //    //Tried the 2D printing but works out strange
            //    //user.ListOrder.Print2d();

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
                                        Console.WriteLine("Press 9 to go back...");
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
