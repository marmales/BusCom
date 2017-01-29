using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class ProjectRepository : IProjectRepository
    {
        private BuscomContext DBcontext = new BuscomContext();

        public IEnumerable<Project> projects { get { return DBcontext.Projects; }  }

        public ProjectRepository()
        {
        }

        public bool AddProject(Project project)
        {
            throw new NotImplementedException();
        }

        public IChatRepository getChannels(Project project)
        {
            if (projects.Select(x => x.ProjectId).Contains(project.ProjectId))
                return new ChatRepository(project);
            else
                throw new KeyNotFoundException("No such Project in database");
        }

        public IRepoRepository getCommits(Project project)
        {
            if (projects.Select(x => x.ProjectId).Contains(project.ProjectId))
                return new RepoRepository(project);
            else
                throw new KeyNotFoundException("No such Project in database");
        }
    }
}
