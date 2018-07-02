using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Order
    {
        public Address orderAddress;
        public User user;
        public DateTime orderTime;
        public bool upToTwelve;
        public bool upToFiveHundredDollars;


    }
}
