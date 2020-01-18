using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Students
    {
        public Students()
        {
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
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? Status { get; set; }
        public string MatherName { get; set; }
        public long? ParentId { get; set; }

        public User Parent { get; set; }
        public ICollection<StudentEvents> StudentEvents { get; set; }
    }
}
