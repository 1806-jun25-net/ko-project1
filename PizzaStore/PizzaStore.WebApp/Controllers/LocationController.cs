using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Library.Repositories;
using PizzaStore.WebApp.Models;

namespace PizzaStore.WebApp.Controllers
{
    public class LocationController : Controller
    {

        public PizzaStoreRepository Repo { get; }

        public LocationController(PizzaStoreRepository repo)
        {
            Repo = repo;
        }

        // GET: Location
        public ActionResult Index()
        {
            var LibLocations = Repo.GetLocations();
            var WebLocations = LibLocations.Select(x => new Location
            {
                LocationID = x.LocationID,
                Inventory = x.Inventory
            });
            return View(WebLocations);
        }

        public ActionResult OrderHistory(int i)
        {
            var LibOrders = Repo.GetOrdersByLocation(i);
            var WebOrders = LibOrders.Select(x => new Order
            {
                Id = x.Id,
                LocationID = x.LocationID,
                UserID = x.UserID,
                OrderTime = x.OrderTime,
                PizzaList = x.PizzaList,
                Price = x.Price,
                NumPizza = x.NumPizza
            });
            return View(WebOrders);
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            var libUser = Repo.GetLocation(id);
            var webUser = new Location
            {
                LocationID = libUser.LocationID,
                Inventory = libUser.Inventory
            };
            return View(webUser);
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Location location)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repo.AddLocation(new Library.Location
                    {
                        LocationID = location.LocationID,
                        Inventory = location.Inventory
                    });
                    Repo.Save();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}