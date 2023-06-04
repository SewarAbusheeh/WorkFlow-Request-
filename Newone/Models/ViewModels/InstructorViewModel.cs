using Microsoft.AspNetCore.Http;
using Newone.Models.SharedProp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Newone.Models.ViewModels
{
    public class InstructorViewModel :CommonProp
    {
        public string InstructorName { get; set; }
        [Required(ErrorMessage = "Select Img")]
        public IFormFile InstructorImg { get; set; }
        public string InstructorPosition { get; set; }
        public string InstructorDescription { get; set; }
        public string Tw { get; set; }
        public string Fb { get; set; }
    }
}
