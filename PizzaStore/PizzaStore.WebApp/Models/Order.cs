using PizzaStore.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.WebApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int LocationID { get; set; }
        public Library.User User { get; set; }
        public int UserID { get; set; }
        public DateTime OrderTime { get; set; }
        public List<Library.Pizza> PizzaList { get; set; }
        public decimal Price { get; set; }
        public int NumPizza { get; set; }
    }
}
