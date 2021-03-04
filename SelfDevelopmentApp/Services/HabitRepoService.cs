using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SelfDevelopmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Services
{
    public class HabitRepoService:IHabitRepository
    {
        private readonly AppDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public HabitRepoService(AppDbContext context, 
            UserManager<ApplicationUser> user_Manager)
        {
            this.context = context;
            userManager = user_Manager;
        }
        public List<Habit> GetAllHabits(string user_ID) 
        {
            return context.Habits.Where(habit => habit.UserID == user_ID).ToList();
        }
        public Habit Details(int id)
        {
            return context.Habits.Find(id);
        }
        public void Edit(int id, Habit habit)
        {
            Habit _habit = context.Habits.Find(id);
            _habit.Description = habit.Description;
            _habit.Color = habit.Color;
            
            //We get user from system so we can't edit it.
        }
        public void Delete(int id)
        {
            context.Remove(context.Habits.Find(id));
            context.SaveChanges();
        }
        public void Insert(Habit habit)
        {
            context.Habits.Add(habit);
            context.SaveChanges();
        }
    }
}
