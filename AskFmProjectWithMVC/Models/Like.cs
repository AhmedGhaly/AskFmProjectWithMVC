using System.ComponentModel.DataAnnotations.Schema;

namespace AskFmProjectWithMVC.Models
{
    public class Like
    {
        public int id { get; set; }


        [ForeignKey("user")]
        public int user_id { get; set; }

        public virtual User user { get; set; }

        [ForeignKey("answer")]
        public int answer_id { get; set; }

        public virtual Answer answer { get; set; }
    }
}
