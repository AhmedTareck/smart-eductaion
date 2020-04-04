using System;
using System.Collections.Generic;

namespace Web.Modelsv1
{
    public partial class Permissions
    {
        public Permissions()
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
