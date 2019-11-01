using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class MessageType
    {
        public MessageType()
        {
            Conversations = new HashSet<Conversations>();
        }

        public long MessageTypeId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Description { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Name { get; set; }
        public short? Status { get; set; }

        public Users CreatedByNavigation { get; set; }
        public Users ModifiedByNavigation { get; set; }
        public ICollection<Conversations> Conversations { get; set; }
    }
}
