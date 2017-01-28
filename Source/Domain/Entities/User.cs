using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Domain.Entities
{
    public class User
    {
        public User()
        {
            AdminProjects = new List<Project>();
            Projects = new List<Project>();
            ChatRooms = new List<ChatRoom>();
        }

        public int UserId { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        protected virtual string HashedPassword { get; set; }
        public static readonly Expression<Func<User, string>> HashedExpression = p => p.HashedPassword;

        [NotMapped]
        public string Password
        {
            get { return HashedPassword; }
            set
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(value);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                HashedPassword = System.Text.Encoding.ASCII.GetString(data);
            }
        }

        public virtual ICollection<Project> AdminProjects { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<ChatRoom> ChatRooms { get; set; }
        public virtual ICollection<Message> SendedMessages { get; set; }
    }
}
