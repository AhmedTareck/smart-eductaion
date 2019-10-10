using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.DTOs
{
    public class ReplayMessageDTO
    {
        public long ConversationId { get; set; }
        public string MessageReplay { get; set; }
    }
}
