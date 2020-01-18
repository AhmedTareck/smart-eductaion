using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Schools
    {
        public long SchoolId { get; set; }
        public string Name { get; set; }
        public long? UserId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public User User { get; set; }
    }
}
