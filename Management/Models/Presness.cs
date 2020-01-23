using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Presness
    {
        public Presness()
        {
            PresnessInfo = new HashSet<PresnessInfo>();
        }

        public long Id { get; set; }
        public DateTime? LectureDate { get; set; }
        public string Note { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? Status { get; set; }
        public long? EventId { get; set; }

        public Events Event { get; set; }
        public ICollection<PresnessInfo> PresnessInfo { get; set; }
    }
}
