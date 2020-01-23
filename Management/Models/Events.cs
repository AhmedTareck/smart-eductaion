using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Events
    {
        public Events()
        {
            Presness = new HashSet<Presness>();
            StudentEvents = new HashSet<StudentEvents>();
        }

        public long EventId { get; set; }
        public string EventGroup { get; set; }
        public int? AcadimecYearId { get; set; }
        public long? YearId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? Status { get; set; }

        public AcadimacYears AcadimecYear { get; set; }
        public Years Year { get; set; }
        public ICollection<Presness> Presness { get; set; }
        public ICollection<StudentEvents> StudentEvents { get; set; }
    }
}
