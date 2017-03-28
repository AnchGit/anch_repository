using System.ComponentModel.DataAnnotations;

namespace Cars.WebUI.Models
{
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords aren't the same")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}