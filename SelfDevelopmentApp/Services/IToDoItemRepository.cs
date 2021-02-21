using SelfDevelopmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Services
{
    public interface IToDoItemRepository
    {
        public List<ToDoItem> GetAll(int id);
        public ToDoItem GetDetails(int id);
        public void Insert(ToDoItem toDo);
        public void Update(int id, ToDoItem toDo);
        public void Delete(int id);
    }
}
