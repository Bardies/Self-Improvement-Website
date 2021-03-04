using SelfDevelopmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Services
{
    public interface IHabitRepository
    {
        public List<Habit> GetAllHabits(string currentUserID);
        public Habit Details(int id);
        public void Edit(int id, Habit habit);
        public void Delete(int id);
        public void Insert(Habit habit);
    }
}
