using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Project
    {
        public Project()
        {
            Users = new List<User>();
            Commits = new List<Commit>();
        }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        
        public string AdminId { get; set; }
        [ForeignKey("AdminId")]
        public virtual User Admin { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Commit> Commits { get; set; }
    }
}
