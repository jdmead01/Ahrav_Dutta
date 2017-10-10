using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using form_submission.Models;
using DbConnection;

namespace form_submission.Controllers
{
    public class UsersController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            UserViewModel userModel = new UserViewModel();
            return View(userModel);
        }

        [HttpPost]
        [Route("submit_info")]
        public IActionResult SubmitInfo(UserViewModel newUserViewModel)
        {
            if(ModelState.IsValid)
            {
                User newUser = new User{
                    First_name = newUserViewModel.First_name,
                    Last_name = newUserViewModel.Last_name,
                    Age = newUserViewModel.Age,
                    Email = newUserViewModel.Email,
                    Password = newUserViewModel.Password,
                    Created_at = DateTime.Now,
                    Updated_at = DateTime.Now
                };
                string query = $"INSERT INTO Users (First_name, Last_name, Age, Email, Password, Created_at, Updated_at) VALUES('{newUser.First_name}', '{newUser.Last_name}', '{newUser.Age}','{newUser.Email}', '{newUser.Password}', NOW(), NOW())";
                DbConnector.Execute(query);
                return RedirectToAction("Success");
            }
            else
            {
                return View("Index", newUserViewModel);
            }
        }

        [HttpGet]
        [Route("Success")]
        public IActionResult Success()
        {
            string query = "SELECT * FROM Users";
            ViewBag.AllUsers = DbConnector.Query(query);
            return View();
        }
            
    }
}
