using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaStore.Library
{
    public class Location
    {
        // An inventory of the store
        public static Dictionary<string, int> Inventory = new Dictionary<string, int>();

        // A history of orders
        public static List<Order> OrderHistory = new List<Order>();

        // A dictionary of users based on the key value name
        public static Dictionary<string, User> db = new Dictionary<string, User>();


        //A modified version of the Quick Sort algorithm to sort the Order History
        public List<Order> QuickSortForOrderHistory(List<Order> orderhistory, string condition)
        {
            return orderhistory;
        }



    }

}
