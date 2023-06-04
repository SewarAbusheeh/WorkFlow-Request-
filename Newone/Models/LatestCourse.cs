using Newone.Models.SharedProp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Models
{
    public class LatestCourse :CommonProp
    {
        public int LatestCourseId { get; set; }
        [Required(ErrorMessage = "Enter Course Name")]

        public string CName { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string CourseDesc { get; set; }

        public string CourseImg { get; set; }
        public int Hours { get; set; }
        public string Topic { get; set; }
        public decimal Price { get; set; }
        public string Place { get; set; }

        public string Duration { get; set; }
        public DateTime CStart { get; set; }
        public string blockQute { get; set; }
        public string MoreDescription { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
