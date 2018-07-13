using PizzaStore.Library.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class OrderHandler
    {
        public static string FinalizeOrder(Location l, Order o, PizzaStoreRepository repo)
        {
            Console.WriteLine($"Thank you for your order. Your total is ${o.Price}");
            Console.WriteLine("Here are the details of your order:");
            for (var i = 0; i < o.PizzaList.Count; i++)
            {
                Console.WriteLine($"Pizza {i + 1}:");
                Console.WriteLine($"Size: { o.PizzaList[i].PizzaSize}");
                Console.WriteLine("Toppings:");
                foreach (KeyValuePair<string, bool> entry in o.PizzaList[i].Toppings)
                {
                    if (entry.Value == true)
                    {
                        Console.WriteLine(entry.Key);
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            repo.PrintOrderHistory(o);
            repo.UpdateOrder(o);
            repo.Save();
            
            return "Order Finished.";
        }

        public static void AddTopping(Location l, Pizza p, string topping, string ans, PizzaStoreRepository repo)
        {
            if (ans == "y")
            {
                if (l.Inventory[topping] > 0)
                {
                    //p.Toppings.Add(topping);
                    //$1 toppings
                    p.Price++;
                    l.Inventory[topping]--;
                    p.Toppings[topping] = true;
                    repo.UpdateInventory(l);
                    repo.Save();
                    Console.WriteLine($"Current toppings for the {p.PizzaSize} pizza is: ");
                    foreach (KeyValuePair<string, bool> entry in p.Toppings)
                    {
                        if (entry.Value == true)
                        {
                            Console.WriteLine(entry.Key);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, we currently do not have that topping in stock.");
                    Console.WriteLine($"{topping} was NOT added.");
                }
            }
        }
        public static string BeginOrder(string name, User u, Location l, PizzaStoreRepository repo)
        {
            Console.WriteLine("View your order history?");
            string ans = Console.ReadLine();
            if (ans == "y")
            {
                repo.PrintOrderHistory(repo.GetOrdersByUser(u));
            }

            Order o = new Order
            {
                User = u,
                UserID = repo.GetUserID(u),
                OrderTime = DateTime.Now,
                LocationID = l.LocationID,
                NumPizza = 0,
                Price = 0
            };
            repo.AddOrder(o);
            repo.Save();
            o.Id = repo.GetMostRecentOrderID();

            //First check if the user ordered within 2 hours
            //if ((repo.GetMostRecentOrderByUser(o).OrderTime - o.OrderTime).TotalMinutes < 120)
            //{
            //    return $"No, {u.FirstName}, we can't prcoess your order since you have ordered within the past 2 hours.";
            //}


            if (l.UserExistInOrderHistory(l.OrderHistory, name))
            {
                //if the user exists, give a suggestion based on the last order...
                Pizza Suggested = Location.SortOrderHistory(l.OrderHistoryByUser(l.OrderHistory, name), "latest")[0].PizzaList[0];
                Console.WriteLine($"You have ordered a {Suggested.PizzaSize} with {Suggested.Toppings} in the past. Would you like to add this to your order? [y/n]");
                string answ = Console.ReadLine();
                if (answ == "y")
                {
                    o.PizzaList.Add(Suggested);
                    o.NumPizza++;
                    o.Price += Suggested.Price;
                    Console.WriteLine("Would you like to order more pizzas? [y/n]");
                    string more = Console.ReadLine();
                    if (more == "n")
                    {
                        FinalizeOrder(l, o, repo);
                    }
                }

            }
            //Now regardless of user in system or not they can order
            while (o.Price < 500)
            {
                if (o.NumPizza > 11)
                {
                    Console.WriteLine("Cannot order more pizza since you are ordering more than 12 pizzas.");
                    return "Failed to place order";
                }
                //Actually begin to order
                Pizza p = new Pizza()
                {
                    OrderID = repo.GetMostRecentOrderID(),
                    PizzaSize = "A"
                };
                
                Console.WriteLine("Please select the size of your pizza [S/M/L]");
                p.PizzaSize = Console.ReadLine();
                //Update pizza price based on size
                if (p.PizzaSize == "S")
                {
                    p.Price += 10;
                    p.PizzaSize = "S";
                }
                if (p.PizzaSize == "M")
                {
                    p.Price += 15;
                    p.PizzaSize = "M";
                }
                if (p.PizzaSize == "L")
                {
                    p.Price += 20;
                    p.PizzaSize = "L";
                }
                Console.WriteLine("We have the following toppings:");
                l.Toppings.ForEach(Console.WriteLine);
                for (var i = 0; i < l.Toppings.Count; i++)
                {
                    Console.WriteLine($"Add {l.Toppings[i]}? [y/n]");
                    AddTopping(l, p, l.Toppings[i], Console.ReadLine(), repo);
                }
                repo.AddPizza(p);
                repo.Save();
                p.Id = repo.GetMostRecentPizza().Id;
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
            FinalizeOrder(l, o, repo);
            return "Order Finished.";
        }
    }
}
