﻿using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Attachments
    {
        public long AttachmentId { get; set; }
        public byte[] ContentFile { get; set; }
        public long? ConversationId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }

        public Conversations Conversation { get; set; }
        public Users CreatedByNavigation { get; set; }
    }
}
