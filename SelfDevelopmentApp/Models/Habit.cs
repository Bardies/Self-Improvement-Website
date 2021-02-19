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
        public int Longest_Streak { get; set; } = 0;
        public int Current_Streak { get; set; } = 0;
        public int Total_Count { get; set; } = 0;
        [DataType(DataType.Date)]
        [Required]
        public DateTime StartingDate { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }

        public User User { get; set; }

    }
}
