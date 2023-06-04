using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Models
{
    public class Requesttoenroll
    {
        public int RequesttoenrollId { get; set; }
       
        public string  Mesage  { get; set; }

        public DateTime  CreationT { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int LatestCourseId { get; set; }
        public LatestCourse LatestCourse { get; set; }

    }
}
