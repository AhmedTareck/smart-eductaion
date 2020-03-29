using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Users
    {
        public Users()
        {
            Events = new HashSet<Events>();
            Municipalitys = new HashSet<Municipalitys>();
            Schools = new HashSet<Schools>();
        }

        public long Id { get; set; }
        public int? GroupId { get; set; }
        public string Name { get; set; }
        public string LoginName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Image { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? LoginTryAttemptDate { get; set; }
        public short? LoginTryAttempts { get; set; }
        public DateTime? LastLoginOn { get; set; }
        public short? Gender { get; set; }
        public short? UserType { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public short? State { get; set; }

        public Groups Group { get; set; }
        public ICollection<Events> Events { get; set; }
        public ICollection<Municipalitys> Municipalitys { get; set; }
        public ICollection<Schools> Schools { get; set; }
    }
}
