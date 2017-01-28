using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Attachment
    {
        [ForeignKey("Message")]
        public int AttachmentId { get; set; }
        public byte[] FileContent { get; set; }
        public string Extension { get; set; }
        public string Name { get; set; }

        public virtual Message Message { get; set; }
    }
}
