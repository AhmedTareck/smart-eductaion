using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Ads
    {
        public long Id { get; set; }
        public long? EventId { get; set; }
        public string Subject { get; set; }
        public string Post { get; set; }
        public byte[] Image { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public short? Status { get; set; }
    }
}
