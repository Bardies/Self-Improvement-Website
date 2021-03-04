using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SelfDevelopmentApp.Models;
using SelfDevelopmentApp.Services;

namespace SelfDevelopmentApp.Controllers
{
    [Authorize]
    public class ToDoItemsController : Controller
    {
        private readonly IToDoItemRepository toDoItemRepository;
        private readonly UserManager<ApplicationUser> userManager;
        public ToDoItemsController(IToDoItemRepository toDoItemRepository, UserManager<ApplicationUser> userManager)
        {
            this.toDoItemRepository = toDoItemRepository;
            this.userManager = userManager;
        }

        // GET: ToDoItems
        public IActionResult Index()
        {
            var userId = userManager.GetUserId(HttpContext.User);
            
            return View(toDoItemRepository.GetAll(userId));
        }

        // GET: ToDoItems/Details/5
        public IActionResult Details(int id)
        {

            var toDoItem = toDoItemRepository.GetDetails(id);
                
            if (toDoItem == null)
            {
                return NotFound();
            }

            return View(toDoItem);
        }
       
            // GET: ToDoItems/Create
            public IActionResult Create()
            {
                //ViewData["ToDoListID"] = new SelectList(_context.ToDoLists, "ID", "ID");
                return View();
            }

            // POST: ToDoItems/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create([Bind("ID,Description,Priority,Done,DueDate,ReminderTime,ToDoListID")] ToDoItem toDoItem)
            {
                if (ModelState.IsValid)
                {
                var userId = userManager.GetUserId(HttpContext.User);
               /* int myUser = int.Parse(userId);*/
                toDoItemRepository.Create(toDoItem, userId);
                    return RedirectToAction(nameof(Index));
                }
               // ViewData["ToDoListID"] = new SelectList(_context.ToDoLists, "ID", "ID", toDoItem.ToDoListID);
                return View(toDoItem);
            }

           /// GET: ToDoItems/Edit/5
            public IActionResult Edit(int id)
            {
                var toDoItem = toDoItemRepository.GetDetails(id);
                if (toDoItem == null)
                {
                    return NotFound();
                }
                //ViewData["ToDoListID"] = new SelectList(_context.ToDoLists, "ID", "ID", toDoItem.ToDoListID);
                return View(toDoItem);
            }

            // POST: ToDoItems/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit(int id, [Bind("ID,Description,Priority,Done,DueDate,ReminderTime,ToDoListID")] ToDoItem toDoItem)
            {
                if (id != toDoItem.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        toDoItemRepository.Update(id, toDoItem);
                        
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (toDoItemRepository.GetDetails(toDoItem.ID)!=null)
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
            //    ViewData["ToDoListID"] = new SelectList(_context.ToDoLists, "ID", "ID", toDoItem.ToDoListID);
                return View(toDoItem);
            }

            // GET: ToDoItems/Delete/5
            public IActionResult Delete(int id)
        { 

            var toDoItem = toDoItemRepository.GetDetails(id);
                if (toDoItem == null)
                {
                    return NotFound();
                }

                return View(toDoItem);
            }

            // POST: ToDoItems/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public IActionResult DeleteConfirmed(int id)
            {
            toDoItemRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }

      
        public IActionResult MarkDone(string id)
        {   
            int todoID = Convert.ToInt32(id);
            //According to the id to query the database
            toDoItemRepository.MarkDone(todoID);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult MarkNotDone(string id)
        {
            int todoID = Convert.ToInt32(id);
            //According to the id to query the database
            toDoItemRepository.MarkNotDone(todoID);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult QuickAdd(string desc)
        {
            //According to the id to query the database
            var userId = userManager.GetUserId(HttpContext.User);
            toDoItemRepository.QuickAdd(desc, userId);
            return RedirectToAction(nameof(Index));
        }
        /*  private bool ToDoItemExists(int id)
          {
              return _context.ToDoItems.Any(e => e.ID == id);
          }*/
    }
}
