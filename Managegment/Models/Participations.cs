using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Participations
    {
        public long ConversationId { get; set; }
        public long? SentBy { get; set; }
        public long? ReceivedBy { get; set; }
        public short? Status { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsDelete { get; set; }

        public Conversations Conversation { get; set; }
        public Users ReceivedByNavigation { get; set; }
        public Users SentByNavigation { get; set; }
    }
}
