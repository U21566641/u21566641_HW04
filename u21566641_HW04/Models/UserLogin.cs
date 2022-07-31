using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace u21566641_HW04.Models
{
    public class UserLogin
    {
        [Display(Name ="Email address")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Email Address required")]
        public string EmailAddress { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage ="Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
        
    }
}