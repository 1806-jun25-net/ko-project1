using PizzaStore.Library;
using System;

namespace PizzaStore.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Revature's PizzaStore!");
            Console.WriteLine("To begin, please enter your name");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Here are our locations:");
            Console.WriteLine("Location 1 - 123 Alpha street");
            Console.WriteLine("Location 2 - 456 Bravo street");
            Console.WriteLine("Location 3 - 789 Charlie street");
            Console.WriteLine("Location 4 - 246 Delta street");
            Console.WriteLine("Location 5 - 135 Echo street");
            Console.WriteLine("Please enter your preferred location number");
            Location PreferredLocation = Master.LocationList[int.Parse(Console.ReadLine()) - 1];
            if (PreferredLocation.UserDict[name] != null)
            {
                User u = PreferredLocation.UserDict[name];
                OrderHandler.BeginOrder(name, u, PreferredLocation);
            }
            else
            {
                User u = new User(name);
                PreferredLocation.UserDict.Add(name, u);
                OrderHandler.BeginOrder(name, u, PreferredLocation);
            }
           
            

        //    public void BeginOrder()
        //    {
        //        Console.Write("Name: ");
        //        string Name = Console.ReadLine();
        //        if (!Tracker.db.ContainsKey(Name))
        //        {
        //            Tracker.db.Add(Name, new User());
        //        }

        //        User u = Tracker.db[Name];

        //        if (u.defaultLocation != 0)
        //        {
        //            Console.WriteLine($"Your default location is: {u.defaultLocation}. Do you want to keep it? Answer yes or no");
        //            string preferred = Console.ReadLine();
        //            if (preferred == "yes")
        //            {
        //                u.selectedLocation = u.defaultLocation;
        //            }
        //        }
        //        if (u.selectedLocation == 0)
        //        {
        //            Console.WriteLine("Location 1 - 123 Alpha street");
        //            Console.WriteLine("Location 2 - 456 Bravo street");
        //            Console.WriteLine("Location 3 - 789 Charlie street");
        //            Console.WriteLine("Location 4 - 246 Delta street");
        //            Console.WriteLine("Location 5 - 135 Echo street");
        //            Console.WriteLine("Please enter your preferred location number");

        //            string preferredLocation = Console.ReadLine();
        //            u.selectedLocation = int.Parse(preferredLocation);
        //            //update the default location if preferred location changed
        //            u.defaultLocation = u.selectedLocation;
        //        }
        //    }
        //Order curr = new Order();
        //    curr.BeginOrder();




        }
    }
}
