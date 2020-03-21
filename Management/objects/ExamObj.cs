using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.objects
{
    public class ExamObj
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public int FullMarck { get; set; }
        public float Lenght { get; set; }

        public List<QuestionsObj> QuestionsObj = new List<QuestionsObj>();
    }
}
