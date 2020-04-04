using System;
using System.Collections.Generic;

namespace Web.Models
{
    public partial class Municipalitys
    {
        public Municipalitys()
        {
            Schools = new HashSet<Schools>();
        }

        public long Id { get; set; }
        public long? ResponsibleId { get; set; }
        public long? LocationId { get; set; }
        public string Name { get; set; }
        public string AddressDiscreption { get; set; }
        public string Discreption { get; set; }
        public long? ModifiedBy { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public short? Status { get; set; }

        public Locations Location { get; set; }
        public Users Responsible { get; set; }
        public ICollection<Schools> Schools { get; set; }
    }
}
