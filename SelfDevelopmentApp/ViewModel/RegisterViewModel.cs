using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        [StringLength(100)]
        public string Fname { get; set; }


        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last Name")]
        [StringLength(100)]
        public string Lname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
