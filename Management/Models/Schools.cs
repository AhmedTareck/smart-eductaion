using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Schools
    {
        public Schools()
        {
            Packeges = new HashSet<Packeges>();
        }

        public long SchoolId { get; set; }
        public string Name { get; set; }
        public long? UserId { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public Users User { get; set; }
        public ICollection<Packeges> Packeges { get; set; }
    }
}
