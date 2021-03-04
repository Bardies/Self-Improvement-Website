using SelfDevelopmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Services
{
    public interface IToDoItemRepository
    {
        public List<ToDoItem> GetAll(string id);
        public ToDoItem GetDetails(int id);
        public void MarkDone(int id);
        public void MarkNotDone(int id);
        public void QuickAdd(string desc, string userID);
        public void Create(ToDoItem toDo, string userID);
        public void Update(int id, ToDoItem toDo);
        public void Delete(int id);
    }
}
