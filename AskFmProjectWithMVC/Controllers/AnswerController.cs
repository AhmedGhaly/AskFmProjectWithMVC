using AskFmProjectWithMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AskFmProjectWithMVC.Controllers
{
    public class AnswerController: Controller
    {

        public IActionResult answerQuestion(int question_id, string answer_text) {
            using(AskContext context = new AskContext())
            {
                Question question = context.questions.Find(question_id);
                if(question is not null)
                {
                    Answer answer = new Answer() {
                        answer_text = answer_text,
                        question_id = question_id,
                        post_date = DateTime.Now,
                        user_id = int.Parse(Request.Cookies["user_id"]),
                        
                    };
                    question.answer = answer;
                    context.SaveChanges();
                    return Json(true);
                }
            }
            return Json(false);
        }

        public IActionResult deleteAnswer(int id)
        {
            using(AskContext context = new AskContext())
            {
                Answer answer = context.answers.Find(id);
                Question question = context.questions.Where(t => t.answer.id == id).FirstOrDefault();
                if(answer is not null)
                {
                    context.answers.Remove(answer);
                    context.questions.Remove(question);
                    context.SaveChanges();
                    return Json(true);
                }
                return Json(false);
            }
        }

        public IActionResult editAnswer(int id, string answerText)
        {
            using(AskContext context = new AskContext())
            {
                Answer answer = context.answers.Find(id);
                if(answer is not null && answerText.Length >= 3 && answerText.Length <= 200)
                {
                    answer.answer_text = answerText;
                    context.answers.Update(answer);
                    context.SaveChanges();
                    return Json(true);
                }
            }
            return Json(false);
        }
    }
}
