using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Location
    {
        public Dictionary<string, int> inventory = new Dictionary<string, int>();
        public IEnumerable<Order> orderHistory;

    }

}
