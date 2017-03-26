using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Cars.Domain.Identity;

namespace Cars.Domain.Identity
{
    public class EFDBIdentity : IdentityDbContext<User>
    {
        public EFDBIdentity() : base("EFDbContext") { }

        public static EFDBIdentity Create()
        {
            return new EFDBIdentity();
        }
    }
}
