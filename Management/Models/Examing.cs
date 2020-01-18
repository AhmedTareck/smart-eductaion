using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Examing
    {
        public long ExamingId { get; set; }
        public string Name { get; set; }
        public int? Marck { get; set; }
        public long? EventId { get; set; }
        public long? SubjectId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public short? Status { get; set; }

        public Events Event { get; set; }
        public Subjects Subject { get; set; }
    }
}
