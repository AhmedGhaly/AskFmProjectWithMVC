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
                Like check = context.likes.Where(r => r.user_id == user_id && r.answer_id == answerId).FirstOrDefault();
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
                Like check = context.likes.Where(r => r.user_id == user_id && r.answer_id == answerId).FirstOrDefault();

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

        public IActionResult usersWhoLike(int answer_id)
        {
            using (AskContext context = new AskContext())
            {
                return Json(context.likes.Where(r => r.answer_id == answer_id).Select(t => t.user).Select(r => r.username).ToList() );
            }
        }
    }
}

