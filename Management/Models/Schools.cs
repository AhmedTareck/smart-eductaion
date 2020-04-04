using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Schools
    {
        public Schools()
        {
            Students = new HashSet<Students>();
        }

        public long Id { get; set; }
        public long? MunicipalityId { get; set; }
        public long? LocationId { get; set; }
        public long? ResponsibleId { get; set; }
        public string Name { get; set; }
        public string AddressDiscreption { get; set; }
        public short? EducationalLevel { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public short? Status { get; set; }

        public virtual Locations Location { get; set; }
        public virtual Municipalitys Municipality { get; set; }
        public virtual Users Responsible { get; set; }
        public virtual ICollection<Students> Students { get; set; }
    }
}
