using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelfDevelopmentApp.Models;
using SelfDevelopmentApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace SelfDevelopmentApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IEmailRepository _emailService;
        //private readonly IUserRepository _userService;
        public HomeController(ILogger<HomeController> logger/*, IEmailRepository emailService, IUserRepository user*/)
        {
            _logger = logger;
            //_emailService = emailService;
            //_userService = user;
        }
        //public void f1()
        //{

        //    ThreadStart childref = new ThreadStart(f2);
        //    Thread childThread = new Thread(childref);
        //    childThread.Start();
        //}

        //static readonly object locker = new object();
        //public System.Timers.Timer aTimer = new System.Timers.Timer();

        //public void f2()
        //{
        //    Thread.Sleep(100);
        //    lock (locker)
        //    {
        //        //aTimer = new System.Timers.Timer();
        //        // some list
        //        foreach (var user in userRepository.AllUser())
        //        {
        //            foreach (var item in user.ToDoList.ListItems)
        //            {
        //                if (!item.Done)
        //                {
        //                    if (item.ReminderTime <= DateTime.Now)
        //                    {
        //                        string emailBody = "It is time of your todo item " + item.Description;
        //                        emailRepository.SendEmail(emailBody);
        //                    }

        //                    if (item.DueDate <= DateTime.Now)
        //                    {
        //                        string emailBody = "Oops! it is the due date of your todo item "
        //                                            + item.Description;
        //                        emailRepository.SendEmail(emailBody);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
        //string emailBody="";

        //public /*async Task<bool>*/void sendEmail()
        //{
        //    foreach (var user in _userService.AllUser())
        //    {
        //        foreach (var item in user.ToDoList.ListItems)
        //        {
        //            if (!item.Done)
        //            {
        //                if (item.ReminderTime <= DateTime.Now)
        //                {
        //                    emailBody = "It is time of your todo item " + item.Description;
        //                   _emailService.SendEmailAsync("na1556@fayoum.edu.eg", "This is email subject", emailBody);
        //                }

        //                if (item.DueDate <= DateTime.Now)
        //                {
        //                    emailBody = "Oops! it is the due date of your todo item "
        //                                        + item.Description;
        //                   _emailService.SendEmailAsync("na1556@fayoum.edu.eg", "This is email subject", emailBody);
        //                }

        //            }
        //        }
        //    }
        //}


        //private async void OnTimedEvent(object source, ElapsedEventArgs e)
        //{
        //    await sendEmail();
        //}

        //public System.Threading.Timer aTimer = new Timer(sendEmail);// Timer();
       // public static System.Timers.Timer aTimer = new System.Timers.Timer();// Timer();



        //public static async Task SetInterval(Action action, TimeSpan timeout)
        //{
        //    await Task.Delay(timeout).ConfigureAwait(false);

        //    action();

        //    await SetInterval(action, timeout);
        //}
        //private async void SetTimer()
        //{
        //    await SetInterval(() => sendEmail(), TimeSpan.FromSeconds(20));

        //    Thread.Sleep(TimeSpan.FromMinutes(1));
        //}

        public IActionResult IndexAsync()
        {
            //f1();

             //SetTimer();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult BlogSingle()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
