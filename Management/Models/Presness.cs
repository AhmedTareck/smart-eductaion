using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Presness
    {
        public long PresnessId { get; set; }
        public long? StudentEventId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public short? Status { get; set; }

        public StudentEvents StudentEvent { get; set; }
    }
}
