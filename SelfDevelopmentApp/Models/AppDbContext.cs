using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SelfDevelopmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Models
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>

    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {  }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>().HasIndex(t => t.Name).IsUnique();
            modelBuilder.Entity<ApplicationUser>()
                        .Property(m => m.PPImageData)
                        .IsRequired(false);
            base.OnModelCreating(modelBuilder);
        
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Topic> Topics { get; set; }
        //public DbSet<User_deleted> Users { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        

        

    }
}
