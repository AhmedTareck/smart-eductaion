using System;
using System.Collections.Generic;

namespace Web.Modelsv1
{
    public partial class Messages
    {
        public Messages()
        {
            MessageTransaction = new HashSet<MessageTransaction>();
        }

        public long MesssageId { get; set; }
        public string Subject { get; set; }
        public string Payload { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }

        public ICollection<MessageTransaction> MessageTransaction { get; set; }
    }
}
