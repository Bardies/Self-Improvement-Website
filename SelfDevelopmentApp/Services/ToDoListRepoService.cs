using Self_Improvement.Models;
using SelfDevelopmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Services
{
    public class ToDoListRepoService:IToDoListRepository
    {
        private readonly AppDbContext context;

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ToDoList GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ToDoList toDo)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, ToDoList toDo)
        {
            throw new NotImplementedException();
        }
    }
}
