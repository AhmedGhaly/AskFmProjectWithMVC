using AskFmProjectWithMVC.Models;
using AskFmProjectWithMVC.ViewModel;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AskFmProjectWithMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult index() 
        { 
            int? user_id = int.Parse(Request.Cookies["user_id"]);

            UserWithFollowingAnswerViewModel myFollowerAnswer;

            using (AskContext context = new AskContext())
            {
                User user = context.users
                    .Include(t => t.following).ThenInclude(t => t.follower_user)
                    .ThenInclude(t => t.answers).ThenInclude(t => t.question).ThenInclude(t => t.user_who_ask)
                    .FirstOrDefault(t => t.id == user_id);

                myFollowerAnswer = new UserWithFollowingAnswerViewModel() { id = user.id, bio = user.bio, image = user.image, username = user.username };


                foreach (var item in user.following)
                {
                    foreach (var ans in item.follower_user.answers)
                    {
                        string input = ans.id.ToString();
                        if (amIReact(ans.id))
                            ViewData[input] = true;
                        else
                            ViewData[input] = false;
                        myFollowerAnswer.FollowingAns.Add(ans);
                    }
                }

                myFollowerAnswer.FollowingAns = myFollowerAnswer.FollowingAns.OrderBy(t => t.post_date).ToList();


            }
            return View(myFollowerAnswer); 
        }
        bool amIReact(int answer_id)
        {
            int user_id = int.Parse(Request.Cookies["user_id"]);
            using (AskContext context = new AskContext())
            {
                Like like = context.likes.Where(l => l.answer_id == answer_id && l.user_id == user_id).FirstOrDefault();
                if (like is not null)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
