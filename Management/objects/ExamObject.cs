using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.objects
{
    public class ExamObject
    {
        public long id { get; set; }
        public long eventId { get; set; }
        public long yearId { get; set; }
        public string name { get; set; }
        public DateTime examDate { get; set; }
        public int fullMarck { get; set; }
        public string disctiption { get; set; }
    }
}
