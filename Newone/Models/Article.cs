
using Newone.Models.SharedProp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Models
{
    public class Article : CommonProp
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string ArticleImg { get; set; }
        public string Desc { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
    
        public string BtnUrl { get; set; }
    }
}
