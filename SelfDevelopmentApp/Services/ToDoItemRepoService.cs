
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IToDoListRepository toDoListRepository;
        public ToDoItemRepoService(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
            //this.toDoListRepository = toDoListRepository;
        }

        public void Delete(int id)
        {
            context.ToDoItems.Remove(context.ToDoItems.Find(id));
            context.SaveChanges();
        }

        public List<ToDoItem> GetAll(string id)
        {
            int ToDoId;
            if (context.ToDoLists.Where(i => i.UserID == id).ToList().Count == 1)
            {
                ToDoId = context.ToDoLists.Where(i => i.UserID == id).FirstOrDefault().ID;
            }
            else
            {
                ToDoList toDoList = new ToDoList();
                toDoList.UserID = id;
                context.ToDoLists.Add(toDoList);
                context.SaveChanges();
                ToDoId = context.ToDoLists.Where(i => i.UserID == id).FirstOrDefault().ID;
            }
            List<ToDoItem> toDoItems = context.ToDoItems.Where(i => i.ToDoListID == ToDoId).ToList();
            return toDoItems;
        }

        public ToDoItem GetDetails(int id)
        {
            return context.ToDoItems.FirstOrDefault(i => i.ID == id);
        }

        public void Create(ToDoItem toDo, string id)
        {
            //toDo.ToDoListID = 1;
            int ToDoId = context.ToDoLists.Where(i => i.UserID == id).FirstOrDefault().ID;
            toDo.ToDoListID = ToDoId;
            context.ToDoItems.Add(toDo);
            context.SaveChanges();
        }

        public void Update(int id, ToDoItem toDo)
        {
            ToDoItem oldItem = context.ToDoItems.Find(id);
            oldItem.Description = toDo.Description;
            oldItem.Done = toDo.Done;
            oldItem.DueDate = toDo.DueDate;
            oldItem.Priority = toDo.Priority;
            oldItem.ReminderTime = toDo.ReminderTime;
            context.SaveChanges();

        }

        public void MarkDone(int id)
        {
            ToDoItem oldItem = context.ToDoItems.Find(id);
            oldItem.Done = true;
            context.SaveChanges();
        }
        public void MarkNotDone(int id)
        {
            ToDoItem oldItem = context.ToDoItems.Find(id);
            oldItem.Done = false;
            context.SaveChanges();
        }

        public void QuickAdd(string desc, string userId)
        {
            ToDoItem toDoItem = new ToDoItem();
            toDoItem.Description = desc;
            Create(toDoItem, userId);
        }
    }
}
