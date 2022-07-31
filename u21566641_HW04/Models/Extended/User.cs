using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace u21566641_HW04.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
        public String ConfirmPassword { get; set; }
    }

    public class UserMetaData
    {
        [Display(Name ="First Name")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Please enter your first name")]
        public string FirstName { get; set; }

        [Display(Name = "Surname")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your  surname")]
        public string Surname { get; set; }

        [Display(Name = "Phone number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your  phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email Address")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your  password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage ="Minimum password length is 6 characters.")]
        public string Password { get; set; }

        [Display(Name ="Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Passwords do not match!")]
        public string ConfirmPassword { get; set; }
    }
}