using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelfDevelopmentApp.Models;
using SelfDevelopmentApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
//using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace SelfDevelopmentApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleRepository _articleRepo;
        private readonly IEmailRepository _emailService;
        private readonly IUserRepository _userService;

        public HomeController(ILogger<HomeController> logger, IArticleRepository articleRepo , IEmailRepository emailService, IUserRepository user)
        {
            _logger = logger;
            _articleRepo = articleRepo;
            _logger = logger;
            _emailService = emailService;
            _userService = user;
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

       // private string emailBody;
        public /*async Task<bool>*/void sendEmail()
        {
            string emailBody = "";
            foreach (var user in _userService.AllUser())
            {
                foreach (var item in user?.ToDoList?.ListItems?? new List<ToDoItem>())
                {
                    if (!item.Done)
                    {
                        if (item.ReminderTime <= DateTime.Now && item.DueDate > DateTime.Now)
                        {
                            emailBody = "It is time of your todo item " + item.Description;
                           _emailService.SendEmailAsync(user.Email, "SALAM Reminder", emailBody);
                        }

                        if (item.DueDate <= DateTime.Now)
                        {
                            emailBody = "Oops! it is the due date of your todo item "
                                                + item.Description;
                            _emailService.SendEmailAsync(user.Email, "SALAM Task Due-Date", emailBody);
                        }
                    }
                }
            }
        }


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

            sendEmail();

            return View();
        }

        public IActionResult Home()
        {
            IEnumerable<Article> art_lst = _articleRepo.AllArticles();
            //art_lst.Reverse();
            //IEnumerable<IEnumerable<Article>> Tri_Art = Split<Article>(art_lst, 3);
            /*
            //ViewBag.art_img = _articleRepo.GetArticleByID(2).Image;
            //data:Image/png;base64,<%= System.Convert.ToBase64String((byte[])ViewBag.art_img) %>
            byte[] bytes = _articleRepo.GetArticleByID(2).Image;
            string strBase64 = Convert.ToBase64String(bytes);
            //Image1.ImageUrl = "data:Image/png;base64," + strBase64;
            string url = "data:Image/png;base64," + strBase64;
            ViewBag.art_img = url;
            */
            /*var suggested_articles = "AadaD";
            string str = Encoding.Default.GetString(suggested_articles.Text);
            string displayedTxt = str.Split('\n')[0];
            ViewBag.txt = displayedTxt;
            //Encoding.Default.GetString(suggested_articles.Text).Split('\n')[0]
            ViewBag.suggested_articles = suggested_articles;*/

            //ViewBag.suggested_articles = _articleRepo.GetArticlesByTopic();

            return View(art_lst);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static byte[] GetPhoto(string filePath)
        {
            FileStream stream = new FileStream(
                filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);
            byte[] photo = reader.ReadBytes((int)stream.Length);
            reader.Close();
            stream.Close();
            return photo;
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

        public IActionResult TodoList()
        {
            return View();
        }
        public IActionResult HabitTracker()
        {
            return View();
        }

        public IActionResult arts()
        {
            return View();
        }
    }
}
