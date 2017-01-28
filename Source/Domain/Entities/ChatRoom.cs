using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ChatRoom
    {
        public ChatRoom()
        {
            Users = new List<User>();
            ChatMessages = new List<Message>();
        }
        [Key]
        public int ChatId { get; set; }
        public string ChatName { get; set; }
        public string Description { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Message> ChatMessages { get; set; }
    }
}
