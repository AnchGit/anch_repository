using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Cars.Domain.Identity;

namespace Cars.Domain.Identity
{
    public class UserManager : UserManager<User>
    {
        public UserManager(IUserStore<User> store) : base(store) { }

        public static UserManager Create (IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            EFDBIdentity db = context.Get<EFDBIdentity>();
            UserManager manager = new UserManager(new UserStore<User>(db));
            return manager;
        }

    }
}
