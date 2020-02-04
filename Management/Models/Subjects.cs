using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Subjects
    {
        public Subjects()
        {
            Exams = new HashSet<Exams>();
            HomeWorcks = new HashSet<HomeWorcks>();
            Skedjule = new HashSet<Skedjule>();
        }

        public long SubjectId { get; set; }
        public int? AcadimecYearId { get; set; }
        public string Name { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? Status { get; set; }

        public AcadimacYears AcadimecYear { get; set; }
        public ICollection<Exams> Exams { get; set; }
        public ICollection<HomeWorcks> HomeWorcks { get; set; }
        public ICollection<Skedjule> Skedjule { get; set; }
    }
}
