using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Models
{
    public class ApplicationUser :IdentityUser
    {

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public string CompenyName { get; set; }

        public String Userbackground { get; set; }
        public String Pic { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [DataType(DataType.MultilineText)]
        public string Aboutme { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Glinked { get; set; }
        public string Domain { get; set; }
        public string Hobbies { get; set; }




    }
}
