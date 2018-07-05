using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Master
    {
        //Initialization of stores:
        public static Location FirstLocation = new Location(1);
        public static Location SecondLocation = new Location(2);
        public static Location ThirdLocation = new Location(3);
        public static Location FourthLocation = new Location(4);
        public static Location FifthLocation = new Location(5);

        public static List<Location> LocationList = new List<Location>()
        {
            FirstLocation, SecondLocation, ThirdLocation, FourthLocation, FifthLocation
        };
    }
}
