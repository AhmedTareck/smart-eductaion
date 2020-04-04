using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class StudentAnswer
    {
        public long Id { get; set; }
        public long? StudentExamId { get; set; }
        public long? AnsewrId { get; set; }
        public short? Status { get; set; }

        public virtual Answers Ansewr { get; set; }
        public virtual StudentExam StudentExam { get; set; }
    }
}
