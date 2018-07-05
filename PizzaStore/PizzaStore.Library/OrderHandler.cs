using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class OrderHandler
    {
        public static string BeginOrder(string name, User u, Location l)
        {
            //First check if the user ordered within 2 hours
            Order o = new Order
            {
                User = u,
                OrderTime = DateTime.Now
            };
            //pull the orders from the user
            Order latestOrder = Location.SortOrderHistory(Location.OrderHistoryByUser(Location.OrderHistory, name), "latest")[0];
            if ((o.OrderTime - latestOrder.OrderTime).TotalMinutes < 120)
            {
                Console.WriteLine("We can't process your order. You have ordered within the past 2 hours");
                return null;
            }



        }
    }
}
