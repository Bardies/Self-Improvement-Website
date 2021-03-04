using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SelfDevelopmentApp.Models;

using SelfDevelopmentApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Controllers
{
    public class HabitController : Controller
    {
        private readonly IHabitRepository habitRepository;
        private readonly AppDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public HabitController(IHabitRepository habitRepo, AppDbContext _context, UserManager<ApplicationUser> userManager)
        {
            habitRepository = habitRepo;
            context = _context;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            string currentUserID = userManager.GetUserId(HttpContext.User);
            return View(habitRepository.GetAllHabits(currentUserID));
        }
   
        public IActionResult Edit(int id)
        {
            Habit habit = context.Habits.Find(id);
            return View(habit);
        }
        [HttpPost]
        public IActionResult Edit(int id, Habit habit)
        {
            habitRepository.Edit(id, habit);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            return View(habitRepository.Details(id));
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Habit habit)
        {
            habit.UserID = userManager.GetUserId(HttpContext.User);
            habit.StartingDate = DateTime.Now;
            habitRepository.Insert(habit);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            habitRepository.Delete(id);
            TempData["deletedID"] = id;
            return RedirectToAction("Index");
        }
        //--------------------------------------------
        public IActionResult ShowTracker(int id)
        {
            ViewBag.habitId = id;
            ViewBag.hLabel= habitRepository.Details(id).Description;
            ViewBag.hColor = habitRepository.Details(id).Color;
            return View();
        }
    }
}
