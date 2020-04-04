using System;
using System.Collections.Generic;

namespace Web.Models
{
    public partial class Lectures
    {
        public Lectures()
        {
            LectureFiles = new HashSet<LectureFiles>();
        }

        public long Id { get; set; }
        public long? ShaptersId { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; }
        public string Description { get; set; }
        public string VideoPath { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public short? Status { get; set; }

        public Shapters Shapters { get; set; }
        public ICollection<LectureFiles> LectureFiles { get; set; }
    }
}
