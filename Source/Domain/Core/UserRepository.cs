using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Core
{
    public class UserRepository : IUserRepository
    {
        private BuscomContext context = new BuscomContext();

        public IEnumerable<User> users { get { return context.Users; } }
    }
}
