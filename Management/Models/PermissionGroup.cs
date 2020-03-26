using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class PermissionGroup
    {
        public PermissionGroup()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public int? GroupId { get; set; }
        public int? PermissioinId { get; set; }
        public string Name { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? State { get; set; }

        public Groups Group { get; set; }
        public Permissions Permissioin { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
