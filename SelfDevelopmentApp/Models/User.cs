
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Models
{
    public class User
    {

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        [StringLength(100)]
        public string Fname { get; set; }

       
        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last Name")]
        [StringLength(100)]
        public string Lname { get; set; }

       
        [Required(ErrorMessage = "Please enter your E-mail address")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "Please enter your Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
   
       
        public float? Height { get; set; }
      
        
        public float? Weight { get; set; }
       
        public string Phone { get; set; }
      
        
        
        [Required]
        [DataType(DataType.Date, ErrorMessage ="Please enter your Date of Birth.")]
        public DateTime DOB { get; set; }
       
        
        public byte[] PPImageData { get; set; }

       
        public ICollection<Topic> Topics { get; set;} = new HashSet<Topic>();

        
        public ICollection<Habit> Habits { get; set; } = new HashSet<Habit>();

        
        public virtual ToDoList ToDoList { get; set; }
       





    }
}
