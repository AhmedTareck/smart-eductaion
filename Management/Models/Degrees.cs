using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Degrees
    {
        public long Id { get; set; }
        public byte[] Image { get; set; }
        public long? StudentId { get; set; }
        public DateTime? CreatecdOn { get; set; }
        public long? CreatedBy { get; set; }
        public short? Status { get; set; }

        public Students Student { get; set; }
    }
}
