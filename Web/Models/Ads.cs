using System;
using System.Collections.Generic;

namespace Web.Models
{
    public partial class Ads
    {
        public Ads()
        {
            AdsFiles = new HashSet<AdsFiles>();
        }

        public long Id { get; set; }
        public string Subject { get; set; }
        public string Post { get; set; }
        public byte[] Image { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long? CreatedBy { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public short? Status { get; set; }

        public ICollection<AdsFiles> AdsFiles { get; set; }
    }
}
