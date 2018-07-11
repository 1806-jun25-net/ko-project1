using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PizzaStore.Data;
using PizzaStore.Library;
using PizzaStore.Library.Repositories;
using System;
using System.IO;

namespace PizzaStore.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configBuilder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<PizzaStoreDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaStoreDB"));
            var options = optionsBuilder.Options;

            var PizzaStoreDBContext = new Data.PizzaStoreDBContext(options);
            var PizzaStoreRepo = new PizzaStoreRepository(PizzaStoreDBContext);

            Console.WriteLine("Welcome to Revature's PizzaStore!");
            Console.WriteLine("To begin, please enter your Name");
            Console.Write("First Name: ");
            string fn = Console.ReadLine();
            Console.Write("Last Name: ");
            string ln = Console.ReadLine();
            string name = User.FirstandLastName(fn, ln);

            //Check if pre-existing user:


            Console.WriteLine("Here are our locations:");
            Console.WriteLine("Location 1 - 123 Alpha street");
            Console.WriteLine("Location 2 - 456 Bravo street");
            Console.WriteLine("Location 3 - 789 Charlie street");
            Console.WriteLine("Location 4 - 246 Delta street");
            Console.WriteLine("Location 5 - 135 Echo street");
            string answer;
            while (true)
            {
                Console.WriteLine("Please enter your preferred location number");
                answer = Console.ReadLine();
                if (!int.TryParse(answer, out int n))
                {
                    Console.WriteLine("Please enter a number between 1 and 5");
                }
                else if (int.Parse(answer) > 0 && int.Parse(answer) < 6)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not a valid store! Write a number 1 to 5");
                }
            }
            int PreferredLocation = int.Parse(answer);
            string toPrint;
            //If user exists already:
            if (PizzaStoreRepo.DoesUserExist(fn, ln))
            {
                User u = PizzaStoreRepo.GetUser(fn, ln);
                if (u.DefaultLocation != PreferredLocation)
                {
                    Console.WriteLine($"Your default location is {u.DefaultLocation}. Would you like to change it to {PreferredLocation}? [y/n]");
                    string ans = Console.ReadLine();
                    if (ans == "y")
                    {
                        u.DefaultLocation = PreferredLocation;
                        //UPDATE THE USER HERE AND SAVE TO REPO
                    }
                }
                toPrint = OrderHandler.BeginOrder(name, u, Master.LocationList[PreferredLocation - 1], PizzaStoreRepo);
            }
            else
            {
                User u = new User(name)
                {
                    FirstName = fn,
                    LastName = ln,
                    Name = name,
                    DefaultLocation = PreferredLocation
                };
                Master.UserDict.Add(name, u);
                PizzaStoreRepo.AddUser(u);
                PizzaStoreRepo.Save();
                toPrint = OrderHandler.BeginOrder(name, u, Master.LocationList[PreferredLocation - 1], PizzaStoreRepo);
            }
            Console.WriteLine(toPrint);
        }
    }
}

