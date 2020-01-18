﻿using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class User
    {
        public User()
        {
            Schools = new HashSet<Schools>();
            Students = new HashSet<Students>();
        }

        public long UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string LoginName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public short Gender { get; set; }
        public short? UserType { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? Status { get; set; }

        public ICollection<Schools> Schools { get; set; }
        public ICollection<Students> Students { get; set; }
    }
}