using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.objects
{
    public class LectureObject
    {

        public long? shapterSelected { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; }
        public string decreption { get; set; }
        public List<BaseFile> attashFile = new List<BaseFile>();
        public List<BaseFile> sound = new List<BaseFile>();
        public List<BaseFile> Video = new List<BaseFile>();
        public List<BaseFile> Photo = new List<BaseFile>();


    }

    public class BaseFile
    {
        public string FileName { get; set; }
        public string FileBase64 { get; set; }
    }


}
