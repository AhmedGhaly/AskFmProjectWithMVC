using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AskFmProjectWithMVC.Models
{
    public class Answer
    {

        public int id { get; set; }

        public string answer_text { get; set; }
        public int likeCount { get; set; } = 0;


        public DateTime post_date { get; set; }

        [ForeignKey("question")]
        public int question_id { get; set; }

        public virtual Question? question { get; set; }


        [ForeignKey("user")]
        public int user_id { get; set; }

        public virtual User user { get; set; }

        public virtual List<Like> likes { get; set; }

    }
}
