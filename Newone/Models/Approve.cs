using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Models
{
    public class Approve
    {
        public int ApproveId { get; set; }
        public DateTime CreationT { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int LatestCourseId { get; set; }
        public LatestCourse LatestCourse { get; set; }
     
    }
}
