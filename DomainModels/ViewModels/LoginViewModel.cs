using System.ComponentModel.DataAnnotations;
namespace DomainModels.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        public string Password { get; set; }
    }
}
