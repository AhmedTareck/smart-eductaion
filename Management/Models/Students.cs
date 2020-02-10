using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Students
    {
        public Students()
        {
            Grids = new HashSet<Grids>();
            PresnessInfo = new HashSet<PresnessInfo>();
            StudentEvents = new HashSet<StudentEvents>();
        }

        public long StudentId { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string SurName { get; set; }
        public string Adrress { get; set; }
        public string PhoneNumber { get; set; }
        public bool? Sex { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? Status { get; set; }
        public string MatherName { get; set; }
        public long? ParentId { get; set; }

        public Users Parent { get; set; }
        public ICollection<Grids> Grids { get; set; }
        public ICollection<PresnessInfo> PresnessInfo { get; set; }
        public ICollection<StudentEvents> StudentEvents { get; set; }
    }
}
