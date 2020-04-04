using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class StudentExam
    {
        public StudentExam()
        {
            StudentAnswer = new HashSet<StudentAnswer>();
        }

        public long Id { get; set; }
        public long? StudentId { get; set; }
        public long? ExamId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? Status { get; set; }

        public virtual Exams Exam { get; set; }
        public virtual Students Student { get; set; }
        public virtual ICollection<StudentAnswer> StudentAnswer { get; set; }
    }
}
