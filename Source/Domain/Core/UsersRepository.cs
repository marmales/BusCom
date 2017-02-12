
using System;
using System.Collections.Generic;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Core
{
    public class UsersRepository : IUsersRepository
    {
        private BuscomContext _context = new BuscomContext();

        public IEnumerable<User> EveryUser { get { return _context.Users; } }
        public IProjectRepository EveryProject { get; set; }
        public UsersRepository()
        {
            EveryProject = new ProjectRepository(_context);
        }
    }
}
