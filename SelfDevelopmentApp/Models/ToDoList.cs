using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Models
{
    public class ToDoList
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        public ICollection<ToDoItem> ListItems { get; set; } = new HashSet<ToDoItem>();
    }
}
