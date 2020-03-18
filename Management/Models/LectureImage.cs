using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class LectureImage
    {
        public long Id { get; set; }
        public long? LectureId { get; set; }
        public string Image { get; set; }

        public Lectures Lecture { get; set; }
    }
}
