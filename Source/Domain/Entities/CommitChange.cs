using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
    public class CommitChange
    {
        [Key]
        public int ChangeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}
