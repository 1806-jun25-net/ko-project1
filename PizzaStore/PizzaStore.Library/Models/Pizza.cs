using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Pizza
    {
        public int Id;
        public int OrderID;
        public string PizzaSize { get; set; }
        public Dictionary<string, bool> Toppings { get; set; } = new Dictionary<string, bool>()
        {
                { "Pepperoni", false },
                { "Chicken", false },
                { "Ham", false },
                { "Sausage", false },
                { "Mushroom", false },
                { "Onion", false },
                { "Pineapple", false },
                { "Jalapeno", false },
                { "Olive", false },
                { "Tomato", false }
        };
        public decimal Price { get; set; }
    }
}
