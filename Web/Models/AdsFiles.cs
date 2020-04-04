using System;
using System.Collections.Generic;

namespace Web.Models
{
    public partial class AdsFiles
    {
        public long Id { get; set; }
        public long? AdsId { get; set; }
        public string AttashmentFile { get; set; }
        public short? Status { get; set; }

        public Ads Ads { get; set; }
    }
}
