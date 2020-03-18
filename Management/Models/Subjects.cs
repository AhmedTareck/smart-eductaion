using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Subjects
    {
        public Subjects()
        {
            Events = new HashSet<Events>();
            Shapters = new HashSet<Shapters>();
        }

        public long Id { get; set; }
        public int? AcadimecYearId { get; set; }
        public string Name { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? Status { get; set; }

        public AcadimacYears AcadimecYear { get; set; }
        public ICollection<Events> Events { get; set; }
        public ICollection<Shapters> Shapters { get; set; }
    }
}
