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
using System.Threading.Tasks;

namespace SelfDevelopmentApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleRepository _articleRepo;

        public HomeController(ILogger<HomeController> logger, IArticleRepository articleRepo)
        {
            _logger = logger;
            _articleRepo = articleRepo;
            /*
            string fName = "C:\\Users\\zeina\\Pictures\\Pictures\\error404.jpg";
            Article a = new Article()
            {
                Title = "Drink Water, for a better life!",
                Author = "Zeinab Rabie",
                Text = Encoding.ASCII.GetBytes("Getting enough water every day is important for your health. Drinking water can prevent dehydration, a condition that can cause unclear thinking, result in mood change, cause your body to overheat, and lead to constipation and kidney stones. Water helps your body: Keep a normal temperature"),
                Image = GetPhoto(fName),
                TopicID = 1
            };
            _articleRepo.InsertArticle(a);*/
        }

        public IActionResult Index()
        {
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
