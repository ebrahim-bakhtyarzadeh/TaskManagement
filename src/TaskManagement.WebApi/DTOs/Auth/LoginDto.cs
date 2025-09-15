using System.ComponentModel.DataAnnotations;

namespace TaskManagement.WebApi.DTOs.Auth
{
    public class    LoginDto
    {

        public string Email { get; set; }


        [Required(ErrorMessage = "لطقا رمز عبور خود را وارد کنید")]
        public string Password { get; set; }

        [Required(ErrorMessage ="لطفا شماره تماس خود را وارد کنید")]
        public string PhoneNumber { get; set; }

    }
}
