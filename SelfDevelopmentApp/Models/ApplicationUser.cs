﻿
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Models
{
    public class ApplicationUser : IdentityUser
    {


        
        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        [StringLength(100)]
        public string Fname { get; set; }


        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last Name")]
        [StringLength(100)]
        public string Lname { get; set; }

        public float? Height { get; set; }


        public float? Weight { get; set; }


      
        [DataType(DataType.Date, ErrorMessage = "Please enter your Data of Birth.")]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}")]
        public DateTime DOB { get; set; }


        public string PPImageData { get; set; }


        public ICollection<Topic> Topics { get; set; } = new HashSet<Topic>();


        public ICollection<Habit> Habits { get; set; } = new HashSet<Habit>();


        public virtual ToDoList ToDoList { get; set; }






    }
}
