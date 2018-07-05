using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Order
    {
        public User User { get; set; }
        public DateTime OrderTime { get; set; }
        public bool UpToTwelve = false;
        public bool UpToFiveHundredDollars = false;

        public void BeginOrder()
        {
            Console.Write("Name: ");
            string Name = Console.ReadLine();
            if (!Tracker.db.ContainsKey(Name))
            {
                Tracker.db.Add(Name, new User());
            }

            User u = Tracker.db[Name];

            if (u.defaultLocation != 0)
            {
                Console.WriteLine($"Your default location is: {u.defaultLocation}. Do you want to keep it? Answer yes or no");
                string preferred = Console.ReadLine();
                if (preferred == "yes")
                {
                    u.selectedLocation = u.defaultLocation;
                }
            }
            if (u.selectedLocation == 0)
            {
                Console.WriteLine("Location 1 - 123 Alpha street");
                Console.WriteLine("Location 2 - 456 Bravo street");
                Console.WriteLine("Location 3 - 789 Charlie street");
                Console.WriteLine("Location 4 - 246 Delta street");
                Console.WriteLine("Location 5 - 135 Echo street");
                Console.WriteLine("Please enter your preferred location number");

                string preferredLocation = Console.ReadLine();
                u.selectedLocation = int.Parse(preferredLocation);
                //update the default location if preferred location changed
                u.defaultLocation = u.selectedLocation;
            }
        }
    }

}
