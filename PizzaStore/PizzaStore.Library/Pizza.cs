using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Pizza
    {
        public string PizzaSize { get; set; }
        public List<string> Toppings { get; set; } = new List<string>();
        public double Price { get; set; }
    }
}
