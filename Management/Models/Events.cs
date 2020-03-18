using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Events
    {
        public long Id { get; set; }
        public long? SubjectId { get; set; }
        public string Name { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? Status { get; set; }

        public Subjects Subject { get; set; }
    }
}
