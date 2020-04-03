using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class AcadimacYears
    {
        public AcadimacYears()
        {
            Students = new HashSet<Students>();
            Subjects = new HashSet<Subjects>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public short? Status { get; set; }

        public  ICollection<Exams> Exams { get; set; }
        public  ICollection<Students> Students { get; set; }
        public  ICollection<Subjects> Subjects { get; set; }

    }
}
