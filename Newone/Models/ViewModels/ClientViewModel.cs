using Microsoft.AspNetCore.Http;
using Newone.Models.SharedProp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Models.ViewModels
{
    public class ClientViewModel : CommonProp
    {
        public string CName { get; set; }
        //    public string CEmail { get; set; }

        public string Comment { get; set; }

        public IFormFile CImg { get; set; }

        public string CStatus { get; set; }
    }
}
