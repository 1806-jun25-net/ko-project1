using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lib = PizzaStore.Library.Models;
using PizzaStore.Library.Repositories;
using PizzaStore.WebApp.Models;

namespace PizzaStore.WebApp.Controllers
{
    public class OrderController : Controller
    {
        public PizzaStoreRepository Repo { get; }

        public OrderController(PizzaStoreRepository repo)
        {
            Repo = repo;
        }

        // GET: Order
        public ActionResult Index([FromQuery]string search = null)
        {
            var libOrders = Repo.GetOrders(search);
            var webOrders = libOrders.Select(x => new Order
            {
                Id = x.Id,
                LocationID = x.LocationID,
                UserID = x.UserID,
                OrderTime = x.OrderTime,
                PizzaList = x.PizzaList,
                Price = x.Price,
                NumPizza = x.NumPizza
    });
            return View(webOrders);
        }

        public ActionResult MostExpensive()
        {
            var libOrders = Repo.SortByMostExpensive();
            var webOrders = libOrders.Select(x => new Order
            {
                Id = x.Id,
                LocationID = x.LocationID,
                UserID = x.UserID,
                OrderTime = x.OrderTime,
                PizzaList = x.PizzaList,
                Price = x.Price,
                NumPizza = x.NumPizza
            });
            return View(webOrders);
        }

        public ActionResult LeastExpensive([FromQuery]string search = null)
        {
            var libOrders = Repo.SortByLeastExpensive();
            var webOrders = libOrders.Select(x => new Order 
            {
                Id = x.Id,
                LocationID = x.LocationID,
                UserID = x.UserID,
                OrderTime = x.OrderTime,
                PizzaList = x.PizzaList,
                Price = x.Price,
                NumPizza = x.NumPizza
            });
            return View(webOrders);
        }

        public ActionResult MostRecent([FromQuery]string search = null)
        {
            var libOrders = Repo.SortByLatest();
            var webOrders = libOrders.Select(x => new Order
            {
                Id = x.Id,
                LocationID = x.LocationID,
                UserID = x.UserID,
                OrderTime = x.OrderTime,
                PizzaList = x.PizzaList,
                Price = x.Price,
                NumPizza = x.NumPizza
            });
            return View(webOrders);
        }

        public ActionResult LeastRecent([FromQuery]string search = null)
        {
            var libOrders = Repo.SortByEarliest();
            var webOrders = libOrders.Select(x => new Order
            {
                Id = x.Id,
                LocationID = x.LocationID,
                UserID = x.UserID,
                OrderTime = x.OrderTime,
                PizzaList = x.PizzaList,
                Price = x.Price,
                NumPizza = x.NumPizza
            });
            return View(webOrders);
        }

        public ActionResult ByLocation([FromQuery]string search = null)
        {
            var libOrders = Repo.SortByLocation();
            var webOrders = libOrders.Select(x => new Order
            {
                Id = x.Id,
                LocationID = x.LocationID,
                UserID = x.UserID,
                OrderTime = x.OrderTime,
                PizzaList = x.PizzaList,
                Price = x.Price,
                NumPizza = x.NumPizza
            });
            return View(webOrders);
        }

            // GET: Order/Details/5
            public ActionResult Details(int id)
        {
            var libPizza = Repo.GetPizzasByOrderId(id);
            var webPizza = libPizza.Select(x => new Pizza
            {
                Id = x.Id,
                OrderID = x.OrderID, 
                PizzaSize = x.PizzaSize,
                Pepperoni = x.Toppings["Pepperoni"],
                Chicken = x.Toppings["Chicken"],
                Ham = x.Toppings["Ham"],
                Sausage = x.Toppings["Sausage"],
                Mushroom = x.Toppings["Mushroom"],
                Onion = x.Toppings["Onion"],
                Pineapple = x.Toppings["Pineapple"],
                Jalapeno = x.Toppings["Jalapeno"],
                Olive = x.Toppings["Olive"],
                Tomato = x.Toppings["Tomato"],
            });
            return View(webPizza);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repo.AddOrder(new Library.Order
                    {
                        Id = order.Id,
                        LocationID = order.LocationID,
                        UserID = order.UserID,
                        OrderTime = order.OrderTime,
                        PizzaList = order.PizzaList,
                        Price = order.Price,
                        NumPizza = order.NumPizza
                    });
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }

                return View(order);
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            var libOrders = Repo.GetOrderById(id);
            var webOrder = new Order
            {
                Id = libOrders.Id,
                LocationID = libOrders.LocationID,
                UserID = libOrders.UserID,
                OrderTime = libOrders.OrderTime,
                PizzaList = libOrders.PizzaList,
                Price = libOrders.Price,
                NumPizza = libOrders.NumPizza
            };
            return View(webOrder);
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var libOrder = new Library.Order
                    {
                        Id = order.Id,
                        LocationID = order.LocationID,
                        UserID = order.UserID,
                        OrderTime = order.OrderTime,
                        PizzaList = order.PizzaList,
                        Price = order.Price,
                        NumPizza = order.NumPizza
                    };
                    Repo.UpdateOrder(libOrder);
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }

                return View(order);
            }
            catch
            {
                return View(order);
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Order order)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(order);
            }
        }
    }
}