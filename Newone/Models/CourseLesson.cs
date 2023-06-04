using Newone.Models.SharedProp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Models
{
    public class CourseLesson : CommonProp
    {
        public int CourseLessonId { get; set; }
        public string CTitle  { get; set; }
        public int SerialNumber { get; set; }
        public string Contatnt  { get; set; }
        public string FilePath { get; set; }
        public int LatestCourseId { get; set; }
        public LatestCourse LatestCourse { get; set; }
    }
}
