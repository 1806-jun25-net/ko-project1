using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Order
    {
        public User User { get; set; }
        public DateTime OrderTime { get; set; }
        public List<Pizza> PizzaList { get; set; } = new List<Pizza>();
        public double Price { get; set; } = 0;
        public int NumPizza { get; set; } = 0;
    }

}
