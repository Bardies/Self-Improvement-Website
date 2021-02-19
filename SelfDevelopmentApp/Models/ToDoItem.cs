using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Models
{
    public class ToDoItem
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="Please enter a description.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please choose a priority.")]
        public Priority Priority { get; set; }

        public bool Done { get; set; } = false;
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? ReminderTime { get; set; }

        [ForeignKey("ToDoList")]
        public int ToDoListID { get; set; }
        public ToDoList ToDoList { get; set; }


    }
}
