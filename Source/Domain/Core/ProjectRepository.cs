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
        private BuscomContext DBcontext;

        public IEnumerable<Project> projects { get { return DBcontext.Projects; }  }
        public ProjectRepository(BuscomContext contextParam)
        {
            DBcontext = contextParam;
        }

        public bool AddProject(Project project)
        {
            project.ChatRooms.Add(new ChatRoom
            {
                ChatName = "general",
                Description = "For general purpose",
                Users = new List<User> { project.Admin }
            });
    
            DBcontext.Projects.Add(project);
            int rowAffected = DBcontext.SaveChanges();

            return rowAffected > 0 ? true : false;
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
