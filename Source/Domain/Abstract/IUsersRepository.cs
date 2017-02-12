
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Abstract
{
    public interface IUsersRepository
    {
        IProjectRepository EveryProject { get; set; }
        IEnumerable<User> EveryUser { get; }
    }
}
