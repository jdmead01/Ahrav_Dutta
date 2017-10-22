using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ef_dojo_league.Models;

namespace ef_dojo_league.Controllers
{
    public class LeagueController : Controller
    {
        private DojoLeagueContext _context;
        public LeagueController(DojoLeagueContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("Ninjas")]
        public IActionResult Index()
        {
            SetTheBag();
            return View();
        }
        [HttpPost]
        [Route("RegisterNinja")]
        public IActionResult RegisterNinja (RegisterNinja newNinja)
        {
            if(ModelState.IsValid)
            {
                    Ninja theNinja = new Ninja
                    {
                        Name = newNinja.Name,
                        Level = newNinja.Level,
                        DojoId = newNinja.DojoId,
                        Description = newNinja.Description,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };
                    _context.Ninjas.Add(theNinja);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
            }
            SetTheBag();
            return View("Index", newNinja);
        }
        [HttpGet]
        [Route("/Dojos")]
        public IActionResult DojoPage()
        {
            SetTheBag();
            return View();
        }
        [HttpPost]
        [Route("RegisterDojo")]
        public IActionResult RegisterDojo(RegisterDojo newDojo)
        {
            if(ModelState.IsValid)
            {
                Dojo theDojo = new Dojo
                {
                    Name = newDojo.Name,
                    Location = newDojo.Location,
                    Information = newDojo.Information,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.Dojos.Add(theDojo);
                _context.SaveChanges();
                return RedirectToAction("DojoPage");
            }
            SetTheBag();
            return View("DojoPage", newDojo);
        }
        [HttpGet]
        [Route("/Ninja/{ninja_id}")]
        public IActionResult ShowNinja(int ninja_id)
        {
            Ninja theNinja = _context.Ninjas.Where(n => n.Id == ninja_id).SingleOrDefault();
            ViewBag.Dojo = _context.Dojos.Where(d => d.Id == theNinja.DojoId).SingleOrDefault();
            return View(theNinja);
        }
        [HttpGet]
        [Route("/Dojo/{dojo_id}")]
        public IActionResult ShowDojo(int dojo_id)
        {
            Dojo theDojo = _context.Dojos.Include(d => d.Ninjas).Where(d => d.Id == dojo_id).SingleOrDefault();
            ViewBag.RogueNinjas = _context.Ninjas.Where(n => n.DojoId == 2).ToList();
            return View(theDojo);
        }
        [HttpGet]
        [Route("/remove/{ninja_id}/{model_id}")]
        public IActionResult RemoveNinja(int ninja_id, int model_id)
        {
            Ninja NinjaToBeRemoved = _context.Ninjas.SingleOrDefault(n => n.Id == ninja_id);
            NinjaToBeRemoved.DojoId = 2;
            _context.SaveChanges();
            return Redirect($"/Dojo/{model_id}");
        }
        [HttpGet]
        [Route("/recruit/{ninja_id}/{dojo_id}")]
        public IActionResult RecruitNinja(int ninja_id, int dojo_id)
        {
            Ninja NinjaToBeRecruited = _context.Ninjas.SingleOrDefault(n => n.Id == ninja_id);
            NinjaToBeRecruited.DojoId = dojo_id;
            _context.SaveChanges();
            return Redirect($"/Dojo/{dojo_id}");
        }
        public void SetTheBag()
        {
            ViewBag.AllNinjas = _context.Ninjas.Include(n => n.Dojo).ToList();
            ViewBag.AllDojos = _context.Dojos.ToList();
        }
    }
}
