using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SelfDevelopmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Services
{
    public class UserRepoService : IUserRepository
    {
        public AppDbContext AppDbContext { get; }
        private readonly UserManager<ApplicationUser> userManager;
        public UserRepoService(AppDbContext appDbContext, UserManager<ApplicationUser> userManager)
        {
            AppDbContext = appDbContext;
        this.userManager = userManager;
    }
        public List<ApplicationUser> AllUser()
        {
            return userManager.Users.Include(u => u.Habits).Include(u => u.ToDoList).ThenInclude(t=> t.ListItems).ToList();
        }
    }
}
