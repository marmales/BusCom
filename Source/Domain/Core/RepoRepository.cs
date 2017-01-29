using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Core
{
    public class RepoRepository : IRepoRepository
    {
        private BuscomContext context = new BuscomContext();
        private Project project;

        public RepoRepository(Project project)
        {
            this.project = project;
        }

        public IEnumerable<Commit> commits { get { return context.Commits.Where(x => x.Project.ProjectId == project.ProjectId); } }

        public bool AddCommit(Commit commit)
        {
            throw new NotImplementedException();
        }
    }
}
