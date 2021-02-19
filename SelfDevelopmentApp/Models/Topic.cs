using Microsoft.EntityFrameworkCore;
using SelfDevelopmentApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Models
{
    public class Topic
    {
        [Key]
        public int ID { get; set; }

        
        [Required(ErrorMessage ="Topic name is required")]
        //[Index(IsUnique=true)]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; } = new HashSet<User>();

        public ICollection<Article> Articles { get; set; } = new HashSet<Article>();


    }
}
