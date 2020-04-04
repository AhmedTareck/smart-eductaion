using System;
using System.Collections.Generic;

namespace Web.Modelsv1
{
    public partial class Locations
    {
        public Locations()
        {
            InverseParent = new HashSet<Locations>();
            Municipalitys = new HashSet<Municipalitys>();
            Schools = new HashSet<Schools>();
        }

        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string Name { get; set; }
        public string Coordinates { get; set; }
        public short? Level { get; set; }
        public short? Status { get; set; }

        public Locations Parent { get; set; }
        public ICollection<Locations> InverseParent { get; set; }
        public ICollection<Municipalitys> Municipalitys { get; set; }
        public ICollection<Schools> Schools { get; set; }
    }
}
