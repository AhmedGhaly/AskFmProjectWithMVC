using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AskFmProjectWithMVC.ViewModel
{
    public class LoginViewModel
    {
        [RegularExpression(@"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$", ErrorMessage = "invlaid email")]
        [Display(Name = "E-Mail")]
        [Remote("checkEmail", "account", AdditionalFields = "id", ErrorMessage = "this email is not founded")]
        public string email { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "your password is weak")]
        [DataType(dataType: DataType.Password)]
        public string password { get; set; }

    }
}
