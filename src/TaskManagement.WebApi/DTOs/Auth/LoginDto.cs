using System.ComponentModel.DataAnnotations;

namespace TaskManagement.WebApi.DTOs.Auth
{
    public class LoginDto
    {

        [Required (ErrorMessage = "لطقا ایمیل خود را وارد کنید")] 
        public string Email { get; set; }


        [Required(ErrorMessage = "لطقا ایمیل خود را وارد کنید")]
        public string Password { get; set; }
    }
}
