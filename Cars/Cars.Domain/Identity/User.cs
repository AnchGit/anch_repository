using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Cars.Domain.Identity
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a surname")]
        public string Surname { get; set; }
    }
}
