using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.WebApp.Models
{
    public class PizzaStoreView
    {
        //User Info
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DefaultLocation { get; set; }
        public Order LastOrder { get; set; }

        //Order Info
        public int OrderId { get; set; }
        public Library.User User { get; set; }
        public DateTime OrderTime { get; set; }
        public List<Library.Pizza> PizzaList { get; set; }
        public decimal Price { get; set; }
        public int NumPizza { get; set; }

        //Pizza Info
        public int PizzaId { get; set; }
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
        public Library.Pizza Recommended { get; set; }
    }
}
