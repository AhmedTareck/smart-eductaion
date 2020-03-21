using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class Lectures
    {
        public Lectures()
        {
            LectureImage = new HashSet<LectureImage>();
        }

        public long Id { get; set; }
        public long? ShaptersId { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; }
        public string Description { get; set; }
        public byte[] AttashmentFile { get; set; }
        public byte[] SoundFile { get; set; }
        public byte[] VideoFile { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public short? Status { get; set; }

        public Shapters Shapters { get; set; }
        public ICollection<LectureImage> LectureImage { get; set; }
    }
}
