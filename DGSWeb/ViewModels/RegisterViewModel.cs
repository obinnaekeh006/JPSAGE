using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DGSWeb.ViewModels
{
    public class RegisterViewModel
    {
        //[Required]
        //public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must not be less than 6 characters")]
        [MaxLength(15, ErrorMessage = "Password can not be more than 15 characters")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You have to accept the terms and conditions")]
        public bool TermsAndConditions { get; set; }


        //[Required]
        //public string FirstName { get; set; }
        
        //[Required]
        //public string LastName { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public long PhoneNumber { get; set; }


    }
}
