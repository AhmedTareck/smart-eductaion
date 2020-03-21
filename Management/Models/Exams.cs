using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Exams
    {
        public Exams()
        {
            Questions = new HashSet<Questions>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; }
        public int? FullMarck { get; set; }
        public double? Lenght { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? Status { get; set; }

        public ICollection<Questions> Questions { get; set; }
    }
}
