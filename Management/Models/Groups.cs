using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Groups
    {
        public Groups()
        {
            PermissionGroup = new HashSet<PermissionGroup>();
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? State { get; set; }

        public ICollection<PermissionGroup> PermissionGroup { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
