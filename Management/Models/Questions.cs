using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Questions
    {
        public long Id { get; set; }
        public long? ExamId { get; set; }
        public int? Number { get; set; }
        public int? Points { get; set; }
        public string Question { get; set; }
        public int? Answer { get; set; }
        public string A1 { get; set; }
        public string A2 { get; set; }
        public string A3 { get; set; }
        public string A4 { get; set; }
        public short? Status { get; set; }

        public Exams Exam { get; set; }
    }
}
