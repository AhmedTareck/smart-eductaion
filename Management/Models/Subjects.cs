using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Subjects
    {
        public Subjects()
        {
            Grids = new HashSet<Grids>();
        }

        public long SubjectId { get; set; }
        public int? AcadimecYearId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? Status { get; set; }

        public AcadimacYears AcadimecYear { get; set; }
        public ICollection<Grids> Grids { get; set; }
    }
}
