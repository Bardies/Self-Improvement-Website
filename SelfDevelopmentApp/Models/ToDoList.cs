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
        public string UserID { get; set; }

        public virtual ApplicationUser User { get; set; }

        public ICollection<ToDoItem> ListItems { get; set; } = new HashSet<ToDoItem>();
    }
}
