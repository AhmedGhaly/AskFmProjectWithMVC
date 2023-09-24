using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AskFmProjectWithMVC.Models
{
    public class Question
    {
        public int id { get; set; }

        public string question_text { get; set; }

        public DateTime? post_date { get; set; } = DateTime.Now;

        public virtual Answer? answer { get; set; }

        [ForeignKey("user_who_ask")]
        public int? user_who_ask_id { get; set; }
        
        public virtual User? user_who_ask { get; set; }



        [ForeignKey("user_who_answer")]
        public int user_who_answer_id { get; set; }

        public virtual User? user_who_answer { get; set; }

    }
}
