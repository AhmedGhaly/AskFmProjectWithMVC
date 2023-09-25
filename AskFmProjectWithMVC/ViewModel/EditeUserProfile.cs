using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AskFmProjectWithMVC.ViewModel
{
    public class EditeUserProfile
    {
        public int id { get; set; }

        [MaxLength(20, ErrorMessage = "username must be less than 20 charchter")]
        [Display(Name = "user name")]
        [Required]
        [MinLength(5, ErrorMessage = "username must be greater than 5 charchter")]
        public string username { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$", ErrorMessage = "invlaid email")]
        [Display(Name = "E-Mail")]
        [Remote("confirmEmail", "account", AdditionalFields = "id", ErrorMessage = "this email is already exist")]
        public string email { get; set; }

        public string? bio { get; set; }


    }
}
