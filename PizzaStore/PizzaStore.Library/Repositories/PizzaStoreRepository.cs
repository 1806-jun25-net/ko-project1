﻿using System;
using PizzaStore.Data;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Library.Models;

namespace PizzaStore.Library.Repositories
{
    public class PizzaStoreRepository
    {
        private readonly PizzaStoreDBContext _db;

        public PizzaStoreRepository(PizzaStoreDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        //Users

        public void AddUser(Library.User user)
        {
            _db.Add(Models.Mapper.Map(user));
        }

        //DOESN'T WORK BUT DO WE NEED THIS IMPLEMENTATION...?
        public void DeleteUser(Library.User user)
        {
            _db.Remove(Mapper.Map(user));
        }

        public void UpdateUser(Library.User user)
        {
            _db.Entry(_db.Users.Find(user.Id)).CurrentValues.SetValues(Mapper.Map(user));
        }

        public bool DoesUserExist(string first, string last)
        {
            var users = _db.Users;
            foreach (var item in users)
            {
                if (first == item.FirstName && last == item.LastName)
                {
                    return true;
                }
            }
            return false;
        }

        public User GetUser(string first, string last)
        {
            var users = _db.Users;
            foreach (var item in users)
            {
                if (first == item.FirstName && last == item.LastName)
                {
                    return Mapper.Map(item);
                }
            }
            return null;
        }

        public int GetUserID(Library.User user)
        {

            var users = _db.Users;
            foreach (var item in users)
            {
                if (user.FirstName == item.FirstName && user.LastName == item.LastName)
                {
                    return item.Id;
                }
            }
            return 0;
        }

        //Orders

        public void AddOrder(Library.Order order)
        {
            _db.Add(Models.Mapper.Map(order));
        }

        public void SetUserIdInOrder(User u, Order o)
        {
            o.Id = _db.Orders.Find(GetMostRecentOrderByUser(u)).Id;
        }

        public void UpdateOrder(Library.Order order)
        {
            _db.Entry(_db.Orders.Find(order.Id)).CurrentValues.SetValues(Mapper.Map(order));
        }

        public List<Library.Order> GetOrders()
        {
            return Models.Mapper.Map(_db.Orders.Include(x => x.Location).Include(y => y.User).AsNoTracking());
        }

        public List<Library.Order> GetOrdersByUser(User u)
        {
            var orders = _db.Orders;
            List<Order> result = new List<Order>();
            foreach (var item in orders)
            {
                if (item.UserId == u.Id)
                {
                    result.Add(Mapper.Map(item));
                }
            }
            return result;
        }

        public void PrintOrderHistory(Order o)
        {

            Console.WriteLine();
            Console.WriteLine($"Order ID = {o.Id}");
            Console.WriteLine($"User ID = {o.UserID}");
            Console.WriteLine($"Location ID = {o.LocationID}");
            Console.WriteLine($"Order Time = {o.OrderTime}");
            Console.WriteLine($"Price = {o.Price}");
            Console.WriteLine();
        }

        public void PrintOrderHistory(List<Order> OrderHistory)
        {
            foreach (var item in OrderHistory)
            {
                Console.WriteLine();
                Console.WriteLine($"Order ID = {item.Id}");
                Console.WriteLine($"User ID = {item.UserID}");
                Console.WriteLine($"Location ID = {item.LocationID}");
                Console.WriteLine($"Order Time = {item.OrderTime}");
                Console.WriteLine($"Price = {item.Price}");
                Console.WriteLine();
            }
        }

        public Order GetMostRecentOrderByUser(User user)
        {
            var orders = _db.Orders;
            Order result = null;
            DateTime res = DateTime.MinValue;
            foreach (var item in orders)
            {
                if (user.Id == item.UserId)
                {
                    if (item.OrderTime.CompareTo(res) > 0)
                    {
                        result = Mapper.Map(item);
                        res = item.OrderTime;

                    }
                }
            }
            return result;
        }




        //Locations

        public void AddLocation(Library.Location location)
        {
            _db.Add(Models.Mapper.Map(location));
        }

        //Pizzas
        public void AddPizza(Library.Pizza pizza)
        {
            _db.Add(Models.Mapper.Map(pizza));
        }

        public int GetMostRecentOrderID()
        {
            var orders = _db.Orders;
            var RecentOrder = new PizzaStore.Data.Orders()
            {
                OrderTime = DateTime.MinValue
            };
            foreach (var item in orders)
            {
                if (item.OrderTime > RecentOrder.OrderTime)
                {
                    RecentOrder = item;
                }
            }
            return RecentOrder.Id;
        }





        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
