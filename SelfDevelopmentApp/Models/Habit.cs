using SelfDevelopmentApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Models
{
    
    public class Habit
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "You must enter a description.")]
        public string Description { get; set; }
       
	public string Color { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime StartingDate { get; set; }
        [ForeignKey("User")]
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
    }
}
