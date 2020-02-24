using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Packeges
    {
        public long Id { get; set; }
        public long? SchoolId { get; set; }
        public DateTime? StatrtDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }

        public Schools School { get; set; }
    }
}
