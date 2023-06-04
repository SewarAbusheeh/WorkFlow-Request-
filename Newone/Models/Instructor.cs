
using Newone.Models.SharedProp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Models
{
    public class Instructor : CommonProp
    {
        public int InstructorId { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string InstructorName { get; set; }
        [Required(ErrorMessage = "Select Img")]
        public string InstructorImg { get; set; }
        public string InstructorPosition { get; set; }
        public string InstructorDescription { get; set; }
        public string Tw { get; set; }
        public string Fb { get; set; }
    }
}
