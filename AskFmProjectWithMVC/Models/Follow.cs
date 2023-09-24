using System.ComponentModel.DataAnnotations.Schema;

namespace AskFmProjectWithMVC.Models
{
    public class Follow
    {
        public int follower_user_id { get; set; }

        public int following_user_id { get; set; }

        public virtual User follower_user { get; set; }
        public virtual User following_user { get; set; }
    }
}
