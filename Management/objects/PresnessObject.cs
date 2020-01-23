using Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.objects
{
    public class PresnessObject
    {
        public long? presnessId { get; set; }
        public List<Students> Students { get; set; }
        public long YearSelected { get; set; }
        public long EventSelectd { get; set; }
        public DateTime LectureDate { get; set; }

        public List<EditpresnessObject> edit {get; set;}
        
    }

    public class EditpresnessObject
    {
        public long id { get; set; }
        public bool editStatus { get; set; }
    }
}
