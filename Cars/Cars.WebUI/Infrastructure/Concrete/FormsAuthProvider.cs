using System;
using System.Web.Security;
using Cars.WebUI.Infrastructure.Abstract;

namespace Cars.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string login, string password)
        {
            bool result = FormsAuthentication.Authenticate(login, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(login, false);
            }
            return result;
        }
    }
}