using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Exams
    {
        public Exams()
        {
            Questions = new HashSet<Questions>();
            StudentExam = new HashSet<StudentExam>();
        }

        public long Id { get; set; }
        public long? AcadimacYearId { get; set; }
        public long? EventId { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; }
        public int? FullMarck { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public short? Status { get; set; }

        public virtual AcadimacYears AcadimacYear { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
        public virtual ICollection<StudentExam> StudentExam { get; set; }
    }
}
