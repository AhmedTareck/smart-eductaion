using System;
using System.Collections.Generic;

namespace Web.Models
{
    public partial class Answers
    {
        public Answers()
        {
            StudentAnswer = new HashSet<StudentAnswer>();
        }

        public long Id { get; set; }
        public long? QuestionId { get; set; }
        public string ExamAnswers { get; set; }
        public long? ModifiedBy { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public short? Status { get; set; }

        public Questions Question { get; set; }
        public ICollection<StudentAnswer> StudentAnswer { get; set; }
    }
}
