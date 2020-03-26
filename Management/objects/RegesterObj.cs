using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.objects
{
    public class RegesterObj
    {
        public long? UserId { get; set; }
        public string Name { get; set; }
        public string LoginName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public short Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int ShoolId { get; set; }
        public int AcadimacYearId { get; set; }
        
    }
}
