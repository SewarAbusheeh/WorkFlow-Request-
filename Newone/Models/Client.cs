

using Newone.Models.SharedProp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Models
{
    public class Client : CommonProp
    {
        public int ClientId { get; set; }
        public string CName { get; set; }
    //    public string CEmail { get; set; }
        
        public string  Comment { get; set; }

         public string CImg { get; set; }

          public string CStatus { get; set; }
    }
}
