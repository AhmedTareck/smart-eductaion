using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class HomeWorcks
    {
        public long Id { get; set; }
        public long? EventId { get; set; }
        public long? SubjectId { get; set; }
        public string Name { get; set; }
        public string Disctiption { get; set; }
        public DateTime? LastDayDilavary { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public short? Status { get; set; }

        public Events Event { get; set; }
        public Subjects Subject { get; set; }
    }
}
