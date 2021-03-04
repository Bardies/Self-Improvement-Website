using Microsoft.AspNetCore.Http;
using SelfDevelopmentApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.ViewModel
{
    public class EditProfileViewModel
    {

        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        [StringLength(100)]
        public string Fname { get; set; }


        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last Name")]
        [StringLength(100)]
        public string Lname { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public float? Height { get; set; }


        public float? Weight { get; set; }


        [Required]
        [DataType(DataType.Date, ErrorMessage = "Please enter your Data of Birth.")]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}")]
        public DateTime DOB { get; set; }

      
        public IFormFile  PPImageData { get; set; }

    }
}
