using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class File
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        [MaxLength(4)]
        public string Extension { get; set; }

        public int CommitId { get; set; }
        public Commit Commit { get; set; }


        public CommitChange CommitChange { get; set; }
    }
}
