using AskFmProjectWithMVC.Models;
using AskFmProjectWithMVC.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace AskFmProjectWithMVC.Controllers
{
    public class UserController: Controller
    {
        public IActionResult profile(int id)
        {
            int myUser = int.Parse(Request.Cookies["user_id"]);
            if (id == myUser)
                return RedirectToAction("Index");
            UserWithFollowingAnswerViewModel myuser;
            using (AskContext context = new AskContext())
            {
                User user = context.users.Where(u => u.id == id).AsSplitQuery()
                    .Include(d => d.answers).ThenInclude(y => y.question)
                    .ThenInclude(c => c.user_who_ask).FirstOrDefault();
                Follow iffollow = context.follows.Where(t => t.following_user_id == myUser && t.follower_user_id == user.id).FirstOrDefault();
                myuser = new UserWithFollowingAnswerViewModel()
                { 
                    id = user.id,
                    bio = user.bio, 
                    image = user.image, 
                    username = user.username, 
                    FollowingAns = user.answers.OrderBy(o => o.post_date).ToList(),
                    ifFollow = iffollow is null? true: false 
                };

                myuser.followers = user.follower.Count();
                myuser.following = user.following.Count();

            }

            return View(myuser);
        }

        public IActionResult index()
        {

            int myUser = int.Parse(Request.Cookies["user_id"]);
            UserWithFollowingAnswerViewModel myuser;

            using (AskContext context = new AskContext())
            {
                User user = context.users.Where(u => u.id == myUser).AsSplitQuery()
                    .Include(d => d.answers).ThenInclude(y => y.question)
                    .ThenInclude(c => c.user_who_ask).FirstOrDefault();
                myuser = new UserWithFollowingAnswerViewModel()
                {
                    id = user.id,
                    bio = user.bio,
                    image = user.image,
                    username = user.username,
                    FollowingAns = user.answers.OrderBy(o => o.post_date).ToList(),
                };

                myuser.followers = user.follower.Count();
                myuser.following = user.following.Count();

            }
            return View(myuser);

        }

        public IActionResult ask(int id, string questionText, bool unkown)
        {
            int user_id = int.Parse(Request.Cookies["user_id"]);
                if (questionText.Length >= 3 && questionText.Length <= 200)
                {
                    Question question = new Question()
                    {
                        question_text = questionText,
                        user_who_ask_id = (!unkown) ? user_id: null,
                        user_who_answer_id = id
                    };
                    using (AskContext context = new AskContext()) {
                        context.questions.Add(question);
                        context.SaveChanges();
                    }
                    return Json(true);
                }
            return Json(false);
        }
        public IActionResult editProfile() {
            int user_id = int.Parse(Request.Cookies["user_id"]);
            using (AskContext context = new AskContext())
            {
                EditeUserProfile user = context.users.Where(r => r.id == user_id).Select(t => new EditeUserProfile()
                {
                    id= t.id,
                    username= t.username,
                    email= t.email,
                    bio= t.bio
                }).FirstOrDefault();
                if(user is not null)
                    return View(user);
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult editProfile(EditeUserProfile user)
        {
            if (ModelState.IsValid)
            {
                using (AskContext context = new AskContext())
                {
                    User myUser = context.users.Where(t => t.id == user.id).FirstOrDefault();

                    myUser.email = user.email;
                    myUser.bio = user.bio;
                    myUser.username = user.username;
                    context.SaveChanges();
                }
                    return RedirectToAction("index");
            }
            return RedirectToAction("editProfile", user);
        }


        public async Task<IActionResult>  updatgeImage(IFormFile imageUrl)
        {
            

            if (imageUrl != null && imageUrl.Length > 0)
            {

                var extention = Path.GetExtension(imageUrl.FileName);
                var fileName = Path.GetFileNameWithoutExtension(imageUrl.FileName);
                var imageName = fileName.Replace(" ", "") + Request.Cookies["user_id"] + extention;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", imageName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageUrl.CopyToAsync(fileStream);
                }

                using (AskContext context = new AskContext())
                {
                    User user = context.users.Find(int.Parse(Request.Cookies["user_id"]));

                    string path = @"wwwroot\images\" + user.image;
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                    user.image = imageName;
                    context.SaveChanges();
                }
            }
            return RedirectToAction("index");
        }


        public IActionResult getUserName()
        {
            int user_id = int.Parse(Request.Cookies["user_id"]);
            using (var context = new AskContext())
            {
                User user = context.users.Find(user_id);
                return Json( new { user.image , user.username});
            }
        }
    }
}
