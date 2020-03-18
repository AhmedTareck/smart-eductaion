using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class AcadimacYears
    {
        public AcadimacYears()
        {
            Subjects = new HashSet<Subjects>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? Status { get; set; }

        public ICollection<Subjects> Subjects { get; set; }
    }
}
