using System;
using System.Globalization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using login_registration.Models;
using Microsoft.AspNetCore.Identity;

namespace login_registration.Controllers
{
    public class WallController : Controller
    {
        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Index()
        {
            string messageQuery = "SELECT Messages.id AS message_id, Messages.message AS user_message, Users.first_name AS user_first, Users.last_name AS user_last, Messages.created_at AS message_create FROM Messages JOIN Users ON Messages.user_id = Users.id";
            var allMessages = DbConnector.Query(messageQuery);
            string commentQuery = "SELECT Comments.comment AS comment_comment, Comments.message_id AS comment_message_id, Users.first_name AS comment_first, Users.last_name AS comment_last, Comments.created_at As comment_create FROM Comments JOIN Messages ON Messages.id = Comments.message_id JOIN Users ON Users.id = Comments.user_id;";
            var allComments = DbConnector.Query(commentQuery);
            ViewBag.allComments = allComments;
            ViewBag.allMessages = allMessages;
            Message newMessage = new Message();
            ViewBag.CommentObj = new Comment();
            return View(newMessage);
        }

        [HttpPost]
        [Route("Messages")]
        public IActionResult CreateMessage(Message newMessage)
        {
            if(ModelState.IsValid)
            {
                string query = $"INSERT INTO Messages (message, user_id, created_at, updated_at) VALUES ( '{newMessage.message}', {(int)HttpContext.Session.GetInt32("id")}, NOW(), NOW() )";
                DbConnector.Execute(query);
                return RedirectToAction("Index");
            }
            return View("Index", newMessage);
        }

        [HttpPost]
        [Route("Comment")]
        public IActionResult CreateComment(Comment newComment)
        {
            if(ModelState.IsValid)
            {
                string query = $"INSERT INTO Comments (comment, user_id, message_id, created_at, updated_at) VALUES ( '{newComment.comment}', {(int)HttpContext.Session.GetInt32("id")}, NOW(), NOW() )";
                DbConnector.Execute(query);
                return RedirectToAction("Index");
            }
            Message newMessage = new Message();
            ViewBag.CommentObj = newComment;
            return View("Index", newMessage);
        }
    }
}