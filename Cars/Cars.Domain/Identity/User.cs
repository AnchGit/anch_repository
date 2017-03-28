using Cars.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Cars.Domain.Identity
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a surname")]
        public string Surname { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
