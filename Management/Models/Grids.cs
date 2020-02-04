using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Grids
    {
        public long GridId { get; set; }
        public long? StudentId { get; set; }
        public long? ExamId { get; set; }
        public int? Grid { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public short? Status { get; set; }

        public Exams Exam { get; set; }
        public Students Student { get; set; }
    }
}
