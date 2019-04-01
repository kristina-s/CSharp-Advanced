using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace Class02_CarDeale
{
    class Program
    {
        static void Main(string[] args)
        {
            #region List of cars and dealers
            List<Car> bmwCars = new List<Car>
            {
                new BMW ("530", 5, "Diesel", 12.5, 55000, TypeOfCar.passenger, true),
                new BMW ("X3", 5, "Petrol", 10.5, 33000, TypeOfCar.passenger, false),
                new BMW ("X5 CV", 5, "Petrol", 14, 48000, TypeOfCar.cargo, false),
                new BMW ("M4", 3, "Petrol", 11.5, 52000, TypeOfCar.passenger, true)
            };
            List<Car> audiCars = new List<Car>
            {
                new Audi ("A3", 3, "Diesel", 7.5, 27000, TypeOfCar.passenger, "Dark Blue"),
                new Audi ("A4", 5, "Diesel", 8, 34000, TypeOfCar.passenger, "Red"),
                new Audi ("A7", 5, "Petrol", 8.5, 52000, TypeOfCar.passenger, "White"),
                new Audi ("Q5", 5, "Diesel", 11, 55000, TypeOfCar.cargo, "Silver"),
                new Audi ("Q7", 5, "Petrol", 13.5, 71000, TypeOfCar.cargo, "Matte Black")
            };
            List<Car> opelCars = new List<Car>
            {
                new Opel ("Astra", 5, "Petrol", 7.5, 18000, TypeOfCar.passenger, "Germany"),
                new Opel ("Antara", 5, "Diesel", 10, 22000, TypeOfCar.cargo, "USA"),
                new Opel ("Corsa", 3, "Diesel", 6.5, 11000, TypeOfCar.passenger, "Hungary"),
                new Opel ("Combo Cargo", 5, "Petrol", 9.5, 19000, TypeOfCar.cargo, "Germany"),
                new Opel ("Insignia", 5, "Diesel", 8.5, 17000, TypeOfCar.passenger, "USA")
            };
            #endregion


            Console.WriteLine("Choose to enter one of the following car dealers");
            while (true)
            {
                Console.WriteLine("Press 1 for BMW, 2 for Audi, 3 for Opel...");
                try
                {
                    int userChoiceDealer = int.Parse(Console.ReadLine());

                    switch (userChoiceDealer)
                    {
                        //BMW Dealers
                        case 1:
                            CarDealer bmwDealer = new CarDealer();
                            bmwDealer.Name = "BMW Dealership";
                            bmwDealer.Address = "St. John's st 1A";
                            bmwDealer.CarsList = bmwCars;
                            Console.WriteLine("Welcome to BMW car dealership!");
                            Console.WriteLine("What kind of car would you like to buy?");
                            Console.WriteLine("Press 1 to see passenger vehicles");
                            Console.WriteLine("Press 2 to see cargo vehicles");
                            try
                            {
                                int userChoice = int.Parse(Console.ReadLine());
                                if (userChoice == 1)
                                {
                                    List<Car> bmwPassenger = bmwDealer.CarsList
                                        .Where(x => x.CarType == TypeOfCar.passenger)
                                        .ToList();
                                    foreach (var car in bmwPassenger)
                                    {
                                        Console.WriteLine(car.CarInfo());
                                        Console.WriteLine($"Price in EUR: {car.PrintPrice("eur")}/ Price in MKD {car.PrintPrice("mkd")}");
                                    }
                                }
                                else if (userChoice == 2)
                                {
                                    List<Car> bmwCargo = bmwDealer.CarsList
                                        .Where(x => x.CarType == TypeOfCar.cargo)
                                        .ToList();
                                    foreach (var car in bmwCargo)
                                    {
                                        Console.WriteLine(car.CarInfo());
                                        Console.WriteLine($"Price in EUR: {car.PrintPrice("eur")}/ Price in MKD {car.PrintPrice("mkd")}");

                                    }
                                }
                                else if ((userChoice != 1) || (userChoice != 2))
                                {
                                    Console.WriteLine("No such option!");
                                    break;
                                }
                                Console.WriteLine("--------------------------");
                                Console.WriteLine("You can enter minimum and maximum price range too see vehicles.");
                                Console.WriteLine("Press 1 to see prices in EUR, or 2 to see price in MKD denars");
                                try
                                {
                                    int inpCurrency = int.Parse(Console.ReadLine());
                                    if (inpCurrency == 1)
                                    {
                                        Console.WriteLine("These prices are in euros! \n");
                                        GetMinAndMaxAndPrint(bmwDealer);
                                        continue;
                                    }
                                    else if (inpCurrency == 2)
                                    {
                                        Console.WriteLine("These prices are in denars! \n");
                                        GetMinAndMaxAndPrintMKD(bmwDealer);
                                        continue;
                                    }
                                    else if ((inpCurrency != 1) || (inpCurrency != 2))
                                    {
                                        Console.WriteLine("No such option!");
                                        continue;
                                    }
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                };
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            };
                            break;

                        // AUDI dealership
                        case 2:
                            CarDealer audiDealer = new CarDealer();
                            audiDealer.Name = "AUDI Dealership";
                            audiDealer.Address = "55 Mill Road";
                            audiDealer.CarsList = audiCars;
                            Console.WriteLine("Welcome to AUDI car dealership!");
                            Console.WriteLine("What kind of car would you like to buy?");
                            Console.WriteLine("Press 1 to see passenger vehicles");
                            Console.WriteLine("Press 2 to see cargo vehicles");
                            try
                            {
                                int userChoice02 = int.Parse(Console.ReadLine());
                                if (userChoice02 == 1)
                                {
                                    List<Car> audiPassenger = audiDealer.CarsList
                                        .Where(x => x.CarType == TypeOfCar.passenger)
                                        .ToList();
                                    foreach (var car in audiPassenger)
                                    {
                                        Console.WriteLine(car.CarInfo());
                                        Console.WriteLine($"Price in EUR: {car.PrintPrice("eur")}/ Price in MKD {car.PrintPrice("mkd")}");

                                    }
                                }
                                else if (userChoice02 == 2)
                                {
                                    List<Car> audiCargo = audiDealer.CarsList
                                        .Where(x => x.CarType == TypeOfCar.cargo)
                                        .ToList();
                                    foreach (var car in audiCargo)
                                    {
                                        Console.WriteLine(car.CarInfo());
                                        Console.WriteLine($"Price in EUR: {car.PrintPrice("eur")}/ Price in MKD {car.PrintPrice("mkd")}");

                                    }
                                }
                                else if ((userChoice02 != 1) || (userChoice02 != 2))
                                {
                                    Console.WriteLine("No such option!");
                                    break;
                                }
                                Console.WriteLine("--------------------------");
                                Console.WriteLine("You can enter minimum and maximum price range too see vehicles.");
                                Console.WriteLine("Press 1 to see prices in EUR, or 2 to see price in MKD denars");
                                try
                                {
                                    int inpCurrency = int.Parse(Console.ReadLine());
                                    if (inpCurrency == 1)
                                    {
                                        Console.WriteLine("These prices are in euros! \n");
                                        GetMinAndMaxAndPrint(audiDealer);
                                        continue;
                                    }
                                    else if (inpCurrency == 2)
                                    {
                                        Console.WriteLine("These prices are in denars! \n");
                                        GetMinAndMaxAndPrintMKD(audiDealer);
                                        continue;
                                    }
                                    else if ((inpCurrency != 1) || (inpCurrency != 2))
                                    {
                                        Console.WriteLine("No such option!");
                                        break;
                                    }
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                };
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            };
                            break;

                        //OPEL Dealership
                        case 3:
                            CarDealer opelDealer = new CarDealer();
                            opelDealer.Name = "OPEL Dealership";
                            opelDealer.Address = "100 Downtown St.";
                            opelDealer.CarsList = opelCars;
                            Console.WriteLine("Welcome to OPEL car dealership!");
                            Console.WriteLine("What kind of car would you like to buy?");
                            Console.WriteLine("Press 1 to see passenger vehicles");
                            Console.WriteLine("Press 2 to see cargo vehicles");
                            try
                            {
                                int userChoice03 = int.Parse(Console.ReadLine());
                                if (userChoice03 == 1)
                                {
                                    List<Car> opelPassenger = opelDealer.CarsList
                                        .Where(x => x.CarType == TypeOfCar.passenger)
                                        .ToList();
                                    foreach (var car in opelPassenger)
                                    {
                                        Console.WriteLine(car.CarInfo());
                                        Console.WriteLine($"Price in EUR: {car.PrintPrice("eur")}/ Price in MKD {car.PrintPrice("mkd")}");

                                    }
                                }
                                else if (userChoice03 == 2)
                                {
                                    List<Car> opelCargo = opelDealer.CarsList
                                        .Where(x => x.CarType == TypeOfCar.cargo)
                                        .ToList();
                                    foreach (var car in opelCargo)
                                    {
                                        Console.WriteLine(car.CarInfo());
                                        Console.WriteLine($"Price in EUR: {car.PrintPrice("eur")}/ Price in MKD {car.PrintPrice("mkd")}");

                                    }
                                }
                                else if ((userChoice03 != 1) || (userChoice03 != 2))
                                {
                                    Console.WriteLine("No such option!");
                                }
                                Console.WriteLine("--------------------------");
                                Console.WriteLine("You can enter minimum and maximum price range too see vehicles.");
                                Console.WriteLine("Press 1 to see prices in EUR, or 2 to see price in MKD denars");
                                try
                                {
                                    int inpCurrency = int.Parse(Console.ReadLine());
                                    if (inpCurrency == 1)
                                    {
                                        Console.WriteLine("These prices are in euros! \n");
                                        GetMinAndMaxAndPrint(opelDealer);
                                        continue;
                                    }
                                    else if (inpCurrency == 2)
                                    {
                                        Console.WriteLine("These prices are in denars! \n");
                                        GetMinAndMaxAndPrintMKD(opelDealer);
                                        continue;
                                    }
                                    else if ((inpCurrency != 1) || (inpCurrency != 2))
                                    {
                                        Console.WriteLine("No such option!");
                                        continue;
                                    }
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                };
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            };
                            break;

                        default:
                            Console.WriteLine("No such option! Try again!");
                            break;
                    }
                    continue;
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }               
            }          
        }

        private static void GetMinAndMaxAndPrintMKD(CarDealer cd)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("Choose a min price range ");
            try
            {
                int userMin = int.Parse(Console.ReadLine());
                Console.WriteLine("Choose a max price range ");
                int userMax = int.Parse(Console.ReadLine());
                Console.WriteLine("These cars are within your price range: \n");
                cd.PriceRangeMKD(userMin, userMax);
                Console.WriteLine("--------------------------");

            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void GetMinAndMaxAndPrint(CarDealer cd)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("Choose a min price range ");
            try
            {
                int userMin = int.Parse(Console.ReadLine());
                Console.WriteLine("Choose a max price range ");
                int userMax = int.Parse(Console.ReadLine());
                Console.WriteLine("These cars are within your price range: \n");
                cd.PriceRange(userMin, userMax);
                Console.WriteLine("--------------------------");

            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
      
    
}
