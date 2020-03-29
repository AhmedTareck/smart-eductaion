using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Events
    {
        public Events()
        {
            Shapters = new HashSet<Shapters>();
        }

        public long Id { get; set; }
        public long? TeacherId { get; set; }
        public long? SubjectId { get; set; }
        public string Name { get; set; }
        public string Discreptions { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public short? Status { get; set; }

        public virtual Subjects Subject { get; set; }
        public virtual Users Teacher { get; set; }
        public virtual ICollection<Shapters> Shapters { get; set; }
    }
}
