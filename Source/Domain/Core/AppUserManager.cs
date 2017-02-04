using Domain.Abstract;
using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Domain.Core
{
    public class AppUserManager : UserManager<User>
    {
        public AppUserManager(IUserStore<User> store)
            : base(store) { }
        
        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            BuscomContext db = context.Get<BuscomContext>();
            AppUserManager manager = new AppUserManager(new UserStore<User>(db));

            return manager;
        }
    }
}
