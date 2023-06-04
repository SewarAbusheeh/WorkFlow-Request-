using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Models.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }

      
        [DataType(DataType.Password)]
       
        public string Password { get; set; }
        public String UserName { get; set; }

        public bool Rememberme{ get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public string CompenyName { get; set; }
       
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [DataType(DataType.MultilineText)]
        public string Aboutme { get; set; }

        public FormFile Pic { get; set; }

        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Glinked { get; set; }

    }
}
