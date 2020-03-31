using System;
using System.Collections.Generic;

namespace Web.Models
{
    public partial class Shapters
    {
        public Shapters()
        {
            Lectures = new HashSet<Lectures>();
        }

        public long Id { get; set; }
        public long? EventId { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public short? Status { get; set; }

        public Events Event { get; set; }
        public ICollection<Lectures> Lectures { get; set; }
    }
}
