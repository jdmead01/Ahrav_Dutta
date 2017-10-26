using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using wedding_planner.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace wedding_planner.Controllers
{
    public class WeddingController : Controller
    {
        private WeddingContext _context;
        private User ActiveUser
        {
            get {return _context.Users.Where(u => u.UserId ==HttpContext.Session.GetInt32("id")).FirstOrDefault();}
        }
        public WeddingController(WeddingContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("id") == null)
            {
                return RedirectToAction("Index", "User");
            }
            return View(InitializeDashboard());
        }
        [HttpGet]
        [Route("NewWedding")]
        public IActionResult NewWedding()
        {
            return View();
        }
        [HttpPost]
        [Route("AddWedding")]
        public IActionResult AddWedding(NewWedding newWedding)
        {
            if(ModelState.IsValid)
            {
                Wedding theWedding = new Wedding()
                {
                    Groom = newWedding.Groom,
                    Bride = newWedding.Bride,
                    Date = newWedding.Date,
                    Address = newWedding.Address,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UserId = ActiveUser.UserId,
                };
                _context.Add(theWedding);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("NewWedding");
        }
        [HttpGet]
        [Route("/Wedding/{wedding_id}")]
        public IActionResult ShowWeddingInfo(int wedding_id)
        {
            Wedding theWedding = _context.Weddings.Include(w => w.Guests).ThenInclude(g => g.InvitedUser).SingleOrDefault(w => w.WeddingId == wedding_id);
            return View(theWedding);
        }
        [HttpGet]
        [Route("RSVP/{wedding_id}")]
        public IActionResult JoinWedding(int wedding_id)
        {
            User currentUser = _context.Users.SingleOrDefault(u => u.UserId == ActiveUser.UserId);
            Wedding currentWedding = _context.Weddings.Include(w => w.Guests).ThenInclude(g => g.InvitedUser).SingleOrDefault(w => w.WeddingId == wedding_id);
            Invite newInvite = new Invite
            {
                UserId = currentUser.UserId,
                InvitedUser = currentUser,
                WeddingId = currentWedding.WeddingId,
                Wedding = currentWedding
            };
            currentWedding.Guests.Add(newInvite);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Decline/{wedding_id}")]
        public IActionResult LeaveWedding(int wedding_id)
        {
            User currentUser = _context.Users.SingleOrDefault(u => u.UserId == ActiveUser.UserId);
            Wedding currentWedding = _context.Weddings.Include(w => w.Guests).ThenInclude(g => g.InvitedUser).SingleOrDefault(w => w.WeddingId == wedding_id);
            Invite currentInvite = _context.Invites.SingleOrDefault(i => i.UserId == ActiveUser.UserId && i.WeddingId == wedding_id);
            currentWedding.Guests.Remove(currentInvite);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("Delete/{wedding_id}")]
        public IActionResult DeleteWedding(int wedding_id)
        {
            Wedding theWedding = _context.Weddings.SingleOrDefault(w => w.WeddingId == wedding_id);
            _context.Weddings.Remove(theWedding);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public DashboardModels InitializeDashboard()
        {
            List<Wedding> userJoined = _context.Invites.Where(i => i.UserId == ActiveUser.UserId).Select(u => u.Wedding).ToList();
            List<Wedding> notJoined = _context.Weddings.Except(userJoined).ToList();
            return new DashboardModels
            {
                allWeddings = _context.Weddings.Include(w => w.Guests).ToList(),
                User = ActiveUser,
                JoinedWeddings = userJoined,
                NotJoinedWeddings = notJoined
            };
        }
    }
}