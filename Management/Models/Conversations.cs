﻿using System;
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
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsGroup { get; set; }
        public long? MessageTypeId { get; set; }
        public string Priolti { get; set; }
        public short SentType { get; set; }
        public string Subject { get; set; }

        public Users CreatedByNavigation { get; set; }
        public MessageType MessageType { get; set; }
        public ICollection<Attachments> Attachments { get; set; }
        public ICollection<Messages> Messages { get; set; }
        public ICollection<Participations> Participations { get; set; }
    }
}
