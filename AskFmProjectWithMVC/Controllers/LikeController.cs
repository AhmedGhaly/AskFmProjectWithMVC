using AskFmProjectWithMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AskFmProjectWithMVC.Controllers
{
    public class LikeController : Controller
    {


        public IActionResult addLike(int answerId)
        {
            int user_id = int.Parse(Request.Cookies["user_id"]);
            using (AskContext context = new AskContext()) {
                Answer ans = context.answers.Find(answerId);
                Like check = context.likes.Where(r => r.user_id == user_id).FirstOrDefault();
                Like like = new Like()
                {
                    answer_id = answerId,
                    user_id = user_id

                };
                if (ans != null && check is null)
                {
                    ans.likes.Add(like);
                    ans.likeCount++;
                    context.SaveChanges();
                    return Json(true);
                }

                return Json(false);
            }
        }


        public IActionResult removeLike(int answerId)
        {
            int user_id = int.Parse(Request.Cookies["user_id"]);
            using (AskContext context = new AskContext())
            {
                Answer ans = context.answers.Find(answerId);
                Like check = context.likes.Where(r => r.user_id == user_id).FirstOrDefault();

                if (ans != null && check is not null)
                {
                    ans.likes.Remove(check);
                    ans.likeCount--;
                    context.SaveChanges();
                    return Json(true);
                }

                return Json(false);
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
