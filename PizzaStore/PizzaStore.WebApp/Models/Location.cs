using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.WebApp.Models
{
    public class Location
    {
        // Location ID - an int between 1 to 5
        public int LocationID;

        public Location()
        {
        }

        public Location(int i)
        {
            LocationID = i;
        }

        // An inventory of the store
        public Dictionary<string, int> Inventory { get; set; }
    }
}
