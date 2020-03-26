using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Groups
    {
        public Groups()
        {
            PermissionGroup = new HashSet<PermissionGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? State { get; set; }

        public ICollection<PermissionGroup> PermissionGroup { get; set; }
    }
}
