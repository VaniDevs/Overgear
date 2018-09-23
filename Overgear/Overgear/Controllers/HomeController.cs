using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Overgear.Models;

namespace Overgear.Controllers
{
    public class HomeController : Controller
    {
        private readonly OvergearContext _context;

        public HomeController(OvergearContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new EventViewModel());
        }

        // Calendar
        public JsonResult GetEvents(DateTime start, DateTime end)
        {
            var viewModel = new EventViewModel();
            var events = new List<EventViewModel>();
            start = DateTime.Today.AddDays(-14);
            end = DateTime.Today.AddDays(-11);

            for (var i = 1; i <= 5; i++)
            {
                events.Add(new EventViewModel()
                {
                    id = i,
                    title = "Event " + i,
                    start = start.ToString(),
                    end = end.ToString(),
                    allDay = false
                });

                start = start.AddDays(7);
                end = end.AddDays(7);
            }

            return Json(events.ToArray());
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Inventory()
        {
            ViewData["Boots"] = (from boot in _context.Boot select boot).ToList();
            ViewData["Gloves"] = (from glove in _context.Gloves select glove).ToList();
            ViewData["Headgears"] = (from headgear in _context.Headgear select headgear).ToList();
            ViewData["HighVis"] = (from highvis in _context.HighVisibility select highvis).ToList();
            ViewData["Outerwears"] = (from outerwear in _context.Outerwear select outerwear).ToList();
            ViewData["Pants"] = (from pant in _context.Pants select pant).ToList();
            ViewData["Shirts"] = (from shirt in _context.Shirt select shirt).ToList();
            ViewData["Shoes"] = (from shoe in _context.Shoe select shoe).ToList();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
