using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Years
    {
        public Years()
        {
            Events = new HashSet<Events>();
        }

        public long YearId { get; set; }
        public string Name { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public ICollection<Events> Events { get; set; }
    }
}
