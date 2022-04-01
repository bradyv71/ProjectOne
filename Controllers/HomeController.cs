using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TripContext _context;

        public HomeController(ILogger<HomeController> logger, TripContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new TripListModel
            {
                Trips = new List<Trip>()
            };

            //TODO: Get all Trips from the Database
            var trips = _context.Trips.ToList();

            //Assign each trip to the list of Trips in TripListModel
           
            foreach(var trip in trips)
            {
                model.Trips.Add(trip);
            }

            return View(model);
        }

        public IActionResult Clear()
        {
            TempData.Clear();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
