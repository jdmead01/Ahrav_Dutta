using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Restauranter.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Restauranter.Controllers
{
    public class ReviewController : Controller
    {
        private ReviewContext _context;
        public ReviewController(ReviewContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            Reviews newReview = new Reviews();
            return View("Index");
        }
        [HttpPost]
        [Route("add_review")]
        public IActionResult Add_Review(newReview newReview)
        {
            if(ModelState.IsValid)
            {
                Reviews createReview = new Reviews {
                    ReviewerName = newReview.ReviewerName,
                    RestaurantName = newReview.RestaurantName,
                    Review = newReview.Review,
                    DateOfVisit = newReview.DateOfVisit,
                    Rating = newReview.Rating
                };
                _context.Add(createReview);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
            return View("Index", newReview);
        }
        // GET: /Home/
        [HttpGet]
        [Route("/reviews")]
        public IActionResult Reviews()
        {
            ViewBag.allReviews = _context.Reviews.OrderByDescending(review => review.DateOfVisit);
            return View();
        }
    }
}
