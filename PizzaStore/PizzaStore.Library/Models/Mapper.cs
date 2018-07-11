using PizzaStore.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaStore.Library.Models
{
    public static class Mapper
    {
        public static Users Map(User user) => new Users
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DefaultLocation = user.DefaultLocation
        };

        public static User Map(Users user) => new User
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Name = user.FirstName + user.LastName,
            DefaultLocation = user.DefaultLocation
        };

        public static Locations Map(Location loc) => new Locations
        {
            Orders = (ICollection<Orders>)loc.OrderHistory,
            Users = (ICollection<Users>)loc.userDict,
            Id = loc.LocationID,
            Pepperoni = loc.Inventory["Pepperoni"],
            Chicken = loc.Inventory["Chicken"],
            Ham = loc.Inventory["Ham"],
            Sausage = loc.Inventory["Sausage"],
            Mushroom = loc.Inventory["Mushroom"],
            Onion = loc.Inventory["Onion"],
            Pineapple = loc.Inventory["Pineapple"],
            Jalapeno = loc.Inventory["Jalapeno"],
            Olive = loc.Inventory["Olive"],
            Tomato = loc.Inventory["Tomato"]
        };

        public static Location Map(Locations loc) => new Location
        {
            LocationID = loc.Id,
            Toppings = new List<string> { "Pepperoni", "Chicken", "Ham", "Sausage", "Mushroom", "Onion", "Pineapple", "Jalapeno", "Olive", "Tomato" },
            Inventory = new Dictionary<string, int>() {
                { "Pepperoni", loc.Pepperoni },
                { "Chicken", loc.Chicken },
                { "Ham", loc.Ham },
                { "Sausage", loc.Sausage },
                { "Mushroom", loc.Mushroom },
                { "Onion", loc.Onion },
                { "Pineapple", loc.Pineapple },
                { "Jalapeno", loc.Jalapeno },
                { "Olive", loc.Olive },
                { "Tomato", loc.Tomato }}
        };

        public static Orders Map(Order o) => new Orders
        {
            Id = o.OrderID,
            UserId = o.UserID,
            OrderTime = o.OrderTime,
            LocationId = o.LocationID,
            Price = o.Price
        };

        public static Order Map(Orders o) => new Order
        {
            OrderID = o.Id,
            UserID = o.UserId,
            LocationID = o.LocationId,
            OrderTime = o.OrderTime,
            Price = o.Price
        };

        public static Pizzas Map(Pizza p) => new Pizzas
        {
            PizzaSize = p.PizzaSize,
            OrderId = p.OrderID,
            Pepperoni = p.Toppings["Pepperoni"],
            Chicken = p.Toppings["Chicken"],
            Ham = p.Toppings["Ham"],
            Sausage = p.Toppings["Sausage"],
            Mushroom = p.Toppings["Mushroom"],
            Onion = p.Toppings["Onion"],
            Pineapple = p.Toppings["Pineapple"],
            Jalapeno = p.Toppings["Jalapeno"],
            Olive = p.Toppings["Olive"],
            Tomato = p.Toppings["Tomato"]
        };

        public static Pizza Map(Pizzas p) => new Pizza
        {
            OrderID = p.OrderId,
            PizzaSize = p.PizzaSize,
            Toppings = new Dictionary<string, bool>() {
                { "Pepperoni", p.Pepperoni },
                { "Chicken", p.Chicken },
                { "Ham", p.Ham },
                { "Sausage", p.Sausage },
                { "Mushroom", p.Mushroom },
                { "Onion", p.Onion },
                { "Pineapple", p.Pineapple },
                { "Jalapeno", p.Jalapeno },
                { "Olive", p.Olive },
                { "Tomato", p.Tomato }}
        };


        public static List<User> Map(IEnumerable<Users> users) => users.Select(Map).ToList();
        public static List<Users> Map(IEnumerable<User> users) => users.Select(Map).ToList();

        public static List<Location> Map(IEnumerable<Locations> locations) => locations.Select(Map).ToList();
        public static List<Locations> Map(IEnumerable<Location> locations) => locations.Select(Map).ToList();

        public static List<Order> Map(IEnumerable<Orders> orders) => orders.Select(Map).ToList();
        public static List<Orders> Map(IEnumerable<Order> orders) => orders.Select(Map).ToList();

        public static List<Pizza> Map(IEnumerable<Pizzas> pizzas) => pizzas.Select(Map).ToList();
        public static List<Pizzas> Map(IEnumerable<Pizza> pizzas) => pizzas.Select(Map).ToList();
    }
}
