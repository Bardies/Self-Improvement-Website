using Self_Improvement.Models;
using SelfDevelopmentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Services
{
    public class ToDoItemRepoService : IToDoItemRepository
    {

        private readonly AppDbContext context;
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ToDoItem> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public ToDoItem GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ToDoItem toDo)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, ToDoItem toDo)
        {
            throw new NotImplementedException();
        }
    }
}
