using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectOne.Models;
using System;
using System.Runtime.InteropServices;


namespace ProjectOne.Controllers
{
    public class TripController : Controller
    {
       private  readonly ILogger<TripController> _logger;
        private TripContext _context;
        public TripController(ILogger<TripController> logger, TripContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Add()
        {
            return View(new Trip());
        }



        [HttpPost]
        public IActionResult Add(Trip model)
        {
            var destination = model.Destination;
            var accomodation = model.Accomodation;

            //TODO: Save the model data to TempDate
            TempData["TripId"] = model.TripId;
            TempData["Accomodation"] = accomodation;
            TempData["StartDate"] = model.StartDate;
            TempData["EndDate"] = model.EndDate;
            TempData["Destination"] = destination;
            TempData["AccomodationPhone"] = model.AccomodationPhone;
            TempData["AccomodationEmail"] = model.AccomodationEmail;
            TempData["ThingToDo1"] = model.ThingToDo1;
            TempData["ThingToDo2"] = model.ThingToDo2;
            TempData["ThingToDo3"] = model.ThingToDo3;

            ViewBag.Destination = destination;
            ViewBag.Accomdation = accomodation;

            //TODO: Redirect to Add Step 2
            if (!string.IsNullOrEmpty(model.Accomodation))
            {
                return View("Add2", model);
            }

            return View("Add3", model);
        }
        [HttpPost]
        public IActionResult Add2(Trip model)
        {
            TempData["AccomodationPhone"] = model.AccomodationPhone;
            TempData["AccomodationEmail"] = model.AccomodationEmail;
            return View("Add3", model);
        }

        [HttpPost]
        public IActionResult Save(Trip model)
        {
            model.AccomodationPhone = (string)TempData["AccomodationPhone"];
            model.AccomodationEmail = (string)TempData["AccomodationEmail"];
            model.Accomodation = (string)TempData["Accomodation"];
            model.StartDate = (DateTime)TempData["StartDate"];
            model.EndDate = (DateTime)TempData["EndDate"];
            model.Destination = (string)TempData["Destination"];
          
            _context.Add(model);
            _context.SaveChanges();
            TempData["SuccessMessage"] = $"Trip to {model.Destination} added";
            return Redirect("/Home/Index");
        }
    }
}