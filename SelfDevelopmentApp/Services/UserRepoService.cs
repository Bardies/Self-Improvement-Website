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

        public UserRepoService(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }
        public List<User> AllUser()
        {
            return AppDbContext.Users.Include(u => u.Habits).Include(u => u.ToDoList).ThenInclude(t=> t.ListItems).ToList();
        }
    }
}
