using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using login_registration.Models;
using Microsoft.AspNetCore.Identity;

namespace login_registration.Controllers
{
    public class UserController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // can you think of a way to do this w/o using viewbag?
            // perhaps have a model class for RegViewModel and LoginViewModel references?
            RegisterViewModel userModel = new RegisterViewModel();
            ViewBag.LoginObj = new LoginViewModel();
            return View(userModel);
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel registerUser)
        {
            string checkEmail = $"SELECT id FROM Users WHERE email='{registerUser.email}'";
            if (DbConnector.Query(checkEmail).Count > 0)
            {
                ModelState.AddModelError("email", "Email already in use");
                // return View("Index", registerUser);
            }
            if(ModelState.IsValid)
            {
                PasswordHasher<RegisterViewModel> hasher = new PasswordHasher<RegisterViewModel>();
                string hashed = hasher.HashPassword(registerUser, registerUser.password);
                User newUser = new User{
                    first_name = registerUser.first_name,
                    last_name = registerUser.last_name,
                    email = registerUser.email,
                    password = hashed,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };
                string query = $"INSERT INTO Users (first_name, last_name, email, password, created_at, updated_at) VALUES ( '{newUser.first_name}', '{newUser.last_name}', '{newUser.email}', '{newUser.password}', '{newUser.created_at}', '{newUser.updated_at}')";
                DbConnector.Execute(query);
                string getUser = $"SELECT id FROM Users WHERE email='{registerUser.email}'";
                var users = DbConnector.Query(getUser);
                HttpContext.Session.SetInt32("id", (int)users[0]["id"]);
                return RedirectToAction("Index", "Wall");
            }
            else
            {
                return View("Index", registerUser);
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel loggedUser)
        {
            if (ModelState.IsValid)
            {
                string checkEmail = $"SELECT id, password FROM Users WHERE email='{loggedUser.loginEmail}'";
                List<Dictionary<string,object>> users = DbConnector.Query(checkEmail);
                if (users.Count > 0)
                {
                    PasswordHasher<LoginViewModel> hasher = new PasswordHasher<LoginViewModel>();
                    if(hasher.VerifyHashedPassword(loggedUser, (string)users[0]["password"], loggedUser.loginPassword) == 0)
                    {
                        ModelState.AddModelError("loginEmail", "Username or password is incorrect");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("id", (int)users[0]["id"]);
                        return RedirectToAction("Index", "Wall");
                    }
                }
                else
                {
                    ModelState.AddModelError("loginEmail", "Username or password is incorrect");
                }

            }

            RegisterViewModel userModel = new RegisterViewModel();
            ViewBag.LoginObj = loggedUser;
            return View("Index", userModel);
        }

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            return View();
        }
    }
}

