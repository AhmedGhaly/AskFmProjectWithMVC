using AskFmProjectWithMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AskFmProjectWithMVC.Controllers
{
    public class QuestionController : Controller
    {

        public IActionResult index()
        {
            int user_id = int.Parse(Request.Cookies["user_id"]);
            using (AskContext context =  new AskContext())
            {

                List<Question> questions = context.questions.Where(q => q.answer == null && q.user_who_answer_id == user_id).Include(t => t.user_who_ask).ToList();
                return View(questions);
            }
        }

    }
}
