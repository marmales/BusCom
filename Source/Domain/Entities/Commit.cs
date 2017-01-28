using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Commit
    {
        public Commit()
        {
            Files = new List<File>();
        }
        public int CommitId { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        
        public virtual ICollection<File> Files { get; set; }
    }
}
