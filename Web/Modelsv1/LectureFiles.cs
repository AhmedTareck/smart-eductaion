﻿using System;
using System.Collections.Generic;

namespace Web.Modelsv1
{
    public partial class LectureFiles
    {
        public long Id { get; set; }
        public long? LectureId { get; set; }
        public string AttashmentFile { get; set; }
        public short? Status { get; set; }

        public Lectures Lecture { get; set; }
    }
}
