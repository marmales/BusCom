using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public DateTime PostDate { get; set; }

        public int ChatId { get; set; }
        [ForeignKey("ChatId")]
        public virtual ChatRoom ChatRoom { get; set; }

        public virtual User Sender { get; set; } 

        public int AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; }
    }
}
