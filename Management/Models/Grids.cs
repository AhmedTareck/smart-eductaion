using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Grids
    {
        public long Grid { get; set; }
        public long? StudentEventId { get; set; }
        public long? SubjectId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public short? Status { get; set; }

        public StudentEvents StudentEvent { get; set; }
        public Subjects Subject { get; set; }
    }
}
