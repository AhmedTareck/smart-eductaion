using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Participations
    {
        public long ConversationId { get; set; }
        public long RecivedBy { get; set; }
        public short Status { get; set; }
        public DateTime? CreatedOn { get; set; }
    
        public long? SentBy { get; set; }
        public bool? IsDelete { get; set; }
   



        public Conversations Conversation { get; set; }
        public Users User { get; set; }
    }
}
