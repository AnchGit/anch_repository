using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Cars.Domain.Identity
{
    public class RoleManager : RoleManager<Role>
    {
        public RoleManager(RoleStore<Role> store) : base(store) { }

        public static RoleManager Create(IdentityFactoryOptions<RoleManager> options, IOwinContext context)
        {
            return new RoleManager(new RoleStore<Role>(context.Get<EFDBIdentity>()));
        }
    }
}
