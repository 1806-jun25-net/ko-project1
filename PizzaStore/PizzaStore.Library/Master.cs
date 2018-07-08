using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public static class Master
    {
        //Initialization of stores:
        public static Location FirstLocation { get; set; } = new Location(1);
        public static Location SecondLocation { get; set; } = new Location(2);
        public static Location ThirdLocation { get; set; } = new Location(3);
        public static Location FourthLocation { get; set; } = new Location(4);
        public static Location FifthLocation { get; set; } = new Location(5);

        // A dictionary of users based on the key value name
        public static Dictionary<string, User> UserDict { get; set; } = new Dictionary<string, User>();



        public static List<Location> LocationList = new List<Location>()
        {
            FirstLocation, SecondLocation, ThirdLocation, FourthLocation, FifthLocation
        };


    }
}
