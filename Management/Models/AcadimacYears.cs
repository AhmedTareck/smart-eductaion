using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class AcadimacYears
    {
        public AcadimacYears()
        {
            Events = new HashSet<Events>();
            Subjects = new HashSet<Subjects>();
        }

        public int AcadimecYearId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? Status { get; set; }

        public ICollection<Events> Events { get; set; }
        public ICollection<Subjects> Subjects { get; set; }
    }
}
