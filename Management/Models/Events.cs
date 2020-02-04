using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Events
    {
        public Events()
        {
            Exams = new HashSet<Exams>();
            HomeWorcks = new HashSet<HomeWorcks>();
            Presness = new HashSet<Presness>();
            Skedjule = new HashSet<Skedjule>();
            StudentEvents = new HashSet<StudentEvents>();
        }

        public long EventId { get; set; }
        public string EventGroup { get; set; }
        public int? AcadimecYearId { get; set; }
        public long? YearId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? Status { get; set; }

        public AcadimacYears AcadimecYear { get; set; }
        public Years Year { get; set; }
        public ICollection<Exams> Exams { get; set; }
        public ICollection<HomeWorcks> HomeWorcks { get; set; }
        public ICollection<Presness> Presness { get; set; }
        public ICollection<Skedjule> Skedjule { get; set; }
        public ICollection<StudentEvents> StudentEvents { get; set; }
    }
}
