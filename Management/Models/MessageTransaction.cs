using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class MessageTransaction
    {
        public long MessageTransactionId { get; set; }
        public long? SentByStudent { get; set; }
        public long? RecivedByStudent { get; set; }
        public long? SentByUser { get; set; }
        public long? RecivedByUser { get; set; }
        public long? MessageId { get; set; }
        public int? IsRead { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }

        public Messages Message { get; set; }
    }
}
