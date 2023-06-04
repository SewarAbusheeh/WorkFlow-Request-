using Microsoft.AspNetCore.Http;
using Newone.Models.SharedProp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Models.ViewModels
{
    public class ComingCourseViewModel   :CommonProp
    {
        public string CName { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public string CourseDesc { get; set; }

        public IFormFile CourseImg { get; set; }
        public int Hours { get; set; }
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        public string Place { get; set; }

        public string Duration { get; set; }

        public string blockQute { get; set; }
        public string MoreDescription { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
