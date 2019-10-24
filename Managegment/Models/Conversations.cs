using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Conversations
    {
        public Conversations()
        {
            Attachments = new HashSet<Attachments>();
            Messages = new HashSet<Messages>();
        }

        public long ConversationId { get; set; }
        public long? AdTypeId { get; set; }
        public string Body { get; set; }
        public long? CreatedBy { get; set; }
        public bool? IsGroup { get; set; }
        public string Priolti { get; set; }
        public string Subject { get; set; }
        public DateTime? CreatedOn { get; set; }

        public AdTypes AdType { get; set; }
        public Users CreatedByNavigation { get; set; }
        public Participations Participations { get; set; }
        public ICollection<Attachments> Attachments { get; set; }
        public ICollection<Messages> Messages { get; set; }
    }
}
