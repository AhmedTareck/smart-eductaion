using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Participations
    {
        public long ParticipationsId { get; set; }
        public long ConversationId { get; set; }
        public long RecivedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? IsDelete { get; set; }
        public long SentBy { get; set; }
        public short Status { get; set; }
        public long? DeletedBy { get; set; }

        public Conversations Conversation { get; set; }
        public Users DeletedByNavigation { get; set; }
        public Users RecivedByNavigation { get; set; }
        public Users SentByNavigation { get; set; }
    }
}
