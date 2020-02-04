using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Exams
    {
        public Exams()
        {
            Grids = new HashSet<Grids>();
        }

        public long ExamId { get; set; }
        public long? EventId { get; set; }
        public long? SubjectId { get; set; }
        public string Name { get; set; }
        public string Discreptons { get; set; }
        public int? FullMarck { get; set; }
        public DateTime? ExamDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public short? Status { get; set; }

        public Events Event { get; set; }
        public Subjects Subject { get; set; }
        public ICollection<Grids> Grids { get; set; }
    }
}
