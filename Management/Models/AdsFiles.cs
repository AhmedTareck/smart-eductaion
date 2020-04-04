using System;
using System.Collections.Generic;

namespace Management.Models
{
    public partial class AdsFiles
    {
        public long Id { get; set; }
        public long? AdsId { get; set; }
        public string AttashmentFile { get; set; }
        public short? Status { get; set; }

        public virtual Ads Ads { get; set; }
    }
}
