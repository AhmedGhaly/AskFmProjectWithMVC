using AskFmProjectWithMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskFmProjectWithMVC.Controllers
{
    public class FollowController : Controller
    {
        public IActionResult Index()
        {
            using(AskContext context = new AskContext())
            {
                User users = context.users.
                    Include(r => r.following)
                    .ThenInclude(r => r.follower_user)
                    .Where(r => r.id == int.Parse(Request.Cookies["user_id"]))
                    .FirstOrDefault();

                return View(users.following);
            }
        }

        public void addFollower(Follow ifExits)
        {
            using (AskContext context = new AskContext())
            {
                    context.follows.Add(ifExits);
                    context.SaveChanges();
            }
        }

        public void removeFollower(Follow ifExits)
        {
           
            using(AskContext context = new AskContext())
            {
                context.follows.Remove(ifExits);
                context.SaveChanges();

            }

        }

        public IActionResult addOrRemoveFollower(int followingId)
        {
            Follow follow = new Follow();
            follow.follower_user_id = followingId;
            follow.following_user_id = int.Parse(Request.Cookies["user_id"]);
            using (AskContext context = new AskContext())
            {
                Follow ifExits = context.follows.Where(t => t.following_user_id == follow.following_user_id && t.follower_user_id == follow.follower_user_id).FirstOrDefault();
                if (ifExits is not null)
                {
                    removeFollower(ifExits);
                }else
                    addFollower(follow);
            }
            return Json(true);
        }
    }
}
