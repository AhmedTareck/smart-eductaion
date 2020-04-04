using System;
using System.Collections.Generic;

namespace Web.Modelsv1
{
    public partial class Subjects
    {
        public Subjects()
        {
            Events = new HashSet<Events>();
            Exams = new HashSet<Exams>();
        }

        public long Id { get; set; }
        public long? AcadimecYearId { get; set; }
        public string Name { get; set; }
        public string Discreptions { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public short? Status { get; set; }

        public AcadimacYears AcadimecYear { get; set; }
        public ICollection<Events> Events { get; set; }
        public ICollection<Exams> Exams { get; set; }
    }
}
