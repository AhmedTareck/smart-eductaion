using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class StudentEvents
    {
        public StudentEvents()
        {
            Grids = new HashSet<Grids>();
        }

        public long StudentEventId { get; set; }
        public long? StudentId { get; set; }
        public long? EventId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? Status { get; set; }

        public Events Event { get; set; }
        public Students Student { get; set; }
        public ICollection<Grids> Grids { get; set; }
    }
}
