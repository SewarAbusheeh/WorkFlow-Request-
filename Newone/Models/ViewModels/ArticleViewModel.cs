using Microsoft.AspNetCore.Http;
using Newone.Models.SharedProp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Models.ViewModels
{
    public class ArticleViewModel  :CommonProp
    {
        public string Title { get; set; }

        public IFormFile ArticleImg { get; set; }
        public string Desc { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }

        public string BtnUrl { get; set; }
    }
}
