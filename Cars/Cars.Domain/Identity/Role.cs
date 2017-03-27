using Microsoft.AspNet.Identity.EntityFramework;

namespace Cars.Domain.Identity
{
    public class Role : IdentityRole
    {
        public Role() { }

        public string Description { get; set; }
    }
}
