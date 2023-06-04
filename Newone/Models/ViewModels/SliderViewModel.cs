using Microsoft.AspNetCore.Http;
using Newone.Models.SharedProp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Models.ViewModels
{
    public class SliderViewModel : CommonProp
    {
        public string STitle { get; set; }
        public string SubTitle { get; set; }
        public IFormFile SliderImg { get; set; }
        public string BtnText { get; set; }

        public string BtnUrl { get; set; }

        public string SliderDesc { get; set; }
    }
}
