using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using lost_in_woods.Factories;
using lost_in_woods.Models;

namespace lost_in_woods.Controllers
{
    public class TrailController : Controller
    {
        private readonly TrailFactory trailFactory;
        public TrailController()
        {
            trailFactory = new TrailFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.allTrails = trailFactory.ShowAll();
            return View();
        }
        [HttpGet]
        [Route("new_trail")]
        public IActionResult New_Trail()
        {
            Trail newTrail = new Trail();
            return View(newTrail);
        }
        [HttpPost]
        [Route("add_trail")]
        public IActionResult Add_Trail(Trail newTrail)
        {
            if(ModelState.IsValid)
            {
                trailFactory.AddTrail(newTrail);
                return RedirectToAction("Index");
            }
            return View("New_Trail", newTrail);
        }
        [HttpGet]
        [Route("trails/{trail_id}")]
        public IActionResult Get_Trail(int trail_id)
        {
            ViewBag.Trail = trailFactory.FindByID(trail_id);
            return View();
        }
    }
}
