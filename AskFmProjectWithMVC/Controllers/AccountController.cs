using AskFmProjectWithMVC.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace AskFmProjectWithMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult signup(User user) { 
           // if(user)

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult login(User user)
        {
            using(AskContext context = new AskContext())
            {
                var myUser = context.users.Select(t => new {t.id, t.email,t.password,t.username,t.image}).FirstOrDefault(t => t.email == user.email);
                if(myUser is not null) {
                    if(myUser.password == user.password)
                    {
                        //HttpContext.Session.SetInt32("user_id", myUser.id);
                        CookieOptions s= new CookieOptions();
                        s.Expires = DateTimeOffset.Now.AddDays(10);
                        Response.Cookies.Append("user_id", myUser.id.ToString(), s);
                        Response.Cookies.Append("user_image", myUser.image, s);
                        Response.Cookies.Append("user_name", myUser.username, s);
                        
                        return RedirectToAction("index", "home");
                    }
                }
                return View("index", user);
            }
        }

        public IActionResult Logout()
        {
            Response.Cookies.Append("user_id", "");
            return RedirectToAction("Index");

        }

        public bool confirmPass (string confirmPass, string password)
        {
            return confirmPass == password;
        }

        public bool confirmEmail(string email, int id)
        {
            using (AskContext context = new AskContext())
            {
                User user = context.users.Where(t => t.email == email && t.id != id).FirstOrDefault();
                if (user is null)
                    return true;
                return false;
            }
        }
    }
}
