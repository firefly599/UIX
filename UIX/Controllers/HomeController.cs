using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Runtime.InteropServices;

namespace UIX.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LogInUser()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];

            DataManager.Login(username, password);
            return RedirectToAction("Home");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult SignUpUser()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            string email = Request.Form["email"];
            string firstname = Request.Form["firstname"];
            string lastname = Request.Form["lastname"];

            DataManager.SignUp(username, password, email, firstname, lastname);

            return RedirectToAction("Index");
        }

        public IActionResult Meeting()
        {
            return View();
        }

        public IActionResult CreateMeeting()
        {
            ViewData["staff"] = Request.Form["staff"];
            return View();
        }

        public IActionResult SaveMeeting()
        {
            string student = DataManager.activeUser.Name;
            string staff = Request.Form["staff"];
            int day = Convert.ToInt32(Request.Form["day"]);
            int month = Convert.ToInt32(Request.Form["month"]);
            int hour = Convert.ToInt32(Request.Form["hour"]);
            int minute = Convert.ToInt32(Request.Form["minute"]);
            DataManager.CreateMeeting(student, staff, day, month, hour, minute);

            return RedirectToAction("Meeting");
        }

        public IActionResult Messages()
        {
            return View();
        }

        public IActionResult SendMsg()
        {
            int id = Convert.ToInt32(Request.Form["id"]);
            ViewData["id"] = id;
            return View();
        }

        public IActionResult SaveMsg()
        {
            int id = Convert.ToInt32(Request.Form["id"]);
            string user = DataManager.activeUser.Name;
            string msg = Request.Form["msg"];
            DataManager.messages[id].AddMsg(msg, user);

            return RedirectToAction("Messages");
        }

        public IActionResult NewMsg()
        {
            return View();
        }

        public IActionResult CreateMsg()
        {
            string username = DataManager.activeUser.Name;
            string text = Request.Form["msg"];
            string staff = Request.Form["staff"];
            DataManager.CreateMessage(username, staff, text);
            return RedirectToAction("Messages");
        }

        public IActionResult Profile()
        {
            return RedirectToAction("Home");
        }

        public IActionResult Logout()
        {
            DataManager.Logout();
            return RedirectToAction("Index");
        }
    }
}
