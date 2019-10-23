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
            Participations = new HashSet<Participations>();
        }

        public long ConversationId { get; set; }
        public string Body { get; set; }
        public long? Creator { get; set; }
        public bool? IsGroup { get; set; }
        public string LastSubject { get; set; }
        public string Priolti { get; set; }
        public string Subject { get; set; }
        public DateTime? TimeStamp { get; set; }
        public long MessageTypeId { get; set; }

        public Conversations Conversation { get; set; }
        public Users CreatorNavigation { get; set; }
        public MessageType MessageType { get; set; }
        public Conversations InverseConversation { get; set; }
        public ICollection<Attachments> Attachments { get; set; }
        public ICollection<Messages> Messages { get; set; }
        public ICollection<Participations> Participations { get; set; }
    }
}
