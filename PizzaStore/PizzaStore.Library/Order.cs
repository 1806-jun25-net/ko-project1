using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Order
    {
        public User User { get; set; }
        public DateTime OrderTime { get; set; }
        public double price { get; set; } = 0;
        public bool UpToTwelve = false;
        public bool UpToFiveHundredDollars = false;
    }

}
