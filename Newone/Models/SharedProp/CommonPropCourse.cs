using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Models.SharedProp
{
    public class CommonPropCourse
    {
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public string Topic1 { get; set; }
        public TimeSpan TopicTime1 { get; set; }
        public string Topic2 { get; set; }
        public TimeSpan TopicTime2 { get; set; }
        public string Topic3 { get; set; }
        public TimeSpan TopicTime3 { get; set; }
    }
}
