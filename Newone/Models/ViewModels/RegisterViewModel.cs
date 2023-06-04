using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        
        
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
       
       
        public string ConfirmPassword { get; set; }

       
        public string Mobile { get; set; }
        public String UserName { get; set; }
        public String Gender { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }



    }
}



