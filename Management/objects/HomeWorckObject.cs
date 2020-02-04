using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.objects
{
    public class HomeWorckObject
    {
        public long id { get; set; }
        public long eventId { get; set; }
        public long yearId { get; set; }
        public string name { get; set; }
        public DateTime lastDayDilavary { get; set; }
        public string disctiption { get; set; }
    }
}
