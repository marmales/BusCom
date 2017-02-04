using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            AdminProjects = new List<Project>();
            Projects = new List<Project>();
            ChatRooms = new List<ChatRoom>();
            SendedMessages = new List<Message>();
        }

        public virtual ICollection<Project> AdminProjects { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<ChatRoom> ChatRooms { get; set; }
        public virtual ICollection<Message> SendedMessages { get; set; }
    }
}
