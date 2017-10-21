using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DapperApp.Factory;
using the_dojo_league.Models;

namespace the_dojo_league.Controllers
{
    public class DojoLeagueController : Controller
    {
        private readonly NinjaFactory ninjaFactory;
        private readonly DojoFactory dojoFactory;
        public DojoLeagueController()
        {
            ninjaFactory = new NinjaFactory();
            dojoFactory = new DojoFactory();
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            Ninja newNinja = new Ninja();
            ViewBag.allNinjas = ninjaFactory.AllNinjas();
            ViewBag.allDojos = dojoFactory.AllDojos();
            return View(newNinja);
        }
        [HttpPost]
        [Route("Ninjas/RegisterNinja")]
        public IActionResult RegisterNinja(Ninja newNinja)
        {
            if(ModelState.IsValid)
            {
                ninjaFactory.AddNinja(newNinja);
                return RedirectToAction("Success");
            }
            return View("Index", newNinja);
        }
        [HttpGet]
        [Route("Success")]
        public IActionResult Success()
        {
            return View();
        }
    }
}
