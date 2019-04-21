using Class10_E_shop.Models;
using Class10_E_shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Class10_E_shop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = ProductsService.GetAllProducts();
            var vendors = Enum.GetValues(typeof(Vendor)).Cast<Vendor>().ToList();

            while (true)
            {
                Console.WriteLine("Welcome to our e-shop for trainers. Please enter your name first...");
                string userName = Console.ReadLine();
                User user = new User(userName);
                List<Product> filteredProducts;
                int index = 1;

                do
                {
                    Console.WriteLine("You will see a list of all the vendors we offer. Choose vendor to continue shopping... \n");
                    vendors.ForEach(x => Console.WriteLine(x));
                    Console.WriteLine();
                    string userVendInput = Console.ReadLine();
                    filteredProducts = products
                        .Where(x => x.Vendor.ToString() == userVendInput)
                        .ToList();
                    if (filteredProducts.Count != 0)
                    {
                        Console.WriteLine($"This is a list of all the trainers from vendor {userVendInput}");
                        Console.WriteLine();
                        Console.WriteLine(" ID  |   Name   |  Price  ");
                        filteredProducts.ForEach(x => Console.WriteLine($" {x.Id} | {x.Name} | {x.Price} "));
                        //added another while
                        int userQuantInput = 0;
                        do
                        {
                            Console.WriteLine(" \n Choose a product from the list by entering product code...");
                            string userIdInput = Console.ReadLine();
                            Console.WriteLine("Choose how many products would you like...");

                            try
                            {
                                userQuantInput = int.Parse(Console.ReadLine());
                            }
                                                        
                            catch(FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            Product product = filteredProducts
                                .SingleOrDefault(x => x.Id == userIdInput);
                            Console.WriteLine("-----------------------------------");

                            if (product != null)
                            {
                                user.ListOrder.AddOrderLine(product, userQuantInput, index);
                                index++;
                                Console.WriteLine("Would you like to add another product from this vendor?");
                                Console.WriteLine("Press 1 for Yes, 2 for No");
                                try
                                {
                                    int userSameVendorChoice = int.Parse(Console.ReadLine());
                                    if (userSameVendorChoice == 1)
                                    {
                                        continue;
                                    }
                                    else if (userSameVendorChoice == 2)
                                    {
                                        Console.WriteLine("You can choose another vendor or stop shopping!");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("No such option!");
                                        break;
                                    }
                                }
                                catch(FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("No such id!");
                                break;
                            }
                        }
                        while (true);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You have entered wrong vendor name!");
                        continue;
                    }
                    Console.WriteLine("-----------------------------------");
                                   
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("Press 1 to continue shopping, 2 to get receipt...");

                    try
                    {
                        int userContShoppChoice = int.Parse(Console.ReadLine());
                        if (userContShoppChoice == 1)
                        {
                            continue;
                        }

                        else if (userContShoppChoice == 2)
                        {
                            Console.WriteLine("-----------------------------------");

                            Console.WriteLine("Show me receipt");

                            Console.WriteLine("SHOPPING CART");
                            Console.WriteLine("-----------------------------------");
                            user.ListOrder.PrintOrderList();
                            Console.WriteLine("-----------------------------------");
                            do
                            {
                                Console.WriteLine("Would you like to remove an item from the shopping cart?");
                                Console.WriteLine("Press Y/N... ");
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
                            break;
                        }
                        else
                        {
                            Console.WriteLine("No such choice!!!");
                        }
                       
                    }
                    catch(FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                while (true);

                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Your shopping cart now.");
                user.ListOrder.PrintOrderList();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Showing receipt...");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"Receipt for customer: {user.Name}");
                DateTime timeNow = DateTime.Now;
                Console.WriteLine(timeNow);
                user.ListOrder.PrintOrderList();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"Total amount for you to pay is: {user.ListOrder.OrderTotal()}");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("-----------------------------------");
                //Tried the 2D printing but works out strange
                //user.ListOrder.Print2d();
                Console.WriteLine($"Thank you for shopping here {userName}");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
                continue;

            }
        }
    }
}
