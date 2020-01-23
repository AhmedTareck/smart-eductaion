using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class PresnessInfo
    {
        public long PresnessInfoId { get; set; }
        public long? PresnessId { get; set; }
        public long? StudentId { get; set; }
        public short? Status { get; set; }

        public Presness Presness { get; set; }
        public Students Student { get; set; }
    }
}
