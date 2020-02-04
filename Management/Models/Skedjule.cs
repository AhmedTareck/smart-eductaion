using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Skedjule
    {
        public long Id { get; set; }
        public long? SubjectId { get; set; }
        public long? EventId { get; set; }
        public short? Day { get; set; }
        public short? LectureNumber { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }

        public Events Event { get; set; }
        public Subjects Subject { get; set; }
    }
}
