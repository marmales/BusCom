using System;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IProjectRepository
    {
        IEnumerable<Project> projects { get; }

        bool AddProject(Project project);

        IChatRepository getChannels(Project project);
        IRepoRepository getCommits(Project project);
    }
}
