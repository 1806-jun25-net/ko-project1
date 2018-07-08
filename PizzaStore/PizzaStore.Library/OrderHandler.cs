using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class OrderHandler
    {
        public static string FinalizeOrder(Location l, Order o)
        {
            Console.WriteLine($"Thank you for your order. Your total is ${o.Price}");
            Console.WriteLine("Here are the details of your order:");
            for (var i = 0; i < o.PizzaList.Count; i++)
            {
                Console.WriteLine($"Pizza {i + 1}:");
                Console.WriteLine($"Size: { o.PizzaList[i].PizzaSize}");
                Console.WriteLine("Toppings:");
                o.PizzaList[i].Toppings.ForEach(Console.WriteLine);
                Console.WriteLine();
            }

            o.OrderTime = DateTime.Now;
            l.OrderHistory.Add(o);
            return "Order Finished.";
        }

        public static void AddTopping(Location l, Pizza p, string topping, string ans)
        {
            if (ans == "y")
            {
                if (l.Inventory[topping] > 0)
                {
                    p.Toppings.Add(topping);
                    //$1 toppings
                    p.Price++;
                    l.Inventory[topping]--;
                    Console.WriteLine($"Current toppings for the {p.PizzaSize} pizza is: ");
                    p.Toppings.ForEach(Console.WriteLine);
                }
                else
                {
                    Console.WriteLine("Sorry, we currently do not have that topping in stock.");
                    Console.WriteLine($"{topping} was NOT added.");
                }
            }
        }
        public static string BeginOrder(string name, User u, Location l)
        {
            Order o = new Order
            {
                User = u,
                OrderTime = DateTime.Now
            };
            //First check if the user ordered within 2 hours
            if (l.UserExistInOrderHistory(l.OrderHistory, name))
            {
                Order latestOrder = l.SortOrderHistory(l.OrderHistoryByUser(l.OrderHistory, name), "latest")[0];
                if ((o.OrderTime - latestOrder.OrderTime).TotalMinutes < 120)
                {
                    return "We can't process your order. You have ordered within the past 2 hours";
                }
                //if the user exists, give a suggestion based on the last order...
                Pizza Suggested = l.SortOrderHistory(l.OrderHistoryByUser(l.OrderHistory, name), "latest")[0].PizzaList[0];
                Console.WriteLine($"You have ordered a {Suggested.PizzaSize} with {Suggested.Toppings} in the past. Would you like to add this to your order? [y/n]");
                string ans = Console.ReadLine();
                if (ans == "y")
                {
                    o.PizzaList.Add(Suggested);
                    o.NumPizza++;
                    o.Price += Suggested.Price;
                    Console.WriteLine("Would you like to order more pizzas? [y/n]");
                    string more = Console.ReadLine();
                    if (more == "n")
                    {
                        FinalizeOrder(l, o);
                    }
                }

            }
            //Now regardless of user in system or not they can order
            while (o.NumPizza < 12)
            {
                if (o.Price > 500)
                {
                    Console.WriteLine("Cannot order more pizza since order exceeds $500.");
                    return "Failed to place order";
                }
                //Actually begin to order
                Pizza p = new Pizza();
                Console.WriteLine("Please select the size of your pizza [S/M/L]");
                p.PizzaSize = Console.ReadLine();
                //Update pizza price based on size
                if (p.PizzaSize == "S")
                {
                    p.Price += 10;
                }
                if (p.PizzaSize == "M")
                {
                    p.Price += 15;
                }
                if (p.PizzaSize == "L")
                {
                    p.Price += 20;
                }
                Console.WriteLine("We have the following toppings:");
                l.Toppings.ForEach(Console.WriteLine);
                for (var i = 0; i < l.Toppings.Count; i++)
                {
                    Console.WriteLine($"Add {l.Toppings[i]}? [y/n]");
                    AddTopping(l, p, l.Toppings[i], Console.ReadLine());
                }
                o.PizzaList.Add(p);
                o.Price += p.Price;
                o.NumPizza++;

                Console.WriteLine($"You currently have {o.NumPizza} pizza(s). Would you like to order more? [y/n]");
                string b = Console.ReadLine();
                if (b == "n")
                {
                    break;
                }
            }
            FinalizeOrder(l, o);
            return "Order Finished.";
        }
    }
}
