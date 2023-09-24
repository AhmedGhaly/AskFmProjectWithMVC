using AskFmProjectWithMVC.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AskFmProjectWithMVC.ViewModel
{
    public class UserWithFollowingAnswerViewModel
    {
        public int id { get; set; }

        public string username { get; set; }

        public string? image { get; set; }
        public string? bio { get; set; }

        public int followers { get; set; }

        public int following { get; set; }

        public bool ifFollow { get; set; }


        //public virtual List<Question>? questions { get; set; } = new List<Question>();
        public virtual List<Answer>? FollowingAns { get; set; } = new List<Answer>();

        //public virtual List<Follow>? following { get; set; } = new List<Follow>();
        //public virtual List<Follow>? follower { get; set; } = new List<Follow>();

    }
}
