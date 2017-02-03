using BusCom.Infrastructure.Abstract;
using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BusCom.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        private IUserRepository _users;
        public FormsAuthProvider(IUserRepository usersParam)
        {
            _users = usersParam;
        }
        public bool Authenticate(string username, string password)
        {
            bool result = _users.users.SingleOrDefault(c => c.Login == username && c.Password == password) != null;

            if (result)
                FormsAuthentication.SetAuthCookie(username, false);
            
            return result;
        }
    }
}