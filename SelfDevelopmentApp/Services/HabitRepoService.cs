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
        public HabitRepoService(AppDbContext context)
        {
            this.context = context;
        }
        public List<Habit> GetAllHabits() 
        {
            return context.Habits.ToList();
        }
        public Habit Details(int id)
        {
            return context.Habits.Find(id);
        }
        public void Edit(int id, Habit habit)
        {
            Habit _habit = context.Habits.Find(id);
            _habit.Description = habit.Description;
           
            _habit.StartingDate = habit.StartingDate;
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
