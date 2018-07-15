using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.WebApp.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public decimal Price { get; set; }
        public string PizzaSize { get; set; }
        public bool Pepperoni { get; set; }
        public bool Chicken { get; set; }
        public bool Ham { get; set; }
        public bool Sausage { get; set; }
        public bool Mushroom { get; set; }
        public bool Onion { get; set; }
        public bool Pineapple { get; set; }
        public bool Jalapeno { get; set; }
        public bool Olive { get; set; }
        public bool Tomato { get; set; }
    }
}
