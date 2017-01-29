using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Core
{
    public class ChatRepository : IChatRepository
    {
        private BuscomContext context = new BuscomContext();
        private Project currentProject;

        public ChatRepository(Project project)
        {
            currentProject = project;
        }
        public IEnumerable<ChatRoom> channels { get { return context.ChatRooms.Where(x => x.Project.ProjectId == currentProject.ProjectId); } }
    }
}
