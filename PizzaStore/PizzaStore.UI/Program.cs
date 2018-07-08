using PizzaStore.Library;
using System;

namespace PizzaStore.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Revature's PizzaStore!");
            Console.WriteLine("To begin, please enter your first name");
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
                else if (int.Parse(answer) > 1 && int.Parse(answer) < 6)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not a valid store! Write a number 1 to 5");
                }
            }          
            Location PreferredLocation = Master.LocationList[int.Parse(answer) - 1];
            string toPrint;
            //If user exists already:
            if (Master.UserDict.ContainsKey(name))
            {
                User u = Master.UserDict[name];
                if (u.DefaultLocation != PreferredLocation)
                {
                    Console.WriteLine($"Your default location is {u.DefaultLocation.LocationID}. Would you like to change it to {PreferredLocation.LocationID}? [y/n]");
                    string ans = Console.ReadLine();
                    if (ans == "y")
                    {
                        u.DefaultLocation = PreferredLocation;
                    }
                }
                toPrint = OrderHandler.BeginOrder(name, u, PreferredLocation);
            }
            else
            {
                User u = new User(name)
                {
                    FirstName = fn,
                    LastName = ln,
                    Name = name,
                    DefaultLocation = PreferredLocation,
                    SelectedLocation = PreferredLocation
                    
                };
                Master.UserDict.Add(name, u);
                toPrint = OrderHandler.BeginOrder(name, u, PreferredLocation);
            }
            Console.WriteLine(toPrint);
        }
    }
}
