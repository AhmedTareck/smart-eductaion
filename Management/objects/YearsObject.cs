using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.objects
{
    public class YearsObject
    {
        public long id { get; set; }
        public long? SubjectId { get; set; }
        public int? ShapterNumber { get; set; }
        public string name { get; set; }
    }
}
