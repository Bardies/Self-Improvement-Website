using SelfDevelopmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Services
{
    public interface IToDoListRepository
    {
        public ToDoList GetDetails(int id);
        public void Insert(ToDoList toDo);
        public void Update(int id, ToDoList toDo);
        public void Delete(int id);
    }
}
