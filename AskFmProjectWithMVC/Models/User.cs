using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AskFmProjectWithMVC.Models
{
    public class User
    {

        public User()
        {
            question_i_asked = new List<Question>();
            question_i_will_answer = new List<Question>();
            answers = new List<Answer>();
            following = new List<Follow>();
            follower = new List<Follow>();
        }
            
        public int id { get; set; }

        [MaxLength(20, ErrorMessage = "username must be less than 20 charchter")]
        [Display(Name ="user name")]
        [Required]
        [MinLength(5, ErrorMessage ="username must be greater than 5 charchter")]
        public string username { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$", ErrorMessage = "invlaid email")]
        [Display(Name = "E-Mail")]
        //[Remote("confirmEmail", "account", AdditionalFields = "id", ErrorMessage ="this email is already exist")]
        public string email { get; set; }

        [Required]
        [MinLength(3, ErrorMessage ="your password is weak")]
        [DataType(dataType:DataType.Password)]
        public string password { get; set; }


        public bool active { get; set; } = false;

        [NotMapped]
        [DataType(dataType:DataType.Password)]
        [Display(Name ="confirm password")]
        [Remote("confirmPass", "account", AdditionalFields = "password", ErrorMessage ="password not matched")]
        public string confirmPass { get; set; }

        public string? image { get; set; }
        public string? bio { get; set; }



        [InverseProperty("user_who_ask")]
        public virtual List<Question>? question_i_asked { get; set; }

        [InverseProperty("user_who_answer")]
        public virtual List<Question>? question_i_will_answer { get; set; }

        public virtual List<Answer>? answers { get; set; }

        public virtual List<Follow>? following { get; set; }
        public virtual List<Follow>? follower { get; set; }








    }
}
